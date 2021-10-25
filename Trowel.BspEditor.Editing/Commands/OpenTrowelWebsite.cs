using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Help", "", "Links", "D")]
    [CommandID("BspEditor:Links:SledgeWebsite")]
    public class OpenSledgeWebsite : ICommand
    {
        public string Name { get; set; } = "Trowel Website";
        public string Details { get; set; } = "Go to the Trowel website";

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            await Task.Run(() =>
            {
                var ps = new ProcessStartInfo("https://github.com/mattiascibien/trowel/")
                {
                    UseShellExecute = true,
                    Verb = "open"
                };
                Process.Start(ps);
            });
        }
    }
}