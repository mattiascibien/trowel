using Trowel.BspEditor.Commands;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Editing.Properties;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations;
using Trowel.BspEditor.Primitives.MapData;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Commands.Toggles
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Map:ToggleTextureScalingLock")]
    [MenuItem("Map", "", "Texture", "D")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_TextureScalingLock))]
    public class ToggleTextureScalingLock : BaseCommand, IMenuItemExtendedProperties
    {
        public override string Name { get; set; } = "Texture Scaling Lock";
        public override string Details { get; set; } = "Toggle texture scaling locking.";
        public bool IsToggle => true;

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var tl = document.Map.Data.GetOne<TransformationFlags>() ?? new TransformationFlags();
            tl.TextureScaleLock = !tl.TextureScaleLock;

            await MapDocumentOperation.Perform(document, new TrivialOperation(x => x.Map.Data.Replace(tl), x => x.Update(tl)));
        }

        public bool GetToggleState(IContext context)
        {
            if (!context.TryGet("ActiveDocument", out MapDocument doc)) return false;
            var tf = doc.Map.Data.GetOne<TransformationFlags>() ?? new TransformationFlags();
            return tf.TextureScaleLock;
        }
    }
}