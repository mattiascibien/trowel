using Trowel.BspEditor.Components;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations.Tree;
using Trowel.BspEditor.Properties;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Commands.Clipboard
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:Cut")]
    [DefaultHotkey("Ctrl+X")]
    [MenuItem("Edit", "", "Clipboard", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Cut))]
    public class Cut : BaseCommand
    {
        private readonly Lazy<ClipboardManager> _clipboard;

        public override string Name { get; set; } = "Cut";
        public override string Details { get; set; } = "Copy the current selection and remove it";

        [ImportingConstructor]
        public Cut([Import] Lazy<ClipboardManager> clipboard)
        {
            _clipboard = clipboard;
        }

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var sel = document.Selection.GetSelectedParents().ToList();
            if (sel.Any())
            {
                _clipboard.Value.Push(sel);
                var t = new Transaction(sel.GroupBy(x => x.Hierarchy.Parent.ID).Select(x => new Detatch(x.Key, x)));
                await MapDocumentOperation.Perform(document, t);
            }
        }
    }
}