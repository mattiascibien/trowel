using Trowel.BspEditor.Primitives;
using Trowel.BspEditor.Primitives.MapObjectData;
using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.Common.Transport;
using System.Runtime.Serialization;

namespace Trowel.BspEditor.Tools.Vertex.Selection
{
    public class VertexHidden : IMapObjectData, IRenderVisibility
    {
        public bool IsRenderHidden => true;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Not serialisable
        }

        public SerialisedObject ToSerialisedObject()
        {
            // Not serialisable
            return null;
        }

        public IMapElement Copy(UniqueNumberGenerator numberGenerator)
        {
            return Clone();
        }

        public IMapElement Clone()
        {
            return new VertexHidden();
        }

    }
}
