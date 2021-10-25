using LogicAndTrick.Oy;
using Trowel.Common.Shell.Components;
using Trowel.Common.Shell.Hooks;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Tools
{
    [Export(typeof(IStartupHook))]
    public class ToolActivator : IStartupHook
    {
        private WeakReference<BaseTool> _activeTool;

        private BaseTool ActiveTool => _activeTool == null ? null : _activeTool.TryGetTarget(out BaseTool t) ? t : null;

        public Task OnStartup()
        {
            Oy.Subscribe<ITool>("Tool:Activated", ToolActivated);
            return Task.CompletedTask;
        }

        private async Task ToolActivated(ITool tool)
        {
            var at = ActiveTool;
            if (at != null)
            {
                await at.ToolDeselected();
            }

            _activeTool = new WeakReference<BaseTool>(tool as BaseTool);

            at = ActiveTool;
            if (at != null)
            {
                await at.ToolSelected();
            }
        }
    }
}