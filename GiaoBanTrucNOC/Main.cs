using CsvHelper;
using GiaoBanTrucNOC.SaveLoad;
using GiaoBanTrucNOC.SubForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Word = Microsoft.Office.Interop.Word;

namespace GiaoBanTrucNOC
{
    public partial class Main : Form
    {
        private static readonly string jsonPath = ".\\DanhSach\\devices.json";
        // Move the initialization of `deviceList` to the constructor to avoid referencing a non-static method in a field initializer.
        private List<Device> deviceList;
        private readonly BindingList<Device> dcqgList = new BindingList<Device>();
        private readonly BindingList<Device> nvnnList = new BindingList<Device>();
        private readonly BindingList<Device> cccdList = new BindingList<Device>();
        private readonly BindingList<Device> dddtList = new BindingList<Device>();
        public Main()
        {
            InitializeComponent();
            deviceList = LoadDeviceList(jsonPath); // Initialize here
        }

        private void RoundControl(Control c, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(c.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(c.Width - radius, c.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, c.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            c.Region = new Region(path);
        }

        private void dTPicker_ValueChanged(object sender, EventArgs e)
        {
            TimeChanged();
        }

        private void TimeChanged()
        {
            //Khi người dùng thay đổi thời gian thì thay đổi thời gian của label TimeFrom và TimeTo
            if (cboxShift.SelectedIndex == 0)
            {
                lblTimeFrom.Text = "7h30 ngày " + dTPicker.Value.ToString("dd/MM/yyyy");
                lblTimeTo.Text = "10h30 ngày " + dTPicker.Value.ToString("dd/MM/yyyy");
            }
            if (cboxShift.SelectedIndex == 1)
            {
                lblTimeFrom.Text = "10h30 ngày " + dTPicker.Value.ToString("dd/MM/yyyy");
                lblTimeTo.Text = "14h30 ngày " + dTPicker.Value.ToString("dd/MM/yyyy");
            }
            if (cboxShift.SelectedIndex == 2)
            {
                lblTimeFrom.Text = "14h30 ngày " + dTPicker.Value.ToString("dd/MM/yyyy");
                lblTimeTo.Text = "17h30 ngày " + dTPicker.Value.ToString("dd/MM/yyyy");
            }
            if (cboxShift.SelectedIndex == 3)
            {
                lblTimeFrom.Text = "17h30 ngày " + dTPicker.Value.ToString("dd/MM/yyyy");
                lblTimeTo.Text = "7h30 ngày " + dTPicker.Value.AddDays(1).ToString("dd/MM/yyyy");
            }
        }

        private void cboxShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeChanged();
        }

        private void btnAddRaVao_Click(object sender, EventArgs e)
        {
            using (ThemLuotRaVao form = new ThemLuotRaVao())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //Lấy giá trị từ form ThemLuotRaVao
                    int count = form.Count;
                    string unit = form.Unit;
                    string description = form.Description;
                    //Thêm vào danh sách
                    dgvSoLuotRaVao.Rows.Add(count, unit, description);
                }
            }
        }

