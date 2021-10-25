using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Documents;
using Trowel.Shell.Registers;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.Shell.Commands
{
    /// <summary>
    /// Internal: Export a document to a path
    /// </summary>
    [Export(typeof(ICommand))]
    [CommandID("Internal:ExportDocument")]
    [InternalCommand]
    public class ExportDocument : ICommand
    {
        private readonly Lazy<DocumentRegister> _documentRegister;

        public string Name { get; set; } = "Export";
        public string Details { get; set; } = "Export";

        [ImportingConstructor]
        public ExportDocument(
            [Import] Lazy<DocumentRegister> documentRegister
        )
        {
            _documentRegister = documentRegister;
        }

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            var doc = parameters.Get<IDocument>("Document");
            var path = parameters.Get<string>("Path");
            var hint = parameters.Get("LoaderHint", "");

            await _documentRegister.Value.ExportDocument(doc, path, hint);
        }
    }
}