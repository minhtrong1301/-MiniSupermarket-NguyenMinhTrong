
namespace MiniSupermarket.WinForms
{
    partial class FormProductManagement
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
            pnlTopSearch = new Panel();
            lblSearchBarcode = new Label();
            txtSearchBarcode = new TextBox();
            lblFilterCategory = new Label();
            cboFilterCategory = new ComboBox();
            btnSearch = new Button();

            pnlCenterLeft = new Panel();
            dgvProducts = new DataGridView();

            pnlPagination = new Panel();
            btnPreviousPage = new Button();
            lblPageInfo = new Label();
            btnNextPage = new Button();

            pnlRightDetail = new Panel();
            lblDetailTitle = new Label();
            lblId = new Label();
            txtId = new TextBox();
            lblBarcode = new Label();
            txtBarcode = new TextBox();
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblPrice = new Label();
            nudPrice = new NumericUpDown();
            lblStock = new Label();
            nudStock = new NumericUpDown();

            btnLoad = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();

            pnlTopSearch.SuspendLayout();
            pnlCenterLeft.SuspendLayout();
            pnlPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            pnlRightDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            SuspendLayout();

            // 
            // pnlTopSearch
            // 
            pnlTopSearch.BackColor = Color.WhiteSmoke;
            pnlTopSearch.Controls.Add(lblSearchBarcode);
            pnlTopSearch.Controls.Add(txtSearchBarcode);
            pnlTopSearch.Controls.Add(lblFilterCategory);
            pnlTopSearch.Controls.Add(cboFilterCategory);
            pnlTopSearch.Controls.Add(btnSearch);
            pnlTopSearch.Dock = DockStyle.Top;
            pnlTopSearch.Location = new Point(0, 0);
            pnlTopSearch.Name = "pnlTopSearch";
            pnlTopSearch.Padding = new Padding(12, 10, 12, 10);
            pnlTopSearch.Size = new Size(1120, 67);
            pnlTopSearch.TabIndex = 0;

            // 
            // lblSearchBarcode
            // 
            lblSearchBarcode.AutoSize = true;
            lblSearchBarcode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearchBarcode.Location = new Point(14, 24);
            lblSearchBarcode.Name = "lblSearchBarcode";
            lblSearchBarcode.Size = new Size(102, 20);
            lblSearchBarcode.TabIndex = 0;
            lblSearchBarcode.Text = "Tìm mã vạch:";

            // 
            // txtSearchBarcode
            // 
            txtSearchBarcode.Location = new Point(120, 19);
            txtSearchBarcode.Name = "txtSearchBarcode";
            txtSearchBarcode.Size = new Size(205, 27);
            txtSearchBarcode.TabIndex = 1;

            // 
            // lblFilterCategory
            // 
            lblFilterCategory.AutoSize = true;
            lblFilterCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFilterCategory.Location = new Point(343, 24);
            lblFilterCategory.Name = "lblFilterCategory";
            lblFilterCategory.Size = new Size(84, 20);
            lblFilterCategory.TabIndex = 2;
            lblFilterCategory.Text = "Danh mục:";

            // 
            // cboFilterCategory
            // 
            cboFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterCategory.FormattingEnabled = true;
            cboFilterCategory.Location = new Point(430, 19);
            cboFilterCategory.Name = "cboFilterCategory";
            cboFilterCategory.Size = new Size(228, 28);
            cboFilterCategory.TabIndex = 2;

            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DodgerBlue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(674, 15);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(103, 37);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;

            // 
            // pnlCenterLeft
            // 
            pnlCenterLeft.BackColor = Color.White;
            pnlCenterLeft.Controls.Add(dgvProducts);
            pnlCenterLeft.Controls.Add(pnlPagination);
            pnlCenterLeft.Dock = DockStyle.Fill;
            pnlCenterLeft.Location = new Point(0, 67);
            pnlCenterLeft.Name = "pnlCenterLeft";
            pnlCenterLeft.Padding = new Padding(12);
            pnlCenterLeft.TabIndex = 1;

            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.FixedSingle;
            dgvProducts.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Margin = new Padding(0);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.TabIndex = 0;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;

            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.WhiteSmoke;
            pnlPagination.Controls.Add(btnPreviousPage);
            pnlPagination.Controls.Add(lblPageInfo);
            pnlPagination.Controls.Add(btnNextPage);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Height = 55;
            pnlPagination.Name = "pnlPagination";
            pnlPagination.TabIndex = 1;

            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Anchor = AnchorStyles.Top;
            btnPreviousPage.Location = new Point(150, 10);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(120, 35);
            btnPreviousPage.TabIndex = 0;
            btnPreviousPage.Text = "Trang trước";
            btnPreviousPage.Click += btnPreviousPage_Click;
            btnPreviousPage.UseVisualStyleBackColor = true;

