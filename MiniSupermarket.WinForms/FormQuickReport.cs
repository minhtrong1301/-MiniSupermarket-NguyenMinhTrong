using System;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormQuickReport : Form
    {
        public FormQuickReport()
        {
            InitializeComponent();
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            // Dữ liệu giả lập mô phỏng kết quả báo cáo
            lblTotalOrders.Text = "48";
            lblTotalRevenue.Text = "15,850,000 VNĐ";
            lblBestSeller.Text = "Gạo ST25";
        }
    }
}