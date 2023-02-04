namespace GUI_QuanLy
{
    partial class GUI_DangKy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_DangKy));
            this.lbTittle = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.lbPassword = new System.Windows.Forms.Label();
            this.btnClosed = new System.Windows.Forms.Button();
            this.txtMaNVDangKy = new System.Windows.Forms.TextBox();
            this.txtUserNVDangKy = new System.Windows.Forms.TextBox();
            this.txtPassNVDangKy = new System.Windows.Forms.TextBox();
            this.txtHoTenNVDangKy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdAdminDangKy = new System.Windows.Forms.RadioButton();
            this.rdThuThuDangKy = new System.Windows.Forms.RadioButton();
            this.btnHuyDangKy = new System.Windows.Forms.Button();
            this.txtCaNVDangKy = new System.Windows.Forms.TextBox();
            this.lblCaTrucNVDangKy = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTittle
            // 
            this.lbTittle.AutoSize = true;
            this.lbTittle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbTittle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTittle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(23)))), ((int)(((byte)(39)))));
            this.lbTittle.Location = new System.Drawing.Point(62, 37);
            this.lbTittle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTittle.Name = "lbTittle";
            this.lbTittle.Size = new System.Drawing.Size(357, 41);
            this.lbTittle.TabIndex = 0;
            this.lbTittle.Text = "QUẢN LÝ THƯ VIỆN UIT";
            this.lbTittle.Click += new System.EventHandler(this.label1_Click);
            this.lbTittle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.lbTittle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.lbTittle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // lbUserName
            // 
            this.lbUserName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbUserName.Location = new System.Drawing.Point(69, 115);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(0);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbUserName.Size = new System.Drawing.Size(109, 38);
            this.lbUserName.TabIndex = 1;
            this.lbUserName.Text = "Mã NV";
            this.lbUserName.UseCompatibleTextRendering = true;
            this.lbUserName.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(23)))), ((int)(((byte)(39)))));
            this.btnDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangKy.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Location = new System.Drawing.Point(317, 458);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(216, 50);
            this.btnDangKy.TabIndex = 9;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // lbPassword
            // 
            this.lbPassword.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbPassword.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbPassword.Location = new System.Drawing.Point(68, 223);
            this.lbPassword.Margin = new System.Windows.Forms.Padding(0);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbPassword.Size = new System.Drawing.Size(118, 42);
            this.lbPassword.TabIndex = 11;
            this.lbPassword.Text = "Username :";
            this.lbPassword.UseCompatibleTextRendering = true;
            // 
            // btnClosed
            // 
            this.btnClosed.BackColor = System.Drawing.SystemColors.Control;
            this.btnClosed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClosed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClosed.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClosed.FlatAppearance.BorderSize = 0;
            this.btnClosed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClosed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosed.Image = ((System.Drawing.Image)(resources.GetObject("btnClosed.Image")));
            this.btnClosed.Location = new System.Drawing.Point(1083, 0);
            this.btnClosed.Margin = new System.Windows.Forms.Padding(4, 4, 13, 4);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(55, 46);
            this.btnClosed.TabIndex = 12;
            this.btnClosed.UseVisualStyleBackColor = false;
            this.btnClosed.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtMaNVDangKy
            // 
            this.txtMaNVDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNVDangKy.Location = new System.Drawing.Point(202, 113);
            this.txtMaNVDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNVDangKy.Multiline = true;
            this.txtMaNVDangKy.Name = "txtMaNVDangKy";
            this.txtMaNVDangKy.Size = new System.Drawing.Size(331, 40);
            this.txtMaNVDangKy.TabIndex = 1;
            // 
            // txtUserNVDangKy
            // 
            this.txtUserNVDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserNVDangKy.Location = new System.Drawing.Point(202, 230);
            this.txtUserNVDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserNVDangKy.Multiline = true;
            this.txtUserNVDangKy.Name = "txtUserNVDangKy";
            this.txtUserNVDangKy.Size = new System.Drawing.Size(331, 40);
            this.txtUserNVDangKy.TabIndex = 3;
            // 
            // txtPassNVDangKy
            // 
            this.txtPassNVDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassNVDangKy.Location = new System.Drawing.Point(202, 290);
            this.txtPassNVDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassNVDangKy.Multiline = true;
            this.txtPassNVDangKy.Name = "txtPassNVDangKy";
            this.txtPassNVDangKy.Size = new System.Drawing.Size(331, 40);
            this.txtPassNVDangKy.TabIndex = 4;
            this.txtPassNVDangKy.UseSystemPasswordChar = true;
            // 
            // txtHoTenNVDangKy
            // 
            this.txtHoTenNVDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTenNVDangKy.Location = new System.Drawing.Point(202, 169);
            this.txtHoTenNVDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTenNVDangKy.Multiline = true;
            this.txtHoTenNVDangKy.Name = "txtHoTenNVDangKy";
            this.txtHoTenNVDangKy.Size = new System.Drawing.Size(331, 40);
            this.txtHoTenNVDangKy.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(69, 290);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label2.Size = new System.Drawing.Size(121, 65);
            this.label2.TabIndex = 25;
            this.label2.Text = "Mật khẩu";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Location = new System.Drawing.Point(60, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label5.Size = new System.Drawing.Size(95, 50);
            this.label5.TabIndex = 23;
            this.label5.Text = "Họ Tên :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.UseCompatibleTextRendering = true;
            // 
            // rdAdminDangKy
            // 
            this.rdAdminDangKy.AutoSize = true;
            this.rdAdminDangKy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAdminDangKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdAdminDangKy.Location = new System.Drawing.Point(78, 354);
            this.rdAdminDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.rdAdminDangKy.Name = "rdAdminDangKy";
            this.rdAdminDangKy.Size = new System.Drawing.Size(91, 32);
            this.rdAdminDangKy.TabIndex = 5;
            this.rdAdminDangKy.TabStop = true;
            this.rdAdminDangKy.Text = "Admin";
            this.rdAdminDangKy.UseVisualStyleBackColor = true;
            this.rdAdminDangKy.CheckedChanged += new System.EventHandler(this.rdAdminDangKy_CheckedChanged);
            // 
            // rdThuThuDangKy
            // 
            this.rdThuThuDangKy.AutoSize = true;
            this.rdThuThuDangKy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdThuThuDangKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdThuThuDangKy.Location = new System.Drawing.Point(202, 354);
            this.rdThuThuDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.rdThuThuDangKy.Name = "rdThuThuDangKy";
            this.rdThuThuDangKy.Size = new System.Drawing.Size(100, 32);
            this.rdThuThuDangKy.TabIndex = 6;
            this.rdThuThuDangKy.TabStop = true;
            this.rdThuThuDangKy.Text = "Thủ thư";
            this.rdThuThuDangKy.UseVisualStyleBackColor = true;
            this.rdThuThuDangKy.CheckedChanged += new System.EventHandler(this.rdThuThuDangKy_CheckedChanged);
            // 
            // btnHuyDangKy
            // 
            this.btnHuyDangKy.BackColor = System.Drawing.Color.White;
            this.btnHuyDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyDangKy.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnHuyDangKy.FlatAppearance.BorderSize = 0;
            this.btnHuyDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyDangKy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyDangKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(23)))), ((int)(((byte)(39)))));
            this.btnHuyDangKy.Location = new System.Drawing.Point(66, 458);
            this.btnHuyDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuyDangKy.Name = "btnHuyDangKy";
            this.btnHuyDangKy.Size = new System.Drawing.Size(216, 50);
            this.btnHuyDangKy.TabIndex = 8;
            this.btnHuyDangKy.Text = "Quay Về";
            this.btnHuyDangKy.UseVisualStyleBackColor = false;
            this.btnHuyDangKy.Click += new System.EventHandler(this.btnHuyDangKy_Click);
            // 
            // txtCaNVDangKy
            // 
            this.txtCaNVDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaNVDangKy.Location = new System.Drawing.Point(443, 350);
            this.txtCaNVDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.txtCaNVDangKy.Multiline = true;
            this.txtCaNVDangKy.Name = "txtCaNVDangKy";
            this.txtCaNVDangKy.Size = new System.Drawing.Size(90, 40);
            this.txtCaNVDangKy.TabIndex = 7;
            // 
            // lblCaTrucNVDangKy
            // 
            this.lblCaTrucNVDangKy.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblCaTrucNVDangKy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCaTrucNVDangKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCaTrucNVDangKy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCaTrucNVDangKy.Location = new System.Drawing.Point(334, 354);
            this.lblCaTrucNVDangKy.Margin = new System.Windows.Forms.Padding(0);
            this.lblCaTrucNVDangKy.Name = "lblCaTrucNVDangKy";
            this.lblCaTrucNVDangKy.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblCaTrucNVDangKy.Size = new System.Drawing.Size(105, 40);
            this.lblCaTrucNVDangKy.TabIndex = 24;
            this.lblCaTrucNVDangKy.Text = "Ca trực";
            this.lblCaTrucNVDangKy.UseCompatibleTextRendering = true;
            this.lblCaTrucNVDangKy.Click += new System.EventHandler(this.lblCaTrucNVDangKy_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(609, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(529, 564);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // GUI_DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1138, 557);
            this.ControlBox = false;
            this.Controls.Add(this.btnHuyDangKy);
            this.Controls.Add(this.txtCaNVDangKy);
            this.Controls.Add(this.rdThuThuDangKy);
            this.Controls.Add(this.rdAdminDangKy);
            this.Controls.Add(this.txtPassNVDangKy);
            this.Controls.Add(this.txtHoTenNVDangKy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCaTrucNVDangKy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUserNVDangKy);
            this.Controls.Add(this.txtMaNVDangKy);
            this.Controls.Add(this.btnClosed);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbTittle);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GUI_DangKy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTittle;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Button btnClosed;
        private System.Windows.Forms.TextBox txtMaNVDangKy;
        private System.Windows.Forms.TextBox txtUserNVDangKy;
        private System.Windows.Forms.TextBox txtPassNVDangKy;
        private System.Windows.Forms.TextBox txtHoTenNVDangKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdAdminDangKy;
        private System.Windows.Forms.RadioButton rdThuThuDangKy;
        private System.Windows.Forms.Button btnHuyDangKy;
        private System.Windows.Forms.TextBox txtCaNVDangKy;
        private System.Windows.Forms.Label lblCaTrucNVDangKy;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

