using LogicAndTrick.Oy;
using Trowel.BspEditor.Commands;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Editing.Properties;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Edit", "", "Properties", "B")]
    [CommandID("BspEditor:Map:Properties")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ObjectProperties))]
    [DefaultHotkey("Alt+Enter")]
    public class OpenObjectProperties : BaseCommand
    {
        public override string Name { get; set; } = "Object properties";
        public override string Details { get; set; } = "Open the object properties window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:ObjectProperties"));
        }
    }
}