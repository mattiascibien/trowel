using Trowel.BspEditor.Commands;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Editing.Properties;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations.Data;
using Trowel.BspEditor.Primitives.MapObjectData;
using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Commands.Quick
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("View", "", "Quick", "D")]
    [CommandID("BspEditor:View:QuickHideUnselected")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_HideUnselected))]
    [DefaultHotkey("Ctrl+H")]
    public class HideUnselectedObjects : BaseCommand
    {
        public override string Name { get; set; } = "Quick hide unselected";
        public override string Details { get; set; } = "Quick hide unselected objects";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var transaction = new Transaction();

            foreach (var mo in document.Map.Root.FindAll().Except(document.Selection).Where(x => !(x is Root)).ToList())
            {
                var ex = mo.Data.GetOne<QuickHidden>();
                if (ex != null) transaction.Add(new RemoveMapObjectData(mo.ID, ex));
                transaction.Add(new AddMapObjectData(mo.ID, new QuickHidden()));
            }

            await MapDocumentOperation.Perform(document, transaction);
        }
    }
}