
namespace MiniSupermarket.WinForms
{
    partial class FormUserManagement
    {
        private System.ComponentModel.IContainer components = null;

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
        private System.Windows.Forms.Button btnEditUser;

        private System.Windows.Forms.TextBox txtSearchUser;
        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.Button btnClearSearch;

        private System.Windows.Forms.DataGridView dgvUsers;

        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label lblTotalUsers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle rowStyle =
                new System.Windows.Forms.DataGridViewCellStyle();

            System.Windows.Forms.DataGridViewCellStyle headerStyle =
                new System.Windows.Forms.DataGridViewCellStyle();

            System.Windows.Forms.DataGridViewCellStyle cellStyle =
                new System.Windows.Forms.DataGridViewCellStyle();

            panelInputs = new System.Windows.Forms.Panel();

            lblUsername = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();

            lblPassword = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();

            lblFullName = new System.Windows.Forms.Label();
            txtFullName = new System.Windows.Forms.TextBox();

            lblRole = new System.Windows.Forms.Label();
            cboRole = new System.Windows.Forms.ComboBox();

            btnAddUser = new System.Windows.Forms.Button();
            btnResetPassword = new System.Windows.Forms.Button();
            btnToggleLock = new System.Windows.Forms.Button();
            btnEditUser = new System.Windows.Forms.Button();

            txtSearchUser = new System.Windows.Forms.TextBox();
            btnSearchUser = new System.Windows.Forms.Button();
            btnClearSearch = new System.Windows.Forms.Button();

            dgvUsers = new System.Windows.Forms.DataGridView();

            panelPagination = new System.Windows.Forms.Panel();
            btnPrevious = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            lblPageInfo = new System.Windows.Forms.Label();
            lblTotalUsers = new System.Windows.Forms.Label();

            panelInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panelPagination.SuspendLayout();
            SuspendLayout();

            // 
            // panelInputs
            // 
            panelInputs.BackColor = System.Drawing.Color.White;
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

            panelInputs.Controls.Add(txtSearchUser);
            panelInputs.Controls.Add(btnSearchUser);
            panelInputs.Controls.Add(btnClearSearch);

            panelInputs.Dock = System.Windows.Forms.DockStyle.Top;
            panelInputs.Location = new System.Drawing.Point(0, 0);
            panelInputs.Name = "panelInputs";
            panelInputs.Padding = new System.Windows.Forms.Padding(27, 21, 27, 10);
            panelInputs.Size = new System.Drawing.Size(1257, 270);
            panelInputs.TabIndex = 0;

            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblUsername.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblUsername.Location = new System.Drawing.Point(27, 21);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(123, 21);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập";

            // 
            // txtUsername
            // 
            txtUsername.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtUsername.Location = new System.Drawing.Point(27, 56);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(251, 30);
            txtUsername.TabIndex = 0;

            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblPassword.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblPassword.Location = new System.Drawing.Point(303, 21);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(82, 21);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Mật khẩu";

            // 
            // txtPassword
            // 
            txtPassword.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtPassword.Location = new System.Drawing.Point(303, 56);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(251, 30);
            txtPassword.TabIndex = 1;

            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblFullName.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblFullName.Location = new System.Drawing.Point(578, 21);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new System.Drawing.Size(83, 21);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và tên";

            // 
            // txtFullName
            // 
            txtFullName.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtFullName.Location = new System.Drawing.Point(578, 56);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new System.Drawing.Size(251, 30);
            txtFullName.TabIndex = 2;

            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblRole.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblRole.Location = new System.Drawing.Point(854, 21);
            lblRole.Name = "lblRole";
            lblRole.Size = new System.Drawing.Size(60, 21);
            lblRole.TabIndex = 3;
            lblRole.Text = "Vai trò";

            // 
            // cboRole
            // 
            cboRole.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboRole.FormattingEnabled = true;
            cboRole.Location = new System.Drawing.Point(854, 56);
            cboRole.Name = "cboRole";
            cboRole.Size = new System.Drawing.Size(251, 31);
            cboRole.TabIndex = 3;

            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddUser.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnAddUser.ForeColor = System.Drawing.Color.White;
            btnAddUser.Location = new System.Drawing.Point(27, 115);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new System.Drawing.Size(200, 45);
            btnAddUser.TabIndex = 4;
            btnAddUser.Text = "+ Thêm tài khoản";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;

            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnResetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnResetPassword.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnResetPassword.ForeColor = System.Drawing.Color.White;
            btnResetPassword.Location = new System.Drawing.Point(241, 115);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new System.Drawing.Size(211, 45);
            btnResetPassword.TabIndex = 5;
            btnResetPassword.Text = "Đặt lại mật khẩu";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;

            // 
            // btnToggleLock
            // 
            btnToggleLock.BackColor = System.Drawing.Color.FromArgb(217, 119, 6);
            btnToggleLock.Cursor = System.Windows.Forms.Cursors.Hand;
            btnToggleLock.FlatAppearance.BorderSize = 0;
            btnToggleLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnToggleLock.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnToggleLock.ForeColor = System.Drawing.Color.White;
            btnToggleLock.Location = new System.Drawing.Point(466, 115);
            btnToggleLock.Name = "btnToggleLock";
            btnToggleLock.Size = new System.Drawing.Size(211, 45);
            btnToggleLock.TabIndex = 6;
            btnToggleLock.Text = "Khóa / Mở khóa";
            btnToggleLock.UseVisualStyleBackColor = false;
            btnToggleLock.Click += btnToggleLock_Click;

