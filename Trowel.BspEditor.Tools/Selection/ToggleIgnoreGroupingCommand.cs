using Trowel.BspEditor.Commands;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations;
using Trowel.BspEditor.Primitives.MapData;
using Trowel.BspEditor.Tools.Properties;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Tools.Selection
{
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Map:ToggleIgnoreGrouping")]
    [DefaultHotkey("Ctrl+W")]
    [MenuItem("Map", "", "Grouping", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_IgnoreGrouping))]
    [AutoTranslate]
    public class ToggleIgnoreGroupingCommand : BaseCommand
    {
        public override string Name { get; set; } = "Ignore grouping";
        public override string Details { get; set; } = "Toggle ignore grouping on and off";
        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var opt = document.Map.Data.GetOne<SelectionOptions>() ?? new SelectionOptions();
            opt.IgnoreGrouping = !opt.IgnoreGrouping;
            MapDocumentOperation.Perform(document, new TrivialOperation(x => x.Map.Data.Replace(opt), x => x.Update(opt)));
            return Task.CompletedTask;
        }
    }
}