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
    [MenuItem("Map", "", "Properties", "D")]
    [CommandID("BspEditor:Map:CheckForProblems")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_CheckForProblems))]
    [DefaultHotkey("Alt+P")]
    public class OpenCheckForProblemsDialog : BaseCommand
    {
        public override string Name { get; set; } = "Check for problems";
        public override string Details { get; set; } = "Open the check for problems window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:CheckForProblems"));
        }
    }
}