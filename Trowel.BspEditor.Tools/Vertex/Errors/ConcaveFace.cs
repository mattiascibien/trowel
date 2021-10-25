using Trowel.BspEditor.Tools.Vertex.Selection;
using Trowel.DataStructures.Geometric;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Trowel.BspEditor.Tools.Vertex.Errors
{
    [Export(typeof(IVertexErrorCheck))]
    public class ConcaveFace : IVertexErrorCheck
    {
        private const string Key = "Trowel.BspEditor.Tools.Vertex.Errors.ConcaveFace";

        public IEnumerable<VertexError> GetErrors(VertexSolid solid)
        {
            foreach (var face in solid.Copy.Faces.Where(x => !IsConvex(x)))
            {
                yield return new VertexError(Key, solid).Add(face);
            }
        }

        private static bool IsConvex(MutableFace face)
        {
            return face.Vertices.Count > 2 && new Polygon(face.Vertices.Select(x => x.Position)).IsConvex();
        }
    }
}