            // 
            // btnEditUser
            // 
            btnEditUser.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnEditUser.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEditUser.FlatAppearance.BorderSize = 0;
            btnEditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEditUser.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnEditUser.ForeColor = System.Drawing.Color.White;
            btnEditUser.Location = new System.Drawing.Point(691, 115);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new System.Drawing.Size(211, 45);
            btnEditUser.TabIndex = 7;
            btnEditUser.Text = "Cập nhật tài khoản";
            btnEditUser.UseVisualStyleBackColor = false;
            btnEditUser.Click += btnEditUser_Click;

            // 
            // txtSearchUser
            // 
            txtSearchUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSearchUser.Location = new System.Drawing.Point(27, 205);
            txtSearchUser.Name = "txtSearchUser";
            txtSearchUser.PlaceholderText = "Tìm tên đăng nhập, họ tên hoặc vai trò...";
            txtSearchUser.Size = new System.Drawing.Size(480, 30);
            txtSearchUser.TabIndex = 8;
            txtSearchUser.KeyDown += txtSearchUser_KeyDown;

            // 
            // btnSearchUser
            // 
            btnSearchUser.BackColor = System.Drawing.Color.FromArgb(30, 64, 175);
            btnSearchUser.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSearchUser.FlatAppearance.BorderSize = 0;
            btnSearchUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearchUser.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnSearchUser.ForeColor = System.Drawing.Color.White;
            btnSearchUser.Location = new System.Drawing.Point(520, 202);
            btnSearchUser.Name = "btnSearchUser";
            btnSearchUser.Size = new System.Drawing.Size(120, 36);
            btnSearchUser.TabIndex = 9;
            btnSearchUser.Text = "Tìm kiếm";
            btnSearchUser.UseVisualStyleBackColor = false;
            btnSearchUser.Click += btnSearchUser_Click;

            // 
            // btnClearSearch
            // 
            btnClearSearch.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            btnClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClearSearch.FlatAppearance.BorderSize = 0;
            btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClearSearch.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnClearSearch.ForeColor = System.Drawing.Color.White;
            btnClearSearch.Location = new System.Drawing.Point(650, 202);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new System.Drawing.Size(120, 36);
            btnClearSearch.TabIndex = 10;
            btnClearSearch.Text = "Xóa tìm kiếm";
            btnClearSearch.UseVisualStyleBackColor = false;
            btnClearSearch.Click += btnClearSearch_Click;

            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeRows = false;

            rowStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            dgvUsers.AlternatingRowsDefaultCellStyle = rowStyle;

            dgvUsers.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = System.Drawing.Color.White;
            dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvUsers.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            headerStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            headerStyle.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            headerStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            headerStyle.SelectionForeColor =
                System.Drawing.SystemColors.HighlightText;
            headerStyle.WrapMode =
                System.Windows.Forms.DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvUsers.ColumnHeadersHeight = 44;
            dgvUsers.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            cellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = System.Drawing.Color.White;
            cellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cellStyle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            cellStyle.Padding = new System.Windows.Forms.Padding(10, 4, 5, 4);
            cellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            cellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            cellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvUsers.DefaultCellStyle = cellStyle;

            dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.RowTemplate.Height = 40;
            dgvUsers.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.TabIndex = 1;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;

            // 
            // panelPagination
            // 
            panelPagination.BackColor = System.Drawing.Color.White;
            panelPagination.Controls.Add(lblTotalUsers);
            panelPagination.Controls.Add(btnPrevious);
            panelPagination.Controls.Add(lblPageInfo);
            panelPagination.Controls.Add(btnNext);
            panelPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelPagination.Name = "panelPagination";
            panelPagination.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            panelPagination.Size = new System.Drawing.Size(1257, 58);
            panelPagination.TabIndex = 2;

            // 
            // lblTotalUsers
            // 
            lblTotalUsers.AutoSize = true;
            lblTotalUsers.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTotalUsers.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblTotalUsers.Location = new System.Drawing.Point(20, 19);
            lblTotalUsers.Name = "lblTotalUsers";
            lblTotalUsers.Size = new System.Drawing.Size(139, 20);
            lblTotalUsers.TabIndex = 0;
            lblTotalUsers.Text = "Tổng số tài khoản: 0";

            // 
            // btnPrevious
            // 
            btnPrevious.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;
            btnPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPrevious.Location = new System.Drawing.Point(850, 10);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new System.Drawing.Size(125, 36);
            btnPrevious.TabIndex = 1;
            btnPrevious.Text = "« Trang trước";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;

            // 
            // lblPageInfo
            // 
            lblPageInfo.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;
            lblPageInfo.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblPageInfo.Location = new System.Drawing.Point(980, 10);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new System.Drawing.Size(120, 36);
            lblPageInfo.TabIndex = 2;
            lblPageInfo.Text = "Trang 0/0";
            lblPageInfo.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // btnNext
            // 
            btnNext.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;
            btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnNext.Location = new System.Drawing.Point(1105, 10);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(125, 36);
            btnNext.TabIndex = 3;
            btnNext.Text = "Trang sau »";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;

            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(243, 246, 251);
            ClientSize = new System.Drawing.Size(1257, 880);
            Controls.Add(dgvUsers);
            Controls.Add(panelPagination);
            Controls.Add(panelInputs);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            MinimumSize = new System.Drawing.Size(1140, 784);
            Name = "FormUserManagement";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "MiniSupermarket | Quản lý tài khoản";
            Load += FormUserManagement_Load;

            panelInputs.ResumeLayout(false);
            panelInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panelPagination.ResumeLayout(false);
            panelPagination.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