        private void btnAddIssue_Click(object sender, EventArgs e)
        {
            using (ThemSuCoKyThuat form = new ThemSuCoKyThuat())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //Lấy giá trị từ form ThemSuCoKyThuat
                    var id = Guid.NewGuid();
                    var region = form.Thietbi.Location.Region;
                    var location = form.Thietbi.Location;
                    var name = form.Thietbi.Name;
                    var issue = form.Thietbi.Issue;
                    var note = form.Thietbi.Note;
                    Device device = new Device(id, location, name, issue, note);
                    //Thêm vào danh sách
                    if (region == "DCQG")
                    {
                        dcqgList.Add(device);
                    }
                    if (region == "NVNN")
                    {
                        nvnnList.Add(device);
                    }
                    if (region == "CCCD")
                    {
                        cccdList.Add(device);
                    }
                    if (region == "DDDT")
                    {
                        dddtList.Add(device);
                    }
                }
            }
        }

        private List<Device> LoadDeviceList(string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show($"File {jsonPath} không tồn tại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Device>();
            }
            using (var reader = new StreamReader(jsonPath))
            {
                var json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<List<Device>>(json) ?? new List<Device>();
            }
        }

        private void btnNoOtherWork_Click(object sender, EventArgs e)
        {
            rtboxOtherWork.Text = "Không có công việc nào khác";
        }

        private void btnNoInfraIssue_Click(object sender, EventArgs e)
        {
            rtboxInfrastructure.Text = "Không có sự cố";
        }

        private void btnNormalShift_Click(object sender, EventArgs e)
        {
            rTbxShiftSituation.Text = "Ca trực bình thường";
        }

        private void btnDeviceFull_Click(object sender, EventArgs e)
        {
            rtboxDevice.Text = "Bàn giao trang thiết bị và giấy tờ đầy đủ";
        }

        private bool checkMissingFormInput()
        {
            //Kiểm tra toàn bộ controls đã được fill
            if (string.IsNullOrEmpty(cboxPersonOnDuty.Text))
            {
                MessageBox.Show("Vui lòng chọn cán bộ trực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(cboxShift.Text))
            {
                MessageBox.Show("Vui lòng chọn ca trực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvSoLuotRaVao.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm số lượt ra vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(rTbxShiftSituation.Text))
            {
                MessageBox.Show("Vui lòng nhập tình hình ca trực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(rtboxDevice.Text))
            {
                MessageBox.Show("Vui lòng nhập tình hình trang thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(rtboxInfrastructure.Text))
            {
                MessageBox.Show("Vui lòng nhập tình hình sự cố hạ tầng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(rtboxOtherWork.Text))
            {
                MessageBox.Show("Vui lòng nhập công việc khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnLoadCheckListGSMT_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                // Set the initial directory to the device desktop
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToGrid(ofd.FileName, "GSMT", dgvGSMT);
                    LoadDataToGrid(ofd.FileName, "DHCX", dgvDHCX);
                    LoadDataToGrid(ofd.FileName, "MSB", dgvMSB);
                    LoadDataToGrid(ofd.FileName, "UPS", dgvUPS);
                    LoadDataToGrid(ofd.FileName, "PDU", dgvPDU);
                }
            }
        }

        private void LoadDataToGrid(string csvPath, string prefix, DataGridView gridView)
        {
            var reader = new StreamReader(csvPath);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<SensorReadingMap>();
            var records = csv.GetRecords<SensorReading>()
                             .Where(r => r.TenThietBi.StartsWith(prefix))
                             .ToList();

            var grouped = records.GroupBy(x => x.TenThietBi).Select(g => ProcessDeviceData(g, prefix)).ToList();

            var dt = new DataTable();
            dt.Columns.Add("Thiết bị");

            foreach (var column in grouped.FirstOrDefault()?.Keys.ToList() ?? new List<string>())
            {
                if (column != "Thiết bị") dt.Columns.Add(column);
            }

            foreach (var item in grouped)
            {
                dt.Rows.Add(item.Values.ToArray());
            }

            gridView.DataSource = dt;
            gridView.Sort(gridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            //Release csv file
            reader.Close();
        }

        private Dictionary<string, object> ProcessDeviceData(IGrouping<string, SensorReading> group, string prefix)
        {
            var deviceData = new Dictionary<string, object> { { "Thiết bị", group.Key } };

            // Apply prefix-specific conditions
            switch (prefix)
            {
                case "GSMT":
                    deviceData["Nhiệt độ"] = GetConditionResult(group, "NhietDo", 17, 27);
                    deviceData["Độ ẩm"] = GetConditionResult(group, "DoAm", 40, 60);
                    break;

                case "DHCX":
                    deviceData["Nhiệt độ đường cấp"] = group.FirstOrDefault(x => x.Loai == "Supply")?.GiaTri.ToString() ?? "N/A";
                    deviceData["Nhiệt độ đường hồi"] = group.FirstOrDefault(x => x.Loai == "Return")?.GiaTri.ToString() ?? "N/A";
                    deviceData["Chênh lệch nhiệt độ"] = group.FirstOrDefault(x => x.Loai == "Delta-T")?.GiaTri.ToString() ?? "N/A";
                    break;

                case "MSB":
                    deviceData["ULL-1"] = GetConditionResult(group, "ULL-1", 370, 415);
                    deviceData["ULL-2"] = GetConditionResult(group, "ULL-2", 370, 415);
                    deviceData["ULL-3"] = GetConditionResult(group, "ULL-3", 370, 415);
                    deviceData["ULN-1"] = GetConditionResult(group, "ULN-1", 210, 240);
                    deviceData["ULN-2"] = GetConditionResult(group, "ULN-2", 210, 240);
                    deviceData["ULN-3"] = GetConditionResult(group, "ULN-3", 210, 240);
                    break;

                case "UPS":
                    deviceData["ULN-I"] = GetConditionResult(group, "ULN-IN", 210, 240);
                    deviceData["ULN-O"] = GetConditionResult(group, "ULN-OUT", 230, 230);
                    deviceData["Tần số"] = group.FirstOrDefault(x => x.Loai.Contains("Frequency"))?.GiaTri.ToString() ?? "N/A";
                    break;

                case "PDU":
                    deviceData["Kết quả kiểm tra điện áp"] = GetConditionResult(group, "U", 230, 240);
                    break;
            }
            return deviceData;
        }

        private string GetConditionResult(IGrouping<string, SensorReading> group, string loai, double min, double max)
        {
            var value = group.FirstOrDefault(x => x.Loai.Contains(loai))?.GiaTri;
            return value is double val && val >= min && val <= max ? "OK" : value?.ToString() ?? "N/A";
        }

        private string AccessCount()
        {
            //Lấy danh sách số lượt ra vào
            StringBuilder accessCount = new StringBuilder();
            foreach (DataGridViewRow row in dgvSoLuotRaVao.Rows)
            {
                if (row.IsNewRow) continue;
                string count = row.Cells[0].Value?.ToString();
                string unit = row.Cells[1].Value?.ToString();
                string description = row.Cells[2].Value?.ToString();
                if (string.IsNullOrEmpty(count) || string.IsNullOrEmpty(unit) || string.IsNullOrEmpty(description)) continue;
                accessCount.AppendLine($"{count} lượt cán bộ {unit}: {description}");
            }
            return accessCount.ToString();
        }

        private string PDUReport()
        {
            StringBuilder pDUReport = new StringBuilder();
            foreach (DataGridViewRow row in dgvPDU.Rows)
            {
                var i = 1;
                if (row.IsNewRow) continue;
                string thietBi = row.Cells[0].Value?.ToString();
                string ketQua = row.Cells[1].Value?.ToString();
                if (i == 3)
                {
                    pDUReport.Append("\n");
                }
                pDUReport.Append($"{thietBi}: {ketQua}; ");
                i++;
            }
            return pDUReport.ToString();
        }

        private void ExportTableToBookmark(Word.Document doc, string bookmarkName, DataGridView dgv, bool boldNonOK = false, int? fontSize = null)
        {
            if (!doc.Bookmarks.Exists(bookmarkName))
            {
                MessageBox.Show($"❌ Không tìm thấy Bookmark '{bookmarkName}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Word.Range range = doc.Bookmarks[bookmarkName].Range;
            Word.Table table = doc.Tables.Add(range, dgv.Rows.Count + 1, dgv.Columns.Count);
            table.Borders.Enable = 1;
            if (fontSize.HasValue) table.Range.Font.Size = fontSize.Value;

            // Headers
            for (int col = 0; col < dgv.Columns.Count; col++)
            {
                var cell = table.Cell(1, col + 1).Range;
                cell.Text = dgv.Columns[col].HeaderText;
                cell.Bold = 1;
                cell.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }

            // Data
            for (int row = 0; row < dgv.Rows.Count; row++)
            {
                for (int col = 0; col < dgv.Columns.Count; col++)
                {
                    string cellValue = dgv.Rows[row].Cells[col].Value?.ToString() ?? string.Empty;
                    var cell = table.Cell(row + 2, col + 1).Range;
                    cell.Text = cellValue.Trim('"');
                    cell.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    if (boldNonOK)
                    {
                        cell.Bold = (cellValue != "OK") ? 1 : 0;
                    }
                }
            }
        }

        private void ExportJsonToBookmark(Word.Document doc, string bookmarkName)
        {
            string json = File.ReadAllText(jsonPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine("❌ JSON input rỗng hoặc không hợp lệ.");
                return;
            }

            List<Device> devices;
            try
            {
                devices = JsonSerializer.Deserialize<List<Device>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi đọc JSON: {ex.Message}");
                return;
            }

            if (devices == null || devices.Count == 0)
            {
                MessageBox.Show("❌ Không có thiết bị nào trong dữ liệu JSON.");
                return;
            }

            var grouped = devices
                .GroupBy(d => new { d.Location.Region, d.Location.Rack })
                .OrderBy(g => g.Key.Region)
                .ThenBy(g => g.Key.Rack)
                .ToList();

            if (!doc.Bookmarks.Exists(bookmarkName))
            {
                MessageBox.Show($"❌ Bookmark '{bookmarkName}' không tồn tại trong file template.");
                doc.Close(false);
                return;
            }

            Word.Range bookmarkRange = doc.Bookmarks[bookmarkName].Range;
            int rowCount = grouped.Count + 1;
            int colCount = 4; // Không còn STT, chỉ còn 4 cột

            Word.Table table = doc.Tables.Add(bookmarkRange, rowCount, colCount);
            table.Borders.Enable = 1;
            table.Range.Font.Name = "Times New Roman";
            table.Range.Font.Size = 12;
            table.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            // Độ rộng từng cột
            table.Columns[1].Width = 0.81f * 72;  // Khu vực
            table.Columns[2].Width = 0.69f * 72;  // Rack
            table.Columns[3].Width = 3.44f * 72;   // Thiết bị và lỗi
            table.Columns[4].Width = 1.84f * 72;  // Ghi chú

            // Header
            table.Cell(1, 1).Range.Text = "Khu vực";
            table.Cell(1, 2).Range.Text = "Rack";
            table.Cell(1, 3).Range.Text = "Thiết bị và lỗi";
            table.Cell(1, 4).Range.Text = "Ghi chú";
            table.Rows[1].Range.Bold = 1;

            int row = 2;

            foreach (var group in grouped)
            {
                var deviceList = group
                    .Select(d => $"- {d.Name}: {string.Join(", ", d.Issue?.IssueList ?? new List<string>())}");

                var notes = group
                    .Where(d => !string.IsNullOrWhiteSpace(d.Note))
                    .Select(d => d.Note.Trim());

                table.Cell(row, 1).Range.Text = group.Key.Region;
                table.Cell(row, 2).Range.Text = group.Key.Rack;
                table.Cell(row, 3).Range.Text = string.Join(Environment.NewLine, deviceList);
                table.Cell(row, 4).Range.Text = string.Join(Environment.NewLine, notes);

                // Căn trái nội dung text
                table.Cell(row, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                table.Cell(row, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

                row++;
            }

            // Merge Khu vực và Rack
            int rowStart = 2;
            while (rowStart <= table.Rows.Count)
            {
                string region = table.Cell(rowStart, 1).Range.Text.TrimEnd('\r', '\a');
                int rowEnd = rowStart;

                while (rowEnd + 1 <= table.Rows.Count &&
                       table.Cell(rowEnd + 1, 1).Range.Text.TrimEnd('\r', '\a') == region)
                {
                    rowEnd++;
                }

                // Clear and merge Region
                for (int r = rowStart + 1; r <= rowEnd; r++)
                    table.Cell(r, 1).Range.Text = "";

                if (rowEnd > rowStart)
                {
                    table.Cell(rowStart, 1).Merge(table.Cell(rowEnd, 1));
                    Word.Range mergedRegion = table.Cell(rowStart, 1).Range;
                    mergedRegion.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    mergedRegion.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                }

                // Merge Rack trong Region
                int rackStart = rowStart;
                while (rackStart <= rowEnd)
                {
                    string rack = table.Cell(rackStart, 2).Range.Text.TrimEnd('\r', '\a');
                    int rackEnd = rackStart;

                    while (rackEnd + 1 <= rowEnd &&
                           table.Cell(rackEnd + 1, 2).Range.Text.TrimEnd('\r', '\a') == rack)
                    {
                        rackEnd++;
                    }

                    for (int r = rackStart + 1; r <= rackEnd; r++)
                        table.Cell(r, 2).Range.Text = "";

                    if (rackEnd > rackStart)
                    {
                        table.Cell(rackStart, 2).Merge(table.Cell(rackEnd, 2));
                        Word.Range mergedRack = table.Cell(rackStart, 2).Range;
                        mergedRack.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        mergedRack.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    }

                    rackStart = rackEnd + 1;
                }

                rowStart = rowEnd + 1;
            }
        }




        private void btnAddGtelChecklist_Click(object sender, EventArgs e)
        {
            //Nếu nUDCountGTEL.Value <= 0 thì không thêm vào dgvSoLuotRaVao
            if (nUDCountGTEL.Value <= 0) return;
            dgvSoLuotRaVao.Rows.Add(nUDCountGTEL.Value, "GTEL", "kiểm tra điện, điều hòa chính xác, giám sát môi trường, thiết bị công nghệ thông tin");
        }

        private void tsmiOpenFolder_Click(object sender, EventArgs e)
        {
            var savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileExport");
            Process.Start("explorer.exe", $"/open,\"{savePath}\"");
        }

        private void tsmiCreateReport_Click(object sender, EventArgs e)
        {
            if (!checkMissingFormInput()) return;

            using (var progressDialog = new ProgressDialog())
            {
                progressDialog.Show();
                progressDialog.UpdateProgress(0, "Đang chuẩn bị file...");
                var folder = CreateDateFolderTree(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileExport"));
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GiaoBanTrucNOC.docx");
                var savePath = Path.Combine(folder, $"{dTPicker.Value:dd.MM.yyyy} - Ca {cboxShift.SelectedIndex + 1} - {cboxPersonOnDuty.Text}.docx");
                var wordApp = new Word.Application();
                //Kiểm tra xem file mẫu có đang mở không, nếu có thì thông báo và không mở lại
                if (File.Exists(savePath) && File.GetAttributes(savePath).HasFlag(FileAttributes.ReadOnly))
                {
                    MessageBox.Show("File mẫu đang được mở hoặc không thể ghi đè. Vui lòng đóng file và thử lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var doc = wordApp.Documents.Open(filePath);
                try
                { 
                    progressDialog.UpdateProgress(10, "Đang xuất dữ liệu ca trực...");
                    var data = new Dictionary<string, string>
                    {
                        { "CaTruc", cboxShift.Text },
                        { "FromTime", lblTimeFrom.Text },
                        { "ToTime", lblTimeTo.Text },
                        { "CanBoTruc", cboxPersonOnDuty.Text },
                        { "SoLuotRaVao", AccessCount().Trim() },
                        { "TinhHinhCaTruc", rTbxShiftSituation.Text },
                        { "TrangThietBiGiayTo", rtboxDevice.Text },
                        { "SuCoVoTram", rtboxInfrastructure.Text },
                        { "CongViecKhac", rtboxOtherWork.Text },
                        { "PDU", PDUReport().Trim() },
                        { "KyTenCanBoTruc", cboxPersonOnDuty.Text },
                        { "KyTenCanBoCaSau", cboxNextShift.Text }
                    };
                    progressDialog.UpdateProgress(40, "Đang xuất dữ liệu sự cố thiết bị...");
                    ExportJsonToBookmark(doc, "SuCoKyThuat");
                    progressDialog.UpdateProgress(50, "Đang xuất dữ liệu giám sát môi trường...");
                    if (doc.Bookmarks.Exists("GSMT"))
                    {
                        ExportTableToBookmark(doc, "GSMT", dgvGSMT, true, 12);
                    }
                    progressDialog.UpdateProgress(60, "Đang xuất dữ liệu Điều hòa chính xác...");
                    if (doc.Bookmarks.Exists("DHCX"))
                    {
                        ExportTableToBookmark(doc, "DHCX", dgvDHCX, true, 12);
                    }
                    progressDialog.UpdateProgress(70, "Đang xuất dữ liệu MSB...");
                    if (doc.Bookmarks.Exists("MSB"))
                    {
                        ExportTableToBookmark(doc, "MSB", dgvMSB, true, 12);
                    }
                    progressDialog.UpdateProgress(80, "Đang xuất dữ liệu UPS...");
                    if (doc.Bookmarks.Exists("UPS"))
                    {
                        ExportTableToBookmark(doc, "UPS", dgvUPS, true, 12);
                    }
                    progressDialog.UpdateProgress(90, "Đang gắn lại Bookmarks...");
                    foreach (var kvp in data)
                    {
                        if (doc.Bookmarks.Exists(kvp.Key))
                        {
                            Word.Range range = doc.Bookmarks[kvp.Key].Range;
                            range.Text = kvp.Value;
                            doc.Bookmarks.Add(kvp.Key, range); // Re-add to preserve bookmark
                        }
                    }
                    progressDialog.UpdateProgress(95, "Đang lưu file...");
                    doc.SaveAs2(savePath);
                    //Lưu tbxInfraStructure vào file txt
                    using (StreamWriter sw = new StreamWriter(".\\DanhSach\\SuCoHT.txt", false, Encoding.UTF8))
                    {
                        sw.Write(rtboxInfrastructure.Text);
                    }
                    MessageBox.Show("✅ Đã xuất file thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (File.Exists(savePath))
                        Process.Start("explorer.exe", $"/open,\"{savePath}\"");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    doc.Close(false);
                    wordApp.Quit();
                    Marshal.ReleaseComObject(doc);
                    Marshal.ReleaseComObject(wordApp);
                    progressDialog.UpdateProgress(100, "Completed!");
                    progressDialog.Close();
                }
            }
        }

        private void cboxPersonOnDuty_Enter(object sender, EventArgs e)
        {
            cboxPersonOnDuty.DroppedDown = true;
        }

        private void cboxNextShift_Enter(object sender, EventArgs e)
        {
            cboxNextShift.DroppedDown = true;
        }

        private void cboxShift_Enter(object sender, EventArgs e)
        {
            cboxShift.DroppedDown = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {

            //Nếu chưa có file devices.json thì tạo mới file, thêm 01 device có các trường trống vào file
            if (!File.Exists(jsonPath))
            {
                var device = new Device(Guid.NewGuid(), new Device.DeviceLocation { Region = "DCQG", Rack = "01" }, "Thiết bị 01", new Device.DeviceIssue() , string.Empty);
                deviceList.Add(device);
                var json = JsonSerializer.Serialize(deviceList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonPath, json);
            }
            else
            {
                LoadJsonToDeviceList();
                dgvIssueDCQG.DataSource = dcqgList;
                dgvIssueNVNN.DataSource = nvnnList;
                dgvIssueCCCD.DataSource = cccdList;
                dgvIssueDDDT.DataSource = dddtList;
            }
            //Load SuCoHT gần nhất từ file txt vào rtboxInfrastructure
            if (File.Exists(".\\DanhSach\\SuCoHT.txt"))
            {
                using (StreamReader sr = new StreamReader(".\\DanhSach\\SuCoHT.txt", Encoding.UTF8))
                {
                    rtboxInfrastructure.Text = sr.ReadToEnd();
                }
            }
            //Load file từ desktop vào các DataGridView
            string checkListPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Sensor Summary Data.csv";
            LoadDataToGrid(checkListPath, "GSMT", dgvGSMT);
            LoadDataToGrid(checkListPath, "DHCX", dgvDHCX);
            LoadDataToGrid(checkListPath, "MSB", dgvMSB);
            LoadDataToGrid(checkListPath, "UPS", dgvUPS);
            LoadDataToGrid(checkListPath, "PDU", dgvPDU);
        }

        private string CreateDateFolderTree(string location)
        {
            string yearFolder = Path.Combine(location, dTPicker.Value.Year.ToString());
            string monthFolder = Path.Combine(yearFolder, "Tháng " + dTPicker.Value.Month.ToString("00"));
            string dayFolder = Path.Combine(monthFolder, dTPicker.Value.Day.ToString("00"));
            if (!Directory.Exists(yearFolder))
            {
                Directory.CreateDirectory(yearFolder);
            }
            if (!Directory.Exists(monthFolder))
            {
                Directory.CreateDirectory(monthFolder);
            }
            if (!Directory.Exists(dayFolder))
            {
                Directory.CreateDirectory(dayFolder);
            }
            return dayFolder;
        }

        private void ExportDeviceIssueListToJson()
        {
            //Nhóm 4 BindingList lại thành 1 list và lưu vào file json
            var allDevices = new List<Device>();
            allDevices.AddRange(dcqgList.ToList());
            allDevices.AddRange(nvnnList.ToList());
            allDevices.AddRange(cccdList.ToList());
            allDevices.AddRange(dddtList.ToList());
            var json = JsonSerializer.Serialize(allDevices, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonPath, json);
        }

        private void LoadJsonToDeviceList()
        {
            //Lấy danh sách thiết bị từ file json và thêm vào các BindingList tương ứng
            deviceList = LoadDeviceList(jsonPath);
            //ClearBindingLists
            dcqgList.Clear();
            nvnnList.Clear();
            cccdList.Clear();
            dddtList.Clear();
            foreach (var device in deviceList)
            {
                switch (device.Location.Region)
                {
                    case "DCQG":
                        dcqgList.Add(device);
                        break;
                    case "NVNN":
                        nvnnList.Add(device);
                        break;
                    case "CCCD":
                        cccdList.Add(device);
                        break;
                    case "DDDT":
                        dddtList.Add(device);
                        break;
                }
            }
        }

        private void dgvIssueDCQG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dgv = sender as DataGridView;
                if (dgv.Rows[e.RowIndex].DataBoundItem is Device device)
                {
                    using (var editForm = new EditIssue(device))
                    {
                        editForm.OnDeleteDevice += (deletedDevice) =>
                        {
                            dcqgList.Remove(deletedDevice);
                            ExportDeviceIssueListToJson();
                        };
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            //Lấy _device từ editForm
                            var updatedDevice = editForm._device;
                            //Cập nhật lại danh sách thiết bị
                            var index = dcqgList.IndexOf(device);
                            if (index >= 0)
                            {
                                dcqgList[index] = updatedDevice;
                                ExportDeviceIssueListToJson();
                            }
                            else
                            {
                                dcqgList.Add(updatedDevice);
                                ExportDeviceIssueListToJson();
                            }
                            dgv.Refresh();
                        }
                    }
                }
            }
        }

        private void dgvIssueCCCD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dgv = sender as DataGridView;
                if (dgv.Rows[e.RowIndex].DataBoundItem is Device device)
                {
                    using (var editForm = new EditIssue(device))
                    {
                        editForm.OnDeleteDevice += (deletedDevice) =>
                        {
                            cccdList.Remove(deletedDevice);
                            ExportDeviceIssueListToJson();
                        };
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            //Lấy _device từ editForm
                            var updatedDevice = editForm._device;
                            //Cập nhật lại danh sách thiết bị
                            var index = cccdList.IndexOf(device);
                            if (index >= 0)
                            {
                                cccdList[index] = updatedDevice;
                                ExportDeviceIssueListToJson();
                            }
                            else
                            {
                                cccdList.Add(updatedDevice);
                                ExportDeviceIssueListToJson();
                            }
                            dgv.Refresh();
                        }
                    }
                }
            }
        }

        private void dgvIssueDDDT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dgv = sender as DataGridView;
                if (dgv.Rows[e.RowIndex].DataBoundItem is Device device)
                {
                    using (var editForm = new EditIssue(device))
                    {
                        editForm.OnDeleteDevice += (deletedDevice) =>
                        {
                            dddtList.Remove(deletedDevice);
                            ExportDeviceIssueListToJson();
                        };
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            //Lấy _device từ editForm
                            var updatedDevice = editForm._device;
                            //Cập nhật lại danh sách thiết bị
                            var index = dddtList.IndexOf(device);
                            if (index >= 0)
                            {
                                dddtList[index] = updatedDevice;
                                ExportDeviceIssueListToJson();
                            }
                            else
                            {
                                dddtList.Add(updatedDevice);
                                ExportDeviceIssueListToJson();
                            }
                            dgv.Refresh();
                        }
                    }
                }
            }
        }

        private void dgvIssueNVNN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dgv = sender as DataGridView;
                if (dgv.Rows[e.RowIndex].DataBoundItem is Device device)
                {
                    using (var editForm = new EditIssue(device))
                    {
                        editForm.OnDeleteDevice += (deletedDevice) =>
                        {
                            nvnnList.Remove(deletedDevice);
                            ExportDeviceIssueListToJson();
                        };
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            //Lấy _device từ editForm
                            var updatedDevice = editForm._device;
                            //Cập nhật lại danh sách thiết bị
                            var index = nvnnList.IndexOf(device);
                            if (index >= 0)
                            {
                                nvnnList[index] = updatedDevice;
                                ExportDeviceIssueListToJson();
                            }
                            else
                            {
                                nvnnList.Add(updatedDevice);
                                ExportDeviceIssueListToJson();
                            }
                            dgv.Refresh();
                        }
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Xác nhận đóng ứng dụng
            var confirmResult = MessageBox.Show("Bạn có chắc muốn đóng ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                // Lưu danh sách thiết bị vào file json trước khi đóng
                ExportDeviceIssueListToJson();
                Application.Exit(); // Hoặc Close() nếu bạn muốn đóng form hiện tại
            }
        }
    }
}