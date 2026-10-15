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
            // panelInputs
            // 
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
            panelInputs.Size = new Size(950, 150);
            panelInputs.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(20, 20);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(88, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(120, 17);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(180, 23);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(320, 20);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(390, 17);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(180, 23);
            txtPassword.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(20, 60);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(61, 15);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(120, 57);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(180, 23);
            txtFullName.TabIndex = 5;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(320, 60);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(43, 15);
            lblRole.TabIndex = 6;
            lblRole.Text = "Vai trò:";
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Location = new Point(390, 57);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(180, 23);
            cboRole.TabIndex = 7;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(120, 100);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(120, 32);
            btnAddUser.TabIndex = 8;
            btnAddUser.Text = "Thêm Tài Khoản";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Location = new Point(250, 100);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(130, 32);
            btnResetPassword.TabIndex = 9;
            btnResetPassword.Text = "Đặt Lại Mật Khẩu";
            btnResetPassword.UseVisualStyleBackColor = true;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnToggleLock
            // 
            btnToggleLock.Location = new Point(390, 100);
            btnToggleLock.Name = "btnToggleLock";
            btnToggleLock.Size = new Size(140, 32);
            btnToggleLock.TabIndex = 10;
            btnToggleLock.Text = "Khóa / Mở Khóa";
            btnToggleLock.UseVisualStyleBackColor = true;
            btnToggleLock.Click += btnToggleLock_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Location = new Point(540, 100);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(120, 32);
            btnEditUser.TabIndex = 11;
            btnEditUser.Text = "Sửa Tài Khoản";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(0, 150);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(950, 400);
            dgvUsers.TabIndex = 1;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            // 
            // FormUserManagement
            // 
            ClientSize = new Size(950, 550);
            Controls.Add(dgvUsers);
            Controls.Add(panelInputs);
            Name = "FormUserManagement";
            Text = "Quản Lý Tài Khoản";
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