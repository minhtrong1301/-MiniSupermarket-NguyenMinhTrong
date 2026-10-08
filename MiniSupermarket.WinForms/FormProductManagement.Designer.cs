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
            this.pnlTopSearch = new System.Windows.Forms.Panel();
            this.lblSearchBarcode = new System.Windows.Forms.Label();
            this.txtSearchBarcode = new System.Windows.Forms.TextBox();
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.cboFilterCategory = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlCenterLeft = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.pnlRightDetail = new System.Windows.Forms.Panel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblStock = new System.Windows.Forms.Label();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            this.pnlTopSearch.SuspendLayout();
            this.pnlCenterLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlRightDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlTopSearch (Thanh tìm kiếm & lọc phía trên)
            // 
            this.pnlTopSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTopSearch.Controls.Add(this.lblSearchBarcode);
            this.pnlTopSearch.Controls.Add(this.txtSearchBarcode);
            this.pnlTopSearch.Controls.Add(this.lblFilterCategory);
            this.pnlTopSearch.Controls.Add(this.cboFilterCategory);
            this.pnlTopSearch.Controls.Add(this.btnSearch);
            this.pnlTopSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlTopSearch.Name = "pnlTopSearch";
            this.pnlTopSearch.Size = new System.Drawing.Size(980, 50);
            this.pnlTopSearch.TabIndex = 0;

            // 
            // lblSearchBarcode
            // 
            this.lblSearchBarcode.AutoSize = true;
            this.lblSearchBarcode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearchBarcode.Location = new System.Drawing.Point(12, 18);
            this.lblSearchBarcode.Name = "lblSearchBarcode";
            this.lblSearchBarcode.Size = new System.Drawing.Size(81, 15);
            this.lblSearchBarcode.Text = "Tìm mã vạch:";

            // 
            // txtSearchBarcode
            // 
            this.txtSearchBarcode.Location = new System.Drawing.Point(95, 14);
            this.txtSearchBarcode.Name = "txtSearchBarcode";
            this.txtSearchBarcode.Size = new System.Drawing.Size(180, 23);
            this.txtSearchBarcode.TabIndex = 1;

            // 
            // lblFilterCategory
            // 
            this.lblFilterCategory.AutoSize = true;
            this.lblFilterCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilterCategory.Location = new System.Drawing.Point(300, 18);
            this.lblFilterCategory.Name = "lblFilterCategory";
            this.lblFilterCategory.Size = new System.Drawing.Size(66, 15);
            this.lblFilterCategory.Text = "Danh mục:";

            // 
            // cboFilterCategory
            // 
            this.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCategory.FormattingEnabled = true;
            this.cboFilterCategory.Location = new System.Drawing.Point(372, 14);
            this.cboFilterCategory.Name = "cboFilterCategory";
            this.cboFilterCategory.Size = new System.Drawing.Size(200, 23);
            this.cboFilterCategory.TabIndex = 2;

            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(590, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 28);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // 
            // pnlCenterLeft (Khu vực danh sách 68% bên trái)
            // 
            this.pnlCenterLeft.Controls.Add(this.dgvProducts);
            this.pnlCenterLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCenterLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlCenterLeft.Name = "pnlCenterLeft";
            this.pnlCenterLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCenterLeft.Size = new System.Drawing.Size(666, 520);
            this.pnlCenterLeft.TabIndex = 1;

            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(10, 10);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(646, 500);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);

            // 
            // pnlRightDetail (Khu vực chi tiết 32% bên phải)
            // 
            this.pnlRightDetail.BackColor = System.Drawing.Color.White;
            this.pnlRightDetail.Controls.Add(this.lblDetailTitle);
            this.pnlRightDetail.Controls.Add(this.lblId);
            this.pnlRightDetail.Controls.Add(this.txtId);
            this.pnlRightDetail.Controls.Add(this.lblBarcode);
            this.pnlRightDetail.Controls.Add(this.txtBarcode);
            this.pnlRightDetail.Controls.Add(this.lblProductName);
            this.pnlRightDetail.Controls.Add(this.txtProductName);
            this.pnlRightDetail.Controls.Add(this.lblPrice);
            this.pnlRightDetail.Controls.Add(this.nudPrice);
            this.pnlRightDetail.Controls.Add(this.lblStock);
            this.pnlRightDetail.Controls.Add(this.nudStock);
            this.pnlRightDetail.Controls.Add(this.lblCategory);
            this.pnlRightDetail.Controls.Add(this.cboCategory);
            this.pnlRightDetail.Controls.Add(this.btnLoad);
            this.pnlRightDetail.Controls.Add(this.btnAdd);
            this.pnlRightDetail.Controls.Add(this.btnUpdate);
            this.pnlRightDetail.Controls.Add(this.btnDelete);
            this.pnlRightDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightDetail.Location = new System.Drawing.Point(666, 50);
            this.pnlRightDetail.Name = "pnlRightDetail";
            this.pnlRightDetail.Padding = new System.Windows.Forms.Padding(15);
            this.pnlRightDetail.Size = new System.Drawing.Size(314, 520);
            this.pnlRightDetail.TabIndex = 2;

            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblDetailTitle.Location = new System.Drawing.Point(15, 10);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(183, 21);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "THÔNG TIN SẢN PHẨM";

            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(15, 45);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(43, 15);
            this.lblId.Text = "Mã SP:";

            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(15, 63);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(280, 23);
            this.txtId.TabIndex = 1;

            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(15, 95);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(55, 15);
            this.lblBarcode.Text = "Mã vạch:";

            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(15, 113);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(280, 23);
            this.txtBarcode.TabIndex = 2;

            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(15, 145);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(83, 15);
            this.lblProductName.Text = "Tên sản phẩm:";

            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(15, 163);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(280, 23);
            this.txtProductName.TabIndex = 3;

            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(15, 195);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 15);
            this.lblCategory.Text = "Danh mục:";

            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(15, 213);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(280, 23);
            this.cboCategory.TabIndex = 4;

            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(15, 245);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(51, 15);
            this.lblPrice.Text = "Đơn giá:";

            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 0;
            this.nudPrice.Location = new System.Drawing.Point(15, 263);
            this.nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(280, 23);
            this.nudPrice.TabIndex = 5;
            this.nudPrice.ThousandsSeparator = true;

            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(15, 295);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(53, 15);
            this.lblStock.Text = "Tồn kho:";

            // 
            // nudStock
            // 
            this.nudStock.Location = new System.Drawing.Point(15, 313);
            this.nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(280, 23);
            this.nudStock.TabIndex = 6;

            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(15, 360);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(130, 35);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Làm mới";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(165, 360);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 35);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(15, 410);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 35);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(165, 410);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 35);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // FormProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 570);
            this.Controls.Add(this.pnlRightDetail);
            this.Controls.Add(this.pnlCenterLeft);
            this.Controls.Add(this.pnlTopSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormProductManagement";
            this.Text = "Quản lý Sản phẩm & Kho hàng";
            this.Load += new System.EventHandler(this.FormProductManagement_Load);
            this.pnlTopSearch.ResumeLayout(false);
            this.pnlTopSearch.PerformLayout();
            this.pnlCenterLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlRightDetail.ResumeLayout(false);
            this.pnlRightDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.ResumeLayout(false);
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

        private System.Windows.Forms.Panel pnlRightDetail;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}