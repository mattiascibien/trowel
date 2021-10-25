﻿using Trowel.DataStructures.Geometric;
using System.Collections.Generic;
using System.Numerics;

namespace Trowel.BspEditor.Grid
{
    public class NoGrid : IGrid
    {
        public int Spacing
        {
            get => 1;
            set { }
        }

        public string Description => "\u2013";

        public Vector3 Snap(Vector3 vector)
        {
            return vector.Snap(1);
        }

        public Vector3 AddStep(Vector3 vector, Vector3 add)
        {
            return vector + add;
        }

        public IEnumerable<GridLine> GetLines(Vector3 normal, float scale, Vector3 worldMinimum, Vector3 worldMaximum)
        {
            yield break;
        }
    }
}