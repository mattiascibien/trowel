using Trowel.BspEditor.Documents;
using Trowel.Rendering.Overlay;

namespace Trowel.BspEditor.Rendering.Overlay
{
    public interface IMapDocumentOverlayRenderable : IOverlayRenderable
    {
        void SetActiveDocument(MapDocument doc);
    }
}