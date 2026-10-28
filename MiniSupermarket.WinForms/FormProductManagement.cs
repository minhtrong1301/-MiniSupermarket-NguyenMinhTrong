
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

        // Thông tin phân trang.
        private int _currentPage = 1;
        private int _pageSize = 5;
        private int _totalItems = 0;
        private int _totalPages = 0;

        // Từ khóa và danh mục đang lọc.
        private string _currentKeyword = string.Empty;
        private int _currentCategoryId = 0;

        // DTO nhận dữ liệu sản phẩm từ API.
        private class ProductItemDto
        {
            public int ProductId { get; set; }
            public string Barcode { get; set; } = string.Empty;
            public string ProductName { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int StockQuantity { get; set; }
            public int CategoryId { get; set; }
            public string CategoryName { get; set; } = string.Empty;
        }

        // DTO nhận kết quả phân trang.
        private class PagedResultDto<T>
        {
            public int CurrentPage { get; set; }
            public int PageSize { get; set; }
            public int TotalItems { get; set; }
            public int TotalPages { get; set; }
            public List<T> Items { get; set; } = new List<T>();
        }

        public FormProductManagement()
        {
            InitializeComponent();
        }

        // Khi Form được mở.
        private async void FormProductManagement_Load(object sender, EventArgs e)
        {
            Text = $"Quản Lý Sản Phẩm - [Quyền: {SessionManager.CurrentRole}]";

            // Chỉ Admin mới được sử dụng chức năng xóa.
            if (!string.Equals(
                SessionManager.CurrentRole,
                "Admin",
                StringComparison.OrdinalIgnoreCase))
            {
                btnDelete.Enabled = false;
            }

            ConfigureGrid();

            await LoadCategoriesToComboAsync();
            await LoadDataAsync();
        }

        // Cấu hình các cột của DataGridView.
        private void ConfigureGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductId",
                HeaderText = "ID",
                Width = 50
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Barcode",
                HeaderText = "Mã Vạch",
                Width = 110
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Tên Sản Phẩm",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Đơn Giá",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                Width = 100
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StockQuantity",
                HeaderText = "Tồn Kho",
                Width = 80
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CategoryId",
                HeaderText = "Mã Nhóm",
                Width = 80
            });
        }

        // Tải danh mục vào ComboBox nhập liệu và ComboBox lọc.
        private async Task LoadCategoriesToComboAsync()
        {
            try
            {
                string jsonResult =
                    await ApiClientService.GetDataWithTokenAsync("categories");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var categories =
                    JsonSerializer.Deserialize<List<CategoryDto>>(
                        jsonResult, options) ?? new List<CategoryDto>();

                // ComboBox danh mục trong phần thông tin sản phẩm.
                cboCategory.DataSource = new List<CategoryDto>(categories);
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryId";

                // Thêm lựa chọn hiển thị tất cả danh mục.
                var filterList = new List<CategoryDto>
                {
                    new CategoryDto
                    {
                        CategoryId = 0,
                        CategoryName = "-- Tất cả nhóm hàng --"
                    }
                };

                filterList.AddRange(categories);

                cboFilterCategory.DataSource = filterList;
                cboFilterCategory.DisplayMember = "CategoryName";
                cboFilterCategory.ValueMember = "CategoryId";
                cboFilterCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi nạp danh mục: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Tải sản phẩm từ API theo từ khóa, danh mục và trang hiện tại.
        private async Task LoadDataAsync()
        {
            try
            {
                // Lấy từ khóa đang nhập.
                _currentKeyword = txtSearchBarcode.Text.Trim();

                // Lấy ID danh mục được chọn.
                if (cboFilterCategory.SelectedValue != null)
                {
                    int.TryParse(
                        cboFilterCategory.SelectedValue.ToString(),
                        out _currentCategoryId);
                }
                else
                {
                    _currentCategoryId = 0;
                }

                string keyword = Uri.EscapeDataString(_currentKeyword);

                // Gửi cả categoryId lên API để lọc trước khi phân trang.
                string endpoint =
                    $"products/paged?keyword={keyword}" +
                    $"&pageNumber={_currentPage}" +
                    $"&pageSize={_pageSize}" +
                    $"&categoryId={_currentCategoryId}";

                string json =
                    await ApiClientService.GetDataWithTokenAsync(endpoint);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var result =
                    JsonSerializer.Deserialize<PagedResultDto<ProductItemDto>>(
                        json, options);

                if (result == null)
                {
                    MessageBox.Show("Không đọc được dữ liệu sản phẩm từ API.");
                    return;
                }

                // Cập nhật thông tin phân trang.
                _currentPage = result.CurrentPage;
                _pageSize = result.PageSize;
                _totalItems = result.TotalItems;
                _totalPages = result.TotalPages;

                // Chuyển dữ liệu DTO thành Product để giữ tương thích CRUD.
                _productList = result.Items.Select(item => new Product
                {
                    ProductId = item.ProductId,
                    Barcode = item.Barcode,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    StockQuantity = item.StockQuantity,
                    CategoryId = item.CategoryId
                }).ToList();

                // Hiển thị đúng dữ liệu trang hiện tại từ API.
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = _productList;

                // Cập nhật thông tin phân trang.
                lblPageInfo.Text =
                    $"Trang {Math.Max(1, _currentPage)} / {Math.Max(1, _totalPages)}";

                btnPreviousPage.Enabled = _currentPage > 1;
                btnNextPage.Enabled =
                    _currentPage < _totalPages && _totalPages > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách sản phẩm.\nChi tiết: " + ex.Message,
                    "Lỗi tải dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Nút Làm mới: xóa từ khóa, bỏ lọc và tải lại danh sách.
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            txtSearchBarcode.Clear();

            if (cboFilterCategory.Items.Count > 0)
            {
                cboFilterCategory.SelectedIndex = 0;
            }

            _currentPage = 1;
            _currentCategoryId = 0;
            _currentKeyword = string.Empty;

            ClearInputs();
            await LoadDataAsync();
        }

        // Chọn sản phẩm trong bảng để đưa thông tin lên các ô nhập liệu.
        private void dgvProducts_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                dgvProducts.Rows[e.RowIndex].DataBoundItem is Product p)
            {
                txtId.Text = p.ProductId.ToString();
                txtBarcode.Text = p.Barcode;
                txtProductName.Text = p.ProductName;
                nudPrice.Value = Math.Min(nudPrice.Maximum, Math.Max(nudPrice.Minimum, p.Price));
                nudStock.Value = Math.Min(nudStock.Maximum, Math.Max(nudStock.Minimum, p.StockQuantity));
                cboCategory.SelectedValue = p.CategoryId;
            }
        }

        // Thêm sản phẩm mới.
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên sản phẩm!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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

                var response =
                    await ApiClientService.PostWithTokenAsync("products", newProd);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Thêm mới thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    _currentPage = 1;
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(
                        $"Thêm thất bại! Mã lỗi HTTP: {response.StatusCode}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Cập nhật sản phẩm.
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần sửa từ danh sách!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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

                var response =
                    await ApiClientService.PutWithTokenAsync(
                        $"products/{id}", updateProd);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Cập nhật thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(
                        $"Cập nhật thất bại! Mã lỗi HTTP: {response.StatusCode}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Xóa sản phẩm.
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần xóa!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm ID = {id}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var response =
                    await ApiClientService.DeleteWithTokenAsync($"products/{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Xóa thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    _currentPage = 1;
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(
                        $"Xóa thất bại! Bạn có thể không đủ quyền (Mã lỗi: {response.StatusCode})",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Tìm kiếm theo từ khóa và danh mục.
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadDataAsync();
        }

        // Đăng xuất khỏi hệ thống.
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                SessionManager.JwtToken = string.Empty;
                SessionManager.CurrentRole = string.Empty;
                SessionManager.CurrentUsername = string.Empty;

                FormLogin loginForm = new FormLogin();
                Hide();
                loginForm.ShowDialog();
                Close();
            }
        }

        // Xóa trắng các ô nhập liệu.
        private void ClearInputs()
        {
            txtId.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            nudPrice.Value = 0;
            nudStock.Value = 0;

            if (cboCategory.Items.Count > 0)
            {
                cboCategory.SelectedIndex = 0;
            }
        }

        // Chuyển về trang trước.
        private async void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (_currentPage <= 1)
                return;

            _currentPage--;
            await LoadDataAsync();
        }

        // Chuyển sang trang tiếp theo.
        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage >= _totalPages)
                return;

            _currentPage++;
            await LoadDataAsync();
        }

        private void dgvProducts_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
            // Chưa sử dụng sự kiện này.
        }
    }
}
