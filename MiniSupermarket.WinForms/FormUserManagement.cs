//using System;
//using System.Collections.Generic;
//using System.Net.Http.Json;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using MiniSupermarket.API.Models;

//namespace MiniSupermarket.WinForms
//{
//    public partial class FormUserManagement : Form
//    {
//        public FormUserManagement()
//        {
//            InitializeComponent();
//            cboRole.Items.AddRange(new string[] { "Admin", "Cashier", "Warehouse" });
//            cboRole.SelectedIndex = 1;
//        }

//        private async void FormUserManagement_Load(object sender, EventArgs e)
//        {
//            await LoadUsersAsync();
//        }

//        // 1. Tải danh sách người dùng
//        private async Task LoadUsersAsync()
//        {
//            try
//            {
//                var users = await ApiClientService.Client.GetFromJsonAsync<List<UserDto>>("users");
//                dgvUsers.DataSource = users;

//                if (dgvUsers.Columns["Id"] != null) dgvUsers.Columns["Id"].HeaderText = "Mã ID";
//                if (dgvUsers.Columns["Username"] != null) dgvUsers.Columns["Username"].HeaderText = "Tên đăng nhập";
//                if (dgvUsers.Columns["FullName"] != null) dgvUsers.Columns["FullName"].HeaderText = "Họ và tên";
//                if (dgvUsers.Columns["Role"] != null) dgvUsers.Columns["Role"].HeaderText = "Chức vụ";
//                if (dgvUsers.Columns["IsActive"] != null) dgvUsers.Columns["IsActive"].HeaderText = "Trạng thái (Hoạt động)";
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi lấy danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // 2. Thêm người dùng mới
//        private async void btnAddUser_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
//            {
//                MessageBox.Show("Tên đăng nhập và mật khẩu không được trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            var newUser = new
//            {
//                Username = txtUsername.Text.Trim(),
//                Password = txtPassword.Text.Trim(),
//                FullName = txtFullName.Text.Trim(),
//                Role = cboRole.SelectedItem?.ToString() ?? "Cashier"
//            };

//            var res = await ApiClientService.Client.PostAsJsonAsync("users", newUser);
//            if (res.IsSuccessStatusCode)
//            {
//                MessageBox.Show("Tạo tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                await LoadUsersAsync();
//                txtUsername.Clear();
//                txtPassword.Clear();
//                txtFullName.Clear();
//            }
//            else
//            {
//                MessageBox.Show("Tên đăng nhập đã tồn tại hoặc có lỗi xảy ra!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }

//        // 3. Đặt lại mật khẩu (Reset Password về mặc định 123456)
//        private async void btnResetPassword_Click(object sender, EventArgs e)
//        {
//            if (dgvUsers.CurrentRow?.DataBoundItem is UserDto selectedUser)
//            {
//                var confirm = MessageBox.Show($"Bạn có chắc muốn đặt lại mật khẩu cho tài khoản '{selectedUser.Username}' về '123456'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//                if (confirm == DialogResult.Yes)
//                {
//                    var res = await ApiClientService.Client.PostAsJsonAsync($"users/{selectedUser.Id}/reset-password", new { NewPassword = "123456" });
//                    if (res.IsSuccessStatusCode)
//                    {
//                        MessageBox.Show("Đặt lại mật khẩu thành công! Mật khẩu mới là 123456", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    }
//                    else
//                    {
//                        MessageBox.Show("Đặt lại mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                }
//            }
//            else
//            {
//                MessageBox.Show("Vui lòng chọn 1 tài khoản trong danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }

//        // 4. Khóa / Mở khóa tài khoản
//        private async void btnToggleLock_Click(object sender, EventArgs e)
//        {
//            if (dgvUsers.CurrentRow?.DataBoundItem is UserDto selectedUser)
//            {
//                string action = selectedUser.IsActive ? "Khóa" : "Mở khóa";
//                var confirm = MessageBox.Show($"Bạn có chắc muốn {action} tài khoản '{selectedUser.Username}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//                if (confirm == DialogResult.Yes)
//                {
//                    var res = await ApiClientService.Client.PutAsJsonAsync($"users/{selectedUser.Id}/toggle-status", new { });
//                    if (res.IsSuccessStatusCode)
//                    {
//                        MessageBox.Show($"{action} tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        await LoadUsersAsync();
//                    }
//                    else
//                    {
//                        MessageBox.Show($"{action} tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                }
//            }
//            else
//            {
//                MessageBox.Show("Vui lòng chọn 1 tài khoản trong danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }
//    }

//    public class UserDto
//    {
//        public int Id { get; set; }
//        public string Username { get; set; } = string.Empty;
//        public string FullName { get; set; } = string.Empty;
//        public string Role { get; set; } = string.Empty;
//        public bool IsActive { get; set; }
//    }
//}