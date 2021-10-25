using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations.Selection;
using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.BspEditor.Properties;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Commands.Modification
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:SelectAll")]
    [DefaultHotkey("Ctrl+A")]
    [MenuItem("Edit", "", "Selection", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SelectAll))]
    public class SelectAll : BaseCommand
    {
        public override string Name { get; set; } = "Select All";
        public override string Details { get; set; } = "Select all objects";

        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var op = new Select(document.Map.Root.FindAll().Where(x => x.Hierarchy.Parent != null));
            return MapDocumentOperation.Perform(document, op);
        }
    }
}
