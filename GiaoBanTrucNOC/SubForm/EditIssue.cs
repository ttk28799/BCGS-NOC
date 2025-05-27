using GiaoBanTrucNOC.SaveLoad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GiaoBanTrucNOC.SubForm
{
    public partial class EditIssue : Form
    {
        public event Action<Device> OnDeleteDevice;
        public Device _device;
        public string txtPath = ".\\DanhSach\\IssueList.txt";
        public EditIssue(Device device)
        {
            InitializeComponent();
            _device = device;
        }

        private void EditIssue_Load(object sender, EventArgs e)
        {
            if (_device != null)
            {
                lblDeviceName.Text = _device.Location.ToString() + ": " + _device.Name;
            }
            // Tải danh sách lỗi txt vào clstboxIssue
            List<string> issueList = new List<string>();
            issueList.AddRange(System.IO.File.ReadAllLines(txtPath));
            // So sách tên Issue của _device và clstboxIssue, nếu trùng thì check vào
            foreach (string issue in issueList)
            {
                clstboxIssue.Items.Add(issue);
                if (_device.Issue.IssueList.Contains(issue))
                {
                    clstboxIssue.SetItemChecked(clstboxIssue.Items.Count - 1, true);
                }
            }
            rtboxNote.Text = _device.Note;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn xóa thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                OnDeleteDevice?.Invoke(_device);
                DialogResult = DialogResult.Abort; // hoặc Close()
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lưu lại danh sách lỗi của thiết bị vào _device
            _device.Issue.IssueList.Clear();
            foreach (string issue in clstboxIssue.CheckedItems)
            {
                _device.Issue.IssueList.Add(issue);
            }
            _device.Note = rtboxNote.Text;
            DialogResult = DialogResult.OK;
        }
        public static List<string> LoadFromTxt(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<string>();
            return File.ReadAllLines(filePath).ToList();
        }

        private void btnAddIssueType_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tboxSearchIssue.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lỗi.");
                return;
            }
            // Kiểm tra xem lỗi đã tồn tại trong danh sách chưa
            if (clstboxIssue.Items.Contains(tboxSearchIssue.Text))
            {
                MessageBox.Show("Lỗi đã tồn tại trong danh sách.");
                return;
            }
            // Lưu danh sách lỗi vào file txt
            using (StreamWriter sw = new StreamWriter(txtPath, true))
            {
                sw.WriteLine(Environment.NewLine + tboxSearchIssue.Text);
            }
            // Cập nhật lại danh sách lỗi từ file txt
            var issueList = LoadFromTxt(txtPath);
            clstboxIssue.Items.Clear();
            foreach (var issue in issueList)
            {
                clstboxIssue.Items.Add(issue);
            }
        }
    }
}
