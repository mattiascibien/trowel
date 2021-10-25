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
    [MenuItem("Map", "", "Properties", "E")]
    [CommandID("BspEditor:Map:LogicalTree")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowLogicalTree))]
    public class OpenMapTreeWindow : BaseCommand
    {
        public override string Name { get; set; } = "Show logical tree";
        public override string Details { get; set; } = "Show the logical tree of the current document.";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:MapTree"));
        }
    }
}