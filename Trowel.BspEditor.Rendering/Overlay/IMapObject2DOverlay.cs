using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.Rendering.Cameras;
using Trowel.Rendering.Overlay;
using Trowel.Rendering.Viewports;
using System.Collections.Generic;
using System.Numerics;

namespace Trowel.BspEditor.Rendering.Overlay
{
    public interface IMapObject2DOverlay
    {
        void Render(IViewport viewport, ICollection<IMapObject> objects, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im);
    }
}