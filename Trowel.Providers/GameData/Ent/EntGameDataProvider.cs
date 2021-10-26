using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;

namespace Trowel.Providers.GameData
{
    [Export("Ent", typeof(IGameDataProvider))]
    public class EntGameDataProvider : IGameDataProvider
    {
        public DataStructures.GameData.GameData GetGameDataFromFiles(IEnumerable<string> files)
        {
            var gd = new DataStructures.GameData.GameData();
            foreach (var f in files.Where(IsValidForFile))
            {
                var provider = new EntProvider();
                var d = provider.OpenFile(f);

                gd.MapSizeHigh = d.MapSizeHigh;
                gd.MapSizeLow = d.MapSizeLow;
                gd.Classes.AddRange(d.Classes);
                gd.MaterialExclusions.AddRange(d.MaterialExclusions);
            }
            gd.CreateDependencies();
            gd.RemoveDuplicates();
            return gd;
        }

        public bool IsValidForFile(string filename)
        {
            return File.Exists(filename) && Path.GetExtension(filename) == ".ent";
        }
    }
}