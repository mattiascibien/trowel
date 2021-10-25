using Trowel.Rendering.Cameras;
using Trowel.Rendering.Overlay;
using System;
using System.Windows.Forms;

namespace Trowel.Rendering.Viewports
{
    public interface IViewport : IRenderTarget
    {
        int ID { get; }

        int Width { get; }
        int Height { get; }
        Control Control { get; }
        bool IsFocused { get; }

        ICamera Camera { get; set; }
        ViewportOverlay Overlay { get; }

        void Update(long frame);
        event EventHandler<long> OnUpdate;
    }
}