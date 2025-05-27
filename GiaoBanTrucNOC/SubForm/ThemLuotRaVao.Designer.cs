namespace GiaoBanTrucNOC.SubForm
{
    partial class ThemLuotRaVao
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxUnit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtboxDescription = new System.Windows.Forms.RichTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxExample = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lượt:";
            // 
            // tbxCount
            // 
            this.tbxCount.Location = new System.Drawing.Point(61, 6);
            this.tbxCount.Name = "tbxCount";
            this.tbxCount.Size = new System.Drawing.Size(96, 22);
            this.tbxCount.TabIndex = 1;
            this.tbxCount.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đơn vị:";
            // 
            // cboxUnit
            // 
            this.cboxUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxUnit.FormattingEnabled = true;
            this.cboxUnit.Items.AddRange(new object[] {
            "C06",
            "GTEL",
            "Teca",
            "VNPT",
            "Khách"});
            this.cboxUnit.Location = new System.Drawing.Point(61, 31);
            this.cboxUnit.Name = "cboxUnit";
            this.cboxUnit.Size = new System.Drawing.Size(96, 21);
            this.cboxUnit.TabIndex = 2;
            this.cboxUnit.Enter += new System.EventHandler(this.cboxUnit_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nội dung công việc:";
            // 
            // rtboxDescription
            // 
            this.rtboxDescription.Location = new System.Drawing.Point(15, 105);
            this.rtboxDescription.Name = "rtboxDescription";
            this.rtboxDescription.Size = new System.Drawing.Size(361, 67);
            this.rtboxDescription.TabIndex = 4;
            this.rtboxDescription.Text = "";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(220, 178);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(301, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mẫu:";
            // 
            // cboxExample
            // 
            this.cboxExample.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboxExample.FormattingEnabled = true;
            this.cboxExample.ItemHeight = 13;
            this.cboxExample.Items.AddRange(new object[] {
            "Đo điện, ĐHCX, giám sát môi trường, kiểm tra thiết bị công nghệ thông tin"});
            this.cboxExample.Location = new System.Drawing.Point(46, 78);
            this.cboxExample.Name = "cboxExample";
            this.cboxExample.Size = new System.Drawing.Size(325, 21);
            this.cboxExample.TabIndex = 3;
            this.cboxExample.SelectedIndexChanged += new System.EventHandler(this.cboxExample_SelectedIndexChanged);
            this.cboxExample.Enter += new System.EventHandler(this.cboxExample_Enter);
            // 
            // ThemLuotRaVao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 206);
            this.Controls.Add(this.cboxExample);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rtboxDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboxUnit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxCount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ThemLuotRaVao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm lượt ra vào";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtboxDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxExample;
    }
}