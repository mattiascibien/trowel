using Sledge.BspEditor.Primitives.MapObjects;
using Sledge.Common.Threading;
using Sledge.DataStructures.Geometric;
using System.Collections.Generic;
using System.Linq;

namespace Sledge.BspEditor.Tools.Vertex.Selection
{
    public class MutableSolid
    {
        public IList<MutableFace> Faces { get; }
        public Box BoundingBox => new Box(Faces.SelectMany(x => x.Vertices.Select(v => v.Position)));

        public MutableSolid(Solid solid)
        {
            Faces = new ThreadSafeList<MutableFace>(solid.Faces.Select(x => new MutableFace(x)));
        }
    }
}