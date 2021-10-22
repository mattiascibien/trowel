using Sledge.BspEditor.Primitives.MapObjects;
using System.Runtime.Serialization;

namespace Sledge.BspEditor.Primitives.MapData
{
    /// <summary>
    /// Base interface for generic map metadata
    /// </summary>
    public interface IMapData : ISerializable, IMapElement
    {
        bool AffectsRendering { get; }
    }
}