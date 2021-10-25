using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Trowel.FileSystem;

namespace Trowel.Providers.Texture.Pk3
{
    [Export("Pk3", typeof(ITexturePackageProvider))]
    public class Pk3TexturePackageProvider : ITexturePackageProvider
    {
        public IEnumerable<TexturePackageReference> GetPackagesInFile(IFile file)
        {
            throw new System.NotImplementedException();
        }

        public Task<TexturePackage> GetTexturePackage(TexturePackageReference reference)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TexturePackage>> GetTexturePackages(IEnumerable<TexturePackageReference> references)
        {
            throw new System.NotImplementedException();
        }
    }

}