using LogicAndTrick.Oy;
using Trowel.BspEditor.Documents;
using Trowel.Common.Shell.Components;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Documents;
using Trowel.Shell;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trowel.BspEditor.Editing.History
{
#if DEBUG_EXTRA
    [Export(typeof(ISidebarComponent))]
    [AutoTranslate]
#endif
    public partial class HistorySiderbarPanel : UserControl, ISidebarComponent
    {
        public string Title { get; set; } = "History";
        public object Control => this;

        private WeakReference<MapDocument> _activeDocument;

        public HistorySiderbarPanel()
        {
            InitializeComponent();

            Oy.Subscribe<IDocument>("Document:Activated", DocumentActivated);
            Oy.Subscribe<MapDocument>("MapDocument:HistoryChanged", HistoryChanged);
        }

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        private async Task HistoryChanged(MapDocument doc)
        {
            if (_activeDocument != null && _activeDocument.TryGetTarget(out MapDocument d) && d == doc)
            {
                this.InvokeLater(Rebuild);
            }
        }

        private async Task DocumentActivated(IDocument document)
        {
            var doc = document as MapDocument;
            _activeDocument = new WeakReference<MapDocument>(doc);
            this.InvokeLater(Rebuild);
        }

        private void Rebuild()
        {
            TreeNode lastNode = null;
            HistoryView.BeginUpdate();

            HistoryView.Nodes.Clear();
            if (_activeDocument.TryGetTarget(out MapDocument md))
            {
                var nodes = HistoryView.Nodes;
                var stack = md.Map.Data.GetOne<HistoryStack>();
                if (stack != null)
                {
                    foreach (var item in stack.GetOperations())
                    {
                        lastNode = nodes.Add(item.GetType().Name);
                    }
                }
            }

            HistoryView.EndUpdate();
            lastNode?.EnsureVisible();
        }
    }
}
