using LogicAndTrick.Oy;
using Trowel.BspEditor.Commands;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Editing.Properties;
using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Map", "", "Properties", "A")]
    [CommandID("BspEditor:Map:RootProperties")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_MapProperties))]
    public class OpenRootProperties : BaseCommand
    {
        public override string Name { get; set; } = "Map properties";
        public override string Details { get; set; } = "Open the map properties window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("BspEditor:ObjectProperties:OpenWithSelection", new List<IMapObject> { document.Map.Root });
        }
    }
}