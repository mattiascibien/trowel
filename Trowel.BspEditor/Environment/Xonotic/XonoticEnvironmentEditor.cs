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
using Trowel.DataStructures.GameData;
using Trowel.Providers.GameData;

namespace Trowel.BspEditor.Environment.Xonotic
{
    public partial class XonoticEnvironmentEditor : UserControl, IEnvironmentEditor
    {
        public event EventHandler EnvironmentChanged;
        public Control Control => this;

        private readonly IGameDataProvider _entProvider = Common.Container.Get<IGameDataProvider>("Ent");

        public XonoticEnvironmentEditor()
        {
            InitializeComponent();

            txtGameDir.TextChanged += OnEnvironmentChanged;
            cmbGameExe.SelectedIndexChanged += OnEnvironmentChanged;

            cmbDefaultPointEntity.SelectedIndexChanged += OnEnvironmentChanged;
            cmbDefaultBrushEntity.SelectedIndexChanged += OnEnvironmentChanged;
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
                EntFile = txtEntFile.Text,
                DefaultPointEntity = Convert.ToString(cmbDefaultPointEntity.SelectedItem, CultureInfo.InvariantCulture),
                DefaultBrushEntity = Convert.ToString(cmbDefaultBrushEntity.SelectedItem, CultureInfo.InvariantCulture),
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

        private void BrowseEntFile(object sender, EventArgs e)
        {
            var directory = Path.GetDirectoryName(txtEntFile.Text);
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Radiant Entities File (*.ent)|*.ent";
                if (Directory.Exists(directory)) ofd.InitialDirectory = directory;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtEntFile.Text = ofd.FileName;
                }
            }
        }

        private void FdgFileChanged(object sender, EventArgs e)
        {
            var entities = new List<GameDataObject>();
            if (_entProvider != null)
            {
                if(File.Exists(txtEntFile.Text) && _entProvider.IsValidForFile(txtEntFile.Text))
                {
                    var gd = _entProvider.GetGameDataFromFiles(new [] { txtEntFile.Text });
                    entities.AddRange(gd.Classes);
                }
            }

            var selPoint = cmbDefaultPointEntity.SelectedItem as string;
            var selBrush = cmbDefaultBrushEntity.SelectedItem as string;

            cmbDefaultPointEntity.BeginUpdate();
            cmbDefaultBrushEntity.BeginUpdate();

            cmbDefaultPointEntity.Items.Clear();
            cmbDefaultBrushEntity.Items.Clear();

            cmbDefaultPointEntity.Items.Add("");
            cmbDefaultBrushEntity.Items.Add("");

            foreach (var gdo in entities.OrderBy(x => x.Name, StringComparer.InvariantCultureIgnoreCase))
            {
                if (gdo.ClassType == ClassType.Solid) cmbDefaultBrushEntity.Items.Add(gdo.Name);
                else if (gdo.ClassType != ClassType.Base) cmbDefaultPointEntity.Items.Add(gdo.Name);
            }

            var idx = cmbDefaultBrushEntity.Items.IndexOf(selBrush ?? "");
            if (idx >= 0) cmbDefaultBrushEntity.SelectedIndex = idx;
            idx = cmbDefaultPointEntity.Items.IndexOf(selPoint ?? "");
            if (idx >= 0) cmbDefaultPointEntity.SelectedIndex = idx;

            cmbDefaultPointEntity.EndUpdate();
            cmbDefaultBrushEntity.EndUpdate();
        }

        public void SetEnvironment(XonoticEnvironment env)
        {
            if (env == null) env = new XonoticEnvironment();

            txtGameDir.Text = env.BaseDirectory;
            cmbGameExe.SelectedItem = env.GameExe;
            txtEntFile.Text = env.EntFile;

            cmbDefaultPointEntity.SelectedItem = env.DefaultPointEntity;
            cmbDefaultBrushEntity.SelectedItem = env.DefaultBrushEntity;
        }

        public void Translate(ITranslationStringProvider strings)
        {
            
        }
    }
}
