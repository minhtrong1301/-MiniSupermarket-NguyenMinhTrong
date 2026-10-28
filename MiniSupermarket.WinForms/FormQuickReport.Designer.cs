
namespace MiniSupermarket.WinForms
{
    partial class FormQuickReport
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblDateSelect;
        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Button btnRunReport;

        private System.Windows.Forms.Panel panelCard1;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Label lblTotalOrders;

        private System.Windows.Forms.Panel panelCard2;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Label lblTotalRevenue;

        private System.Windows.Forms.Panel panelCard3;
        private System.Windows.Forms.Label lblCard3Title;
        private System.Windows.Forms.Label lblBestSeller;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblDateSelect = new System.Windows.Forms.Label();
            dtpReportDate = new System.Windows.Forms.DateTimePicker();
            btnRunReport = new System.Windows.Forms.Button();

            panelCard1 = new System.Windows.Forms.Panel();
            lblCard1Title = new System.Windows.Forms.Label();
            lblTotalOrders = new System.Windows.Forms.Label();

            panelCard2 = new System.Windows.Forms.Panel();
            lblCard2Title = new System.Windows.Forms.Label();
            lblTotalRevenue = new System.Windows.Forms.Label();

            panelCard3 = new System.Windows.Forms.Panel();
            lblCard3Title = new System.Windows.Forms.Label();
            lblBestSeller = new System.Windows.Forms.Label();

            panelCard1.SuspendLayout();
            panelCard2.SuspendLayout();
            panelCard3.SuspendLayout();
            SuspendLayout();

            // 
            // lblDateSelect
            // 
            lblDateSelect.AutoSize = true;
            lblDateSelect.Location = new System.Drawing.Point(30, 125);
            lblDateSelect.Name = "lblDateSelect";
            lblDateSelect.Size = new System.Drawing.Size(100, 23);
            lblDateSelect.TabIndex = 0;
            lblDateSelect.Text = "Ngày báo cáo";

            // 
            // dtpReportDate
            // 
            dtpReportDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;
            dtpReportDate.Location = new System.Drawing.Point(145, 118);
            dtpReportDate.Name = "dtpReportDate";
            dtpReportDate.Size = new System.Drawing.Size(160, 30);
            dtpReportDate.TabIndex = 1;

            // 
            // btnRunReport
            // 
            btnRunReport.BackColor =
                System.Drawing.Color.FromArgb(37, 99, 235);
            btnRunReport.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            btnRunReport.ForeColor = System.Drawing.Color.White;
            btnRunReport.Location = new System.Drawing.Point(325, 115);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new System.Drawing.Size(165, 38);
            btnRunReport.TabIndex = 2;
            btnRunReport.Text = "Làm mới báo cáo";
            btnRunReport.UseVisualStyleBackColor = false;
            btnRunReport.Click += btnRunReport_Click;

            // 
            // panelCard1
            // 
            panelCard1.BackColor = System.Drawing.Color.White;
            panelCard1.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            panelCard1.Controls.Add(lblCard1Title);
            panelCard1.Controls.Add(lblTotalOrders);
            panelCard1.Location = new System.Drawing.Point(30, 185);
            panelCard1.Name = "panelCard1";
            panelCard1.Size = new System.Drawing.Size(280, 155);
            panelCard1.TabIndex = 3;

            // 
            // lblCard1Title
            // 
            lblCard1Title.AutoSize = false;
            lblCard1Title.Location = new System.Drawing.Point(20, 20);
            lblCard1Title.Name = "lblCard1Title";
            lblCard1Title.Size = new System.Drawing.Size(240, 30);
            lblCard1Title.TabIndex = 0;
            lblCard1Title.Text = "TỔNG SỐ HÓA ĐƠN";
            lblCard1Title.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = false;
            lblTotalOrders.Location = new System.Drawing.Point(20, 62);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new System.Drawing.Size(240, 65);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "0";
            lblTotalOrders.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // panelCard2
            // 
            panelCard2.BackColor = System.Drawing.Color.White;
            panelCard2.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            panelCard2.Controls.Add(lblCard2Title);
            panelCard2.Controls.Add(lblTotalRevenue);
            panelCard2.Location = new System.Drawing.Point(340, 185);
            panelCard2.Name = "panelCard2";
            panelCard2.Size = new System.Drawing.Size(280, 155);
            panelCard2.TabIndex = 4;

            // 
            // lblCard2Title
            // 
            lblCard2Title.AutoSize = false;
            lblCard2Title.Location = new System.Drawing.Point(20, 20);
            lblCard2Title.Name = "lblCard2Title";
            lblCard2Title.Size = new System.Drawing.Size(240, 30);
            lblCard2Title.TabIndex = 0;
            lblCard2Title.Text = "TỔNG DOANH THU";
            lblCard2Title.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = false;
            lblTotalRevenue.Location = new System.Drawing.Point(20, 62);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new System.Drawing.Size(240, 65);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "0 VNĐ";
            lblTotalRevenue.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // panelCard3
            // 
            panelCard3.BackColor = System.Drawing.Color.White;
            panelCard3.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            panelCard3.Controls.Add(lblCard3Title);
            panelCard3.Controls.Add(lblBestSeller);
            panelCard3.Location = new System.Drawing.Point(650, 185);
            panelCard3.Name = "panelCard3";
            panelCard3.Size = new System.Drawing.Size(280, 155);
            panelCard3.TabIndex = 5;

            // 
            // lblCard3Title
            // 
            lblCard3Title.AutoSize = false;
            lblCard3Title.Location = new System.Drawing.Point(20, 20);
            lblCard3Title.Name = "lblCard3Title";
            lblCard3Title.Size = new System.Drawing.Size(240, 30);
            lblCard3Title.TabIndex = 0;
            lblCard3Title.Text = "MẶT HÀNG BÁN CHẠY NHẤT";
            lblCard3Title.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lblBestSeller
            // 
            lblBestSeller.AutoSize = false;
            lblBestSeller.Location = new System.Drawing.Point(20, 62);
            lblBestSeller.Name = "lblBestSeller";
            lblBestSeller.Size = new System.Drawing.Size(240, 65);
            lblBestSeller.TabIndex = 1;
            lblBestSeller.Text = "Chưa có dữ liệu";
            lblBestSeller.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // FormQuickReport
            // 
            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(980, 600);
            Controls.Add(panelCard3);
            Controls.Add(panelCard2);
            Controls.Add(panelCard1);
            Controls.Add(btnRunReport);
            Controls.Add(dtpReportDate);
            Controls.Add(lblDateSelect);
            Name = "FormQuickReport";
            Text = "Báo cáo doanh thu";
            Load += FormQuickReport_Load;

            panelCard1.ResumeLayout(false);
            panelCard2.ResumeLayout(false);
            panelCard3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
