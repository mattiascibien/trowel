using Trowel.BspEditor.Primitives.MapData;
using Trowel.BspEditor.Primitives.MapObjects;

namespace Trowel.BspEditor.Primitives
{
    /// <summary>
    /// A map. Has a root node and some metadata.
    /// </summary>
    public class Map
    {
        public MapDataCollection Data { get; }
        public Root Root { get; }
        public UniqueNumberGenerator NumberGenerator { get; set; }

        public Map()
        {
            NumberGenerator = new UniqueNumberGenerator();
            Data = new MapDataCollection();
            Root = new Root(NumberGenerator.Next("MapObject"));
        }
    }
}