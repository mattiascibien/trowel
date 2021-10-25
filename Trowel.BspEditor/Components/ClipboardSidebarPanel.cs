using LogicAndTrick.Oy;
using Trowel.BspEditor.Documents;
using Trowel.Common.Shell.Components;
using Trowel.Common.Shell.Context;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trowel.BspEditor.Components
{
#if DEBUG_EXTRA
    [AutoTranslate]
    [Export(typeof(ISidebarComponent))]
#endif
    [OrderHint("K")]
    public partial class ClipboardSidebarPanel : UserControl, ISidebarComponent
    {
        [Import] private Lazy<ClipboardManager> _clipboard;

        public string Title { get; set; } = "Clipboard";
        public object Control => this;

        public ClipboardSidebarPanel()
        {
            InitializeComponent();

            Oy.Subscribe<ClipboardManager>("BspEditor:ClipboardChanged", ClipboardChanged);
        }

        private Task ClipboardChanged(ClipboardManager arg)
        {
            UpdateList();
            return Task.CompletedTask;
        }

        private void UpdateList()
        {
            ClipboardList.BeginUpdate();
            ClipboardList.Items.Clear();

            foreach (var val in _clipboard.Value.GetClipboardRing().Reverse())
            {
                ClipboardList.Items.Add(val);
            }
            if (ClipboardList.Items.Count > 0) ClipboardList.SelectedIndex = 0;

            ClipboardList.EndUpdate();
        }

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }
    }
}
