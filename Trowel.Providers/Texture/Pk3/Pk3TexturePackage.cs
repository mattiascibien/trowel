using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Trowel.FileSystem;
using Trowel.Packages.Zip;

namespace Trowel.Providers.Texture.Pk3
{
    public class Pk3TexturePackage : TexturePackage
    {
        readonly IFile _file;

        protected override IEqualityComparer<string> GetComparer => StringComparer.InvariantCultureIgnoreCase;

        public Pk3TexturePackage(TexturePackageReference reference) : base(reference.File.Name, "Pk3")
        {
            _file = reference.File;
            using (var stream = new ZipPackage(new FileInfo(_file.FullPathName)))
            {
                Textures.UnionWith(stream.GetFiles().Where(f => Path.GetExtension(f) == ".tga"));
            }
        }

        public override ITextureStreamSource GetStreamSource()
        {
            return new Pk3StreamSource(_file);
        }

        public override Task<TextureItem> GetTexture(string name)
        {
            if (!Textures.Contains(name)) return null;

            using(var zp = new ZipPackage(new FileInfo(_file.FullPathName)))
            { 
                var entry = zp.GetEntry(name);
                if (entry == null) return null;
                return Task.FromResult(new TextureItem(entry.Name, GetFlags(entry), 100, 100));
            }
        }

        public override Task<IEnumerable<TextureItem>> GetTextures(IEnumerable<string> names)
        {
            var textures = new HashSet<string>(names);
            textures.IntersectWith(Textures);
            if (!textures.Any()) return Task.FromResult(new TextureItem[0].AsEnumerable());

            using (var zp = new ZipPackage(new FileInfo(_file.FullPathName)))
            {
                var list = new List<TextureItem>();

                foreach (var name in textures)
                {
                    var entry = zp.GetEntry(name);
                    if (entry == null) continue;
                    var item = new TextureItem(entry.Name, GetFlags(entry), 100, 100);
                    list.Add(item);
                }

                return Task.FromResult(list.AsEnumerable());
            }
        }


        // TODO: decide
        private TextureFlags GetFlags(Packages.IPackageEntry entry)
        {
            return TextureFlags.None;
        }
    }
}