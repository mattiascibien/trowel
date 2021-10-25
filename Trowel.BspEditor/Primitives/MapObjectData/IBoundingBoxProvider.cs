using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.DataStructures.Geometric;

namespace Trowel.BspEditor.Primitives.MapObjectData
{
    public interface IBoundingBoxProvider : IMapObjectData
    {
        Box GetBoundingBox(IMapObject obj);
    }
}
