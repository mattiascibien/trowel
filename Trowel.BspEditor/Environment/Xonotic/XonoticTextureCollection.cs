﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Environment.Xonotic
{
    public class XonoticTextureCollection : TextureCollection
    {
        public XonoticTextureCollection(IEnumerable<Trowel.Providers.Texture.TexturePackage> packages) : base(packages)
        {
        }

        public override IEnumerable<string> GetBrowsableTextures()
        {
            var hs = new HashSet<string>();
            foreach (var pack in Packages.Where(x => x.Type == "pk3")) hs.UnionWith(pack.Textures);
            return hs;
        }

        public override IEnumerable<string> GetDecalTextures()
        {
            return Packages.Where(x => string.Equals(x.Location, "decals.wad", StringComparison.CurrentCultureIgnoreCase)).SelectMany(x => x.Textures);
        }

        public override IEnumerable<string> GetSpriteTextures()
        {
            return Packages.Where(x => string.Equals(x.Location, "sprites", StringComparison.InvariantCultureIgnoreCase)).SelectMany(x => x.Textures);
        }

        public override bool IsNullTexture(string name)
        {
            switch (name?.ToLower())
            {
                case "null":
                case "bevel":
                    return true;
                default:
                    return false;
            }
        }

        public override float GetOpacity(string name)
        {
            switch (name?.ToLower())
            {
                case "aaatrigger":
                case "hint":
                case "clip":
                case "origin":
                case "skip":
                    return 0.5f;
                default:
                    return 1;
            }
        }
    }
}
