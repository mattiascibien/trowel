using Sledge.BspEditor.Primitives.MapObjects;
using Sledge.Common.Transport;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;

namespace Sledge.BspEditor.Primitives.MapObjectData
{
    public class CordonHidden : IMapObjectData, IObjectVisibility
    {
        public bool IsHidden => true;

        public CordonHidden()
        {
        }

        public CordonHidden(SerialisedObject obj)
        {
        }

        [Export(typeof(IMapElementFormatter))]
        public class ActiveTextureFormatter : StandardMapElementFormatter<CordonHidden> { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        public IMapElement Clone()
        {
            return new CordonHidden();
        }

        public IMapElement Copy(UniqueNumberGenerator numberGenerator)
        {
            return Clone();
        }

        public SerialisedObject ToSerialisedObject()
        {
            var so = new SerialisedObject("CordonHidden");
            return so;
        }
    }
}