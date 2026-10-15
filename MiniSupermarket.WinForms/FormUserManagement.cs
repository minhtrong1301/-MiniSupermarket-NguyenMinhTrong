
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent();

            // Khởi tạo danh sách vai trò.
            cboRole.Items.Clear();
            cboRole.Items.AddRange(new string[]
            {
                "Admin",
                "Cashier",
                "Warehouse"
            });

            cboRole.SelectedIndex = 1;
        }

        // Tự động tải danh sách tài khoản khi mở form.
        private async void FormUserManagement_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        // Lấy danh sách tài khoản từ API.
        private async Task LoadUsersAsync()
        {
            try
            {
                string json =
                    await ApiClientService.GetDataWithTokenAsync("users");

                var users = JsonSerializer.Deserialize<List<UserDto>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                dgvUsers.DataSource = null;
                dgvUsers.DataSource = users ?? new List<UserDto>();

                // Đổi tên tiêu đề các cột.
                if (dgvUsers.Columns["Id"] != null)
                    dgvUsers.Columns["Id"].HeaderText = "Mã ID";

                if (dgvUsers.Columns["Username"] != null)
                    dgvUsers.Columns["Username"].HeaderText = "Tên đăng nhập";

                if (dgvUsers.Columns["FullName"] != null)
                    dgvUsers.Columns["FullName"].HeaderText = "Họ và tên";

                if (dgvUsers.Columns["Role"] != null)
                    dgvUsers.Columns["Role"].HeaderText = "Vai trò";

                if (dgvUsers.Columns["IsActive"] != null)
                    dgvUsers.Columns["IsActive"].HeaderText = "Đang hoạt động";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi lấy danh sách tài khoản:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Thêm tài khoản mới.
        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string fullName = txtFullName.Text.Trim();
            string role = cboRole.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin tài khoản!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newUser = new
                {
                    Username = username,
                    Password = password,
                    FullName = fullName,
                    Role = role
                };

                var response =
                    await ApiClientService.PostWithTokenAsync("users", newUser);

                string responseBody =
                    await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Thêm tài khoản thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Xóa dữ liệu đã nhập.
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtFullName.Clear();
                    cboRole.SelectedIndex = 1;

                    await LoadUsersAsync();
                }
                else
                {
                    MessageBox.Show(
                        "Không thể thêm tài khoản.\n" + responseBody,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi thêm tài khoản:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Lấy tài khoản đang được chọn trên bảng.
        private UserDto GetSelectedUser()
        {
            if (dgvUsers.CurrentRow == null ||
                dgvUsers.CurrentRow.DataBoundItem is not UserDto user)
            {
                MessageBox.Show(
                    "Vui lòng chọn một tài khoản trong danh sách!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return null;
            }

            return user;
        }

        // Đặt lại mật khẩu tài khoản được chọn về 123456.
        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            UserDto selectedUser = GetSelectedUser();

            if (selectedUser == null)
                return;

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn đặt lại mật khẩu của tài khoản " +
                $"{selectedUser.Username} về 123456 không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var response =
                    await ApiClientService.PutWithTokenAsync(
                        $"users/{selectedUser.Id}/reset-password",
                        new { NewPassword = "123456" });

                string responseBody =
                    await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Đặt lại mật khẩu thành công!\nMật khẩu mới: 123456",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Không thể đặt lại mật khẩu.\n" + responseBody,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi đặt lại mật khẩu:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Chuyển trạng thái khóa/mở khóa tài khoản.
        private async void btnToggleLock_Click(object sender, EventArgs e)
        {
            UserDto selectedUser = GetSelectedUser();

            if (selectedUser == null)
                return;

            string action = selectedUser.IsActive
                ? "khóa"
                : "mở khóa";

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn {action} tài khoản " +
                $"{selectedUser.Username} không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var response =
                    await ApiClientService.PutWithTokenAsync(
                        $"users/{selectedUser.Id}/toggle-lock",
                        new { });

                string responseBody =
                    await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        $"Đã {action} tài khoản thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await LoadUsersAsync();
                }
                else
                {
                    MessageBox.Show(
                        $"Không thể {action} tài khoản.\n" + responseBody,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi {action} tài khoản:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Sửa họ tên và vai trò của tài khoản được chọn.
        private async void btnEditUser_Click(object sender, EventArgs e)
        {
            UserDto selectedUser = GetSelectedUser();

            if (selectedUser == null)
                return;

            // Hiển thị thông tin tài khoản lên các ô nhập.
            txtUsername.Text = selectedUser.Username;
            txtUsername.ReadOnly = true;

            txtPassword.Clear();
            txtPassword.ReadOnly = true;

            txtFullName.Text = selectedUser.FullName;
            cboRole.SelectedItem = selectedUser.Role;

            // Xác nhận trước khi lưu thay đổi.
            DialogResult confirm = MessageBox.Show(
                $"Bạn có muốn cập nhật tài khoản {selectedUser.Username} không?",
                "Xác nhận sửa tài khoản",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
            {
                txtUsername.ReadOnly = false;
                txtPassword.ReadOnly = false;
                return;
            }

            string fullName = txtFullName.Text.Trim();
            string role = cboRole.Text;

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ họ tên và vai trò!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsername.ReadOnly = false;
                txtPassword.ReadOnly = false;
                return;
            }

            try
            {
                var updatedUser = new
                {
                    FullName = fullName,
                    Role = role
                };

                var response =
                    await ApiClientService.PutWithTokenAsync(
                        $"users/{selectedUser.Id}",
                        updatedUser);

                string responseBody =
                    await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Cập nhật tài khoản thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await LoadUsersAsync();

                    // Đưa các ô nhập về trạng thái bình thường.
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtFullName.Clear();
                    cboRole.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show(
                        "Không thể cập nhật tài khoản.\n" + responseBody,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi cập nhật tài khoản:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                txtUsername.ReadOnly = false;
                txtPassword.ReadOnly = false;
            }
        }

        // Hiển thị thông tin tài khoản khi chọn một dòng trong bảng.
        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null ||
                dgvUsers.CurrentRow.DataBoundItem is not UserDto user)
            {
                return;
            }

            // Hiển thị thông tin tài khoản lên các ô nhập.
            txtUsername.Text = user.Username;
            txtFullName.Text = user.FullName;

            if (cboRole.Items.Contains(user.Role))
            {
                cboRole.SelectedItem = user.Role;
            }

            // Không hiển thị mật khẩu cũ.
            txtPassword.Clear();
        }


    }

    // DTO nhận dữ liệu danh sách tài khoản từ API.
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
