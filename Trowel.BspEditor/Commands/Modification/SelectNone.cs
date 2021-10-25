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
using System.Threading.Tasks;

namespace Trowel.BspEditor.Commands.Modification
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:SelectNone")]
    [DefaultHotkey("Shift+Q")]
    [MenuItem("Edit", "", "Selection", "D")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SelectNone))]
    public class SelectNone : BaseCommand
    {
        public override string Name { get; set; } = "Select None";
        public override string Details { get; set; } = "Clear selection";

        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var op = new Deselect(document.Map.Root.FindAll());
            return MapDocumentOperation.Perform(document, op);
        }
    }
}