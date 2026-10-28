
namespace MiniSupermarket.WinForms
{
    partial class FormCustomerManagement
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblRewardPoints;
        private System.Windows.Forms.Label lblMembershipRank;

        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtRewardPoints;
        private System.Windows.Forms.TextBox txtMembershipRank;

        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.DataGridView dgvCustomers;

        // Các control phân trang
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPageInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();

            this.grpInput = new System.Windows.Forms.GroupBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblRewardPoints = new System.Windows.Forms.Label();
            this.lblMembershipRank = new System.Windows.Forms.Label();

            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtRewardPoints = new System.Windows.Forms.TextBox();
            this.txtMembershipRank = new System.Windows.Forms.TextBox();

            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();

            this.dgvCustomers = new System.Windows.Forms.DataGridView();

            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();

            this.grpInput.SuspendLayout();
            this.grpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 18F, System.Drawing.FontStyle.Bold);

            this.lblTitle.Location = new System.Drawing.Point(17, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(863, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ KHÁCH HÀNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.lblCustomerId);
            this.grpInput.Controls.Add(this.txtCustomerId);
            this.grpInput.Controls.Add(this.lblCustomerName);
            this.grpInput.Controls.Add(this.txtCustomerName);
            this.grpInput.Controls.Add(this.lblPhoneNumber);
            this.grpInput.Controls.Add(this.txtPhoneNumber);
            this.grpInput.Controls.Add(this.lblAddress);
            this.grpInput.Controls.Add(this.txtAddress);
            this.grpInput.Controls.Add(this.lblRewardPoints);
            this.grpInput.Controls.Add(this.txtRewardPoints);
            this.grpInput.Controls.Add(this.lblMembershipRank);
            this.grpInput.Controls.Add(this.txtMembershipRank);

            this.grpInput.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.grpInput.Location = new System.Drawing.Point(17, 60);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(863, 205);
            this.grpInput.TabIndex = 1;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Thông tin khách hàng";

            // Mã khách hàng
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(20, 35);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(96, 20);
            this.lblCustomerId.TabIndex = 0;
            this.lblCustomerId.Text = "Mã khách hàng:";

            this.txtCustomerId.Location = new System.Drawing.Point(155, 32);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(250, 23);
            this.txtCustomerId.TabIndex = 1;

            // Tên khách hàng
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(20, 75);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(104, 20);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Tên khách hàng:";

            this.txtCustomerName.Location = new System.Drawing.Point(155, 72);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 23);
            this.txtCustomerName.TabIndex = 3;

            // Số điện thoại
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(20, 115);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(93, 20);
            this.lblPhoneNumber.TabIndex = 4;
            this.lblPhoneNumber.Text = "Số điện thoại:";

            this.txtPhoneNumber.Location = new System.Drawing.Point(155, 112);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(250, 23);
            this.txtPhoneNumber.TabIndex = 5;

            // Địa chỉ
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(450, 35);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(52, 20);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Địa chỉ:";

            this.txtAddress.Location = new System.Drawing.Point(565, 32);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(270, 23);
            this.txtAddress.TabIndex = 7;

            // Điểm tích lũy
            this.lblRewardPoints.AutoSize = true;
            this.lblRewardPoints.Location = new System.Drawing.Point(450, 75);
            this.lblRewardPoints.Name = "lblRewardPoints";
            this.lblRewardPoints.Size = new System.Drawing.Size(89, 20);
            this.lblRewardPoints.TabIndex = 8;
            this.lblRewardPoints.Text = "Điểm tích lũy:";

            this.txtRewardPoints.Location = new System.Drawing.Point(565, 72);
            this.txtRewardPoints.Name = "txtRewardPoints";
            this.txtRewardPoints.Size = new System.Drawing.Size(270, 23);
            this.txtRewardPoints.TabIndex = 9;

            // Hạng thành viên
            this.lblMembershipRank.AutoSize = true;
            this.lblMembershipRank.Location = new System.Drawing.Point(450, 115);
            this.lblMembershipRank.Name = "lblMembershipRank";
            this.lblMembershipRank.Size = new System.Drawing.Size(104, 20);
            this.lblMembershipRank.TabIndex = 10;
            this.lblMembershipRank.Text = "Hạng thành viên:";

            this.txtMembershipRank.Location = new System.Drawing.Point(565, 112);
            this.txtMembershipRank.Name = "txtMembershipRank";
            this.txtMembershipRank.Size = new System.Drawing.Size(270, 23);
            this.txtMembershipRank.TabIndex = 11;

            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.btnLoad);
            this.grpActions.Controls.Add(this.btnAdd);
            this.grpActions.Controls.Add(this.btnUpdate);
            this.grpActions.Controls.Add(this.btnDelete);
            this.grpActions.Controls.Add(this.txtSearch);
            this.grpActions.Controls.Add(this.btnSearch);

            this.grpActions.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.grpActions.Location = new System.Drawing.Point(17, 275);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(863, 70);
            this.grpActions.TabIndex = 2;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Chức năng";

            // Tải dữ liệu
            this.btnLoad.Location = new System.Drawing.Point(15, 28);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Tải dữ liệu";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(
                this.btnLoad_Click);

            // Thêm
            this.btnAdd.Location = new System.Drawing.Point(125, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(
                this.btnAdd_Click);

            // Cập nhật
            this.btnUpdate.Location = new System.Drawing.Point(220, 28);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 30);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(
                this.btnUpdate_Click);

            // Xóa
            this.btnDelete.Location = new System.Drawing.Point(325, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(
                this.btnDelete_Click);

            // Ô tìm kiếm
            this.txtSearch.Location = new System.Drawing.Point(420, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 23);
            this.txtSearch.TabIndex = 4;

            // Tìm kiếm
            this.btnSearch.Location = new System.Drawing.Point(730, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 30);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(
                this.btnSearch_Click);

            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCustomers.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(17, 355);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.RowTemplate.Height = 25;
            this.dgvCustomers.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(863, 285);
            this.dgvCustomers.TabIndex = 3;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(
                this.dgvCustomers_CellClick);
            this.dgvCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(
                this.dgvCustomers_CellContentClick);

            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(565, 650);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(100, 32);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "« Trang trước";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(
                this.btnPrevious_Click);

            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Location = new System.Drawing.Point(670, 650);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(105, 32);
            this.lblPageInfo.TabIndex = 5;
            this.lblPageInfo.Text = "Trang 1/1";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(780, 650);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 32);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Trang sau »";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(
                this.btnNext_Click);

            // 
            // FormCustomerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 700);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnNext);

            this.MinimumSize = new System.Drawing.Size(912, 739);
            this.Name = "FormCustomerManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khách hàng";
            this.Load += new System.EventHandler(
                this.FormCustomerManagement_Load);

            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpActions.ResumeLayout(false);
            this.grpActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
