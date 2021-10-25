using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Rendering.Viewport;
using Trowel.BspEditor.Tools.Draggable;
using Trowel.Rendering.Cameras;
using System.Numerics;

namespace Trowel.BspEditor.Tools.Selection.TransformationHandles
{
    public interface ITransformationHandle : IDraggable
    {
        string Name { get; }
        Matrix4x4? GetTransformationMatrix(MapViewport viewport, OrthographicCamera camera, BoxState state, MapDocument doc);
        TextureTransformationType GetTextureTransformationType(MapDocument doc);
    }
}
