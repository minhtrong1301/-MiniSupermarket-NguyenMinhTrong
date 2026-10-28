
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormCustomerManagement : Form
    {
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7195/")
        };

        // Mỗi trang hiển thị 5 khách hàng.
        private const int PageSize = 5;
        private int _currentPage = 1;
        private int _totalPages = 0;
        private string _currentKeyword = string.Empty;

        public FormCustomerManagement()
        {
            InitializeComponent();
        }

        private async void FormCustomerManagement_Load(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
        }

        // Tải dữ liệu của trang hiện tại từ API.
        private async Task LoadCustomersAsync()
        {
            try
            {
                string url =
                    $"api/customers/paged?pageNumber={_currentPage}" +
                    $"&pageSize={PageSize}" +
                    $"&keyword={Uri.EscapeDataString(_currentKeyword)}";

                var result =
                    await _httpClient.GetFromJsonAsync<PagedResultDto<CustomerDto>>(url);

                if (result == null)
                {
                    dgvCustomers.DataSource = null;
                    _totalPages = 0;
                    UpdatePaginationControls();
                    return;
                }

                // Nếu dữ liệu bị thay đổi làm giảm số trang,
                // quay về trang hợp lệ cuối cùng.
                if (result.TotalPages > 0 && _currentPage > result.TotalPages)
                {
                    _currentPage = result.TotalPages;
                    await LoadCustomersAsync();
                    return;
                }

                _totalPages = result.TotalPages;
                _currentPage = result.CurrentPage;

                dgvCustomers.DataSource = result.Items;

                UpdatePaginationControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách khách hàng.\n" +
                    "Hãy kiểm tra API và endpoint phân trang.\n\n" + ex.Message,
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Cập nhật thông tin trang và trạng thái nút.
        private void UpdatePaginationControls()
        {
            lblPageInfo.Text = _totalPages == 0
                ? "Trang 0/0"
                : $"Trang {_currentPage}/{_totalPages}";

            btnPrevious.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;
        }

        // Chuyển về trang trước.
        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage <= 1)
                return;

            _currentPage--;
            await LoadCustomersAsync();
        }

        // Chuyển sang trang sau.
        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage >= _totalPages)
                return;

            _currentPage++;
            await LoadCustomersAsync();
        }

        // Hiển thị khách hàng được chọn lên các ô nhập liệu.
        private void dgvCustomers_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                dgvCustomers.Rows[e.RowIndex].DataBoundItem is not CustomerDto selected)
                return;

            txtCustomerId.Text = selected.CustomerId.ToString();
            txtCustomerName.Text = selected.CustomerName;
            txtPhoneNumber.Text = selected.PhoneNumber;
            txtAddress.Text = selected.Address ?? string.Empty;
            txtRewardPoints.Text = selected.RewardPoints.ToString();
            txtMembershipRank.Text = selected.MembershipRank;
        }

        // Tải lại danh sách và bỏ điều kiện tìm kiếm.
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            _currentKeyword = string.Empty;
            txtSearch.Clear();
            _currentPage = 1;

            await LoadCustomersAsync();
        }

        // Thêm khách hàng.
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.");
                txtCustomerName.Focus();
                return;
            }

            var newCustomer = new CustomerDto
            {
                CustomerName = txtCustomerName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                RewardPoints = int.TryParse(
                    txtRewardPoints.Text, out int points) ? points : 0,
                MembershipRank = string.IsNullOrWhiteSpace(txtMembershipRank.Text)
                    ? "Chuẩn"
                    : txtMembershipRank.Text.Trim()
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync(
                    "api/customers", newCustomer);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm khách hàng thành công!");

                    _currentPage = 1;
                    ClearInput();
                    await LoadCustomersAsync();
                }
                else
                {
                    MessageBox.Show(
                        $"Thêm khách hàng thất bại: {(int)response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}");
            }
        }

        // Cập nhật khách hàng.
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật.");
                return;
            }

            var updateCustomer = new CustomerDto
            {
                CustomerId = id,
                CustomerName = txtCustomerName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                RewardPoints = int.TryParse(
                    txtRewardPoints.Text, out int points) ? points : 0,
                MembershipRank = string.IsNullOrWhiteSpace(txtMembershipRank.Text)
                    ? "Chuẩn"
                    : txtMembershipRank.Text.Trim()
            };

            try
            {
                var response = await _httpClient.PutAsJsonAsync(
                    $"api/customers/{id}", updateCustomer);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!");
                    ClearInput();
                    await LoadCustomersAsync();
                }
                else
                {
                    MessageBox.Show(
                        $"Cập nhật thất bại: {(int)response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}");
            }
        }

        // Xóa khách hàng.
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.");
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa khách hàng này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var response = await _httpClient.DeleteAsync(
                    $"api/customers/{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa khách hàng thành công!");
                    ClearInput();
                    await LoadCustomersAsync();
                }
                else
                {
                    MessageBox.Show(
                        $"Xóa thất bại: {(int)response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}");
            }
        }

        // Tìm kiếm và bắt đầu từ trang đầu tiên.
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _currentKeyword = txtSearch.Text.Trim();
            _currentPage = 1;

            await LoadCustomersAsync();
        }

        private void ClearInput()
        {
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtRewardPoints.Text = "0";
            txtMembershipRank.Text = "Chuẩn";
        }

        private void FormCustomerManagement_Load_1(
            object sender, EventArgs e)
        {
            // Giữ lại nếu Designer còn đăng ký sự kiện này.
        }

        private void dgvCustomers_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
            // Giữ lại nếu Designer còn đăng ký sự kiện này.
        }
    }

    // DTO phân trang dùng chung trong project WinForms.
    // Chỉ giữ một định nghĩa PagedResultDto<T> trong toàn project.
    public class PagedResultDto<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new List<T>();
    }

    // DTO khách hàng phía WinForms.
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
        public int RewardPoints { get; set; }
        public string MembershipRank { get; set; } = "Chuẩn";
    }
}
