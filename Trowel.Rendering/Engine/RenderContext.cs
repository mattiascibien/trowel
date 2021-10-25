using Trowel.Rendering.Interfaces;
using System.Numerics;
using Veldrid;

namespace Trowel.Rendering.Engine
{
    public class RenderContext : IUpdateable
    {
        public ResourceLoader ResourceLoader { get; }
        public GraphicsDevice Device { get; }
        public Matrix4x4 SelectiveTransform { get; set; } = Matrix4x4.Identity;

        public RenderContext(GraphicsDevice device)
        {
            Device = device;
            ResourceLoader = new ResourceLoader(this);
        }

        public void Update(long frame)
        {

        }
    }
}
