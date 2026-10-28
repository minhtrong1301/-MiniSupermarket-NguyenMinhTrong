
namespace MiniSupermarket.WinForms
{
    partial class FormUserManagement
    {
        private System.ComponentModel.IContainer components = null;

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
            panelInputs = new Panel();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblRole = new Label();
            cboRole = new ComboBox();
            btnAddUser = new Button();
            btnResetPassword = new Button();
            btnToggleLock = new Button();
            btnEditUser = new Button();
            dgvUsers = new DataGridView();

            panelInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();

            // 
            // panelInputs - KHU VUC NHAP THONG TIN
            // 
            panelInputs.BackColor = Color.White;
            panelInputs.Controls.Add(lblUsername);
            panelInputs.Controls.Add(txtUsername);
            panelInputs.Controls.Add(lblPassword);
            panelInputs.Controls.Add(txtPassword);
            panelInputs.Controls.Add(lblFullName);
            panelInputs.Controls.Add(txtFullName);
            panelInputs.Controls.Add(lblRole);
            panelInputs.Controls.Add(cboRole);
            panelInputs.Controls.Add(btnAddUser);
            panelInputs.Controls.Add(btnResetPassword);
            panelInputs.Controls.Add(btnToggleLock);
            panelInputs.Controls.Add(btnEditUser);
            panelInputs.Dock = DockStyle.Top;
            panelInputs.Location = new Point(0, 0);
            panelInputs.Name = "panelInputs";
            panelInputs.Padding = new Padding(24, 18, 24, 18);
            panelInputs.Size = new Size(1100, 200);
            panelInputs.TabIndex = 0;

            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(51, 65, 85);
            lblUsername.Location = new Point(24, 23);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(109, 19);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập";

            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtUsername.BackColor = Color.FromArgb(248, 250, 252);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 10.5F);
            txtUsername.Location = new Point(24, 48);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(235, 26);
            txtUsername.TabIndex = 1;

            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(51, 65, 85);
            lblPassword.Location = new Point(285, 23);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(72, 19);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu";

            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(248, 250, 252);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10.5F);
            txtPassword.Location = new Point(285, 48);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(235, 26);
            txtPassword.TabIndex = 3;

            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(51, 65, 85);
            lblFullName.Location = new Point(545, 23);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(74, 19);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Họ và tên";

            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.FromArgb(248, 250, 252);
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Segoe UI", 10.5F);
            txtFullName.Location = new Point(545, 48);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(235, 26);
            txtFullName.TabIndex = 5;

            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(51, 65, 85);
            lblRole.Location = new Point(805, 23);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(53, 19);
            lblRole.TabIndex = 6;
            lblRole.Text = "Vai trò";

            // 
            // cboRole
            // 
            cboRole.BackColor = Color.FromArgb(248, 250, 252);
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 10.5F);
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(805, 48);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(245, 27);
            cboRole.TabIndex = 7;

            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.FromArgb(22, 163, 74);
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(21, 128, 61);
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(24, 105);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(180, 40);
            btnAddUser.TabIndex = 8;
            btnAddUser.Text = "+  Thêm tài khoản";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;

            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.FromArgb(37, 99, 235);
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(29, 78, 216);
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.Location = new Point(216, 105);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(190, 40);
            btnResetPassword.TabIndex = 9;
            btnResetPassword.Text = "Đặt lại mật khẩu";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;

            // 
            // btnToggleLock
            // 
            btnToggleLock.BackColor = Color.FromArgb(217, 119, 6);
            btnToggleLock.FlatAppearance.BorderSize = 0;
            btnToggleLock.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(180, 83, 9);
            btnToggleLock.FlatStyle = FlatStyle.Flat;
            btnToggleLock.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnToggleLock.ForeColor = Color.White;
            btnToggleLock.Location = new Point(418, 105);
            btnToggleLock.Name = "btnToggleLock";
            btnToggleLock.Size = new Size(190, 40);
            btnToggleLock.TabIndex = 10;
            btnToggleLock.Text = "Khóa / Mở khóa";
            btnToggleLock.UseVisualStyleBackColor = false;
            btnToggleLock.Click += btnToggleLock_Click;

            // 
            // btnEditUser
            // 
            btnEditUser.BackColor = Color.FromArgb(71, 85, 105);
            btnEditUser.FlatAppearance.BorderSize = 0;
            btnEditUser.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(51, 65, 85);
            btnEditUser.FlatStyle = FlatStyle.Flat;
            btnEditUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEditUser.ForeColor = Color.White;
            btnEditUser.Location = new Point(620, 105);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(180, 40);
            btnEditUser.TabIndex = 11;
            btnEditUser.Text = "Cập nhật tài khoản";
            btnEditUser.UseVisualStyleBackColor = false;
            btnEditUser.Click += btnEditUser_Click;

            // 
            // dgvUsers - DANH SACH TAI KHOAN
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.FromArgb(245, 247, 251);
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;
            dgvUsers.ColumnHeadersHeight = 46;
            dgvUsers.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.FromArgb(226, 232, 240);
            dgvUsers.Location = new Point(0, 200);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1100, 460);
            dgvUsers.TabIndex = 1;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;

            // Tiêu đề bảng
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(30, 41, 59);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvUsers.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            dgvUsers.ColumnHeadersDefaultCellStyle.Padding =
                new Padding(10, 0, 5, 0);

            // Nội dung bảng
            dgvUsers.DefaultCellStyle.BackColor = Color.White;
            dgvUsers.DefaultCellStyle.ForeColor =
                Color.FromArgb(51, 65, 85);
            dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvUsers.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(219, 234, 254);
            dgvUsers.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(30, 41, 59);
            dgvUsers.DefaultCellStyle.Padding =
                new Padding(10, 5, 5, 5);
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252);
            dgvUsers.RowTemplate.Height = 40;

            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(1100, 660);
            MinimumSize = new Size(1000, 600);
            Font = new Font("Segoe UI", 9F);
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(dgvUsers);
            Controls.Add(panelInputs);
            Name = "FormUserManagement";
            Text = "MiniSupermarket | Quản lý tài khoản";
            Load += FormUserManagement_Load;

            panelInputs.ResumeLayout(false);
            panelInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelInputs;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnToggleLock;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnEditUser;
    }
}
