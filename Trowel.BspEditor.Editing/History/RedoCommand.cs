using Trowel.BspEditor.Commands;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Editing.Properties;
using Trowel.BspEditor.Modification;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.History
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:Redo")]
    [DefaultHotkey("Ctrl+Y")]
    [MenuItem("Edit", "", "History", "D")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Redo))]
    public class RedoCommand : BaseCommand
    {
        public override string Name { get; set; } = "Redo";
        public override string Details { get; set; } = "Redo the last undone operation";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var stack = document.Map.Data.GetOne<HistoryStack>();
            if (stack == null) return;
            if (stack.CanRedo()) await MapDocumentOperation.Perform(document, stack.RedoOperation());
        }
    }
}