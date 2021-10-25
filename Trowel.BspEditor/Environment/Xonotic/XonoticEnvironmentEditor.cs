using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trowel.Common.Translations;
using Trowel.Providers.GameData;

namespace Trowel.BspEditor.Environment.Xonotic
{
    public partial class XonoticEnvironmentEditor : UserControl, IEnvironmentEditor
    {
        public event EventHandler EnvironmentChanged;
        public Control Control => this;

        private readonly IGameDataProvider _fgdProvider = Common.Container.Get<IGameDataProvider>("Fgd");

        public XonoticEnvironmentEditor()
        {
            InitializeComponent();

            txtGameDir.TextChanged += OnEnvironmentChanged;
            cmbGameExe.SelectedIndexChanged += OnEnvironmentChanged;
        }

        private void GameDirectoryTextChanged(object sender, EventArgs e)
        {
            UpdateGameDirectory();
        }

        private void UpdateGameDirectory()
        {
            var dir = txtGameDir.Text;
            if (!Directory.Exists(dir)) return;

            cmbGameExe.Items.Clear();

            var exes = Directory.GetFiles(dir, "*.exe").Select(Path.GetFileName);
            var ignored = new [] { "xonotic-x86-dedicated.exe", "xonotic-dedicated.exe" };

            var range = exes.Where(x => !ignored.Contains(x.ToLowerInvariant())).OfType<object>().ToArray();
            cmbGameExe.Items.AddRange(range);

            // Set game executable
            var exe = cmbGameExe.SelectedItem ?? "";

            if (cmbGameExe.Items.Contains(exe)) cmbGameExe.SelectedItem = exe;
            else if (cmbGameExe.Items.Count > 0) cmbGameExe.SelectedIndex = 0;
        }

        private void OnEnvironmentChanged(object sender, EventArgs e)
        {
            EnvironmentChanged?.Invoke(this, e);
        }


        public IEnvironment Environment 
        { 
            get => GetEnvironment(); 
            set => SetEnvironment(value as XonoticEnvironment); 
        }

        public IEnvironment GetEnvironment()
        {
            return new XonoticEnvironment()
            {
                BaseDirectory = txtGameDir.Text,
                GameExe = Convert.ToString(cmbGameExe.SelectedItem, CultureInfo.InvariantCulture),
            };
        }

        private void BrowseGameDirectory(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (Directory.Exists(txtGameDir.Text)) fbd.SelectedPath = txtGameDir.Text;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtGameDir.Text = fbd.SelectedPath;
                }
            }
        }

        public void SetEnvironment(XonoticEnvironment env)
        {
            if (env == null) env = new XonoticEnvironment();

            txtGameDir.Text = env.BaseDirectory;
            cmbGameExe.SelectedItem = env.GameExe;
        }

        public void Translate(ITranslationStringProvider strings)
        {
            
        }
    }
}
