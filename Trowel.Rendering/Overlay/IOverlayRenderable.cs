using Trowel.Rendering.Cameras;
using Trowel.Rendering.Viewports;
using System.Numerics;

namespace Trowel.Rendering.Overlay
{
    public interface IOverlayRenderable
    {
        void Render(IViewport viewport, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im);
        void Render(IViewport viewport, PerspectiveCamera camera, I2DRenderer im);
    }
}