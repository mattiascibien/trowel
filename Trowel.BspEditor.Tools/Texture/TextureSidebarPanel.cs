﻿using LogicAndTrick.Oy;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Primitives.MapData;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Components;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Documents;
using Trowel.Common.Shell.Hooks;
using Trowel.Common.Translations;
using Trowel.Providers.Texture;
using Trowel.Shell;
using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trowel.BspEditor.Tools.Texture
{
    [AutoTranslate]
    [Export(typeof(ISidebarComponent))]
    [Export(typeof(IInitialiseHook))]
    [OrderHint("B")]
    public partial class TextureSidebarPanel : UserControl, ISidebarComponent, IInitialiseHook
    {
        public Task OnInitialise()
        {
            Oy.Subscribe<IDocument>("Document:Activated", DocumentActivated);
            Oy.Subscribe<Change>("MapDocument:Changed", DocumentChanged);
            return Task.FromResult(0);
        }

        public string Title { get; set; } = "Texture";
        public object Control => this;

        private string _currentTexture;
        private WeakReference<MapDocument> _activeDocument;

        public string Apply
        {
            set => this.InvokeLater(() => ApplyButton.Text = value);
        }

        public string Browse
        {
            set => this.InvokeLater(() => BrowseButton.Text = value);
        }

        public string Replace
        {
            set => this.InvokeLater(() => ReplaceButton.Text = value);
        }

        public TextureSidebarPanel()
        {
            CreateHandle();
            InitializeComponent();

            SizeLabel.Text = "";
            NameLabel.Text = "";
            _activeDocument = new WeakReference<MapDocument>(null);
        }

        private void ApplyButtonClicked(object sender, EventArgs e)
        {
            Oy.Publish("Command:Run", new CommandMessage("BspEditor:ApplyActiveTexture"));
        }

        private void BrowseButtonClicked(object sender, EventArgs e)
        {
            Oy.Publish("Command:Run", new CommandMessage("BspEditor:BrowseActiveTexture"));
        }

        private void ReplaceButtonClicked(object sender, EventArgs e)
        {
            Oy.Publish("Command:Run", new CommandMessage("BspEditor:ReplaceTextures"));
        }

        private async Task DocumentActivated(IDocument doc)
        {
            var md = doc as MapDocument;

            _activeDocument = new WeakReference<MapDocument>(md);
            _currentTexture = null;

            await this.InvokeAsync(() =>
            {
                var dis = SelectionPictureBox.Image;
                SelectionPictureBox.Image = null;
                dis?.Dispose();
            });

            if (md != null)
            {
                await TextureSelected(md.Map.Data.GetOne<ActiveTexture>()?.Name);
            }
        }

        private async Task DocumentChanged(Change change)
        {
            if (_activeDocument.TryGetTarget(out MapDocument t) && change.Document == t)
            {
                await TextureSelected(t.Map.Data.GetOne<ActiveTexture>()?.Name);
            }
        }

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        private async Task TextureSelected(string selection)
        {
            if (selection == _currentTexture) return;
            _currentTexture = selection;

            if (!_activeDocument.TryGetTarget(out MapDocument doc)) return;

            Bitmap bmp = null;
            TextureItem texItem = null;

            if (selection != null)
            {
                var tc = await doc.Environment.GetTextureCollection();
                texItem = await tc.GetTextureItem(selection);

                if (texItem != null)
                {
                    using (var ss = tc.GetStreamSource())
                    {
                        bmp = await ss.GetImage(selection, 256, 256);
                    }
                }
            }

            this.InvokeLater(() =>
            {
                if (bmp != null)
                {
                    if (bmp.Width > SelectionPictureBox.Width || bmp.Height > SelectionPictureBox.Height)
                    {
                        SelectionPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        SelectionPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                }

                var dis = SelectionPictureBox.Image;
                SelectionPictureBox.Image = null;
                dis?.Dispose();

                SelectionPictureBox.Image = bmp;
                NameLabel.Text = texItem?.Name ?? "";
                SizeLabel.Text = texItem == null ? "" : $"{texItem.Width} x {texItem.Height}";
            });
        }
    }
}
