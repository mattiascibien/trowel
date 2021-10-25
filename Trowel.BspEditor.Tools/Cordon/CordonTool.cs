using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations;
using Trowel.BspEditor.Primitives.MapData;
using Trowel.BspEditor.Tools.Draggable;
using Trowel.BspEditor.Tools.Properties;
using Trowel.Common.Shell.Components;
using Trowel.Common.Shell.Hotkeys;
using Trowel.DataStructures.Geometric;
using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Tools.Cordon
{
    [Export(typeof(ITool))]
    [OrderHint("R")]
    [DefaultHotkey("Shift+K")]
    public class CordonTool : BaseDraggableTool
    {
        private readonly CordonBoxDraggableState _cordonBox;

        public CordonTool()
        {
            _cordonBox = new CordonBoxDraggableState(this);
            _cordonBox.BoxColour = Color.Red;
            _cordonBox.FillColour = Color.FromArgb(/*View.SelectionBoxBackgroundOpacity*/ 64, Color.LightGray);
            _cordonBox.State.Changed += CordonBoxChanged;
            States.Add(_cordonBox);

            Usage = ToolUsage.View2D;
        }

        public override Image GetIcon()
        {
            return Resources.Tool_Cordon;
        }

        public override string GetName()
        {
            return "CordonTool";
        }

        public override async Task ToolSelected()
        {
            _cordonBox.Update();
            await base.ToolSelected();
        }

        private void CordonBoxChanged(object sender, EventArgs e)
        {
            // Only commit changes after the resize has finished
            if (_cordonBox.State.Action != BoxAction.Drawn) return;

            var document = GetDocument();
            if (document == null) return;

            var bounds = new Box(_cordonBox.State.Start, _cordonBox.State.End);
            var cb = new CordonBounds
            {
                Box = bounds,
                Enabled = document.Map.Data.GetOne<CordonBounds>()?.Enabled == true
            };
            MapDocumentOperation.Perform(document, new TrivialOperation(x => x.Map.Data.Replace(cb), x => x.Update(cb)));
        }
    }
}
