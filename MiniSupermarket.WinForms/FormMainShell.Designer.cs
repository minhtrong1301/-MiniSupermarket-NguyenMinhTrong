namespace MiniSupermarket.WinForms
{
    partial class FormMainShell
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelTopHeader;
        private System.Windows.Forms.Panel panelContent; // Đã đổi tên chuẩn với code-behind
        private System.Windows.Forms.Panel panelUserFooter;

        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblHeaderTitle; // Đã đổi tên chuẩn với code-behind
        private System.Windows.Forms.Label lblUserInfo;

        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUserManage;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelTopHeader = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelUserFooter = new System.Windows.Forms.Panel();

            this.lblLogo = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();

            this.btnPOS = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnUserManage = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // FormMainShell
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Bán lẻ & Tồn kho Siêu thị Mini";
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(24, 30, 48);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Width = 230;

            // panelTopHeader
            this.panelTopHeader.BackColor = System.Drawing.Color.White;
            this.panelTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopHeader.Height = 60;

            // panelContent
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(244, 245, 247);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;

            // lblHeaderTitle
            this.lblHeaderTitle.Text = "BÀN LÀM VIỆC HỆ THỐNG";
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 16);

            // lblUserInfo
            this.lblUserInfo.Text = "Xin chào: ...";
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblUserInfo.Location = new System.Drawing.Point(700, 20);

            this.panelTopHeader.Controls.Add(this.lblHeaderTitle);
            this.panelTopHeader.Controls.Add(this.lblUserInfo);

            // Logo
            this.lblLogo.Text = "🛒 MiniMart POS";
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogo.Height = 60;
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Footer chứa Đăng xuất
            this.panelUserFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUserFooter.Height = 60;

            this.btnLogout.Text = "🚪 Đăng xuất";
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.panelUserFooter.Controls.Add(this.btnLogout);

            // Nút Menu Sidebar (Thêm theo thứ tự từ dưới lên do Dock = Top)
            ConfigureButton(this.btnUserManage, "🛡 Quản trị Tài khoản", this.btnUserManage_Click);
            ConfigureButton(this.btnReports, "📊 Báo cáo Doanh thu", this.btnReports_Click);
            ConfigureButton(this.btnCustomer, "👥 Quản lý Khách hàng", this.btnCustomer_Click);
            ConfigureButton(this.btnProduct, "📦 Quản lý Sản phẩm", this.btnProduct_Click);
            ConfigureButton(this.btnCategory, "📁 Quản lý Danh mục", this.btnCategory_Click);
            ConfigureButton(this.btnPOS, "🛒 Bán hàng (POS)", this.btnPOS_Click);

            this.panelSidebar.Controls.Add(this.btnUserManage);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnCustomer);
            this.panelSidebar.Controls.Add(this.btnProduct);
            this.panelSidebar.Controls.Add(this.btnCategory);
            this.panelSidebar.Controls.Add(this.btnPOS);
            this.panelSidebar.Controls.Add(this.lblLogo);
            this.panelSidebar.Controls.Add(this.panelUserFooter);

            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTopHeader);
            this.Controls.Add(this.panelSidebar);

            this.Load += new System.EventHandler(this.FormMainShell_Load);
            this.ResumeLayout(false);
        }

        private void ConfigureButton(System.Windows.Forms.Button btn, string text, System.EventHandler clickEvent)
        {
            btn.Text = "  " + text;
            btn.Dock = System.Windows.Forms.DockStyle.Top;
            btn.Height = 45;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = System.Drawing.Color.White;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Click += clickEvent;
        }

        #endregion
    }
}