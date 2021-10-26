using LogicAndTrick.Oy;
using Microsoft.Win32;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Documents;
using Trowel.Common.Shell.Hooks;
using Trowel.Common.Shell.Settings;
using Trowel.Common.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Trowel.Shell.Registers
{
    /// <summary>
    /// The document register handles document loaders
    /// </summary>
    [Export(typeof(IStartupHook))]
    [Export]
    public class DocumentRegister : IStartupHook
    {
        private readonly ThreadSafeList<IDocument> _openDocuments;
        public IReadOnlyCollection<IDocument> OpenDocuments => _openDocuments;

        private readonly List<IDocumentLoader> _loaders;

        private readonly string _programId;
        private readonly string _programIdVer = "1";

        [ImportingConstructor]
        public DocumentRegister(
            [ImportMany] IEnumerable<Lazy<IDocumentLoader>> documentLoaders
        )
        {
            _loaders = documentLoaders.Select(x => x.Value).ToList();

            var assembly = Assembly.GetEntryAssembly()?.GetName().Name ?? "Trowel.Shell";
            _programId = assembly.Replace(".", "");

            _openDocuments = new ThreadSafeList<IDocument>();
        }

        public Task OnStartup()
        {
            return Task.FromResult(0);
        }

        // Public interface

        public IEnumerable<FileExtensionInfo> GetSupportedFileExtensions(IDocument document)
        {
            return _loaders.Where(x => x.CanSave(document)).SelectMany(x => x.SupportedFileExtensions);
        }

        public DocumentPointer GetDocumentPointer(IDocument document)
        {
            var loader = _loaders.FirstOrDefault(x => x.CanSave(document));
            var pointer = loader?.GetDocumentPointer(document);
            return pointer;
        }

        // Save/load/open documents

        public bool IsOpen(string fileName)
        {
            return _openDocuments.Any(x => string.Equals(x.FileName, fileName, StringComparison.InvariantCultureIgnoreCase));
        }

        public IDocument GetDocumentByFileName(string fileName)
        {
            return _openDocuments.FirstOrDefault(x => string.Equals(x.FileName, fileName, StringComparison.InvariantCultureIgnoreCase));
        }

        public bool IsOpen(IDocument document)
        {
            return _openDocuments.Contains(document);
        }

        public async Task<IDocument> NewDocument(IDocumentLoader loader)
        {
            var doc = await loader.CreateBlank();
            if (doc != null) OpenDocument(doc);
            return doc;
        }

        public async Task<IDocument> OpenDocument(DocumentPointer documentPointer, string loaderName = null)
        {
            var fileName = documentPointer.FileName;
            if (!File.Exists(fileName)) return null;

            if (IsOpen(fileName))
            {
                ActivateDocument(GetDocumentByFileName(fileName));
                return null;
            }

            var loader = _loaders.FirstOrDefault(x => x.GetType().Name == loaderName && x.CanLoad(fileName));
            if (loader == null) return null;

            var doc = await loader.Load(documentPointer);
            if (doc != null) OpenDocument(doc);

            return doc;
        }

        public async Task<IDocument> OpenDocument(string fileName, string loaderHint = "")
        {
            if (!File.Exists(fileName)) return null;

            if (IsOpen(fileName))
            {
                ActivateDocument(GetDocumentByFileName(fileName));
                return null;
            }

            IDocumentLoader loader = null;
            if (!String.IsNullOrWhiteSpace(loaderHint)) loader = _loaders.FirstOrDefault(x => x.GetType().Name == loaderHint);
            if (loader == null) loader = _loaders.FirstOrDefault(x => x.CanLoad(fileName));

            if (loader != null)
            {
                var doc = await loader.Load(fileName);
                if (doc != null) OpenDocument(doc);
                return doc;
            }

            return null;
        }

        public async Task ActivateDocument(IDocument document)
        {
            if (document == null)
            {
                await Oy.Publish<IDocument>("Document:Activated", new NoDocument());
                await Oy.Publish("Context:Remove", new ContextInfo("ActiveDocument"));
            }
            else
            {
                await Oy.Publish("Document:Activated", document);
                await Oy.Publish("Context:Add", new ContextInfo("ActiveDocument", document));
            }
        }

        public Task<bool> ExportDocument(IDocument document, string fileName, string loaderHint = "")
        {
            return SaveDocument(document, fileName, loaderHint, false);
        }

        public Task<bool> SaveDocument(IDocument document, string fileName, string loaderHint = "")
        {
            return SaveDocument(document, fileName, loaderHint, true);
        }

        private async Task<bool> SaveDocument(IDocument document, string fileName, string loaderHint, bool switchFileName)
        {
            if (document == null || fileName == null) return false;

            IDocumentLoader loader = null;
            if (!String.IsNullOrWhiteSpace(loaderHint)) loader = _loaders.FirstOrDefault(x => x.GetType().Name == loaderHint);
            if (loader == null) loader = _loaders.FirstOrDefault(x => x.CanSave(document) && x.CanLoad(fileName));

            if (loader == null) return false;

            await Oy.Publish("Document:BeforeSave", document);

            await loader.Save(document, fileName);

            // Only publish document saved when the file name is changed
            // Otherwise we're not actually saving the document's file
            if (switchFileName)
            {
                document.FileName = fileName;
                await Oy.Publish("Document:Saved", document);
            }

            return true;
        }

        /// <summary>
        /// Request to close a document. The document will be closed
        /// (if possible) before returning.
        /// </summary>
        /// <param name="document">The document to close</param>
        /// <returns>True if the document was closed</returns>
        public async Task<bool> RequestCloseDocument(IDocument document)
        {
            var canClose = await document.RequestClose();

            var msg = new DocumentCloseMessage(document);
            await Oy.Publish("Document:RequestClose", msg);
            if (msg.Cancelled) canClose = false;

            if (canClose) ForceCloseDocument(document);
            return canClose;
        }

        public async Task ForceCloseDocument(IDocument document)
        {
            await Oy.Publish("Document:BeforeClose", document);

            _openDocuments.Remove(document);

            await Oy.Publish("Document:Closed", document);
        }

        private async Task OpenDocument(IDocument doc)
        {
            _openDocuments.Add(doc);
            await Oy.Publish("Document:Opened", doc);
            await ActivateDocument(doc);
        }

        private static string ExecutableLocation()
        {
            return Assembly.GetEntryAssembly().Location;
        }
    }
}