            // 
            // lblPageInfo
            // 
            lblPageInfo.Anchor = AnchorStyles.Top;
            lblPageInfo.Location = new Point(285, 10);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(160, 35);
            lblPageInfo.TabIndex = 1;
            lblPageInfo.Text = "Trang 1 / 1";
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.Top;
            btnNextPage.Location = new Point(460, 10);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(120, 35);
            btnNextPage.TabIndex = 2;
            btnNextPage.Text = "Trang sau";
            btnNextPage.Click += btnNextPage_Click;
            btnNextPage.UseVisualStyleBackColor = true;

            // 
            // pnlRightDetail
            // 
            pnlRightDetail.BackColor = Color.White;
            pnlRightDetail.Controls.Add(lblDetailTitle);
            pnlRightDetail.Controls.Add(lblId);
            pnlRightDetail.Controls.Add(txtId);
            pnlRightDetail.Controls.Add(lblBarcode);
            pnlRightDetail.Controls.Add(txtBarcode);
            pnlRightDetail.Controls.Add(lblProductName);
            pnlRightDetail.Controls.Add(txtProductName);
            pnlRightDetail.Controls.Add(lblCategory);
            pnlRightDetail.Controls.Add(cboCategory);
            pnlRightDetail.Controls.Add(lblPrice);
            pnlRightDetail.Controls.Add(nudPrice);
            pnlRightDetail.Controls.Add(lblStock);
            pnlRightDetail.Controls.Add(nudStock);
            pnlRightDetail.Controls.Add(btnLoad);
            pnlRightDetail.Controls.Add(btnAdd);
            pnlRightDetail.Controls.Add(btnUpdate);
            pnlRightDetail.Controls.Add(btnDelete);
            pnlRightDetail.Dock = DockStyle.Right;
            pnlRightDetail.Name = "pnlRightDetail";
            pnlRightDetail.Padding = new Padding(17, 20, 17, 20);
            pnlRightDetail.Size = new Size(359, 693);
            pnlRightDetail.TabIndex = 2;

            // 
            // lblDetailTitle
            // 
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.Navy;
            lblDetailTitle.Location = new Point(17, 13);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(237, 28);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "THÔNG TIN SẢN PHẨM";

            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(17, 60);
            lblId.Name = "lblId";
            lblId.Size = new Size(53, 20);
            lblId.TabIndex = 1;
            lblId.Text = "Mã SP:";

            // 
            // txtId
            // 
            txtId.Location = new Point(17, 84);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(319, 27);
            txtId.TabIndex = 1;

            // 
            // lblBarcode
            // 
            lblBarcode.AutoSize = true;
            lblBarcode.Location = new Point(17, 127);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(67, 20);
            lblBarcode.TabIndex = 2;
            lblBarcode.Text = "Mã vạch:";

            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(17, 151);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(319, 27);
            txtBarcode.TabIndex = 2;

            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(17, 193);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(103, 20);
            lblProductName.TabIndex = 3;
            lblProductName.Text = "Tên sản phẩm:";

            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(17, 217);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(319, 27);
            txtProductName.TabIndex = 3;

            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(17, 260);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(79, 20);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Danh mục:";

            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(17, 284);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(319, 28);
            cboCategory.TabIndex = 5;

            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(17, 327);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(65, 20);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Đơn giá:";

            // 
            // nudPrice
            // 
            nudPrice.Location = new Point(17, 351);
            nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(320, 27);
            nudPrice.TabIndex = 7;
            nudPrice.ThousandsSeparator = true;

            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(17, 393);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(65, 20);
            lblStock.TabIndex = 8;
            lblStock.Text = "Tồn kho:";

            // 
            // nudStock
            // 
            nudStock.Location = new Point(17, 417);
            nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(320, 27);
            nudStock.TabIndex = 9;

            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(17, 480);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(149, 47);
            btnLoad.TabIndex = 10;
            btnLoad.Text = "Làm mới";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;

            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.ForestGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(189, 480);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(149, 47);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;

            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DodgerBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(17, 547);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(149, 47);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;

            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(189, 547);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(149, 47);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;

            // 
            // FormProductManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 760);
            MinimumSize = new Size(950, 650);
            Controls.Add(pnlCenterLeft);
            Controls.Add(pnlRightDetail);
            Controls.Add(pnlTopSearch);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormProductManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Sản phẩm & Kho hàng";
            Load += FormProductManagement_Load;

            pnlTopSearch.ResumeLayout(false);
            pnlTopSearch.PerformLayout();
            pnlCenterLeft.ResumeLayout(false);
            pnlPagination.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            pnlRightDetail.ResumeLayout(false);
            pnlRightDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTopSearch;
        private System.Windows.Forms.Label lblSearchBarcode;
        private System.Windows.Forms.TextBox txtSearchBarcode;
        private System.Windows.Forms.Label lblFilterCategory;
        private System.Windows.Forms.ComboBox cboFilterCategory;
        private System.Windows.Forms.Button btnSearch;

        private System.Windows.Forms.Panel pnlCenterLeft;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Label lblPageInfo;

        private System.Windows.Forms.Panel pnlRightDetail;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}
