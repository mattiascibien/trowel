using Trowel.Common.Shell;
using System;
using System.ComponentModel.Composition;
using System.IO;

namespace Trowel.Editor
{
    [Export(typeof(IApplicationInfo))]
    public class ApplicationInfo : IApplicationInfo
    {
        private string Name => "Trowel";

        public string GetApplicationSettingsFolder(string subfolder)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Name);
            if (String.IsNullOrWhiteSpace(subfolder)) return path;
            return Path.Combine(path, subfolder);
        }
    }
}
