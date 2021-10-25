﻿using Trowel.BspEditor.Tools.Vertex.Selection;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Trowel.BspEditor.Tools.Vertex.Errors
{
    [Export(typeof(IVertexErrorCheck))]
    public class CoplanarFaces : IVertexErrorCheck
    {
        private const string Key = "Trowel.BspEditor.Tools.Vertex.Errors.CoplanarFaces";

        private IEnumerable<MutableFace> GetCoplanarFaces(MutableSolid solid)
        {
            var faces = solid.Faces.ToList();
            return faces.Where(f1 => faces.Where(f2 => f2 != f1).Any(f2 => f2.Plane == f1.Plane));
        }

        public IEnumerable<VertexError> GetErrors(VertexSolid solid)
        {
            foreach (var group in GetCoplanarFaces(solid.Copy).GroupBy(x => x.Plane))
            {
                yield return new VertexError(Key, solid).Add(group);
            }
        }
    }
}