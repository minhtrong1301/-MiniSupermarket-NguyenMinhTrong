
namespace MiniSupermarket.WinForms
{
    partial class FormPOS
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelLeft = new Panel();
            dgvCart = new DataGridView();
            panelTopLeft = new Panel();
            lblBarcode = new Label();
            txtBarcode = new TextBox();
            panelRight = new Panel();
            lblTitle = new Label();
            lblPhone = new Label();
            txtCustomerPhone = new TextBox();
            btnSearchCustomer = new Button();
            lblCustNameHeader = new Label();
            lblCustomerName = new Label();
            lblTotalHeader = new Label();
            lblTotalAmount = new Label();
            lblCashHeader = new Label();
            txtCashReceived = new TextBox();
            lblChangeHeader = new Label();
            lblChange = new Label();
            btnCheckout = new Button();
            btnClearCart = new Button();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            panelTopLeft.SuspendLayout();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(245, 247, 251);
            panelLeft.Controls.Add(dgvCart);
            panelLeft.Controls.Add(panelTopLeft);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Margin = new Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(23, 27, 23, 27);
            panelLeft.Size = new Size(869, 960);
            panelLeft.TabIndex = 0;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCart.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCart.ColumnHeadersHeight = 48;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.Padding = new Padding(8, 4, 8, 4);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCart.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.GridColor = Color.FromArgb(235, 239, 245);
            dgvCart.Location = new Point(23, 150);
            dgvCart.Margin = new Padding(0, 19, 0, 0);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.RowTemplate.Height = 42;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(823, 783);
            dgvCart.TabIndex = 1;
            dgvCart.CellContentClick += dgvCart_CellContentClick_1;
            // 
            // panelTopLeft
            // 
            panelTopLeft.BackColor = Color.White;
            panelTopLeft.Controls.Add(lblBarcode);
            panelTopLeft.Controls.Add(txtBarcode);
            panelTopLeft.Dock = DockStyle.Top;
            panelTopLeft.Location = new Point(23, 27);
            panelTopLeft.Margin = new Padding(3, 4, 3, 4);
            panelTopLeft.Name = "panelTopLeft";
            panelTopLeft.Padding = new Padding(14, 16, 14, 16);
            panelTopLeft.Size = new Size(823, 123);
            panelTopLeft.TabIndex = 0;
            // 
            // lblBarcode
            // 
            lblBarcode.AutoSize = true;
            lblBarcode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBarcode.ForeColor = Color.FromArgb(51, 65, 85);
            lblBarcode.Location = new Point(18, 20);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(183, 23);
            lblBarcode.TabIndex = 0;
            lblBarcode.Text = "QUÉT MÃ SẢN PHẨM";
            // 
            // txtBarcode
            // 
            txtBarcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBarcode.BackColor = Color.FromArgb(248, 250, 252);
            txtBarcode.BorderStyle = BorderStyle.FixedSingle;
            txtBarcode.Font = new Font("Segoe UI", 12F);
            txtBarcode.Location = new Point(18, 57);
            txtBarcode.Margin = new Padding(3, 4, 3, 4);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(781, 34);
            txtBarcode.TabIndex = 1;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.White;
            panelRight.Controls.Add(lblTitle);
            panelRight.Controls.Add(lblPhone);
            panelRight.Controls.Add(txtCustomerPhone);
            panelRight.Controls.Add(btnSearchCustomer);
            panelRight.Controls.Add(lblCustNameHeader);
            panelRight.Controls.Add(lblCustomerName);
            panelRight.Controls.Add(lblTotalHeader);
            panelRight.Controls.Add(lblTotalAmount);
            panelRight.Controls.Add(lblCashHeader);
            panelRight.Controls.Add(txtCashReceived);
            panelRight.Controls.Add(lblChangeHeader);
            panelRight.Controls.Add(lblChange);
            panelRight.Controls.Add(btnCheckout);
            panelRight.Controls.Add(btnClearCart);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(869, 0);
            panelRight.Margin = new Padding(3, 4, 3, 4);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(27, 32, 27, 32);
            panelRight.Size = new Size(502, 960);
            panelRight.TabIndex = 1;
            panelRight.Paint += panelRight_Paint_1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblTitle.Location = new Point(27, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(210, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THANH TOÁN";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(71, 85, 105);
            lblPhone.Location = new Point(27, 111);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(145, 23);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "Số điện thoại KH";
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.BackColor = Color.FromArgb(248, 250, 252);
            txtCustomerPhone.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerPhone.Font = new Font("Segoe UI", 11F);
            txtCustomerPhone.Location = new Point(32, 148);
            txtCustomerPhone.Margin = new Padding(3, 4, 3, 4);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.Size = new Size(251, 32);
            txtCustomerPhone.TabIndex = 2;
            // 
            // btnSearchCustomer
            // 
            btnSearchCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearchCustomer.BackColor = Color.FromArgb(37, 99, 235);
            btnSearchCustomer.FlatAppearance.BorderSize = 0;
            btnSearchCustomer.FlatStyle = FlatStyle.Flat;
            btnSearchCustomer.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSearchCustomer.ForeColor = Color.White;
            btnSearchCustomer.Location = new Point(294, 144);
            btnSearchCustomer.Margin = new Padding(3, 4, 3, 4);
            btnSearchCustomer.Name = "btnSearchCustomer";
            btnSearchCustomer.Size = new Size(149, 45);
            btnSearchCustomer.TabIndex = 3;
            btnSearchCustomer.Text = "Tìm khách";
            btnSearchCustomer.UseVisualStyleBackColor = false;
            btnSearchCustomer.Click += btnSearchCustomer_Click;
            // 
            // lblCustNameHeader
            // 
            lblCustNameHeader.AutoSize = true;
            lblCustNameHeader.Font = new Font("Segoe UI", 10F);
            lblCustNameHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblCustNameHeader.Location = new Point(27, 220);
            lblCustNameHeader.Name = "lblCustNameHeader";
            lblCustNameHeader.Size = new Size(101, 23);
            lblCustNameHeader.TabIndex = 4;
            lblCustNameHeader.Text = "Khách hàng";
            // 
            // lblCustomerName
            // 
            lblCustomerName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCustomerName.ForeColor = Color.FromArgb(30, 64, 175);
            lblCustomerName.Location = new Point(27, 253);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(411, 43);
            lblCustomerName.TabIndex = 5;
            lblCustomerName.Text = "Khách vãng lai";
            // 
            // lblTotalHeader
            // 
            lblTotalHeader.AutoSize = true;
            lblTotalHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalHeader.ForeColor = Color.FromArgb(71, 85, 105);
            lblTotalHeader.Location = new Point(27, 329);
            lblTotalHeader.Name = "lblTotalHeader";
            lblTotalHeader.Size = new Size(126, 25);
            lblTotalHeader.TabIndex = 6;
            lblTotalHeader.Text = "TỔNG CỘNG";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(220, 38, 38);
            lblTotalAmount.Location = new Point(27, 369);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(411, 64);
            lblTotalAmount.TabIndex = 7;
            lblTotalAmount.Text = "0 đ";
            // 
            // lblCashHeader
            // 
            lblCashHeader.AutoSize = true;
            lblCashHeader.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblCashHeader.ForeColor = Color.FromArgb(51, 65, 85);
            lblCashHeader.Location = new Point(27, 476);
            lblCashHeader.Name = "lblCashHeader";
            lblCashHeader.Size = new Size(143, 25);
            lblCashHeader.TabIndex = 8;
            lblCashHeader.Text = "Tiền khách đưa";
            // 
            // txtCashReceived
            // 
            txtCashReceived.BackColor = Color.FromArgb(248, 250, 252);
            txtCashReceived.BorderStyle = BorderStyle.FixedSingle;
            txtCashReceived.Font = new Font("Segoe UI", 14F);
            txtCashReceived.Location = new Point(32, 517);
            txtCashReceived.Margin = new Padding(3, 4, 3, 4);
            txtCashReceived.Name = "txtCashReceived";
            txtCashReceived.Size = new Size(411, 39);
            txtCashReceived.TabIndex = 4;
            txtCashReceived.TextChanged += txtCashReceived_TextChanged;
            // 
            // lblChangeHeader
            // 
            lblChangeHeader.AutoSize = true;
            lblChangeHeader.Font = new Font("Segoe UI", 10.5F);
            lblChangeHeader.ForeColor = Color.FromArgb(71, 85, 105);
            lblChangeHeader.Location = new Point(27, 593);
            lblChangeHeader.Name = "lblChangeHeader";
            lblChangeHeader.Size = new Size(133, 25);
            lblChangeHeader.TabIndex = 9;
            lblChangeHeader.Text = "Tiền thừa trả lại";
            // 
            // lblChange
            // 
            lblChange.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblChange.ForeColor = Color.FromArgb(22, 163, 74);
            lblChange.Location = new Point(27, 633);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(411, 53);
            lblChange.TabIndex = 10;
            lblChange.Text = "0 đ";
            // 
            // btnCheckout
            // 
            btnCheckout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCheckout.BackColor = Color.FromArgb(22, 163, 74);
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 128, 61);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(32, 771);
            btnCheckout.Margin = new Padding(3, 4, 3, 4);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(410, 72);
            btnCheckout.TabIndex = 5;
            btnCheckout.Text = "THANH TOÁN  (F9)";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnClearCart
            // 
            btnClearCart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnClearCart.BackColor = Color.FromArgb(254, 242, 242);
            btnClearCart.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnClearCart.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 226, 226);
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClearCart.ForeColor = Color.FromArgb(220, 38, 38);
            btnClearCart.Location = new Point(32, 856);
            btnClearCart.Margin = new Padding(3, 4, 3, 4);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(410, 56);
            btnClearCart.TabIndex = 6;
            btnClearCart.Text = "HỦY GIỎ HÀNG";
            btnClearCart.UseVisualStyleBackColor = false;
            btnClearCart.Click += btnClearCart_Click;
            // 
            // FormPOS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(1371, 960);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1255, 891);
            Name = "FormPOS";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiniSupermarket | Bán hàng POS";
            Load += FormPOS_Load;
            panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            panelTopLeft.ResumeLayout(false);
            panelTopLeft.PerformLayout();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ResumeLayout(false);
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
