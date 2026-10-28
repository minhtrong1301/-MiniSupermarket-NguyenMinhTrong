
namespace MiniSupermarket.WinForms
{
    partial class FormCategoryManagement
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
            components = new System.ComponentModel.Container();

            // Khởi tạo các control
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();

            panelSearch = new Panel();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            btnSearch = new Button();
            btnLoad = new Button();

            dgvCategories = new DataGridView();

            grpDetails = new GroupBox();
            lblId = new Label();
            txtId = new TextBox();
            lblName = new Label();
            txtCategoryName = new TextBox();
            lblDesc = new Label();
            txtDescription = new TextBox();

            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();

            //btnLogout = new Button();

            panelPagination = new Panel();
            btnPrevious = new Button();
            lblPageInfo = new Label();
            btnNext = new Button();

            panelHeader.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            grpDetails.SuspendLayout();
            panelPagination.SuspendLayout();
            SuspendLayout();

            // 
            // panelHeader - thanh tiêu đề
            // 
            panelHeader.BackColor = Color.FromArgb(25, 55, 109);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            //panelHeader.Controls.Add(btnLogout);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 100);
            panelHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(390, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ DANH MỤC";

            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(220, 230, 245);
            lblSubtitle.Location = new Point(29, 61);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(330, 21);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Quản lý và cập nhật danh mục sản phẩm";

            // 
            // btnLogout
            // 
            //btnLogout.BackColor = Color.FromArgb(220, 53, 69);
            //btnLogout.FlatAppearance.BorderSize = 0;
            //btnLogout.FlatAppearance.MouseOverBackColor =
            //    Color.FromArgb(190, 40, 55);
            //btnLogout.FlatStyle = FlatStyle.Flat;
            //btnLogout.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            //btnLogout.ForeColor = Color.White;
            //btnLogout.Location = new Point(843, 29);
            //btnLogout.Name = "btnLogout";
            //btnLogout.Size = new Size(132, 42);
            //btnLogout.TabIndex = 2;
            //btnLogout.UseVisualStyleBackColor = false;
            //btnLogout.Click += btnLogout_Click;

            // 
            // panelSearch - khu vực tìm kiếm
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(lblKeyword);
            panelSearch.Controls.Add(txtKeyword);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(btnLoad);
            panelSearch.Location = new Point(20, 115);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(960, 82);
            panelSearch.TabIndex = 1;

            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblKeyword.ForeColor = Color.FromArgb(55, 65, 81);
            lblKeyword.Location = new Point(17, 8);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(82, 21);
            lblKeyword.TabIndex = 0;
            lblKeyword.Text = "Tìm kiếm";

            // 
            // txtKeyword
            // 
            txtKeyword.BorderStyle = BorderStyle.FixedSingle;
            txtKeyword.Font = new Font("Segoe UI", 10F);
            txtKeyword.Location = new Point(20, 35);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Nhập tên danh mục...";
            txtKeyword.Size = new Size(400, 30);
            txtKeyword.TabIndex = 1;

            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(37, 99, 235);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(29, 78, 216);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(435, 33);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(105, 35);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;

            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(229, 231, 235);
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(209, 213, 219);
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLoad.ForeColor = Color.FromArgb(31, 41, 55);
            btnLoad.Location = new Point(550, 33);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(105, 35);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Làm mới";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;

            // 
            // dgvCategories - bảng danh mục
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.AllowUserToResizeRows = false;
            dgvCategories.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.BackgroundColor = Color.White;
            dgvCategories.BorderStyle = BorderStyle.None;
            dgvCategories.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategories.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;
            dgvCategories.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(25, 55, 109);
            dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dgvCategories.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvCategories.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            dgvCategories.ColumnHeadersHeight = 45;
            dgvCategories.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCategories.DefaultCellStyle.BackColor = Color.White;
            dgvCategories.DefaultCellStyle.ForeColor =
                Color.FromArgb(31, 41, 55);
            dgvCategories.DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F);
            dgvCategories.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(219, 234, 254);
            dgvCategories.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(30, 58, 138);
            dgvCategories.DefaultCellStyle.Padding =
                new Padding(8, 4, 4, 4);
            dgvCategories.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252);
            dgvCategories.EnableHeadersVisualStyles = false;
            dgvCategories.GridColor = Color.FromArgb(229, 231, 235);
            dgvCategories.Location = new Point(20, 210);
            dgvCategories.MultiSelect = false;
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.RowTemplate.Height = 42;
            dgvCategories.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(590, 400);
            dgvCategories.TabIndex = 2;
            dgvCategories.CellClick += dgvCategories_CellClick;
            dgvCategories.CellContentClick +=
                dgvCategories_CellContentClick;

            // 
            // grpDetails - thông tin chi tiết
            // 
            grpDetails.BackColor = Color.White;
            grpDetails.Controls.Add(lblId);
            grpDetails.Controls.Add(txtId);
            grpDetails.Controls.Add(lblName);
            grpDetails.Controls.Add(txtCategoryName);
            grpDetails.Controls.Add(lblDesc);
            grpDetails.Controls.Add(txtDescription);
            grpDetails.Controls.Add(btnAdd);
            grpDetails.Controls.Add(btnUpdate);
            grpDetails.Controls.Add(btnDelete);
            grpDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpDetails.ForeColor = Color.FromArgb(25, 55, 109);
            grpDetails.Location = new Point(630, 210);
            grpDetails.Name = "grpDetails";
            grpDetails.Padding = new Padding(15);
            grpDetails.Size = new Size(350, 400);
            grpDetails.TabIndex = 3;
            grpDetails.TabStop = false;
            grpDetails.Text = "Thông tin danh mục";

            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblId.ForeColor = Color.FromArgb(55, 65, 81);
            lblId.Location = new Point(18, 39);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 0;
            lblId.Text = "ID";

            // 
            // txtId
            // 
            txtId.BackColor = Color.FromArgb(243, 244, 246);
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Font = new Font("Segoe UI", 10F);
            txtId.Location = new Point(20, 64);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(310, 30);
            txtId.TabIndex = 1;

            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(55, 65, 81);
            lblName.Location = new Point(18, 106);
            lblName.Name = "lblName";
            lblName.Size = new Size(105, 21);
            lblName.TabIndex = 2;
            lblName.Text = "Tên danh mục";

            // 
            // txtCategoryName
            // 
            txtCategoryName.BorderStyle = BorderStyle.FixedSingle;
            txtCategoryName.Font = new Font("Segoe UI", 10F);
            txtCategoryName.Location = new Point(20, 131);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(310, 30);
            txtCategoryName.TabIndex = 3;

            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDesc.ForeColor = Color.FromArgb(55, 65, 81);
            lblDesc.Location = new Point(18, 174);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(48, 21);
            lblDesc.TabIndex = 4;
            lblDesc.Text = "Mô tả";

            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(20, 199);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(310, 75);
            txtDescription.TabIndex = 5;

            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(22, 163, 74);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(21, 128, 61);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(20, 291);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(310, 38);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "+  Thêm danh mục";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;

            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(245, 158, 11);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(217, 119, 6);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(20, 340);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 38);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;

            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(185, 28, 45);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(180, 340);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 38);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;

            // 
            // panelPagination - phân trang
            // 
            panelPagination.BackColor = Color.FromArgb(248, 250, 252);
            panelPagination.Controls.Add(btnPrevious);
            panelPagination.Controls.Add(lblPageInfo);
            panelPagination.Controls.Add(btnNext);
            panelPagination.Location = new Point(20, 620);
            panelPagination.Name = "panelPagination";
            panelPagination.Size = new Size(590, 50);
            panelPagination.TabIndex = 4;

            // 
            // btnPrevious
            // 
            btnPrevious.BackColor = Color.White;
            btnPrevious.FlatAppearance.BorderColor =
                Color.FromArgb(203, 213, 225);
            btnPrevious.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(219, 234, 254);
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPrevious.ForeColor = Color.FromArgb(37, 99, 235);
            btnPrevious.Location = new Point(105, 7);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(115, 35);
            btnPrevious.TabIndex = 0;
            btnPrevious.Text = "‹ Trang trước";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += btnPrevious_Click;

            // 
            // lblPageInfo
            // 
            lblPageInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPageInfo.ForeColor = Color.FromArgb(55, 65, 81);
            lblPageInfo.Location = new Point(225, 7);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(135, 35);
            lblPageInfo.TabIndex = 1;
            lblPageInfo.Text = "Trang 0/0";
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // btnNext
            // 
            btnNext.BackColor = Color.White;
            btnNext.FlatAppearance.BorderColor =
                Color.FromArgb(203, 213, 225);
            btnNext.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(219, 234, 254);
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNext.ForeColor = Color.FromArgb(37, 99, 235);
            btnNext.Location = new Point(365, 7);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(115, 35);
            btnNext.TabIndex = 2;
            btnNext.Text = "Trang sau ›";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;

            // 
            // FormCategoryManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1000, 690);
            Controls.Add(panelPagination);
            Controls.Add(grpDetails);
            Controls.Add(dgvCategories);
            Controls.Add(panelSearch);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = true;
            Name = "FormCategoryManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý danh mục sản phẩm";
            Load += FormCategoryManagement_Load;

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            panelPagination.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblKeyword;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;

        private System.Windows.Forms.DataGridView dgvCategories;

        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        //private System.Windows.Forms.Button btnLogout;

        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNext;
    }
}
