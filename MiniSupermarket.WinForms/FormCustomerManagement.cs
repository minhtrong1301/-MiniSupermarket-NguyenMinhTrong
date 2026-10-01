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
            BaseAddress = new Uri("https://localhost:7195/") // Sửa lại đúng Port API của bạn
        };

        public FormCustomerManagement()
        {
            InitializeComponent();
        }

        private async void FormCustomerManagement_Load(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
        }

        // 1. Lấy danh sách khách hàng
        private async Task LoadCustomersAsync()
        {
            try
            {
                var customers = await _httpClient.GetFromJsonAsync<List<CustomerDto>>("api/customers");
                dgvCustomers.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Click trên DataGridView để hiển thị lên Form
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomers.Rows[e.RowIndex].DataBoundItem is CustomerDto selected)
            {
                txtCustomerId.Text = selected.CustomerId.ToString();
                txtCustomerName.Text = selected.CustomerName;
                txtPhoneNumber.Text = selected.PhoneNumber;
                txtAddress.Text = selected.Address;
                txtRewardPoints.Text = selected.RewardPoints.ToString();
                txtMembershipRank.Text = selected.MembershipRank;
            }
        }

        // 2. Nút Tải lại (btnLoad)
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
        }

        // 3. Nút Thêm (btnAdd)
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newCustomer = new CustomerDto
            {
                CustomerName = txtCustomerName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Address = txtAddress.Text,
                RewardPoints = int.TryParse(txtRewardPoints.Text, out int pts) ? pts : 0,
                MembershipRank = string.IsNullOrWhiteSpace(txtMembershipRank.Text) ? "Chuẩn" : txtMembershipRank.Text
            };

            var response = await _httpClient.PostAsJsonAsync("api/customers", newCustomer);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo");
                await LoadCustomersAsync();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Lỗi");
            }
        }

        // 4. Nút Sửa (btnUpdate)
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int id)) return;

            var updateCustomer = new CustomerDto
            {
                CustomerId = id,
                CustomerName = txtCustomerName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Address = txtAddress.Text,
                RewardPoints = int.TryParse(txtRewardPoints.Text, out int pts) ? pts : 0,
                MembershipRank = txtMembershipRank.Text
            };

            var response = await _httpClient.PutAsJsonAsync($"api/customers/{id}", updateCustomer);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                await LoadCustomersAsync();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi");
            }
        }

        // 5. Nút Xóa (btnDelete)
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int id)) return;

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var response = await _httpClient.DeleteAsync($"api/customers/{id}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    await LoadCustomersAsync();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi");
                }
            }
        }

        // 6. Nút Tìm kiếm (btnSearch)
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(kw))
            {
                await LoadCustomersAsync();
                return;
            }

            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<CustomerDto>>($"api/customers/search?keyword={kw}");
                dgvCustomers.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không tìm thấy kết quả: {ex.Message}", "Thông báo");
            }
        }

        private void FormCustomerManagement_Load_1(object sender, EventArgs e)
        {

        }
    }

    // DTO hứng dữ liệu phía WinForms
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