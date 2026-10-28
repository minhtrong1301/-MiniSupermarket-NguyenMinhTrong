using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormPOS : Form
    {
        // Lưu danh sách sản phẩm đang có trong giỏ hàng
        private readonly List<CartItemDto> _cart = new List<CartItemDto>();

        // Lưu mã khách hàng đang được chọn; null nghĩa là khách vãng lai
        private int? _selectedCustomerId = null;

        public FormPOS()
        {
            InitializeComponent();
            SetupCartGrid();
            ApplyPosStyling();
        }

        private void FormPOS_Load(object sender, EventArgs e)
        {
            Text = $"Quầy Bán Hàng POS - [Thu ngân: {SessionManager.CurrentUsername}]";
            lblCustomerName.Text = "Khách vãng lai";
            UpdateCartDisplay();
            txtBarcode.Focus();
        }

        private void SetupCartGrid()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductId",
                DataPropertyName = "ProductId",
                HeaderText = "Mã SP",
                Width = 70,
                ReadOnly = true
            });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                DataPropertyName = "ProductName",
                HeaderText = "Tên sản phẩm",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitPrice",
                DataPropertyName = "UnitPrice",
                HeaderText = "Đơn giá",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                DataPropertyName = "Quantity",
                HeaderText = "SL",
                Width = 55,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dgvCart.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Decrease",
                HeaderText = "",
                Text = "−",
                UseColumnTextForButtonValue = true,
                Width = 38,
                ReadOnly = true
            });
            dgvCart.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Increase",
                HeaderText = "",
                Text = "+",
                UseColumnTextForButtonValue = true,
                Width = 38,
                ReadOnly = true
            });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalPrice",
                DataPropertyName = "TotalPrice",
                HeaderText = "Thành tiền",
                Width = 110,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvCart.ReadOnly = true;
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.MultiSelect = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.RowHeadersVisible = false;

            dgvCart.CellContentClick -= dgvCart_CellContentClick;
            dgvCart.CellContentClick += dgvCart_CellContentClick;
        }

        private void ApplyPosStyling()
        {
            Color background = Color.FromArgb(245, 247, 250);
            Color primary = Color.FromArgb(22, 163, 74);
            Color primaryDark = Color.FromArgb(21, 128, 61);
            Color text = Color.FromArgb(31, 41, 55);
            Color border = Color.FromArgb(226, 232, 240);

            BackColor = background;
            ForeColor = text;
            Font = new Font("Segoe UI", 10F);
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;

            panelLeft.BackColor = background;
            panelRight.BackColor = Color.White;
            panelTopLeft.BackColor = Color.White;

            lblTitle.ForeColor = text;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblBarcode.ForeColor = text;
            lblBarcode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPhone.ForeColor = text;
            lblCustNameHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblCustomerName.ForeColor = primaryDark;
            lblCustomerName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            lblTotalHeader.ForeColor = text;
            lblTotalHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalAmount.ForeColor = primaryDark;
            lblTotalAmount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblCashHeader.ForeColor = text;
            lblChangeHeader.ForeColor = text;
            lblChange.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblChange.ForeColor = primaryDark;

            txtBarcode.Font = new Font("Segoe UI", 12F);
            txtBarcode.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerPhone.Font = new Font("Segoe UI", 11F);
            txtCustomerPhone.BorderStyle = BorderStyle.FixedSingle;
            txtCashReceived.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            txtCashReceived.BorderStyle = BorderStyle.FixedSingle;

            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.GridColor = border;
            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvCart.ColumnHeadersDefaultCellStyle.ForeColor = text;
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvCart.ColumnHeadersHeight = 42;
            dgvCart.RowTemplate.Height = 40;
            dgvCart.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvCart.DefaultCellStyle.ForeColor = text;
            dgvCart.DefaultCellStyle.BackColor = Color.White;
            dgvCart.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 252, 231);
            dgvCart.DefaultCellStyle.SelectionForeColor = text;
            dgvCart.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            StyleButton(btnSearchCustomer, Color.FromArgb(37, 99, 235), Color.FromArgb(29, 78, 216));
            StyleButton(btnCheckout, primary, primaryDark);
            StyleButton(btnClearCart, Color.FromArgb(220, 38, 38), Color.FromArgb(185, 28, 28));
        }

        private static void StyleButton(Button button, Color normal, Color hover)
        {
            button.BackColor = normal;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = hover;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.RowIndex >= _cart.Count)
                return;

            string columnName = dgvCart.Columns[e.ColumnIndex].Name;
            CartItemDto item = _cart[e.RowIndex];

            if (columnName == "Increase")
            {
                item.Quantity++;
            }
            else if (columnName == "Decrease" && item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                return;
            }

            UpdateCartDisplay();
        }

        // Bắt sự kiện nhấn ENTER tại ô Mã Vạch.
        private async void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            string barcode = txtBarcode.Text.Trim();
            if (string.IsNullOrWhiteSpace(barcode))
                return;

            await AddProductToCartByBarcodeAsync(barcode);
            txtBarcode.Clear();
            txtBarcode.Focus();
        }

        private async Task AddProductToCartByBarcodeAsync(string barcode)
        {
            try
            {
                string jsonResult = await ApiClientService.GetDataWithTokenAsync(
                    $"products/barcode/{Uri.EscapeDataString(barcode)}");

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var product = JsonSerializer.Deserialize<ProductDto>(jsonResult, options);

                if (product == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã vạch này!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingItem = _cart.FirstOrDefault(c => c.ProductId == product.ProductId);
                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    _cart.Add(new CartItemDto
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        UnitPrice = product.Price,
                        Quantity = 1
                    });
                }

                UpdateCartDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm sản phẩm: " + ex.Message, "Lỗi API",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCartDisplay()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart.ToList();

            decimal total = _cart.Sum(x => x.TotalPrice);
            lblTotalAmount.Text = $"{total:N0} đ";
            CalculateChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            decimal total = _cart.Sum(x => x.TotalPrice);

            if (decimal.TryParse(txtCashReceived.Text.Trim(), out decimal cashReceived))
            {
                decimal change = cashReceived - total;
                if (change >= 0)
                {
                    lblChange.Text = $"{change:N0} đ";
                    lblChange.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblChange.Text = "Chưa đủ tiền!";
                    lblChange.ForeColor = Color.Red;
                }
            }
            else
            {
                lblChange.Text = "0 đ";
                lblChange.ForeColor = Color.Black;
            }
        }


        private async void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            string phone = txtCustomerPhone.Text.Trim();

            // Mặc định chưa chọn khách hàng
            _selectedCustomerId = null;

            // Nếu không nhập số điện thoại thì sử dụng khách vãng lai
            if (string.IsNullOrEmpty(phone))
            {
                lblCustomerName.Text = "Khách vãng lai";
                return;
            }

            try
            {
                // Gọi API tìm khách hàng theo số điện thoại
                string jsonResult = await ApiClientService.GetDataWithTokenAsync(
                    $"customers/phone/{Uri.EscapeDataString(phone)}");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var customer = JsonSerializer.Deserialize<CustomerDto>(
                    jsonResult, options);

                if (customer != null)
                {
                    // Lưu mã khách hàng để gửi lên API khi thanh toán
                    _selectedCustomerId = customer.CustomerId;

                    // Hiển thị thông tin khách hàng trên giao diện
                    lblCustomerName.Text =
                        $"{customer.CustomerName} ({customer.MembershipRank})";
                }
                else
                {
                    lblCustomerName.Text = "Khách hàng mới";
                }
            }
            catch (Exception ex)
            {
                // Nếu API lỗi thì không giữ lại mã khách hàng cũ
                _selectedCustomerId = null;
                lblCustomerName.Text = "Không tìm thấy khách hàng";

                MessageBox.Show(
                    $"Không thể tìm khách hàng.\nChi tiết: {ex.Message}",
                    "Lỗi tìm kiếm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            // Không cho thanh toán nếu giỏ hàng đang trống
            if (_cart.Count == 0)
            {
                MessageBox.Show(
                    "Giỏ hàng đang trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Tính tổng tiền theo giỏ hàng hiện tại
            decimal total = _cart.Sum(item => item.TotalPrice);

            // Kiểm tra số tiền khách đưa
            if (!decimal.TryParse(txtCashReceived.Text.Trim(), out decimal cashReceived)
                || cashReceived < total)
            {
                MessageBox.Show(
                    $"Số tiền khách đưa không hợp lệ hoặc chưa đủ!\nTổng tiền: {total:N0} VNĐ",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCashReceived.Focus();
                return;
            }

            // Tránh người dùng nhấn thanh toán nhiều lần
            btnCheckout.Enabled = false;

            try
            {
                // Chuẩn bị dữ liệu gửi đến API
                var orderRequest = new
                {
                    CashierUsername = SessionManager.CurrentUsername,
                    CustomerId = _selectedCustomerId,
                    CashReceived = cashReceived,
                    Items = _cart.Select(item => new
                    {
                        item.ProductId,
                        item.Quantity,
                        item.UnitPrice
                    }).ToList()
                };

                // Gọi đúng endpoint checkout của API Tiết 5
                using var response = await ApiClientService.PostWithTokenAsync(
                    "checkout",
                    orderRequest);

                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Đọc kết quả API trả về
                    using var document = JsonDocument.Parse(responseBody);
                    var root = document.RootElement;

                    int orderId = root.GetProperty("orderId").GetInt32();
                    decimal actualTotal = root.GetProperty("totalAmount").GetDecimal();
                    decimal actualCash = root.GetProperty("cashReceived").GetDecimal();
                    decimal change = root.GetProperty("changeAmount").GetDecimal();

                    int earnedPoints = root.TryGetProperty("earnedPoints", out var pointsElement)
                        ? pointsElement.GetInt32()
                        : 0;

                    MessageBox.Show(
                        $"Thanh toán thành công!\n\n" +
                        $"Mã đơn hàng: {orderId}\n" +
                        $"Tổng tiền: {actualTotal:N0} VNĐ\n" +
                        $"Khách đưa: {actualCash:N0} VNĐ\n" +
                        $"Tiền thối: {change:N0} VNĐ\n" +
                        $"Điểm tích lũy: +{earnedPoints}",
                        "Thanh toán thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Chỉ xóa giỏ hàng sau khi API xác nhận thành công
                    _cart.Clear();
                    txtCashReceived.Clear();
                    txtCustomerPhone.Clear();
                    _selectedCustomerId = null;
                    lblCustomerName.Text = "Khách vãng lai";

                    UpdateCartDisplay();
                    CalculateChange();
                    txtBarcode.Focus();
                }
                else
                {
                    // Hiển thị lỗi do API trả về
                    string errorMessage = responseBody;

                    try
                    {
                        using var errorDocument = JsonDocument.Parse(responseBody);
                        var errorRoot = errorDocument.RootElement;

                        if (errorRoot.TryGetProperty("message", out var messageElement))
                            errorMessage = messageElement.GetString() ?? responseBody;
                    }
                    catch (JsonException)
                    {
                        // Giữ nguyên nội dung phản hồi nếu không phải JSON
                    }

                    MessageBox.Show(
                        $"Thanh toán thất bại!\n{errorMessage}",
                        "Lỗi thanh toán",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể thực hiện thanh toán.\nChi tiết: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                // Cho phép thanh toán lại sau khi xử lý xong
                btnCheckout.Enabled = true;
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (_cart.Count > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ giỏ hàng?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _cart.Clear();
                UpdateCartDisplay();
                txtCashReceived.Clear();
                txtBarcode.Focus();
            }
        }

        // Các sự kiện này được giữ lại vì Designer đang đăng ký chúng.
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F9)
            {
                btnCheckout.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void panelRight_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dgvCart_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class CartItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
