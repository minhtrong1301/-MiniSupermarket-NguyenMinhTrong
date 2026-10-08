using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.API.Models;
namespace MiniSupermarket.WinForms
{
    public partial class FormProductManagement : Form
    {
        private List<Product> _productList = new List<Product>();

        public FormProductManagement()
        {
            InitializeComponent();
        }

        // 1. Sự kiện khi Form vừa hiện lên
        private async void FormProductManagement_Load(object sender, EventArgs e)
        {
            // Hiển thị vai trò của người dùng trên thanh tiêu đề
            this.Text = $"Quản Lý Sản Phẩm - [Quyền: {SessionManager.CurrentRole}]";

            // Phân quyền nâng cao: Nếu không phải Admin thì khóa nút Xóa
            if (!string.Equals(SessionManager.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                btnDelete.Enabled = false; // Khóa nút Xóa nếu là Nhân viên
            }

            ConfigureGrid();
            await LoadCategoriesToComboAsync();
            await LoadDataAsync();
        }

        // Cấu hình các cột cho DataGridView
        private void ConfigureGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "ID", Width = 50 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Barcode", HeaderText = "Mã Vạch", Width = 110 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên Sản Phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Đơn Giá", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }, Width = 100 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StockQuantity", HeaderText = "Tồn Kho", Width = 80 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CategoryId", HeaderText = "Mã Nhóm", Width = 80 });
        }

        // Tải danh mục nạp vào ComboBox nhập liệu và lọc
        private async Task LoadCategoriesToComboAsync()
        {
            try
            {
                string jsonResult = await ApiClientService.GetDataWithTokenAsync("categories");
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var categories = JsonSerializer.Deserialize<List<CategoryDto>>(jsonResult, options) ?? new List<CategoryDto>();

                // ComboBox nhập liệu chi tiết
                cboCategory.DataSource = new List<CategoryDto>(categories);
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryId";

                // ComboBox Lọc danh mục phía trên
                var filterList = new List<CategoryDto>
                {
                    new CategoryDto { CategoryId = 0, CategoryName = "-- Tất cả nhóm hàng --" }
                };
                filterList.AddRange(categories);

                cboFilterCategory.DataSource = filterList;
                cboFilterCategory.DisplayMember = "CategoryName";
                cboFilterCategory.ValueMember = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Hàm Tải danh sách Sản phẩm từ Web API (Có kèm Token bảo mật)
        private async Task LoadDataAsync()
        {
            try
            {
                string jsonResult = await ApiClientService.GetDataWithTokenAsync("products");
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                _productList = JsonSerializer.Deserialize<List<Product>>(jsonResult, options) ?? new List<Product>();

                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm lọc danh sách tại máy client
        private void ApplyFilter()
        {
            string keyword = txtSearchBarcode.Text.Trim().ToLower();
            int selectedCatId = Convert.ToInt32(cboFilterCategory.SelectedValue ?? 0);

            var filteredList = _productList.Where(p =>
                (string.IsNullOrEmpty(keyword) ||
                 (!string.IsNullOrEmpty(p.Barcode) && p.Barcode.ToLower().Contains(keyword)) ||
                 (!string.IsNullOrEmpty(p.ProductName) && p.ProductName.ToLower().Contains(keyword))) &&
                (selectedCatId == 0 || p.CategoryId == selectedCatId)
            ).ToList();

            dgvProducts.DataSource = null;
            dgvProducts.DataSource = filteredList;
        }

        // Nút Tải lại dữ liệu (Refresh)
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            txtSearchBarcode.Clear();
            if (cboFilterCategory.Items.Count > 0) cboFilterCategory.SelectedIndex = 0;
            ClearInputs();
            await LoadDataAsync();
        }

        // Click dòng trên bảng -> Đưa dữ liệu lên các ô nhập liệu
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Rows[e.RowIndex].DataBoundItem is Product p)
            {
                txtId.Text = p.ProductId.ToString();
                txtBarcode.Text = p.Barcode;
                txtProductName.Text = p.ProductName;
                nudPrice.Value = p.Price;
                nudStock.Value = p.StockQuantity;
                cboCategory.SelectedValue = p.CategoryId;
            }
        }

        // Nút THÊM MỚI (POST)
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newProd = new
                {
                    Barcode = txtBarcode.Text.Trim(),
                    ProductName = txtProductName.Text.Trim(),
                    Price = nudPrice.Value,
                    StockQuantity = (int)nudStock.Value,
                    CategoryId = Convert.ToInt32(cboCategory.SelectedValue)
                };

                var response = await ApiClientService.PostWithTokenAsync("products", newProd);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show($"Thêm thất bại! Mã lỗi HTTP: {response.StatusCode}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút CẬP NHẬT (PUT)
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = int.Parse(txtId.Text);
                var updateProd = new
                {
                    ProductId = id,
                    Barcode = txtBarcode.Text.Trim(),
                    ProductName = txtProductName.Text.Trim(),
                    Price = nudPrice.Value,
                    StockQuantity = (int)nudStock.Value,
                    CategoryId = Convert.ToInt32(cboCategory.SelectedValue)
                };

                var response = await ApiClientService.PutWithTokenAsync($"products/{id}", updateProd);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show($"Cập nhật thất bại! Mã lỗi HTTP: {response.StatusCode}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút XÓA (DELETE)
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm ID = {id}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var response = await ApiClientService.DeleteWithTokenAsync($"products/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show($"Xóa thất bại! Bạn có thể không đủ quyền (Mã lỗi: {response.StatusCode})", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút TÌM KIẾM
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // Nút ĐĂNG XUẤT (Reset Session & Mở lại Form Đăng nhập)
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // 1. Xóa sạch dữ liệu Token & Role lưu trữ tạm
                SessionManager.JwtToken = string.Empty;
                SessionManager.CurrentRole = string.Empty;
                SessionManager.CurrentUsername = string.Empty;

                // 2. Mở lại Form Đăng nhập
                FormLogin loginForm = new FormLogin();
                this.Hide();
                loginForm.ShowDialog();
                this.Close(); // Đóng hẳn form quản lý khi FormLogin kết thúc
            }
        }

        // Hàm xóa trắng ô nhập liệu sau khi thao tác xong
        private void ClearInputs()
        {
            txtId.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            nudPrice.Value = 0;
            nudStock.Value = 0;
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
        }
    }

  
}