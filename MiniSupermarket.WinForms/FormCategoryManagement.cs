
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormCategoryManagement : Form
    {
        // Cấu hình phân trang
        private int _currentPage = 1;
        private const int PageSize = 5;
        private int _totalPages = 0;
        private string _currentKeyword = string.Empty;

        public FormCategoryManagement()
        {
            InitializeComponent();
        }

        // DTO nhận dữ liệu phân trang từ API
        public class PagedResultDto<T>
        {
            public int CurrentPage { get; set; }
            public int PageSize { get; set; }
            public int TotalItems { get; set; }
            public int TotalPages { get; set; }
            public List<T> Items { get; set; } = new List<T>();
        }

        // Sự kiện khi Form vừa hiện lên
        private async void FormCategoryManagement_Load(
            object sender, EventArgs e)
        {
            
            this.Text =
                $"Quản Lý Danh Mục - [Quyền: {SessionManager.CurrentRole}]";

            // Chỉ Admin mới được xóa danh mục
            if (!string.Equals(
                SessionManager.CurrentRole,
                "Admin",
                StringComparison.OrdinalIgnoreCase))
            {
                btnDelete.Enabled = false;
            }

            _currentPage = 1;
            await LoadDataAsync();
        }

        // Tải danh mục từ API có phân trang và tìm kiếm
        private async Task LoadDataAsync()
        {
            try
            {
                string url =
                    $"categories/paged?pageNumber={_currentPage}" +
                    $"&pageSize={PageSize}" +
                    $"&keyword={Uri.EscapeDataString(_currentKeyword)}";

                string jsonResult =
                    await ApiClientService.GetDataWithTokenAsync(url);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var result =
                    JsonSerializer.Deserialize<PagedResultDto<CategoryDto>>(
                        jsonResult, options);

                if (result == null)
                {
                    MessageBox.Show(
                        "Không đọc được dữ liệu danh mục từ API.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                _totalPages = result.TotalPages;

                // Nếu trang hiện tại không còn hợp lệ sau khi xóa dữ liệu
                if (_totalPages > 0 && _currentPage > _totalPages)
                {
                    _currentPage = _totalPages;
                    await LoadDataAsync();
                    return;
                }

                // Hiển thị dữ liệu trên DataGridView
                dgvCategories.DataSource = result.Items;

                // Cập nhật thông tin trang
                int displayPage = _totalPages == 0 ? 0 : _currentPage;

                lblPageInfo.Text =
                    $"Trang {displayPage}/{_totalPages}";

                btnPrevious.Enabled =
                    _totalPages > 0 && _currentPage > 1;

                btnNext.Enabled =
                    _currentPage < _totalPages;

                // Xóa thông tin chi tiết nếu không còn dữ liệu
                if (result.Items.Count == 0)
                {
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải danh mục: " + ex.Message,
                    "Lỗi truy cập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Nút tải lại dữ liệu
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            _currentKeyword = string.Empty;
            _currentPage = 1;

            await LoadDataAsync();
        }

        // Chuyển về trang trước
        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadDataAsync();
            }
        }

        // Chuyển sang trang tiếp theo
        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadDataAsync();
            }
        }

        // Chọn một dòng để hiển thị thông tin chi tiết
        private void dgvCategories_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvCategories.Rows[e.RowIndex];

            txtId.Text =
                row.Cells["CategoryId"].Value?.ToString() ?? string.Empty;

            txtCategoryName.Text =
                row.Cells["CategoryName"].Value?.ToString() ?? string.Empty;

            txtDescription.Text =
                row.Cells["Description"].Value?.ToString() ?? string.Empty;
        }

        // Thêm mới danh mục
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên danh mục!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newCat = new
                {
                    CategoryName = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                var response =
                    await ApiClientService.PostWithTokenAsync(
                        "categories", newCat);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Thêm mới thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearInputs();
                    _currentPage = 1;
                    await LoadDataAsync();
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

        // Cập nhật danh mục
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục cần sửa từ danh sách!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên danh mục!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var updateCat = new
                {
                    CategoryId = id,
                    CategoryName = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                var response =
                    await ApiClientService.PutWithTokenAsync(
                        $"categories/{id}", updateCat);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Cập nhật thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearInputs();
                    await LoadDataAsync();
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

        // Xóa danh mục
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục cần xóa!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa danh mục ID = {id}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var response =
                    await ApiClientService.DeleteWithTokenAsync(
                        $"categories/{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Xóa thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearInputs();
                    await LoadDataAsync();
                }
                else
                {
                    MessageBox.Show(
                        $"Xóa thất bại! Bạn có thể không đủ quyền " +
                        $"(Mã lỗi: {response.StatusCode})",
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

        // Tìm kiếm kết hợp phân trang
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _currentKeyword = txtKeyword.Text.Trim();
            _currentPage = 1;

            await LoadDataAsync();
        }

        // Đăng xuất
        //private void btnLogout_Click(object sender, EventArgs e)
        //{
        //    var confirm = MessageBox.Show(
        //        "Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?",
        //        "Xác nhận",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question);

        //    if (confirm != DialogResult.Yes)
        //        return;

        //    SessionManager.JwtToken = string.Empty;
        //    SessionManager.CurrentRole = string.Empty;

        //    FormLogin loginForm = new FormLogin();

        //    Hide();
        //    loginForm.ShowDialog();
        //    Close();
        //}

        // Xóa trắng các ô nhập liệu
        private void ClearInputs()
        {
            txtId.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();
        }

        // Sự kiện CellContentClick được giữ lại để tương thích Designer
        private void dgvCategories_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }
    }

    // DTO nhận thông tin danh mục
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
