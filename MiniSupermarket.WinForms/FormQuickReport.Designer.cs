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
            this.lblDateSelect = new System.Windows.Forms.Label();
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.btnRunReport = new System.Windows.Forms.Button();

            this.panelCard1 = new System.Windows.Forms.Panel();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();

            this.panelCard2 = new System.Windows.Forms.Panel();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();

            this.panelCard3 = new System.Windows.Forms.Panel();
            this.lblCard3Title = new System.Windows.Forms.Label();
            this.lblBestSeller = new System.Windows.Forms.Label();

            this.panelCard1.SuspendLayout();
            this.panelCard2.SuspendLayout();
            this.panelCard3.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblDateSelect
            // 
            this.lblDateSelect.AutoSize = true;
            this.lblDateSelect.Location = new System.Drawing.Point(30, 25);
            this.lblDateSelect.Name = "lblDateSelect";
            this.lblDateSelect.Size = new System.Drawing.Size(124, 23);
            this.lblDateSelect.Text = "Chọn ngày xem:";

            // 
            // dtpReportDate
            // 
            this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReportDate.Location = new System.Drawing.Point(160, 20);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.Size = new System.Drawing.Size(150, 30);

            // 
            // btnRunReport
            // 
            this.btnRunReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRunReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunReport.ForeColor = System.Drawing.Color.White;
            this.btnRunReport.Location = new System.Drawing.Point(330, 18);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(150, 35);
            this.btnRunReport.Text = "Xem báo cáo";
            this.btnRunReport.UseVisualStyleBackColor = false;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);

            // 
            // panelCard1 (Tổng số hóa đơn)
            // 
            this.panelCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelCard1.Controls.Add(this.lblTotalOrders);
            this.panelCard1.Controls.Add(this.lblCard1Title);
            this.panelCard1.Location = new System.Drawing.Point(30, 80);
            this.panelCard1.Name = "panelCard1";
            this.panelCard1.Size = new System.Drawing.Size(280, 130);

            this.lblCard1Title.AutoSize = true;
            this.lblCard1Title.ForeColor = System.Drawing.Color.White;
            this.lblCard1Title.Location = new System.Drawing.Point(15, 15);
            this.lblCard1Title.Text = "TỔNG SỐ HÓA ĐƠN";

            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.White;
            this.lblTotalOrders.Location = new System.Drawing.Point(15, 50);
            this.lblTotalOrders.Text = "0";

            // 
            // panelCard2 (Tổng doanh thu)
            // 
            this.panelCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelCard2.Controls.Add(this.lblTotalRevenue);
            this.panelCard2.Controls.Add(this.lblCard2Title);
            this.panelCard2.Location = new System.Drawing.Point(340, 80);
            this.panelCard2.Name = "panelCard2";
            this.panelCard2.Size = new System.Drawing.Size(280, 130);

            this.lblCard2Title.AutoSize = true;
            this.lblCard2Title.ForeColor = System.Drawing.Color.White;
            this.lblCard2Title.Location = new System.Drawing.Point(15, 15);
            this.lblCard2Title.Text = "TỔNG DOANH THU";

            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.White;
            this.lblTotalRevenue.Location = new System.Drawing.Point(15, 50);
            this.lblTotalRevenue.Text = "0 VNĐ";

            // 
            // panelCard3 (Mặt hàng bán chạy nhất)
            // 
            this.panelCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.panelCard3.Controls.Add(this.lblBestSeller);
            this.panelCard3.Controls.Add(this.lblCard3Title);
            this.panelCard3.Location = new System.Drawing.Point(650, 80);
            this.panelCard3.Name = "panelCard3";
            this.panelCard3.Size = new System.Drawing.Size(280, 130);

            this.lblCard3Title.AutoSize = true;
            this.lblCard3Title.ForeColor = System.Drawing.Color.White;
            this.lblCard3Title.Location = new System.Drawing.Point(15, 15);
            this.lblCard3Title.Text = "MẶT HÀNG BÁN CHẠY NHẤT";

            this.lblBestSeller.AutoSize = true;
            this.lblBestSeller.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBestSeller.ForeColor = System.Drawing.Color.White;
            this.lblBestSeller.Location = new System.Drawing.Point(15, 50);
            this.lblBestSeller.Text = "Chưa có";

            // 
            // FormQuickReport
            // 
            this.ClientSize = new System.Drawing.Size(980, 600);
            this.Controls.Add(this.panelCard3);
            this.Controls.Add(this.panelCard2);
            this.Controls.Add(this.panelCard1);
            this.Controls.Add(this.btnRunReport);
            this.Controls.Add(this.dtpReportDate);
            this.Controls.Add(this.lblDateSelect);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormQuickReport";
            this.Text = "Báo cáo Doanh thu Nhanh";
            this.panelCard1.ResumeLayout(false);
            this.panelCard1.PerformLayout();
            this.panelCard2.ResumeLayout(false);
            this.panelCard2.PerformLayout();
            this.panelCard3.ResumeLayout(false);
            this.panelCard3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}