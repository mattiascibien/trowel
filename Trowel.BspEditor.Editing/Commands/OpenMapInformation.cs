using LogicAndTrick.Oy;
using Trowel.BspEditor.Commands;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Editing.Properties;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Map", "", "Properties", "B")]
    [CommandID("BspEditor:Map:MapInformation")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowInformation))]
    public class OpenMapInformation : BaseCommand
    {
        public override string Name { get; set; } = "Map information";
        public override string Details { get; set; } = "Open the map information window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:MapInformation"));
        }
    }
}