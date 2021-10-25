using LogicAndTrick.Oy;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.Shell.Commands
{
    /// <summary>
    /// Opens the command box
    /// </summary>
    [Export(typeof(ICommand))]
    [DefaultHotkey("Ctrl+T")]
    [AutoTranslate]
    public class OpenCommandBox : ICommand
    {
        public string Name { get; set; } = "Open the command box";
        public string Details { get; set; } = "Open the command box";

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            await Oy.Publish<string>("Shell:OpenCommandBox", "");
        }
    }
}
