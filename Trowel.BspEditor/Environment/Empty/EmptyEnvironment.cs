﻿using Trowel.BspEditor.Compile;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Primitives.MapData;
using Trowel.DataStructures.GameData;
using Trowel.FileSystem;
using Trowel.Providers.Texture;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Environment.Empty
{
    public class EmptyEnvironment : IEnvironment
    {
        public string Engine => "None";
        public string ID => "Empty";
        public string Name => "Empty";
        public IFile Root => null;
        public IEnumerable<string> Directories => new string[0];

        public async Task<TextureCollection> GetTextureCollection()
        {
            return new EmptyTextureCollection(new TexturePackage[0]);
        }

        public async Task<GameData> GetGameData()
        {
            return new GameData();
        }

        public Task UpdateDocumentData(MapDocument document)
        {
            return Task.FromResult(0);
        }

        public void AddData(IEnvironmentData data)
        {

        }

        public IEnumerable<T> GetData<T>() where T : IEnvironmentData
        {
            return null;
        }

        public Task<Batch> CreateBatch(IEnumerable<BatchArgument> arguments, BatchOptions options)
        {
            return Task.FromResult<Batch>(null);
        }

        public IEnumerable<AutomaticVisgroup> GetAutomaticVisgroups()
        {
            yield break;
        }

        public bool IsNullTexture(string name)
        {
            return false;
        }

        public string DefaultBrushEntity => "";
        public string DefaultPointEntity => "";
        public decimal DefaultTextureScale => 1;
    }
}
