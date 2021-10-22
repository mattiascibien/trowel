using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Sledge.Shell.Forms
{
    public partial class AddLanguageForm : Form
    {
        public string Code => txtCode.Text;
        public string Description => txtDescription.Text;

        public AddLanguageForm()
        {
            InitializeComponent();
            btnOK.Enabled = false;
            DialogResult = DialogResult.Cancel;
        }

        private void OpenLanguageCodeList(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes");
        }

        private void OKClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void FormTextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = Code.Length > 0 && Description.Length > 0;
        }
    }
}
