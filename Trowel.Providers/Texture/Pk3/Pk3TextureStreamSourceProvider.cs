using System.Drawing;
using System.Threading.Tasks;
using Trowel.FileSystem;

namespace Trowel.Providers.Texture.Pk3
{
    public class Pk3StreamSource : ITextureStreamSource
    {
        public Pk3StreamSource(IFile file)
        {
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task<Bitmap> GetImage(string item, int maxWidth, int maxHeight)
        {
            throw new System.NotImplementedException();
        }

        public bool HasImage(string item)
        {
            throw new System.NotImplementedException();
        }
    }
}