using Trowel.Common.Logging;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Documents;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using Trowel.Shell.Properties;
using Trowel.Shell.Registers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Trowel.Shell.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("File:New")]
    [DefaultHotkey("Ctrl+N")]
    [MenuItem("File", "", "File", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_New))]
    public class NewFile : ICommand
    {
        private readonly Lazy<DocumentRegister> _documentRegister;
        private readonly IEnumerable<Lazy<IDocumentLoader>> _loaders;

        public string Name { get; set; } = "New";
        public string Details { get; set; } = "New";

        [ImportingConstructor]
        public NewFile(
            [Import] Lazy<DocumentRegister> documentRegister,
            [ImportMany] IEnumerable<Lazy<IDocumentLoader>> loaders
        )
        {
            _documentRegister = documentRegister;
            _loaders = loaders;
        }

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            var loaders = _loaders.Where(x => x.Value.CanLoad(null)).Select(x => x.Value).ToList();
            if (!loaders.Any()) return;

            var loader = loaders[0];
            if (loaders.Count > 1)
            {
                // prompt user to select document type
                //loader = null;
                // todo BETA: Support multiple document types
                Log.Info(nameof(NewFile), "Todo: Prompt for user to select document type");
            }

            if (loader != null)
            {
                await _documentRegister.Value.NewDocument(loader);
            }
        }
    }
}