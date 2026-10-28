namespace MiniSupermarket.WinForms
{
    partial class FormCustomerManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            grpInput = new GroupBox();
            lblCustomerId = new Label();
            txtCustomerId = new TextBox();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblRewardPoints = new Label();
            txtRewardPoints = new TextBox();
            lblMembershipRank = new Label();
            txtMembershipRank = new TextBox();
            grpActions = new GroupBox();
            btnLoad = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvCustomers = new DataGridView();
            grpInput.SuspendLayout();
            grpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Navy;
            lblTitle.Location = new Point(263, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(402, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ KHÁCH HÀNG (POS)";
            // 
            // grpInput
            // 
            grpInput.Controls.Add(lblCustomerId);
            grpInput.Controls.Add(txtCustomerId);
            grpInput.Controls.Add(lblCustomerName);
            grpInput.Controls.Add(txtCustomerName);
            grpInput.Controls.Add(lblPhoneNumber);
            grpInput.Controls.Add(txtPhoneNumber);
            grpInput.Controls.Add(lblAddress);
            grpInput.Controls.Add(txtAddress);
            grpInput.Controls.Add(lblRewardPoints);
            grpInput.Controls.Add(txtRewardPoints);
            grpInput.Controls.Add(lblMembershipRank);
            grpInput.Controls.Add(txtMembershipRank);
            grpInput.Font = new Font("Segoe UI", 9.5F);
            grpInput.Location = new Point(17, 73);
            grpInput.Margin = new Padding(3, 4, 3, 4);
            grpInput.Name = "grpInput";
            grpInput.Padding = new Padding(3, 4, 3, 4);
            grpInput.Size = new Size(863, 173);
            grpInput.TabIndex = 1;
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin khách hàng";
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(23, 40);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(119, 21);
            lblCustomerId.TabIndex = 0;
            lblCustomerId.Text = "Mã khách hàng:";
            // 
            // txtCustomerId
            // 
            txtCustomerId.Location = new Point(143, 36);
            txtCustomerId.Margin = new Padding(3, 4, 3, 4);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.ReadOnly = true;
            txtCustomerId.Size = new Size(137, 29);
            txtCustomerId.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(303, 40);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(120, 21);
            lblCustomerName.TabIndex = 2;
            lblCustomerName.Text = "Tên khách hàng:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(423, 36);
            txtCustomerName.Margin = new Padding(3, 4, 3, 4);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(159, 29);
            txtCustomerName.TabIndex = 3;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(600, 40);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(104, 21);
            lblPhoneNumber.TabIndex = 4;
            lblPhoneNumber.Text = "Số điện thoại:";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(703, 36);
            txtPhoneNumber.Margin = new Padding(3, 4, 3, 4);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(137, 29);
            txtPhoneNumber.TabIndex = 5;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(23, 100);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(60, 21);
            lblAddress.TabIndex = 6;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(143, 96);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(251, 29);
            txtAddress.TabIndex = 7;
            // 
            // lblRewardPoints
            // 
            lblRewardPoints.AutoSize = true;
            lblRewardPoints.Location = new Point(411, 100);
            lblRewardPoints.Name = "lblRewardPoints";
            lblRewardPoints.Size = new Size(104, 21);
            lblRewardPoints.TabIndex = 8;
            lblRewardPoints.Text = "Điểm tích lũy:";
            // 
            // txtRewardPoints
            // 
            txtRewardPoints.Location = new Point(514, 96);
            txtRewardPoints.Margin = new Padding(3, 4, 3, 4);
            txtRewardPoints.Name = "txtRewardPoints";
            txtRewardPoints.Size = new Size(68, 29);
            txtRewardPoints.TabIndex = 9;
            txtRewardPoints.Text = "0";
            // 
            // lblMembershipRank
            // 
            lblMembershipRank.AutoSize = true;
            lblMembershipRank.Location = new Point(600, 100);
            lblMembershipRank.Name = "lblMembershipRank";
            lblMembershipRank.Size = new Size(76, 21);
            lblMembershipRank.TabIndex = 10;
            lblMembershipRank.Text = "Hạng thẻ:";
            // 
            // txtMembershipRank
            // 
            txtMembershipRank.Location = new Point(703, 96);
            txtMembershipRank.Margin = new Padding(3, 4, 3, 4);
            txtMembershipRank.Name = "txtMembershipRank";
            txtMembershipRank.Size = new Size(137, 29);
            txtMembershipRank.TabIndex = 11;
            txtMembershipRank.Text = "Chuẩn";
            // 
            // grpActions
            // 
            grpActions.Controls.Add(btnLoad);
            grpActions.Controls.Add(btnAdd);
            grpActions.Controls.Add(btnUpdate);
            grpActions.Controls.Add(btnDelete);
            grpActions.Controls.Add(lblSearch);
            grpActions.Controls.Add(txtSearch);
            grpActions.Controls.Add(btnSearch);
            grpActions.Font = new Font("Segoe UI", 9.5F);
            grpActions.Location = new Point(17, 260);
            grpActions.Margin = new Padding(3, 4, 3, 4);
            grpActions.Name = "grpActions";
            grpActions.Padding = new Padding(3, 4, 3, 4);
            grpActions.Size = new Size(863, 87);
            grpActions.TabIndex = 2;
            grpActions.TabStop = false;
            grpActions.Text = "Chức năng";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(17, 31);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(86, 40);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(109, 31);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(86, 40);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(200, 31);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(86, 40);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(291, 31);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 40);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(411, 40);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(77, 21);
            lblSearch.TabIndex = 4;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(486, 35);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(251, 29);
            txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(743, 31);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(97, 40);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(17, 360);
            dgvCustomers.Margin = new Padding(3, 4, 3, 4);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(863, 293);
            dgvCustomers.TabIndex = 3;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            // 
            // FormCustomerManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 673);
            Controls.Add(dgvCustomers);
            Controls.Add(grpActions);
            Controls.Add(grpInput);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormCustomerManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Khách Hàng - Mini Supermarket";
            Load += FormCustomerManagement_Load;
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            grpActions.ResumeLayout(false);
            grpActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblRewardPoints;
        private System.Windows.Forms.TextBox txtRewardPoints;
        private System.Windows.Forms.Label lblMembershipRank;
        private System.Windows.Forms.TextBox txtMembershipRank;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvCustomers;
    }
}