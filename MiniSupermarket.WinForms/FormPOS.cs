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
        private readonly List<CartItemDto> _cart = new List<CartItemDto>();

        public FormPOS()
        {
            InitializeComponent();
            SetupCartGrid();
        }

        private void FormPOS_Load(object sender, EventArgs e)
        {
            this.Text = $"Quầy Bán Hàng POS - [Thu ngân: {SessionManager.CurrentUsername}]";
            lblCustomerName.Text = "Khách vãng lai";
            UpdateCartDisplay();
        }

        private void SetupCartGrid()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "Mã SP", Width = 70 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên Sản Phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "Đơn Giá", Width = 100 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL", Width = 60 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalPrice", HeaderText = "Thành Tiền", Width = 110 });
        }

        // Bắt sự kiện nhấn ENTER tại ô Mã Vạch
        private async void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                string barcode = txtBarcode.Text.Trim();
                txtBarcode.Clear();
                await AddProductToCartByBarcodeAsync(barcode);
            }
        }

        private async Task AddProductToCartByBarcodeAsync(string barcode)
        {
            try
            {
                string jsonResult = await ApiClientService.GetDataWithTokenAsync($"products/barcode/{barcode}");
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var product = JsonSerializer.Deserialize<ProductDto>(jsonResult, options);

                if (product == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã vạch này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Lỗi tìm sản phẩm: " + ex.Message, "Lỗi API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCartDisplay()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart;

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
            if (string.IsNullOrEmpty(phone))
            {
                lblCustomerName.Text = "Khách vãng lai";
                return;
            }

            try
            {
                string jsonResult = await ApiClientService.GetDataWithTokenAsync($"customers/phone/{phone}");
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var customer = JsonSerializer.Deserialize<CustomerDto>(jsonResult, options);

                if (customer != null)
                {
                    lblCustomerName.Text = $"{customer.CustomerName} ({customer.MembershipRank})";
                }
                else
                {
                    lblCustomerName.Text = "Khách hàng mới";
                }
            }
            catch
            {
                lblCustomerName.Text = "Khách vãng lai";
            }
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = _cart.Sum(x => x.TotalPrice);
            if (!decimal.TryParse(txtCashReceived.Text.Trim(), out decimal cashReceived) || cashReceived < total)
            {
                MessageBox.Show("Số tiền khách đưa chưa đủ để thanh toán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var orderRequest = new
                {
                    CashierUsername = SessionManager.CurrentUsername,
                    CustomerPhone = txtCustomerPhone.Text.Trim(),
                    TotalAmount = total,
                    Items = _cart.Select(i => new
                    {
                        i.ProductId,
                        i.Quantity,
                        i.UnitPrice
                    }).ToList()
                };

                var response = await ApiClientService.PostWithTokenAsync("orders/checkout", orderRequest);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _cart.Clear();
                    UpdateCartDisplay();
                    txtCashReceived.Clear();
                    txtCustomerPhone.Clear();
                    lblCustomerName.Text = "Khách vãng lai";
                }
                else
                {
                    MessageBox.Show($"Thanh toán thất bại! Mã lỗi: {response.StatusCode}", "Lỗi API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (_cart.Count > 0 && MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _cart.Clear();
                UpdateCartDisplay();
                txtCashReceived.Clear();
            }
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