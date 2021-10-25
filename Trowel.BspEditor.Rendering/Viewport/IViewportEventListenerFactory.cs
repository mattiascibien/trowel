using System.Collections.Generic;

namespace Trowel.BspEditor.Rendering.Viewport
{
    public interface IViewportEventListenerFactory
    {
        IEnumerable<IViewportEventListener> Create(MapViewport viewport);
    }
}