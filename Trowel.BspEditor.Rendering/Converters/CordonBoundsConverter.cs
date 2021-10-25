using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Primitives.MapData;
using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.BspEditor.Rendering.Resources;
using Trowel.Rendering.Cameras;
using Trowel.Rendering.Pipelines;
using Trowel.Rendering.Primitives;
using Trowel.Rendering.Resources;
using System.ComponentModel.Composition;
using System.Numerics;
using System.Threading.Tasks;
using Plane = Trowel.DataStructures.Geometric.Plane;

namespace Trowel.BspEditor.Rendering.Converters
{
    [Export(typeof(IMapObjectSceneConverter))]
    public class CordonBoundsConverter : IMapObjectSceneConverter
    {
        public MapObjectSceneConverterPriority Priority => MapObjectSceneConverterPriority.OverrideLow;

        private CordonBounds GetCordon(MapDocument doc)
        {
            return doc.Map.Data.GetOne<CordonBounds>() ?? new CordonBounds { Enabled = false };
        }

        public bool ShouldStopProcessing(MapDocument document, IMapObject obj)
        {
            return false;
        }

        public bool Supports(IMapObject obj)
        {
            return obj is Root;
        }

        public Task Convert(BufferBuilder builder, MapDocument document, IMapObject obj, ResourceCollector resourceCollector)
        {
            var c = GetCordon(document);
            if (!c.Enabled) return Task.FromResult(0);

            // It's always a box, these numbers are known
            const uint numVertices = 4 * 6;
            const uint numWireframeIndices = numVertices * 2;

            var points = new VertexStandard[numVertices];
            var indices = new uint[numWireframeIndices];

            var colour = new Vector4(1, 0, 0, 1);

            var vi = 0u;
            var wi = 0u;
            foreach (var face in c.Box.GetBoxFaces())
            {
                var offs = vi;

                var normal = new Plane(face[0], face[1], face[2]).Normal;
                foreach (var v in face)
                {
                    points[vi++] = new VertexStandard
                    {
                        Position = v,
                        Colour = colour,
                        Normal = normal,
                        Texture = Vector2.Zero,
                        Tint = Vector4.One
                    };
                }

                // Lines - [0 1] ... [n-1 n] [n 0]
                for (uint i = 0; i < 4; i++)
                {
                    indices[wi++] = offs + i;
                    indices[wi++] = offs + (i == 4 - 1 ? 0 : i + 1);
                }
            }

            var groups = new[]
            {
                new BufferGroup(PipelineType.Wireframe, CameraType.Both, 0, numWireframeIndices)
            };

            builder.Append(points, indices, groups);

            return Task.FromResult(0);
        }
    }
}