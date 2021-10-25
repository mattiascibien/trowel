using Trowel.BspEditor.Commands;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Editing.Properties;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations;
using Trowel.BspEditor.Primitives.MapData;
using Trowel.BspEditor.Primitives.MapObjectData;
using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Commands.Toggles
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Map:ToggleHideNullTextures")]
    [MenuItem("Map", "", "Texture", "H")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_HideNullTextures))]
    public class ToggleHideNullTextures : BaseCommand, IMenuItemExtendedProperties
    {
        public override string Name { get; set; } = "Hide Null Textures";
        public override string Details { get; set; } = "Toggle null texture display.";
        public bool IsToggle => true;

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var tl = document.Map.Data.GetOne<DisplayFlags>() ?? new DisplayFlags();
            tl.HideNullTextures = !tl.HideNullTextures;

            var tc = await document.Environment.GetTextureCollection();

            await MapDocumentOperation.Perform(document,
                new TrivialOperation(
                    x => x.Map.Data.Replace(tl),
                    x =>
                    {
                        x.Update(tl);
                        x.UpdateRange(x.Document.Map.Root.Find(s => s is Solid).Where(s => s.Data.Get<Face>().Any(f => tc.IsNullTexture(f.Texture.Name))));
                    })
            );
        }

        public bool GetToggleState(IContext context)
        {
            if (!context.TryGet("ActiveDocument", out MapDocument doc)) return false;
            var tf = doc.Map.Data.GetOne<DisplayFlags>() ?? new DisplayFlags();
            return tf.HideNullTextures;
        }
    }
}