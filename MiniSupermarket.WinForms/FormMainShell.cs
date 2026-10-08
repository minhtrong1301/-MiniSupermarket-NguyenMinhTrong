using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormMainShell : Form
    {
        private Form _activeForm = null;
        private Button _currentButton = null;

        public FormMainShell()
        {
            InitializeComponent();
        }

        private void FormMainShell_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin mặc định
            if (lblUserInfo != null)
            {
                lblUserInfo.Text = "Chế độ Test (Không dùng User)";
            }

            // Mặc định mở màn hình Bán hàng (POS) khi vừa chạy
            btnPOS.PerformClick();
        }

        #region Hàm Nhúng Form Con (OpenChildForm)
        /// <summary>
        /// Mở một Form con nhúng vào panelContent chính của FormMainShell
        /// </summary>
        private void OpenChildForm(Form childForm, string titleText, object senderBtn)
        {
            // Nếu có Form đang mở thì đóng lại để giải phóng tài nguyên
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            // Đổi màu làm nổi bật nút đang được chọn trên Sidebar
            ActivateButton(senderBtn);

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Xóa các control cũ và thêm Form mới vào panelContent
            panelContent.Controls.Clear();
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();

            // Cập nhật tiêu đề trang trên Header Bar
            if (lblHeaderTitle != null)
            {
                lblHeaderTitle.Text = titleText;
            }
        }

        /// <summary>
        /// Đổi màu hiệu ứng Active cho nút bấm trên Sidebar
        /// </summary>
        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null && senderBtn is Button btn)
            {
                // Trả màu nút trước đó về mặc định
                if (_currentButton != null)
                {
                    _currentButton.BackColor = Color.FromArgb(35, 40, 45);
                    _currentButton.ForeColor = Color.White;
                }

                // Đổi màu nút vừa được bấm
                _currentButton = btn;
                _currentButton.BackColor = Color.FromArgb(0, 122, 204);
                _currentButton.ForeColor = Color.White;
            }
        }
        #endregion

        #region Sự Kiện Bấm Nút Trực Tiếp Trên Sidebar

        // 1. Quản lý Danh mục
        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCategoryManagement(), "QUẢN LÝ DANH MỤC NHÓM HÀNG", btnCategory);
        }

        // 2. Bán hàng POS
        private void btnPOS_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormPOS(), "HỆ THỐNG QUẦY BÁN HÀNG & THU NGÂN (POS)", btnPOS);
        }

        // 3. Quản lý Sản phẩm & Kho hàng
        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormProductManagement(), "QUẢN LÝ THÔNG TIN SẢN PHẨM & KHO HÀNG", btnProduct);
        }

        // 4. Quản lý Khách hàng
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCustomerManagement(), "QUẢN LÝ KHÁCH HÀNG & TÍCH ĐIỂM", btnCustomer);
        }

        // 5. Báo cáo Doanh thu
        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQuickReport(), "BÁO CÁO DOANH THU & HIỆU SUẤT CA BÁN", btnReports);
        }

        // 6. Quản trị Tài khoản (Đang bỏ qua để test)
        private void btnUserManage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý User hiện đang tạm tắt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 7. Thoát ứng dụng
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion
    }
}