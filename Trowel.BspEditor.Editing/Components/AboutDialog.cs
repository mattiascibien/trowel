﻿using Trowel.BspEditor.Documents;
using System.Diagnostics;
using System.Windows.Forms;

namespace Trowel.BspEditor.Editing.Components
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();

            VersionLabel.Text = FileVersionInfo.GetVersionInfo(typeof(MapDocument).Assembly.Location).FileVersion;

            LTLink.Click += (s, e) => OpenSite("https://logic-and-trick.com");
            GithubLink.Click += (s, e) => OpenSite("https://github.com/mattiascibien/trowel");
            GPLLink.Click += (s, e) => OpenSite("https://opensource.org/licenses/BSD-3-Clause");
            AJLink.Click += (s, e) => OpenSite("https://ajscarcella.com/");
            TWHLLink.Click += (s, e) => OpenSite("https://twhl.info");
        }

        private void OpenSite(string url)
        {
            var ps = new ProcessStartInfo(url)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }
    }
}
