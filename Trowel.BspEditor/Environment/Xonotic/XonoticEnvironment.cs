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
using Trowel.Common;
using Trowel.DataStructures.GameData;
using Trowel.FileSystem;
using Trowel.Providers.GameData;
using Trowel.Providers.Texture;

namespace Trowel.BspEditor.Environment.Xonotic
{
    public class XonoticEnvironment : IEnvironment
    {
        private readonly ITexturePackageProvider _pk3Provider;
        private readonly IGameDataProvider _fgdProvider;
        private readonly Lazy<Task<TextureCollection>> _textureCollection;
        private readonly Lazy<Task<GameData>> _gameData;

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

        public XonoticEnvironment()
        {
            _pk3Provider = Container.Get<ITexturePackageProvider>("Pk3");
            _fgdProvider = Container.Get<IGameDataProvider>("Fgd");
            _gameData = new Lazy<Task<GameData>>(MakeGameDataAsync);
            _textureCollection = new Lazy<Task<TextureCollection>>(MakeTextureCollectionAsync);
        }


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

        public Task<GameData> GetGameData() =>  _gameData.Value;

        private async Task<TextureCollection> MakeTextureCollectionAsync()
        {
            var pk3Refs = _pk3Provider.GetPackagesInFile(Root);
            var packages = await _pk3Provider.GetTexturePackages(pk3Refs);

            return new XonoticTextureCollection(packages);
        }

        private Task<GameData> MakeGameDataAsync()
        {
            return Task.FromResult(_fgdProvider.GetGameDataFromFiles(new [] { FgdFile }));
        }

        public Task<TextureCollection> GetTextureCollection() => _textureCollection.Value;

        public Task UpdateDocumentData(MapDocument document)
        {
            return Task.CompletedTask;
        }
    }
}
