using GiaoBanTrucNOC.SaveLoad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace GiaoBanTrucNOC.SubForm
{
    public partial class ThemSuCoKyThuat : Form
    {
        static string jsonPath = ".\\DanhSach\\devices.json";
        static string txtPath = ".\\DanhSach\\IssueList.txt";
        List<Device> deviceList = LoadDeviceList(jsonPath);

        public Device Thietbi { get; set; } = new Device(Guid.NewGuid(), new Device.DeviceLocation(), string.Empty, new Device.DeviceIssue(), string.Empty);

        public ThemSuCoKyThuat()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var selectedRegion = grpBxRegion.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRegion != null)
            {
                Thietbi.Location.Region = selectedRegion.Text;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vùng.");
                return;
            }
            if (cboxRACK.SelectedItem != null)
            {
                Thietbi.Location.Rack = cboxRACK.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một rack.");
                return;
            }
            if (lstBoxDevice.SelectedItem != null)
            {
                Thietbi.Name = lstBoxDevice.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thiết bị.");
                return;
            }
            if (clstboxIssue.CheckedItems.Count > 0)
            {
                foreach(var item in clstboxIssue.CheckedItems)
                {
                    Thietbi.Issue.IssueList.Add(item.ToString());
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một lỗi.");
                return;
            }
            if (string.IsNullOrWhiteSpace(rtboxNote.Text))
            {
                Thietbi.Note = string.Empty;
            }
            else
            {
                Thietbi.Note = rtboxNote.Text;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ThemSuCoKyThuat_Load(object sender, EventArgs e)
        {
            // Load danh sách lỗi từ txtFile
            var issueList = LoadFromTxt(txtPath);
            foreach (var issue in issueList)
            {
                clstboxIssue.Items.Add(issue);
            }
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            // Tạo một thiết bị mới với tên trong tbxSearchDevice, Vùng và Rack đã chọn, lỗi và ghi chú null
            if (string.IsNullOrWhiteSpace(tboxSearchDevice.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thiết bị.");
                return;
            }
            var selectedRegion = grpBxRegion.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRegion == null)
            {
                MessageBox.Show("Vui lòng chọn một khu vực.");
                return;
            }
            var selectedRack = cboxRACK.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedRack))
            {
                MessageBox.Show("Vui lòng chọn một rack.");
                return;
            }
            var newDevice = new Device(Guid.NewGuid(), new Device.DeviceLocation { Region = selectedRegion.Text, Rack = selectedRack }, tboxSearchDevice.Text, new Device.DeviceIssue(), string.Empty);
            // Kiểm tra xem thiết bị đã tồn tại trong danh sách chưa
            if (deviceList.Any(d => d.Name.Equals(newDevice.Name, StringComparison.OrdinalIgnoreCase) && d.Location.Region == newDevice.Location.Region && d.Location.Rack == newDevice.Location.Rack))
            {
                MessageBox.Show("Thiết bị đã tồn tại trong danh sách.");
                return;
            }
            // Thêm thiết bị vào danh sách
            deviceList.Add(newDevice);
            // Cập nhật danh sách thiết bị trong lstBoxDevice
            lstBoxDevice.Items.Clear();
            tboxSearchDevice.Clear();
            UpdateDeviceList();
            // Lưu danh sách thiết bị vào file JSON
            ExportDeviceList(deviceList, jsonPath);
        }

        public static void ExportDeviceList(List<Device> deviceList, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

            string jsonString = JsonSerializer.Serialize(deviceList, options);
            File.WriteAllText(filePath, jsonString);
        }

        private void UpdateDeviceList()
        {
            // Kiểm tra để chắc chắc rằng có một radio button được chọn trong grpbxRegion
            if (grpBxRegion.Controls.OfType<RadioButton>().Any(r => r.Checked))
            {
                // Kiểm tra cboxRACK có item nào được chọn không
                if (cboxRACK.SelectedItem != null)
                {
                    var selectedRegion = grpBxRegion.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                    var selectedRack = cboxRACK.SelectedItem.ToString();
                    //Show tên thiết bị vào lstBoxDevice theo selectedRegion và selectedRack
                    var filteredDevices = deviceList.Where(d => d.Location.Region == selectedRegion.Text && d.Location.Rack == selectedRack).ToList();
                    lstBoxDevice.Items.Clear();
                    foreach (var device in filteredDevices)
                    {
                        lstBoxDevice.Items.Add(device);
                    }
                }
            }
        }

        public static List<Device> LoadDeviceList(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Device>();

            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Device>>(jsonString, options) ?? new List<Device>();
        }

        public static List<string> LoadFromTxt(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<string>();
            return File.ReadAllLines(filePath).ToList();
        }

        private void rdoDCQG_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }

        private void rdoNVNN_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }

        private void rdoCCCD_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }

        private void rdoDDDT_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }

        private void cboxRACK_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }

        private void lstBoxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDevice = lstBoxDevice.SelectedItem as Device;
            if (selectedDevice != null)
            {
                // Create a copy of the items to iterate over
                var itemsCopy = clstboxIssue.Items.Cast<object>().ToList();

                foreach (var item in itemsCopy)
                {
                    bool isChecked = selectedDevice.Issue.IssueList.Contains(item.ToString());
                    int index = clstboxIssue.Items.IndexOf(item);
                    clstboxIssue.SetItemChecked(index, isChecked);
                }
            }
        }

        private void tboxSearchDevice_TextChanged(object sender, EventArgs e)
        {
            //Tìm kiếm trong lstBoxDevice theo tboxSearchDevice và selectRegion và selectedRack
            var searchText = tboxSearchDevice.Text.ToLower();
            var selectedRegion = grpBxRegion.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            var selectedRack = cboxRACK.SelectedItem?.ToString();
            var filteredDevices = deviceList.Where(d => 
                d.Location.Region == selectedRegion.Text && 
                d.Location.Rack == selectedRack && 
                d.Name.ToLower().Contains(searchText)).ToList();
            lstBoxDevice.Items.Clear();
            foreach (var device in filteredDevices)
            {
                lstBoxDevice.Items.Add(device);
            }
        }

        private void clstboxIssue_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var selectedDevice = lstBoxDevice.SelectedItem as Device;
            if (selectedDevice == null)
                return;

            string issue = clstboxIssue.Items[e.Index].ToString();

            // Sử dụng BeginInvoke để đảm bảo CheckedItems đã cập nhật
            BeginInvoke(new Action(() =>
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (!selectedDevice.Issue.IssueList.Contains(issue))
                        selectedDevice.Issue.IssueList.Add(issue);
                }
                else
                {
                    if (selectedDevice.Issue.IssueList.Contains(issue))
                        selectedDevice.Issue.IssueList.Remove(issue);
                }
                // Nếu muốn lưu lại thay đổi ngay lập tức
                ExportDeviceList(deviceList, jsonPath);
            }));
        }

        private void btnAddIssueType_Click(object sender, EventArgs e)
        {
            //Thêm lỗi trong tboxsearchIssue vào textfile
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