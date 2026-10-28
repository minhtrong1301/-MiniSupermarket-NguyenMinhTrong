
using System;
using System.Drawing;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormQuickReport : Form
    {
        // Màu sắc chủ đạo của dashboard.
        private readonly Color _backgroundColor =
            Color.FromArgb(243, 246, 251);

        private readonly Color _textColor =
            Color.FromArgb(30, 41, 59);

        private readonly Color _mutedColor =
            Color.FromArgb(100, 116, 139);

        private readonly Color _blueColor =
            Color.FromArgb(37, 99, 235);

        private readonly Color _greenColor =
            Color.FromArgb(22, 163, 74);

        private readonly Color _purpleColor =
            Color.FromArgb(147, 51, 234);

        private Label lblPageTitle;
        private Label lblPageDescription;

        public FormQuickReport()
        {
            InitializeComponent();

            ApplyDashboardStyle();

            // Tự căn chỉnh các thẻ khi thay đổi kích thước form.
            Resize += (s, e) => LayoutCards();
        }

        // Thiết lập giao diện tổng quan.
        private void ApplyDashboardStyle()
        {
            Text = "Báo cáo doanh thu";
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = _backgroundColor;
            MinimumSize = new Size(900, 500);
            Font = new Font("Segoe UI", 10F);

            // Tiêu đề chính.
            lblPageTitle = new Label
            {
                Text = "Báo cáo doanh thu",
                Font = new Font("Segoe UI", 23F, FontStyle.Bold),
                ForeColor = _textColor,
                AutoSize = true,
                Location = new Point(30, 20)
            };

            lblPageDescription = new Label
            {
                Text = "Tổng quan hoạt động bán hàng trong ngày",
                Font = new Font("Segoe UI", 10F),
                ForeColor = _mutedColor,
                AutoSize = true,
                Location = new Point(33, 65)
            };

            Controls.Add(lblPageTitle);
            Controls.Add(lblPageDescription);

            // Khu vực chọn ngày báo cáo.
            lblDateSelect.Text = "Ngày báo cáo";
            lblDateSelect.AutoSize = true;
            lblDateSelect.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDateSelect.ForeColor = _textColor;
            lblDateSelect.Location = new Point(30, 125);

            dtpReportDate.Format = DateTimePickerFormat.Short;
            dtpReportDate.Location = new Point(145, 118);
            dtpReportDate.Size = new Size(160, 35);
            dtpReportDate.Font = new Font("Segoe UI", 10F);

            // Nút làm mới báo cáo.
            btnRunReport.Text = "Làm mới báo cáo";
            btnRunReport.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRunReport.BackColor = _blueColor;
            btnRunReport.ForeColor = Color.White;
            btnRunReport.FlatStyle = FlatStyle.Flat;
            btnRunReport.FlatAppearance.BorderSize = 0;
            btnRunReport.Cursor = Cursors.Hand;
            btnRunReport.Size = new Size(165, 38);
            btnRunReport.Location = new Point(325, 115);
            btnRunReport.UseVisualStyleBackColor = false;

            // Thẻ tổng số hóa đơn.
            StyleCard(
                panelCard1,
                lblCard1Title,
                lblTotalOrders,
                "TỔNG SỐ HÓA ĐƠN",
                "0",
                _blueColor);

            // Thẻ tổng doanh thu.
            StyleCard(
                panelCard2,
                lblCard2Title,
                lblTotalRevenue,
                "TỔNG DOANH THU",
                "0 VNĐ",
                _greenColor);

            // Thẻ mặt hàng bán chạy nhất.
            StyleCard(
                panelCard3,
                lblCard3Title,
                lblBestSeller,
                "MẶT HÀNG BÁN CHẠY NHẤT",
                "Chưa có dữ liệu",
                _purpleColor);

            LayoutCards();
        }

        // Định dạng thống nhất cho các thẻ thống kê.

        private void StyleCard(
            Panel panel,
            Label titleLabel,
            Label valueLabel,
            string title,
            string initialValue,
            Color accentColor)
        {
            // Thẻ trắng, viền nhẹ, đồng bộ với giao diện MiniMart POS.
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;

            titleLabel.Text = title;
            titleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(100, 116, 139);
            titleLabel.AutoSize = false;
            titleLabel.Location = new Point(20, 16);
            titleLabel.Size = new Size(panel.Width - 40, 28);
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;

            valueLabel.Text = initialValue;
            valueLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            valueLabel.ForeColor = accentColor;
            valueLabel.AutoSize = false;
            valueLabel.Location = new Point(20, 53);
            valueLabel.Size = new Size(panel.Width - 40, 65);
            valueLabel.TextAlign = ContentAlignment.MiddleLeft;

            // Tránh nội dung dài làm tràn khỏi thẻ.
            valueLabel.AutoEllipsis = true;
        }

        // Bố trí ba thẻ cùng hàng, khoảng cách đồng đều.
        private void LayoutCards()
        {
            int margin = 26;
            int gap = 16;

            int availableWidth =
                ClientSize.Width - margin * 2 - gap * 2;

            int cardWidth = availableWidth / 3;
            int cardHeight = 138;
            int top = 165;

            if (cardWidth <= 0)
                return;

            panelCard1.SetBounds(
                margin, top, cardWidth, cardHeight);

            panelCard2.SetBounds(
                margin + cardWidth + gap,
                top, cardWidth, cardHeight);

            panelCard3.SetBounds(
                margin + (cardWidth + gap) * 2,
                top, cardWidth, cardHeight);

            ResizeCardLabels(
                panelCard1, lblCard1Title, lblTotalOrders);

            ResizeCardLabels(
                panelCard2, lblCard2Title, lblTotalRevenue);

            ResizeCardLabels(
                panelCard3, lblCard3Title, lblBestSeller);
        }


        // Cập nhật chiều rộng nội dung trong từng thẻ.
        private void ResizeCardLabels(
            Panel panel,
            Label titleLabel,
            Label valueLabel)
        {
            int labelWidth = Math.Max(
                100, panel.ClientSize.Width - 40);

            titleLabel.Width = labelWidth;
            valueLabel.Width = labelWidth;
        }

        // Sự kiện được đăng ký trong Designer.cs.
        private async void FormQuickReport_Load(
            object sender,
            EventArgs e)
        {
            await RunReportAsync();
        }

        // Người dùng bấm nút làm mới báo cáo.
        private async void btnRunReport_Click(
            object sender,
            EventArgs e)
        {
            await RunReportAsync();
        }

        // Gọi API và cập nhật dữ liệu thật lên giao diện.
        private async Task RunReportAsync()
        {
            try
            {
                btnRunReport.Enabled = false;
                btnRunReport.Text = "Đang tải...";

                string selectedDate =
                    dtpReportDate.Value.ToString("yyyy-MM-dd");

                string endpoint =
                    $"Orders/quick-report?date={selectedDate}";

                string json =
                    await ApiClientService.GetDataWithTokenAsync(
                        endpoint);

                using JsonDocument document =
                    JsonDocument.Parse(json);

                JsonElement root = document.RootElement;

                if (root.ValueKind != JsonValueKind.Object)
                {
                    throw new Exception(
                        "API không trả về dữ liệu báo cáo hợp lệ.");
                }

                int totalOrders =
                    root.GetProperty("totalOrders").GetInt32();

                decimal totalRevenue =
                    root.GetProperty("totalRevenue").GetDecimal();

                string bestSeller =
                    root.GetProperty("bestSeller").GetString()
                    ?? "Chưa có dữ liệu";

                int bestSellerQuantity = 0;

                if (root.TryGetProperty(
                    "bestSellerQuantity",
                    out JsonElement quantityElement))
                {
                    bestSellerQuantity =
                        quantityElement.GetInt32();
                }

                // Hiển thị số liệu từ API.
                lblTotalOrders.Text =
                    totalOrders.ToString("N0");

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
