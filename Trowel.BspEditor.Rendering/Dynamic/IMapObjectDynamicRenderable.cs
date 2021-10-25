using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Rendering.Resources;
using Trowel.Rendering.Resources;

namespace Trowel.BspEditor.Rendering.Dynamic
{
    public interface IMapObjectDynamicRenderable
    {
        void Render(MapDocument document, BufferBuilder builder, ResourceCollector resourceCollector);
    }
}