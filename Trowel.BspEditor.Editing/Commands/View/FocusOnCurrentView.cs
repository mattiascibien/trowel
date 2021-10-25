using LogicAndTrick.Oy;
using Trowel.BspEditor.Commands;
using Trowel.BspEditor.Documents;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Commands.View
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:View:FocusCurrent")]
    [MenuItem("View", "", "SplitView", "B")]
    [DefaultHotkey("Shift+Z")]
    public class FocusOnCurrentView : BaseCommand
    {
        public override string Name { get; set; } = "Focus on current view";
        public override string Details { get; set; } = "Maximise the current view in the viewport grid";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("BspEditor:SplitView:FocusCurrent");
        }
    }
}