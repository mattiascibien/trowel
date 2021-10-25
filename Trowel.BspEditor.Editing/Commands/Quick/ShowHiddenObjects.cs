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
    [MenuItem("View", "", "Quick", "F")]
    [CommandID("BspEditor:View:ShowHidden")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowHidden))]
    [DefaultHotkey("U")]
    public class ShowHiddenObjects : BaseCommand
    {
        public override string Name { get; set; } = "Show hidden objects";
        public override string Details { get; set; } = "Show objects hidden with quick hide";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var transaction = new Transaction();

            foreach (var mo in document.Map.Root.Find(x => x.Data.Get<QuickHidden>().Any()))
            {
                transaction.Add(new RemoveMapObjectData(mo.ID, mo.Data.GetOne<QuickHidden>()));
            }

            await MapDocumentOperation.Perform(document, transaction);
        }
    }
}