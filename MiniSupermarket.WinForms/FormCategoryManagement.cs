using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormCategoryManagement : Form
    {
        public FormCategoryManagement()
        {
            InitializeComponent();
        }

        // 1. Sự kiện khi Form vừa hiện lên
        private async void FormCategoryManagement_Load(object sender, EventArgs e)
        {
            // Hiển thị vai trò của người dùng trên thanh tiêu đề
            this.Text = $"Quản Lý Danh Mục - [Quyền: {SessionManager.CurrentRole}]";

            // Phân quyền nâng cao: Nếu không phải Admin thì ẩn/khóa nút Xóa
            if (!string.Equals(SessionManager.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                btnDelete.Enabled = false; // Khóa nút Xóa nếu là Nhân viên thường
            }

            await LoadDataAsync();
        }

        // 2. Hàm Tải danh sách Categories từ Web API (Có kèm Token bảo mật)
        private async Task LoadDataAsync()
        {
            try
            {
                string jsonResult = await ApiClientService.GetDataWithTokenAsync("categories");

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var categories = JsonSerializer.Deserialize<List<CategoryDto>>(jsonResult, options);

                dgvCategories.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Tải lại dữ liệu (Refresh)
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // Click dòng trên bảng -> Đưa dữ liệu lên các ô nhập liệu
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                txtId.Text = row.Cells["CategoryId"].Value?.ToString();
                txtCategoryName.Text = row.Cells["CategoryName"].Value?.ToString();
                txtDescription.Text = row.Cells["Description"]?.Value?.ToString() ?? string.Empty;
            }
        }

        // Nút THÊM MỚI (POST)
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newCat = new
                {
                    CategoryName = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                var response = await ApiClientService.PostWithTokenAsync("categories", newCat);
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
                MessageBox.Show("Vui lòng chọn danh mục cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = int.Parse(txtId.Text);
                var updateCat = new
                {
                    CategoryId = id,
                    CategoryName = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                var response = await ApiClientService.PutWithTokenAsync($"categories/{id}", updateCat);
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
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa danh mục ID = {id}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var response = await ApiClientService.DeleteWithTokenAsync($"categories/{id}");
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

        // Nút TÌM KIẾM (GET search)
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                string jsonResult = await ApiClientService.GetDataWithTokenAsync($"categories/search?keyword={keyword}");
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<List<CategoryDto>>(jsonResult, options);

                dgvCategories.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy kết quả hoặc lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            txtCategoryName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }

    // Class DTO nhận dữ liệu từ Web API
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}