using Trowel.FileSystem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trowel.Providers.Texture
{
    public interface ITexturePackageProvider
    {
        Task<TexturePackage> GetTexturePackage(TexturePackageReference reference);

        Task<IEnumerable<TexturePackage>> GetTexturePackages(IEnumerable<TexturePackageReference> references);

        IEnumerable<TexturePackageReference> GetPackagesInFile(IFile file);
    }
}