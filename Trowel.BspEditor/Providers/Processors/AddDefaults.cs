using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Grid;
using Trowel.BspEditor.Primitives.MapData;
using Trowel.BspEditor.Primitives.MapObjectData;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Providers.Processors
{
    /// <summary>
    /// Add some known defaults to the bsp after loading
    /// </summary>
    [Export(typeof(IBspSourceProcessor))]
    public class AddDefaults : IBspSourceProcessor
    {
        private readonly SquareGridFactory _squareGridFactory;

        [ImportingConstructor]
        public AddDefaults([Import] SquareGridFactory squareGridFactory)
        {
            _squareGridFactory = squareGridFactory;
        }

        public string OrderHint => "A";

        public async Task AfterLoad(MapDocument document)
        {
            if (!document.Map.Data.Any(x => x is GridData))
            {
                var grid = await _squareGridFactory.Create(document.Environment);
                document.Map.Data.Add(new GridData(grid));
            }

            var gd = await document.Environment.GetGameData();
            document.Map.Root.Data.Replace(new PointEntityGameDataBoundingBoxProvider(gd));
            document.Map.Root.Invalidate();
        }

        public Task BeforeSave(MapDocument document)
        {
            return Task.FromResult(0);
        }
    }
}