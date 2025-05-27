using System;
using System.Windows.Forms;

namespace GiaoBanTrucNOC.SubForm
{
    public partial class ThemLuotRaVao : Form
    {
        public int Count { get; set; } = 0;
        public string Unit { get; set; } = "";
        public string Description { get; set; } = "";

        public ThemLuotRaVao()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboxUnit.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(rtboxDescription.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (int.Parse(tbxCount.Text) <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượt lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Count = int.Parse(tbxCount.Text);
            Unit = cboxUnit.Text;
            Description = rtboxDescription.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cboxExample_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtboxDescription.Text = cboxExample.Text;
        }

        private void cboxExample_Enter(object sender, EventArgs e)
        {
            cboxExample.DroppedDown = true;
        }

        private void cboxUnit_Enter(object sender, EventArgs e)
        {
            cboxUnit.DroppedDown = true;
        }
    }
}