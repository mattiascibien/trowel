using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Documents;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using Trowel.Shell.Properties;
using Trowel.Shell.Registers;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trowel.Shell.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("File:SaveAs")]
    [DefaultHotkey("Ctrl+Shift+S")]
    [MenuItem("File", "", "File", "J")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SaveAs))]
    public class SaveFileAs : ICommand
    {
        private readonly Lazy<DocumentRegister> _documentRegister;

        public string Name { get; set; } = "Save As...";
        public string Details { get; set; } = "Save As...";

        [ImportingConstructor]
        public SaveFileAs(
            [Import] Lazy<DocumentRegister> documentRegister
        )
        {
            _documentRegister = documentRegister;
        }

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out IDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            var doc = context.Get<IDocument>("ActiveDocument");
            if (doc != null)
            {
                string filename;

                var filter = _documentRegister.Value.GetSupportedFileExtensions(doc)
                    .Select(x => x.Description + "|" + String.Join(";", x.Extensions.Select(ex => "*" + ex)))
                    .ToList();

                using (var sfd = new SaveFileDialog { Filter = String.Join("|", filter) })
                {
                    if (sfd.ShowDialog() != DialogResult.OK) return;
                    filename = sfd.FileName;
                }

                await _documentRegister.Value.SaveDocument(doc, filename);
            }
        }
    }
}