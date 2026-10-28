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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblDateSelect = new Label();
            dtpReportDate = new DateTimePicker();
            btnRunReport = new Button();
            panelCard1 = new Panel();
            lblTotalOrders = new Label();
            lblCard1Title = new Label();
            panelCard2 = new Panel();
            lblTotalRevenue = new Label();
            lblCard2Title = new Label();
            panelCard3 = new Panel();
            lblBestSeller = new Label();
            lblCard3Title = new Label();
            panelCard1.SuspendLayout();
            panelCard2.SuspendLayout();
            panelCard3.SuspendLayout();
            SuspendLayout();
            // 
            // lblDateSelect
            // 
            lblDateSelect.AutoSize = true;
            lblDateSelect.Location = new Point(30, 25);
            lblDateSelect.Name = "lblDateSelect";
            lblDateSelect.Size = new Size(134, 23);
            lblDateSelect.TabIndex = 5;
            lblDateSelect.Text = "Chọn ngày xem:";
            // 
            // dtpReportDate
            // 
            dtpReportDate.Format = DateTimePickerFormat.Short;
            dtpReportDate.Location = new Point(160, 20);
            dtpReportDate.Name = "dtpReportDate";
            dtpReportDate.Size = new Size(150, 30);
            dtpReportDate.TabIndex = 4;
            // 
            // btnRunReport
            // 
            btnRunReport.BackColor = Color.FromArgb(0, 122, 204);
            btnRunReport.FlatStyle = FlatStyle.Flat;
            btnRunReport.ForeColor = Color.White;
            btnRunReport.Location = new Point(330, 18);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new Size(150, 35);
            btnRunReport.TabIndex = 3;
            btnRunReport.Text = "Xem báo cáo";
            btnRunReport.UseVisualStyleBackColor = false;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // panelCard1
            // 
            panelCard1.BackColor = Color.FromArgb(52, 152, 219);
            panelCard1.Controls.Add(lblTotalOrders);
            panelCard1.Controls.Add(lblCard1Title);
            panelCard1.Location = new Point(30, 80);
            panelCard1.Name = "panelCard1";
            panelCard1.Size = new Size(280, 130);
            panelCard1.TabIndex = 2;
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalOrders.ForeColor = Color.White;
            lblTotalOrders.Location = new Point(15, 50);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(43, 50);
            lblTotalOrders.TabIndex = 0;
            lblTotalOrders.Text = "0";
            // 
            // lblCard1Title
            // 
            lblCard1Title.AutoSize = true;
            lblCard1Title.ForeColor = Color.White;
            lblCard1Title.Location = new Point(15, 15);
            lblCard1Title.Name = "lblCard1Title";
            lblCard1Title.Size = new Size(168, 23);
            lblCard1Title.TabIndex = 1;
            lblCard1Title.Text = "TỔNG SỐ HÓA ĐƠN";
            // 
            // panelCard2
            // 
            panelCard2.BackColor = Color.FromArgb(46, 204, 113);
            panelCard2.Controls.Add(lblTotalRevenue);
            panelCard2.Controls.Add(lblCard2Title);
            panelCard2.Location = new Point(340, 80);
            panelCard2.Name = "panelCard2";
            panelCard2.Size = new Size(280, 130);
            panelCard2.TabIndex = 1;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalRevenue.ForeColor = Color.White;
            lblTotalRevenue.Location = new Point(15, 50);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(124, 46);
            lblTotalRevenue.TabIndex = 0;
            lblTotalRevenue.Text = "0 VNĐ";
            // 
            // lblCard2Title
            // 
            lblCard2Title.AutoSize = true;
            lblCard2Title.ForeColor = Color.White;
            lblCard2Title.Location = new Point(15, 15);
            lblCard2Title.Name = "lblCard2Title";
            lblCard2Title.Size = new Size(161, 23);
            lblCard2Title.TabIndex = 1;
            lblCard2Title.Text = "TỔNG DOANH THU";
            // 
            // panelCard3
            // 
            panelCard3.BackColor = Color.FromArgb(155, 89, 182);
            panelCard3.Controls.Add(lblBestSeller);
            panelCard3.Controls.Add(lblCard3Title);
            panelCard3.Location = new Point(650, 80);
            panelCard3.Name = "panelCard3";
            panelCard3.Size = new Size(280, 130);
            panelCard3.TabIndex = 0;
            // 
            // lblBestSeller
            // 
            lblBestSeller.AutoSize = true;
            lblBestSeller.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBestSeller.ForeColor = Color.White;
            lblBestSeller.Location = new Point(15, 50);
            lblBestSeller.Name = "lblBestSeller";
            lblBestSeller.Size = new Size(120, 37);
            lblBestSeller.TabIndex = 0;
            lblBestSeller.Text = "Chưa có";
            // 
            // lblCard3Title
            // 
            lblCard3Title.AutoSize = true;
            lblCard3Title.ForeColor = Color.White;
            lblCard3Title.Location = new Point(15, 15);
            lblCard3Title.Name = "lblCard3Title";
            lblCard3Title.Size = new Size(235, 23);
            lblCard3Title.TabIndex = 1;
            lblCard3Title.Text = "MẶT HÀNG BÁN CHẠY NHẤT";
            // 
            // FormQuickReport
            // 
            ClientSize = new Size(980, 600);
            Controls.Add(panelCard3);
            Controls.Add(panelCard2);
            Controls.Add(panelCard1);
            Controls.Add(btnRunReport);
            Controls.Add(dtpReportDate);
            Controls.Add(lblDateSelect);
            Font = new Font("Segoe UI", 10F);
            Name = "FormQuickReport";
            Text = "Báo cáo Doanh thu Nhanh";
            Load += FormQuickReport_Load;
            panelCard1.ResumeLayout(false);
            panelCard1.PerformLayout();
            panelCard2.ResumeLayout(false);
            panelCard2.PerformLayout();
            panelCard3.ResumeLayout(false);
            panelCard3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}