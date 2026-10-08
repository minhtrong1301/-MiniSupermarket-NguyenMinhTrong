namespace MiniSupermarket.WinForms
{
    partial class FormPOS
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.lblCustNameHeader = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblTotalHeader = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblCashHeader = new System.Windows.Forms.Label();
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.lblChangeHeader = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();

            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.panelTopLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelLeft (Chiếm 65% bên trái)
            // 
            this.panelLeft.Controls.Add(this.dgvCart);
            this.panelLeft.Controls.Add(this.panelTopLeft);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeft.Size = new System.Drawing.Size(650, 600);
            this.panelLeft.TabIndex = 0;

            // 
            // panelTopLeft (Khu vực quét mã vạch)
            // 
            this.panelTopLeft.Controls.Add(this.lblBarcode);
            this.panelTopLeft.Controls.Add(this.txtBarcode);
            this.panelTopLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopLeft.Location = new System.Drawing.Point(10, 10);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Size = new System.Drawing.Size(630, 50);
            this.panelTopLeft.TabIndex = 0;

            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBarcode.Location = new System.Drawing.Point(5, 12);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(155, 20);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "Quét Mã Vạch (ENTER):";

            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBarcode.Location = new System.Drawing.Point(170, 8);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(450, 29);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);

            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Location = new System.Drawing.Point(10, 60);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(630, 530);
            this.dgvCart.TabIndex = 1;

            // 
            // panelRight (Chiếm 35% bên phải)
            // 
            this.panelRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelRight.Controls.Add(this.lblTitle);
            this.panelRight.Controls.Add(this.lblPhone);
            this.panelRight.Controls.Add(this.txtCustomerPhone);
            this.panelRight.Controls.Add(this.btnSearchCustomer);
            this.panelRight.Controls.Add(this.lblCustNameHeader);
            this.panelRight.Controls.Add(this.lblCustomerName);
            this.panelRight.Controls.Add(this.lblTotalHeader);
            this.panelRight.Controls.Add(this.lblTotalAmount);
            this.panelRight.Controls.Add(this.lblCashHeader);
            this.panelRight.Controls.Add(this.txtCashReceived);
            this.panelRight.Controls.Add(this.lblChangeHeader);
            this.panelRight.Controls.Add(this.lblChange);
            this.panelRight.Controls.Add(this.btnCheckout);
            this.panelRight.Controls.Add(this.btnClearCart);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(650, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(15);
            this.panelRight.Size = new System.Drawing.Size(350, 600);
            this.panelRight.TabIndex = 1;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(236, 25);
            this.lblTitle.Text = "THÔNG TIN THANH TOÁN";

            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhone.Location = new System.Drawing.Point(15, 60);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(107, 17);
            this.lblPhone.Text = "SĐT Khách Hàng:";

            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(18, 80);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(200, 25);
            this.txtCustomerPhone.TabIndex = 2;

            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearchCustomer.Location = new System.Drawing.Point(225, 79);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(100, 27);
            this.btnSearchCustomer.TabIndex = 3;
            this.btnSearchCustomer.Text = "Tìm Khách";
            this.btnSearchCustomer.UseVisualStyleBackColor = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);

            // 
            // lblCustNameHeader
            // 
            this.lblCustNameHeader.AutoSize = true;
            this.lblCustNameHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCustNameHeader.Location = new System.Drawing.Point(15, 115);
            this.lblCustNameHeader.Name = "lblCustNameHeader";
            this.lblCustNameHeader.Size = new System.Drawing.Size(81, 17);
            this.lblCustNameHeader.Text = "Khách Hàng:";

            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCustomerName.Location = new System.Drawing.Point(100, 115);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(102, 19);
            this.lblCustomerName.Text = "Khách vãng lai";

            // 
            // lblTotalHeader
            // 
            this.lblTotalHeader.AutoSize = true;
            this.lblTotalHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalHeader.Location = new System.Drawing.Point(15, 160);
            this.lblTotalHeader.Name = "lblTotalHeader";
            this.lblTotalHeader.Size = new System.Drawing.Size(102, 20);
            this.lblTotalHeader.Text = "TỔNG TIỀN:";

            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotalAmount.Location = new System.Drawing.Point(15, 185);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(64, 37);
            this.lblTotalAmount.Text = "0 đ";

            // 
            // lblCashHeader
            // 
            this.lblCashHeader.AutoSize = true;
            this.lblCashHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCashHeader.Location = new System.Drawing.Point(15, 240);
            this.lblCashHeader.Name = "lblCashHeader";
            this.lblCashHeader.Size = new System.Drawing.Size(117, 19);
            this.lblCashHeader.Text = "Tiền Khách Đưa:";

            // 
            // txtCashReceived
            // 
            this.txtCashReceived.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtCashReceived.Location = new System.Drawing.Point(18, 265);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Size = new System.Drawing.Size(307, 32);
            this.txtCashReceived.TabIndex = 4;
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);

            // 
            // lblChangeHeader
            // 
            this.lblChangeHeader.AutoSize = true;
            this.lblChangeHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChangeHeader.Location = new System.Drawing.Point(15, 315);
            this.lblChangeHeader.Name = "lblChangeHeader";
            this.lblChangeHeader.Size = new System.Drawing.Size(125, 19);
            this.lblChangeHeader.Text = "Tiền Thừa Trả Lại:";

            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblChange.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblChange.Location = new System.Drawing.Point(15, 340);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(49, 30);
            this.lblChange.Text = "0 đ";

            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(18, 400);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(307, 50);
            this.btnCheckout.TabIndex = 5;
            this.btnCheckout.Text = "THANH TOÁN (F9)";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            // 
            // btnClearCart
            // 
            this.btnClearCart.BackColor = System.Drawing.Color.Crimson;
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearCart.ForeColor = System.Drawing.Color.White;
            this.btnClearCart.Location = new System.Drawing.Point(18, 460);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(307, 40);
            this.btnClearCart.TabIndex = 6;
            this.btnClearCart.Text = "HỦY GIỎ HÀNG";
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);

            // 
            // FormPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "FormPOS";
            this.Text = "Màn hình Bán hàng POS";
            this.Load += new System.EventHandler(this.FormPOS_Load);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.panelTopLeft.ResumeLayout(false);
            this.panelTopLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTopLeft;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.DataGridView dgvCart;

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.Label lblCustNameHeader;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblTotalHeader;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblCashHeader;
        private System.Windows.Forms.TextBox txtCashReceived;
        private System.Windows.Forms.Label lblChangeHeader;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnClearCart;
    }
}