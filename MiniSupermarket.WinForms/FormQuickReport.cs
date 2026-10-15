
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormQuickReport : Form
    {
        public FormQuickReport()
        {
            InitializeComponent();
        }

        private async void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                btnRunReport.Enabled = false;
                btnRunReport.Text = "Đang tải...";

                        var response = await ApiClientService
              .GetDataWithTokenAsync("Orders/quick-report");

                // Nếu API client trả về chuỗi JSON thì dùng trực tiếp.
                // Nếu trả về object thì mới chuyển object thành JSON.
                string json = response is string responseJson
                    ? responseJson
                    : JsonSerializer.Serialize(response);

                using JsonDocument document = JsonDocument.Parse(json);
                JsonElement root = document.RootElement;

                // API có thể trả về chuỗi thông báo thay vì object dữ liệu.
                // Kiểm tra trước để tránh lỗi GetProperty().
                if (root.ValueKind != JsonValueKind.Object)
                {
                    throw new Exception("API không trả về object báo cáo. Dữ liệu: " + json);
                }

                int totalOrders = root.GetProperty("totalOrders").GetInt32();

                decimal totalRevenue = root.GetProperty("totalRevenue").GetDecimal();

                string bestSeller = root.GetProperty("bestSeller").GetString()
                    ?? "Chưa có dữ liệu";

                // Hiển thị dữ liệu thật lên giao diện
                lblTotalOrders.Text = totalOrders.ToString("N0");

                lblTotalRevenue.Text =
                    totalRevenue.ToString("N0") + " VNĐ";

                lblBestSeller.Text = bestSeller;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải báo cáo.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnRunReport.Enabled = true;
                btnRunReport.Text = "Chạy báo cáo";
            }
        }
    }
}
