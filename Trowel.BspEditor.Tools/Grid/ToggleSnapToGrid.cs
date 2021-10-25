using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations;
using Trowel.BspEditor.Primitives.MapData;
using Trowel.BspEditor.Tools.Properties;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Tools.Grid
{
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Grid:ToggleSnapToGrid")]
    [DefaultHotkey("Shift+W")]
    [MenuItem("Map", "", "Grid", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SnapToGrid))]
    [AutoTranslate]
    public class ToggleSnapToGrid : ICommand
    {
        public string Name { get; set; } = "Snap to Grid";
        public string Details { get; set; } = "Toggle grid snapping";
        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                var activeGrid = doc.Map.Data.GetOne<GridData>();
                if (activeGrid != null)
                {
                    var operation = new TrivialOperation(x => activeGrid.SnapToGrid = !activeGrid.SnapToGrid, x => x.Update(activeGrid));
                    await MapDocumentOperation.Perform(doc, operation);
                }
            }
        }
    }
}