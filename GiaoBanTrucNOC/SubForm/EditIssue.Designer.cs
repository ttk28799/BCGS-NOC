namespace GiaoBanTrucNOC.SubForm
{
    partial class EditIssue
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
            this.btnAddIssueType = new System.Windows.Forms.Button();
            this.tboxSearchIssue = new System.Windows.Forms.TextBox();
            this.clstboxIssue = new System.Windows.Forms.CheckedListBox();
            this.rtboxNote = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddIssueType
            // 
            this.btnAddIssueType.Location = new System.Drawing.Point(209, 72);
            this.btnAddIssueType.Name = "btnAddIssueType";
            this.btnAddIssueType.Size = new System.Drawing.Size(33, 23);
            this.btnAddIssueType.TabIndex = 57;
            this.btnAddIssueType.Text = "+";
            this.btnAddIssueType.UseVisualStyleBackColor = true;
            this.btnAddIssueType.Click += new System.EventHandler(this.btnAddIssueType_Click);
            // 
            // tboxSearchIssue
            // 
            this.tboxSearchIssue.Location = new System.Drawing.Point(12, 72);
            this.tboxSearchIssue.Name = "tboxSearchIssue";
            this.tboxSearchIssue.Size = new System.Drawing.Size(191, 20);
            this.tboxSearchIssue.TabIndex = 56;
            // 
            // clstboxIssue
            // 
            this.clstboxIssue.CheckOnClick = true;
            this.clstboxIssue.FormattingEnabled = true;
            this.clstboxIssue.Location = new System.Drawing.Point(12, 104);
            this.clstboxIssue.Name = "clstboxIssue";
            this.clstboxIssue.Size = new System.Drawing.Size(230, 184);
            this.clstboxIssue.TabIndex = 55;
            // 
            // rtboxNote
            // 
            this.rtboxNote.Location = new System.Drawing.Point(248, 72);
            this.rtboxNote.Name = "rtboxNote";
            this.rtboxNote.Size = new System.Drawing.Size(159, 216);
            this.rtboxNote.TabIndex = 53;
            this.rtboxNote.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Ghi chú:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(332, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(248, 294);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Nội dung lỗi:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 294);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 23);
            this.btnDelete.TabIndex = 58;
            this.btnDelete.Text = "Xóa thiết bị này";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeviceName.Location = new System.Drawing.Point(0, 0);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(35, 13);
            this.lblDeviceName.TabIndex = 59;
            this.lblDeviceName.Text = "label1";
            this.lblDeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDeviceName);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 38);
            this.panel1.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(12, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Nếu lỗi đã được khắc phục, chỉ uncheck lỗi, không xóa thiết bị";
            // 
            // EditIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 340);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddIssueType);
            this.Controls.Add(this.tboxSearchIssue);
            this.Controls.Add(this.clstboxIssue);
            this.Controls.Add(this.rtboxNote);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Name = "EditIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa thông tin sự cố";
            this.Load += new System.EventHandler(this.EditIssue_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddIssueType;
        private System.Windows.Forms.TextBox tboxSearchIssue;
        private System.Windows.Forms.CheckedListBox clstboxIssue;
        private System.Windows.Forms.RichTextBox rtboxNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}