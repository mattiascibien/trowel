using Trowel.BspEditor.Commands;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Editing.Properties;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Commands.Pointfile
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Map", "", "Pointfile", "F")]
    [CommandID("BspEditor:Map:UnloadPointfile")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_UnloadPointfile))]
    public class UnloadPointfile : BaseCommand
    {
        public override string Name { get; set; } = "Unload pointfile...";
        public override string Details { get; set; } = "Clear the currently loaded pointfile";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var pf = document.Map.Data.GetOne<Pointfile>();
            if (pf == null) return;

            await MapDocumentOperation.Perform(document, new TrivialOperation(
                d => d.Map.Data.Remove(pf),
                c => c.Add(c.Document.Map.Root)
            ));
        }
    }
}