
using System;
using System.Drawing;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormQuickReport : Form
    {
        // Màu sắc chủ đạo của màn hình báo cáo
        private readonly Color _backgroundColor = Color.FromArgb(245, 247, 250);
        private readonly Color _textColor = Color.FromArgb(45, 55, 72);
        private readonly Color _mutedColor = Color.FromArgb(113, 128, 150);
        private readonly Color _blueColor = Color.FromArgb(49, 130, 206);
        private readonly Color _greenColor = Color.FromArgb(38, 166, 115);
        private readonly Color _purpleColor = Color.FromArgb(128, 90, 213);

        private Label lblPageTitle;
        private Label lblPageDescription;

        public FormQuickReport()
        {
            InitializeComponent();
            ApplyDashboardStyle();
        }

        // Thiết lập giao diện tổng quan báo cáo
        private void ApplyDashboardStyle()
        {
            Text = "Báo cáo doanh thu";
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = _backgroundColor;
            MinimumSize = new Size(900, 500);
            Font = new Font("Segoe UI", 10F);

            // API quick-report hiện tại trả số liệu tổng,
           
            // Hiển thị lại chức năng chọn ngày báo cáo
            dtpReportDate.Visible = true;
            lblDateSelect.Visible = true;

            // Tiêu đề chính
            lblPageTitle = new Label
            {
                Text = "Báo cáo doanh thu",
                Font = new Font("Segoe UI", 23F, FontStyle.Bold),
                ForeColor = _textColor,
                AutoSize = true,
                Location = new Point(30, 22)
            };

            // Mô tả ngắn bên dưới tiêu đề
            lblPageDescription = new Label
            {
                Text = "Tổng quan hoạt động bán hàng từ dữ liệu hệ thống",
                Font = new Font("Segoe UI", 10F),
                ForeColor = _mutedColor,
                AutoSize = true,
                Location = new Point(33, 65)
            };

            Controls.Add(lblPageTitle);
            Controls.Add(lblPageDescription);

            // Nút tải lại báo cáo
            btnRunReport.Text = "Làm mới báo cáo";
            btnRunReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRunReport.BackColor = _blueColor;
            btnRunReport.ForeColor = Color.White;
            btnRunReport.FlatStyle = FlatStyle.Flat;
            btnRunReport.FlatAppearance.BorderSize = 0;
            btnRunReport.Cursor = Cursors.Hand;
            btnRunReport.Size = new Size(165, 42);
            btnRunReport.Location = new Point(30, 110);

            // Thẻ tổng số hóa đơn
            StyleCard(
                panelCard1,
                lblCard1Title,
                lblTotalOrders,
                "TỔNG SỐ HÓA ĐƠN",
                "0",
                _blueColor);

            // Thẻ tổng doanh thu
            StyleCard(
                panelCard2,
                lblCard2Title,
                lblTotalRevenue,
                "TỔNG DOANH THU",
                "0 VNĐ",
                _greenColor);

            // Thẻ sản phẩm bán chạy
            StyleCard(
                panelCard3,
                lblCard3Title,
                lblBestSeller,
                "MẶT HÀNG BÁN CHẠY NHẤT",
                "Chưa có dữ liệu",
                _purpleColor);

            // Bố trí ba thẻ trên cùng một hàng
            LayoutCards();

            // Tải báo cáo ngay khi mở form
            Load += FormQuickReport_Load;
        }

        // Định dạng thống nhất cho từng thẻ thống kê
        private void StyleCard(
            Panel panel,
            Label titleLabel,
            Label valueLabel,
            string title,
            string initialValue,
            Color accentColor)
        {
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Size = new Size(280, 155);

            titleLabel.Text = title;
            titleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            titleLabel.ForeColor = _mutedColor;
            titleLabel.AutoSize = false;
            titleLabel.Location = new Point(18, 20);
            titleLabel.Size = new Size(panel.Width - 36, 30);
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;

            valueLabel.Text = initialValue;
            valueLabel.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            valueLabel.ForeColor = accentColor;
            valueLabel.AutoSize = false;
            valueLabel.Location = new Point(18, 62);
            valueLabel.Size = new Size(panel.Width - 36, 65);
            valueLabel.TextAlign = ContentAlignment.MiddleLeft;

            // Tránh tên sản phẩm dài làm tràn khỏi thẻ
            valueLabel.AutoEllipsis = true;
        }

        // Tính vị trí thẻ theo chiều rộng của form
        private void LayoutCards()
        {
            int margin = 30;
            int gap = 20;
            int availableWidth = ClientSize.Width - margin * 2 - gap * 2;
            int cardWidth = availableWidth / 3;

            panelCard1.SetBounds(margin, 180, cardWidth, 155);
            panelCard2.SetBounds(margin + cardWidth + gap, 180, cardWidth, 155);
            panelCard3.SetBounds(
                margin + (cardWidth + gap) * 2,
                180,
                cardWidth,
                155);

            ResizeCardLabels(panelCard1, lblCard1Title, lblTotalOrders);
            ResizeCardLabels(panelCard2, lblCard2Title, lblTotalRevenue);
            ResizeCardLabels(panelCard3, lblCard3Title, lblBestSeller);
        }

        private void ResizeCardLabels(
            Panel panel,
            Label titleLabel,
            Label valueLabel)
        {
            titleLabel.Width = panel.ClientSize.Width - 36;
            valueLabel.Width = panel.ClientSize.Width - 36;
        }

        private async void FormQuickReport_Load(object sender, EventArgs e)
        {
            await RunReportAsync();
        }

        private async void btnRunReport_Click(object sender, EventArgs e)
        {
            await RunReportAsync();
        }

        // Gọi API và cập nhật các chỉ số trên giao diện
        private async Task RunReportAsync()
        {
            try
            {
                btnRunReport.Enabled = false;
                btnRunReport.Text = "Đang tải...";

                // Lấy ngày người dùng chọn trên giao diện
                string selectedDate = dtpReportDate.Value.ToString("yyyy-MM-dd");

                // Gửi ngày đã chọn lên API để lọc báo cáo
                string endpoint = $"Orders/quick-report?date={selectedDate}";

                string json = await ApiClientService.GetDataWithTokenAsync(endpoint);

                using JsonDocument document = JsonDocument.Parse(json);
                JsonElement root = document.RootElement;

                if (root.ValueKind != JsonValueKind.Object)
                {
                    throw new Exception(
                        "API không trả về dữ liệu báo cáo hợp lệ.");
                }

                int totalOrders = root.GetProperty("totalOrders").GetInt32();

                decimal totalRevenue = root.GetProperty("totalRevenue").GetDecimal();

                string bestSeller = root.GetProperty("bestSeller").GetString()
                    ?? "Chưa có dữ liệu";

                int bestSellerQuantity = 0;

                if (root.TryGetProperty(
                    "bestSellerQuantity",
                    out JsonElement quantityElement))
                {
                    bestSellerQuantity = quantityElement.GetInt32();
                }

                // Hiển thị số liệu thật do API trả về
                lblTotalOrders.Text = totalOrders.ToString("N0");

                lblTotalRevenue.Text =
                    totalRevenue.ToString("N0") + " VNĐ";

                lblBestSeller.Text = bestSellerQuantity > 0
                    ? $"{bestSeller} ({bestSellerQuantity:N0} SP)"
                    : bestSeller;
            }
            catch (JsonException)
            {
                MessageBox.Show(
                    "Dữ liệu báo cáo từ API không đúng định dạng JSON.",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải báo cáo.\n" + ex.Message,
                    "Lỗi báo cáo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnRunReport.Enabled = true;
                btnRunReport.Text = "Làm mới báo cáo";
            }
        }
    }
}
