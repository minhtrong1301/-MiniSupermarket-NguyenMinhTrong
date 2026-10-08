//namespace MiniSupermarket.WinForms
//{
//    partial class FormUserManagement
//    {
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        private void InitializeComponent()
//        {
//            this.panelInputs = new System.Windows.Forms.Panel();
//            this.lblUsername = new System.Windows.Forms.Label();
//            this.txtUsername = new System.Windows.Forms.TextBox();
//            this.lblPassword = new System.Windows.Forms.Label();
//            this.txtPassword = new System.Windows.Forms.TextBox();
//            this.lblFullName = new System.Windows.Forms.Label();
//            this.txtFullName = new System.Windows.Forms.TextBox();
//            this.lblRole = new System.Windows.Forms.Label();
//            this.cboRole = new System.Windows.Forms.ComboBox();
//            this.btnAddUser = new System.Windows.Forms.Button();
//            this.btnResetPassword = new System.Windows.Forms.Button();
//            this.btnToggleLock = new System.Windows.Forms.Button();
//            this.dgvUsers = new System.Windows.Forms.DataGridView();
//            this.panelInputs.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
//            this.SuspendLayout();

//            // panelInputs
//            this.panelInputs.Controls.Add(this.lblUsername);
//            this.panelInputs.Controls.Add(this.txtUsername);
//            this.panelInputs.Controls.Add(this.lblPassword);
//            this.panelInputs.Controls.Add(this.txtPassword);
//            this.panelInputs.Controls.Add(this.lblFullName);
//            this.panelInputs.Controls.Add(this.txtFullName);
//            this.panelInputs.Controls.Add(this.lblRole);
//            this.panelInputs.Controls.Add(this.cboRole);
//            this.panelInputs.Controls.Add(this.btnAddUser);
//            this.panelInputs.Controls.Add(this.btnResetPassword);
//            this.panelInputs.Controls.Add(this.btnToggleLock);
//            this.panelInputs.Dock = System.Windows.Forms.DockStyle.Top;
//            this.panelInputs.Location = new System.Drawing.Point(0, 0);
//            this.panelInputs.Name = "panelInputs";
//            this.panelInputs.Size = new System.Drawing.Size(950, 150);
//            this.panelInputs.TabIndex = 0;

//            // lblUsername & txtUsername
//            this.lblUsername.AutoSize = true;
//            this.lblUsername.Location = new System.Drawing.Point(20, 20);
//            this.lblUsername.Text = "Tên đăng nhập:";
//            this.txtUsername.Location = new System.Drawing.Point(120, 17);
//            this.txtUsername.Size = new System.Drawing.Size(180, 23);

//            // lblPassword & txtPassword
//            this.lblPassword.AutoSize = true;
//            this.lblPassword.Location = new System.Drawing.Point(320, 20);
//            this.lblPassword.Text = "Mật khẩu:";
//            this.txtPassword.Location = new System.Drawing.Point(390, 17);
//            this.txtPassword.PasswordChar = '*';
//            this.txtPassword.Size = new System.Drawing.Size(180, 23);

//            // lblFullName & txtFullName
//            this.lblFullName.AutoSize = true;
//            this.lblFullName.Location = new System.Drawing.Point(20, 60);
//            this.lblFullName.Text = "Họ và tên:";
//            this.txtFullName.Location = new System.Drawing.Point(120, 57);
//            this.txtFullName.Size = new System.Drawing.Size(180, 23);

//            // lblRole & cboRole
//            this.lblRole.AutoSize = true;
//            this.lblRole.Location = new System.Drawing.Point(320, 60);
//            this.lblRole.Text = "Vai trò:";
//            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cboRole.Location = new System.Drawing.Point(390, 57);
//            this.cboRole.Size = new System.Drawing.Size(180, 23);

//            // Nút Thêm User
//            this.btnAddUser.Location = new System.Drawing.Point(120, 100);
//            this.btnAddUser.Size = new System.Drawing.Size(120, 32);
//            this.btnAddUser.Text = "Thêm Tài Khoản";
//            this.btnAddUser.UseVisualStyleBackColor = true;
//            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);

//            // Nút Reset Mật Khẩu
//            this.btnResetPassword.Location = new System.Drawing.Point(250, 100);
//            this.btnResetPassword.Size = new System.Drawing.Size(130, 32);
//            this.btnResetPassword.Text = "Đặt Lại Mật Khẩu";
//            this.btnResetPassword.UseVisualStyleBackColor = true;
//            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);

//            // Nút Khóa / Mở Khóa
//            this.btnToggleLock.Location = new System.Drawing.Point(390, 100);
//            this.btnToggleLock.Size = new System.Drawing.Size(140, 32);
//            this.btnToggleLock.Text = "Khóa / Mở Khóa";
//            this.btnToggleLock.UseVisualStyleBackColor = true;
//            this.btnToggleLock.Click += new System.EventHandler(this.btnToggleLock_Click);

//            // dgvUsers
//            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.dgvUsers.Location = new System.Drawing.Point(0, 150);
//            this.dgvUsers.MultiSelect = false;
//            this.dgvUsers.Name = "dgvUsers";
//            this.dgvUsers.ReadOnly = true;
//            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvUsers.Size = new System.Drawing.Size(950, 400);
//            this.dgvUsers.TabIndex = 1;

//            // FormUserManagement
//            this.ClientSize = new System.Drawing.Size(950, 550);
//            this.Controls.Add(this.dgvUsers);
//            this.Controls.Add(this.panelInputs);
//            this.Name = "FormUserManagement";
//            this.Text = "Quản Lý Tài Khoản";
//            this.Load += new System.EventHandler(this.FormUserManagement_Load);
//            this.panelInputs.ResumeLayout(false);
//            this.panelInputs.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
//            this.ResumeLayout(false);
//        }

//        #endregion

//        private System.Windows.Forms.Panel panelInputs;
//        private System.Windows.Forms.Label lblUsername;
//        private System.Windows.Forms.TextBox txtUsername;
//        private System.Windows.Forms.Label lblPassword;
//        private System.Windows.Forms.TextBox txtPassword;
//        private System.Windows.Forms.Label lblFullName;
//        private System.Windows.Forms.TextBox txtFullName;
//        private System.Windows.Forms.Label lblRole;
//        private System.Windows.Forms.ComboBox cboRole;
//        private System.Windows.Forms.Button btnAddUser;
//        private System.Windows.Forms.Button btnResetPassword;
//        private System.Windows.Forms.Button btnToggleLock;
//        private System.Windows.Forms.DataGridView dgvUsers;
//    }
//}