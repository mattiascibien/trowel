using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.Shell.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("File:Exit")]
    [DefaultHotkey("Alt+F4")]
    [MenuItem("File", "", "Exit", "M")]
    public class Exit : ICommand
    {
        private readonly Forms.Shell _shell;

        public string Name { get; set; } = "Exit";
        public string Details { get; set; } = "Exit";

        [ImportingConstructor]
        internal Exit([Import] Forms.Shell shell)
        {
            _shell = shell;
        }

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public Task Invoke(IContext context, CommandParameters parameters)
        {
            _shell.Close();
            return Task.CompletedTask;
        }
    }
}