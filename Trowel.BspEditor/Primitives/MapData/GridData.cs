﻿using Trowel.BspEditor.Grid;
using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.Common.Transport;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;

namespace Trowel.BspEditor.Primitives.MapData
{
    public class GridData : IMapData
    {
        public bool AffectsRendering => false;

        public bool SnapToGrid { get; set; }
        public IGrid Grid { get; set; }

        public GridData(IGrid grid)
        {
            Grid = grid;
            SnapToGrid = true;
        }

        public GridData(SerialisedObject obj)
        {
            // todo deserialise grid
            SnapToGrid = obj.Get<bool>("SnapToGrid");
        }

        [Export(typeof(IMapElementFormatter))]
        public class GridDataFormatter : StandardMapElementFormatter<GridData> { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Meh
        }

        public IMapElement Clone()
        {
            return new GridData(Grid) { SnapToGrid = SnapToGrid };
        }

        public IMapElement Copy(UniqueNumberGenerator numberGenerator)
        {
            return Clone();
        }

        public SerialisedObject ToSerialisedObject()
        {
            var so = new SerialisedObject("Grid");
            so.Set("SnapToGrid", SnapToGrid);
            return so;
        }
    }
}
