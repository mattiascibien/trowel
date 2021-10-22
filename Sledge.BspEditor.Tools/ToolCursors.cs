﻿using Sledge.BspEditor.Tools.Properties;
using System.IO;
using System.Windows.Forms;

namespace Sledge.BspEditor.Tools
{
    public static class ToolCursors
    {
        public static Cursor RotateCursor { get; }

        static ToolCursors()
        {
            RotateCursor = new Cursor(new MemoryStream(Resources.Cursor_Rotate));
        }
    }
}
