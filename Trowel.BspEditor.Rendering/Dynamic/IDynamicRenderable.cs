using Trowel.BspEditor.Rendering.Resources;
using Trowel.Rendering.Resources;

namespace Trowel.BspEditor.Rendering.Dynamic
{
    public interface IDynamicRenderable
    {
        void Render(BufferBuilder builder, ResourceCollector resourceCollector);
    }
}