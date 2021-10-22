using Sledge.BspEditor.Tools.Vertex.Selection;
using System.Collections.Generic;

namespace Sledge.BspEditor.Tools.Vertex.Errors
{
    public interface IVertexErrorCheck
    {
        IEnumerable<VertexError> GetErrors(VertexSolid solid);
    }
}
