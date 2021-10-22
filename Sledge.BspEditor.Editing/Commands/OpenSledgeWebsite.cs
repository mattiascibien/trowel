using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Threading.Tasks;
using Sledge.Common.Shell.Commands;
using Sledge.Common.Shell.Context;
using Sledge.Common.Shell.Menu;
using Sledge.Common.Translations;

namespace Sledge.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Help", "", "Links", "D")]
    [CommandID("BspEditor:Links:SledgeWebsite")]
    public class OpenSledgeWebsite : ICommand
    {
        public string Name { get; set; } = "Sledge Website";
        public string Details { get; set; } = "Go to the Sledge website";

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            await Task.Run(() => 
            { 
                var ps = new ProcessStartInfo("https://github.com/mattiascibien/sledge/")
                { 
                    UseShellExecute = true, 
                    Verb = "open" 
                };
                Process.Start(ps);
            });
        }
    }
}