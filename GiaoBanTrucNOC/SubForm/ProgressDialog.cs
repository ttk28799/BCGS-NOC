using System.Windows.Forms;

namespace GiaoBanTrucNOC.SubForm
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog()
        {
            InitializeComponent();
        }

        public void UpdateProgress(int value, string message = null)
        {
            progressBar.Value = value;
            if (!string.IsNullOrEmpty(message))
            {
                lblMessage.Text = message;
            }
        }
    }
}