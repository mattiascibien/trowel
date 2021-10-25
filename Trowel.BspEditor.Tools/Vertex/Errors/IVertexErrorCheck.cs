using Trowel.BspEditor.Tools.Vertex.Selection;
using System.Collections.Generic;

namespace Trowel.BspEditor.Tools.Vertex.Errors
{
    public interface IVertexErrorCheck
    {
        IEnumerable<VertexError> GetErrors(VertexSolid solid);
    }
}
