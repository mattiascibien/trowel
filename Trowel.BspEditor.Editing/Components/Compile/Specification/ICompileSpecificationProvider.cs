using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Components.Compile.Specification
{
    public interface ICompileSpecificationProvider
    {
        Task<IEnumerable<CompileSpecification>> GetSpecifications();
    }
}