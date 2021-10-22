using Sledge.Common.Translations;
using System;
using System.Windows.Forms;

namespace Sledge.BspEditor.Environment
{
    public interface IEnvironmentEditor : IManualTranslate
    {
        event EventHandler EnvironmentChanged;
        Control Control { get; }
        IEnvironment Environment { get; set; }
    }
}