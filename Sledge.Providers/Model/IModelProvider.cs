using Sledge.FileSystem;
using Sledge.Rendering.Interfaces;
using System.Threading.Tasks;

namespace Sledge.Providers.Model
{
    public interface IModelProvider
    {
        bool CanLoadModel(IFile file);
        Task<IModel> LoadModel(IFile file);

        bool IsProvider(IModel model);
        IModelRenderable CreateRenderable(IModel model);
    }
}
