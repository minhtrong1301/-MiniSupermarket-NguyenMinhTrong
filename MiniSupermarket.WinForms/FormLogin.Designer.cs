namespace MiniSupermarket.WinForms
{
    partial class FormLogin
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
            lblUser = new Label();
            txtUser = new TextBox();
            lblPass = new Label();
            txtPass = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(70, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(267, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.Location = new Point(40, 80);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(103, 19);
            lblUser.TabIndex = 1;
            lblUser.Text = "Tên đăng nhập:";
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Segoe UI", 10F);
            txtUser.Location = new Point(40, 102);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(320, 25);
            txtUser.TabIndex = 2;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10F);
            lblPass.Location = new Point(40, 140);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(71, 19);
            lblPass.TabIndex = 3;
            lblPass.Text = "Mật khẩu:";
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Segoe UI", 10F);
            txtPass.Location = new Point(40, 162);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(320, 25);
            txtPass.TabIndex = 4;
            txtPass.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Navy;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(40, 215);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(320, 40);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng nhập hệ thống";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // FormLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 290);
            Controls.Add(btnLogin);
            Controls.Add(txtPass);
            Controls.Add(lblPass);
            Controls.Add(txtUser);
            Controls.Add(lblUser);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - MiniSupermarket";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblUser;
        private TextBox txtUser;
        private Label lblPass;
        private TextBox txtPass;
        private Button btnLogin;
    }
}