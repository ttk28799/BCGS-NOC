namespace GiaoBanTrucNOC.SubForm
{
    partial class ThemSuCoKyThuat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxRACK = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpBxRegion = new System.Windows.Forms.GroupBox();
            this.rdoDDDT = new System.Windows.Forms.RadioButton();
            this.rdoCCCD = new System.Windows.Forms.RadioButton();
            this.rdoNVNN = new System.Windows.Forms.RadioButton();
            this.rdoDCQG = new System.Windows.Forms.RadioButton();
            this.rtboxNote = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.clstboxIssue = new System.Windows.Forms.CheckedListBox();
            this.tboxSearchIssue = new System.Windows.Forms.TextBox();
            this.btnAddIssueType = new System.Windows.Forms.Button();
            this.tboxSearchDevice = new System.Windows.Forms.TextBox();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.lstBoxDevice = new System.Windows.Forms.ListBox();
            this.grpBxRegion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(473, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(392, 304);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Nội dung lỗi:";
            // 
            // cboxRACK
            // 
            this.cboxRACK.FormattingEnabled = true;
            this.cboxRACK.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08"});
            this.cboxRACK.Location = new System.Drawing.Point(57, 37);
            this.cboxRACK.Name = "cboxRACK";
            this.cboxRACK.Size = new System.Drawing.Size(40, 21);
            this.cboxRACK.TabIndex = 2;
            this.cboxRACK.SelectedIndexChanged += new System.EventHandler(this.cboxRACK_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "RACK:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Vùng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Tên thiết bị:";
            // 
            // grpBxRegion
            // 
            this.grpBxRegion.Controls.Add(this.rdoDDDT);
            this.grpBxRegion.Controls.Add(this.rdoCCCD);
            this.grpBxRegion.Controls.Add(this.rdoNVNN);
            this.grpBxRegion.Controls.Add(this.rdoDCQG);
            this.grpBxRegion.Location = new System.Drawing.Point(57, -2);
            this.grpBxRegion.Name = "grpBxRegion";
            this.grpBxRegion.Size = new System.Drawing.Size(241, 33);
            this.grpBxRegion.TabIndex = 34;
            this.grpBxRegion.TabStop = false;
            // 
            // rdoDDDT
            // 
            this.rdoDDDT.AutoSize = true;
            this.rdoDDDT.Location = new System.Drawing.Point(184, 9);
            this.rdoDDDT.Name = "rdoDDDT";
            this.rdoDDDT.Size = new System.Drawing.Size(56, 17);
            this.rdoDDDT.TabIndex = 3;
            this.rdoDDDT.TabStop = true;
            this.rdoDDDT.Text = "DDDT";
            this.rdoDDDT.UseVisualStyleBackColor = true;
            this.rdoDDDT.CheckedChanged += new System.EventHandler(this.rdoDDDT_CheckedChanged);
            // 
            // rdoCCCD
            // 
            this.rdoCCCD.AutoSize = true;
            this.rdoCCCD.Location = new System.Drawing.Point(125, 9);
            this.rdoCCCD.Name = "rdoCCCD";
            this.rdoCCCD.Size = new System.Drawing.Size(54, 17);
            this.rdoCCCD.TabIndex = 2;
            this.rdoCCCD.TabStop = true;
            this.rdoCCCD.Text = "CCCD";
            this.rdoCCCD.UseVisualStyleBackColor = true;
            this.rdoCCCD.CheckedChanged += new System.EventHandler(this.rdoCCCD_CheckedChanged);
            // 
            // rdoNVNN
            // 
            this.rdoNVNN.AutoSize = true;
            this.rdoNVNN.Location = new System.Drawing.Point(65, 9);
            this.rdoNVNN.Name = "rdoNVNN";
            this.rdoNVNN.Size = new System.Drawing.Size(56, 17);
            this.rdoNVNN.TabIndex = 1;
            this.rdoNVNN.TabStop = true;
            this.rdoNVNN.Text = "NVNN";
            this.rdoNVNN.UseVisualStyleBackColor = true;
            this.rdoNVNN.CheckedChanged += new System.EventHandler(this.rdoNVNN_CheckedChanged);
            // 
            // rdoDCQG
            // 
            this.rdoDCQG.AutoSize = true;
            this.rdoDCQG.Location = new System.Drawing.Point(6, 9);
            this.rdoDCQG.Name = "rdoDCQG";
            this.rdoDCQG.Size = new System.Drawing.Size(56, 17);
            this.rdoDCQG.TabIndex = 0;
            this.rdoDCQG.TabStop = true;
            this.rdoDCQG.Text = "DCQG";
            this.rdoDCQG.UseVisualStyleBackColor = true;
            this.rdoDCQG.CheckedChanged += new System.EventHandler(this.rdoDCQG_CheckedChanged);
            // 
            // rtboxNote
            // 
            this.rtboxNote.Location = new System.Drawing.Point(554, 82);
            this.rtboxNote.Name = "rtboxNote";
            this.rtboxNote.Size = new System.Drawing.Size(159, 216);
            this.rtboxNote.TabIndex = 35;
            this.rtboxNote.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(554, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Ghi chú:";
            // 
            // clstboxIssue
            // 
            this.clstboxIssue.CheckOnClick = true;
            this.clstboxIssue.FormattingEnabled = true;
            this.clstboxIssue.Location = new System.Drawing.Point(318, 114);
            this.clstboxIssue.Name = "clstboxIssue";
            this.clstboxIssue.Size = new System.Drawing.Size(230, 184);
            this.clstboxIssue.TabIndex = 37;
            this.clstboxIssue.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clstboxIssue_ItemCheck);
            // 
            // tboxSearchIssue
            // 
            this.tboxSearchIssue.Location = new System.Drawing.Point(318, 82);
            this.tboxSearchIssue.Name = "tboxSearchIssue";
            this.tboxSearchIssue.Size = new System.Drawing.Size(191, 20);
            this.tboxSearchIssue.TabIndex = 38;
            // 
            // btnAddIssueType
            // 
            this.btnAddIssueType.Location = new System.Drawing.Point(515, 82);
            this.btnAddIssueType.Name = "btnAddIssueType";
            this.btnAddIssueType.Size = new System.Drawing.Size(33, 23);
            this.btnAddIssueType.TabIndex = 39;
            this.btnAddIssueType.Text = "+";
            this.btnAddIssueType.UseVisualStyleBackColor = true;
            this.btnAddIssueType.Click += new System.EventHandler(this.btnAddIssueType_Click);
            // 
            // tboxSearchDevice
            // 
            this.tboxSearchDevice.Location = new System.Drawing.Point(15, 82);
            this.tboxSearchDevice.Name = "tboxSearchDevice";
            this.tboxSearchDevice.Size = new System.Drawing.Size(259, 20);
            this.tboxSearchDevice.TabIndex = 42;
            this.tboxSearchDevice.TextChanged += new System.EventHandler(this.tboxSearchDevice_TextChanged);
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(280, 82);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(33, 23);
            this.btnAddDevice.TabIndex = 43;
            this.btnAddDevice.Text = "+";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // lstBoxDevice
            // 
            this.lstBoxDevice.FormattingEnabled = true;
            this.lstBoxDevice.Location = new System.Drawing.Point(15, 112);
            this.lstBoxDevice.Name = "lstBoxDevice";
            this.lstBoxDevice.Size = new System.Drawing.Size(297, 186);
            this.lstBoxDevice.TabIndex = 44;
            this.lstBoxDevice.SelectedIndexChanged += new System.EventHandler(this.lstBoxDevice_SelectedIndexChanged);
            // 
            // ThemSuCoKyThuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 332);
            this.Controls.Add(this.lstBoxDevice);
            this.Controls.Add(this.btnAddDevice);
            this.Controls.Add(this.tboxSearchDevice);
            this.Controls.Add(this.btnAddIssueType);
            this.Controls.Add(this.tboxSearchIssue);
            this.Controls.Add(this.clstboxIssue);
            this.Controls.Add(this.rtboxNote);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grpBxRegion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboxRACK);
            this.Controls.Add(this.label2);
            this.Name = "ThemSuCoKyThuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm sự cố kỹ thuật";
            this.Load += new System.EventHandler(this.ThemSuCoKyThuat_Load);
            this.grpBxRegion.ResumeLayout(false);
            this.grpBxRegion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxRACK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpBxRegion;
        private System.Windows.Forms.RadioButton rdoNVNN;
        private System.Windows.Forms.RadioButton rdoDCQG;
        private System.Windows.Forms.RadioButton rdoDDDT;
        private System.Windows.Forms.RadioButton rdoCCCD;
        private System.Windows.Forms.RichTextBox rtboxNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox clstboxIssue;
        private System.Windows.Forms.TextBox tboxSearchIssue;
        private System.Windows.Forms.Button btnAddIssueType;
        private System.Windows.Forms.TextBox tboxSearchDevice;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.ListBox lstBoxDevice;
    }
}