using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations.Tree;
using Trowel.BspEditor.Properties;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Commands.Clipboard
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:Delete")]
    [DefaultHotkey("Del")]
    [MenuItem("Edit", "", "Clipboard", "N")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Delete))]
    public class Delete : BaseCommand
    {
        public override string Name { get; set; } = "Delete";
        public override string Details { get; set; } = "Delete the current selection";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var sel = document.Selection.GetSelectedParents().ToList();
            if (sel.Any())
            {
                var t = new Transaction(sel.GroupBy(x => x.Hierarchy.Parent.ID).Select(x => new Detatch(x.Key, x)));
                await MapDocumentOperation.Perform(document, t);
            }
        }
    }
}