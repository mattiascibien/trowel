using System;
using System.Collections.Generic;
using System.Linq;
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

        public IFile Root => throw new NotImplementedException();

        public IEnumerable<string> Directories => throw new NotImplementedException();

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
