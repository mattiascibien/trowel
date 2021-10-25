using Trowel.BspEditor.Documents;
using Trowel.Rendering.Cameras;
using Trowel.Rendering.Overlay;
using Trowel.Rendering.Viewports;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Numerics;

namespace Trowel.BspEditor.Rendering.Overlay
{
    [Export(typeof(IMapDocumentOverlayRenderable))]
    public class ViewportTextOverlay : IMapDocumentOverlayRenderable
    {
        public void SetActiveDocument(MapDocument doc)
        {
            //
        }

        public void Render(IViewport viewport, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im)
        {
            var str = $"2D {camera.ViewType}";
            var size = im.CalcTextSize(FontType.Normal, str);
            im.AddText(new Vector2(2, 2), Color.White, FontType.Normal, str);
            im.AddRectFilled(Vector2.Zero, size + new Vector2(4, 4), Color.FromArgb(128, Color.Pink));
        }

        public void Render(IViewport viewport, PerspectiveCamera camera, I2DRenderer im)
        {
            var str = $"3D View";
            var size = im.CalcTextSize(FontType.Normal, str);
            im.AddText(new Vector2(2, 2), Color.White, FontType.Normal, str);
            im.AddRectFilled(Vector2.Zero, size + new Vector2(4, 4), Color.FromArgb(128, Color.Pink));
        }
    }
}
