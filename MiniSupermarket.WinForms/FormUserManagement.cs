
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormUserManagement : Form
    {
        // Số tài khoản hiển thị trên mỗi trang.
        private const int PageSize = 5;

        // Trang hiện tại và tổng số trang.
        private int _currentPage = 1;
        private int _totalPages = 0;
        private int _totalItems = 0;

        // Từ khóa tìm kiếm hiện tại.
        private string _currentKeyword = string.Empty;

        private readonly JsonSerializerOptions _jsonOptions =
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

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
            UpdatePaginationControls();
        }

        // Tự động tải trang đầu tiên khi mở form.
        private async void FormUserManagement_Load(object sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadUsersAsync();
        }

        // Tải danh sách tài khoản theo trang và từ khóa tìm kiếm.
        private async Task LoadUsersAsync()
        {
            try
            {
                string keyword = Uri.EscapeDataString(_currentKeyword);

                string endpoint =
                    $"users/paged?pageNumber={_currentPage}" +
                    $"&pageSize={PageSize}&keyword={keyword}";

                string json =
                    await ApiClientService.GetDataWithTokenAsync(endpoint);

                var result =
                    JsonSerializer.Deserialize<PagedResultDto<UserDto>>(
                        json, _jsonOptions);

                if (result == null)
                {
                    MessageBox.Show(
                        "API không trả về dữ liệu hợp lệ.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật thông tin phân trang.
                _currentPage = result.CurrentPage;
                _totalPages = result.TotalPages;
                _totalItems = result.TotalItems;

                // Hiển thị danh sách tài khoản.
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = result.Items ?? new List<UserDto>();

                // Đổi tên tiêu đề cột.
                if (dgvUsers.Columns["Id"] != null)
                    dgvUsers.Columns["Id"].HeaderText = "Mã ID";

                if (dgvUsers.Columns["Username"] != null)
                    dgvUsers.Columns["Username"].HeaderText = "Tên đăng nhập";

                if (dgvUsers.Columns["FullName"] != null)
                    dgvUsers.Columns["FullName"].HeaderText = "Họ và tên";

                if (dgvUsers.Columns["Role"] != null)
                    dgvUsers.Columns["Role"].HeaderText = "Vai trò";

                if (dgvUsers.Columns["IsActive"] != null)
                {
                    dgvUsers.Columns["IsActive"].HeaderText =
                        "Đang hoạt động";

                    dgvUsers.Columns["IsActive"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }

                UpdatePaginationControls();
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

        // Cập nhật thông tin trang và trạng thái nút.
        private void UpdatePaginationControls()
        {
            int displayedPage = _totalPages == 0 ? 0 : _currentPage;

            lblPageInfo.Text =
                $"Trang {displayedPage}/{_totalPages}";

            lblTotalUsers.Text =
                $"Tổng số tài khoản: {_totalItems}";

            btnPrevious.Enabled =
                _totalPages > 0 && _currentPage > 1;

            btnNext.Enabled =
                _totalPages > 0 && _currentPage < _totalPages;
        }

        // Chuyển về trang trước.
        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage <= 1)
                return;

            _currentPage--;
            await LoadUsersAsync();
        }

        // Chuyển sang trang tiếp theo.
        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage >= _totalPages)
                return;

            _currentPage++;
            await LoadUsersAsync();
        }

        // Tìm kiếm tài khoản.
        private async void btnSearchUser_Click(object sender, EventArgs e)
        {
            _currentKeyword = txtSearchUser.Text.Trim();
            _currentPage = 1;

            await LoadUsersAsync();
        }

        // Xóa từ khóa tìm kiếm và tải lại danh sách.
        private async void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchUser.Clear();
            _currentKeyword = string.Empty;
            _currentPage = 1;

            await LoadUsersAsync();
        }

        // Nhấn Enter trong ô tìm kiếm để tìm.
        private async void txtSearchUser_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _currentKeyword = txtSearchUser.Text.Trim();
                _currentPage = 1;

                await LoadUsersAsync();
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
                    await ApiClientService.PostWithTokenAsync(
                        "users", newUser);

                string responseBody =
                    await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Thêm tài khoản thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearInput();

                    // Tài khoản mới có thể nằm ở trang đầu.
                    _currentPage = 1;
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
        // Dấu ? cho phép hàm trả về null khi chưa chọn tài khoản.
        private UserDto? GetSelectedUser()
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
            UserDto? selectedUser = GetSelectedUser();

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

        // Khóa hoặc mở khóa tài khoản.
        private async void btnToggleLock_Click(object sender, EventArgs e)
        {
            UserDto? selectedUser = GetSelectedUser();

            if (selectedUser == null)
                return;

            string action = selectedUser.IsActive ? "khóa" : "mở khóa";

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

        // Cập nhật họ tên và vai trò tài khoản.
        private async void btnEditUser_Click(object sender, EventArgs e)
        {
            UserDto? selectedUser = GetSelectedUser();

            if (selectedUser == null)
                return;

            txtUsername.Text = selectedUser.Username;
            txtUsername.ReadOnly = true;

            txtPassword.Clear();
            txtPassword.ReadOnly = true;

            txtFullName.Text = selectedUser.FullName;
            cboRole.SelectedItem = selectedUser.Role;

            try
            {
                DialogResult confirm = MessageBox.Show(
                    "Hãy chỉnh sửa họ tên và vai trò trong các ô nhập, " +
                    $"sau đó chọn Yes để lưu tài khoản {selectedUser.Username}.",
                    "Xác nhận cập nhật",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

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
                    return;
                }

                var updatedUser = new
                {
                    FullName = fullName,
                    Role = role
                };

                var response =
                    await ApiClientService.PutWithTokenAsync(
                        $"users/{selectedUser.Id}", updatedUser);

                string responseBody =
                    await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Cập nhật tài khoản thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearInput();
                    await LoadUsersAsync();
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

        // Hiển thị thông tin tài khoản được chọn.
        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null ||
                dgvUsers.CurrentRow.DataBoundItem is not UserDto user)
            {
                return;
            }

            txtUsername.Text = user.Username;
            txtFullName.Text = user.FullName;

            if (cboRole.Items.Contains(user.Role))
                cboRole.SelectedItem = user.Role;

            // Không hiển thị mật khẩu cũ.
            txtPassword.Clear();
        }

        // Xóa các ô nhập sau khi thao tác thành công.
        private void ClearInput()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();

            txtUsername.ReadOnly = false;
            txtPassword.ReadOnly = false;

            if (cboRole.Items.Count > 1)
                cboRole.SelectedIndex = 1;
        }

        private void panelInputs_Paint(object sender, PaintEventArgs e)
        {
            // Giữ lại sự kiện Paint của Designer.
        }
    }

    // DTO tài khoản dùng để nhận dữ liệu từ API.
    // Chỉ giữ một định nghĩa UserDto trong namespace này.
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
