using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Primitives;
using Trowel.BspEditor.Primitives.MapObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Modification.Operations.Mutation
{
    /// <summary>
    /// Scale transform all ITextured data objects in a collection
    /// </summary>
    public class TransformTexturesScale : IOperation
    {
        private readonly List<long> _idsToTransform;
        private readonly Matrix4x4 _matrix;

        public bool Trivial => false;

        public TransformTexturesScale(Matrix4x4 matrix, params IMapObject[] objectsToTransform)
        {
            _matrix = matrix;
            _idsToTransform = objectsToTransform.Select(x => x.ID).ToList();
        }

        public TransformTexturesScale(Matrix4x4 matrix, IEnumerable<IMapObject> objectsToTransform)
        {
            _matrix = matrix;
            _idsToTransform = objectsToTransform.Select(x => x.ID).ToList();
        }

        public Task<Change> Perform(MapDocument document)
        {
            var ch = new Change(document);

            var objects = _idsToTransform.Select(x => document.Map.Root.FindByID(x)).Where(x => x != null).ToList();

            foreach (var o in objects)
            {
                foreach (var it in o.Data.OfType<ITextured>())
                {
                    it.Texture.TransformScale(_matrix);
                    ch.Update(o);
                }
            }

            return Task.FromResult(ch);
        }

        public Task<Change> Reverse(MapDocument document)
        {
            if (!Matrix4x4.Invert(_matrix, out var inv)) throw new Exception("Unable to reverse this operation.");
            var ch = new Change(document);

            var objects = _idsToTransform.Select(x => document.Map.Root.FindByID(x)).Where(x => x != null).ToList();

            foreach (var o in objects)
            {
                foreach (var it in o.Data.OfType<ITextured>())
                {
                    it.Texture.TransformScale(inv);
                    ch.Update(o);
                }
            }

            return Task.FromResult(ch);
        }
    }
}