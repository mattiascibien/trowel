using Trowel.BspEditor.Primitives;
using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.BspEditor.Tools.Brush.Brushes.Controls;
using Trowel.DataStructures.Geometric;
using System.Collections.Generic;

namespace Trowel.BspEditor.Tools.Brush
{
    public interface IBrush
    {
        string Name { get; }
        bool CanRound { get; }
        IEnumerable<BrushControl> GetControls();
        IEnumerable<IMapObject> Create(UniqueNumberGenerator idGenerator, Box box, string texture, int roundDecimals);
    }
}
