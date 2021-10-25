using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trowel.BspEditor.Compile;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Primitives.MapData;
using Trowel.DataStructures.GameData;
using Trowel.FileSystem;

namespace Trowel.BspEditor.Environment.Xonotic
{
    public class XonoticEnvironment : IEnvironment
    {
        public string Engine => "Darkplaces";

        public string ID { get; set; }

        public string Name { get; set; }

        public string FgdFile { get; set; }

        private IFile _root;
        public IFile Root
        {
            get
            {
                if (_root == null)
                {
                    var dirs = Directories.Where(Directory.Exists).ToList();
                    if (dirs.Any()) _root = new RootFile(Name, dirs.Select(x => new NativeFile(x)));
                    else _root = new VirtualFile(null, "");
                }
                return _root;
            }
        }

        public IEnumerable<string> Directories
        {
            get
            {
                yield return Path.Combine(BaseDirectory, "data");

                // Editor location to the path, for sprites and the like
                yield return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            }
        }

        public string DefaultBrushEntity { get; set; }

        public string DefaultPointEntity { get; set; }

        public decimal DefaultTextureScale { get; set; } = 1;

        public string BaseDirectory { get; set; }
        public string GameExe { get; internal set; }

        public void AddData(IEnvironmentData data)
        {
            throw new NotImplementedException();
        }

        public Task<Batch> CreateBatch(IEnumerable<BatchArgument> arguments, BatchOptions options)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AutomaticVisgroup> GetAutomaticVisgroups()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetData<T>() where T : IEnvironmentData
        {
            throw new NotImplementedException();
        }

        public Task<GameData> GetGameData()
        {
            throw new NotImplementedException();
        }

        public Task<TextureCollection> GetTextureCollection()
        {
            throw new NotImplementedException();
        }

        public Task UpdateDocumentData(MapDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
