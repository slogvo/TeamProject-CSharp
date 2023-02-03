﻿namespace GUI_QuanLy
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtMaNVDangKy = new System.Windows.Forms.TextBox();
            this.txtUserNVDangKy = new System.Windows.Forms.TextBox();
            this.txtPassNVDangKy = new System.Windows.Forms.TextBox();
            this.txtHoTenNVDangKy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCaTrucNVDangKy = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdAdminDangKy = new System.Windows.Forms.RadioButton();
            this.rdThuThuDangKy = new System.Windows.Forms.RadioButton();
            this.txtCaNVDangKy = new System.Windows.Forms.TextBox();
            this.btnHuyDangKy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTittle
            // 
            this.lbTittle.AutoSize = true;
            this.lbTittle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbTittle.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTittle.ForeColor = System.Drawing.Color.Lime;
            this.lbTittle.Location = new System.Drawing.Point(310, 25);
            this.lbTittle.Name = "lbTittle";
            this.lbTittle.Size = new System.Drawing.Size(385, 29);
            this.lbTittle.TabIndex = 0;
            this.lbTittle.Text = "PHẦM MỀM QUẢN LÝ THƯ VIỆN";
            this.lbTittle.Click += new System.EventHandler(this.label1_Click);
            this.lbTittle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.lbTittle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.lbTittle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // lbUserName
            // 
            this.lbUserName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbUserName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbUserName.Image = ((System.Drawing.Image)(resources.GetObject("lbUserName.Image")));
            this.lbUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbUserName.Location = new System.Drawing.Point(64, 119);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(0);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Padding = new System.Windows.Forms.Padding(2);
            this.lbUserName.Size = new System.Drawing.Size(145, 54);
            this.lbUserName.TabIndex = 1;
            this.lbUserName.Text = "Mã NV :";
            this.lbUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbUserName.UseCompatibleTextRendering = true;
            this.lbUserName.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.Turquoise;
            this.btnDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangKy.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Location = new System.Drawing.Point(472, 365);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(180, 41);
            this.btnDangKy.TabIndex = 5;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // lbPassword
            // 
            this.lbPassword.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbPassword.Image = ((System.Drawing.Image)(resources.GetObject("lbPassword.Image")));
            this.lbPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbPassword.Location = new System.Drawing.Point(64, 178);
            this.lbPassword.Margin = new System.Windows.Forms.Padding(0);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Padding = new System.Windows.Forms.Padding(2);
            this.lbPassword.Size = new System.Drawing.Size(145, 53);
            this.lbPassword.TabIndex = 11;
            this.lbPassword.Text = "UserName :";
            this.lbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnClosed.Location = new System.Drawing.Point(856, 3);
            this.btnClosed.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(41, 37);
            this.btnClosed.TabIndex = 12;
            this.btnClosed.UseVisualStyleBackColor = false;
            this.btnClosed.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(64, 245);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2);
            this.label1.Size = new System.Drawing.Size(136, 53);
            this.label1.TabIndex = 13;
            this.label1.Text = "Loại NV :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // lbCopyright
            // 
            this.lbCopyright.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCopyright.Location = new System.Drawing.Point(12, 423);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(154, 22);
            this.lbCopyright.TabIndex = 17;
            this.lbCopyright.Text = "CopyRight 2017 ©";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(760, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 22);
            this.label3.TabIndex = 18;
            this.label3.Text = "Version 2.4";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(37, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 57);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // txtMaNVDangKy
            // 
            this.txtMaNVDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNVDangKy.Location = new System.Drawing.Point(213, 133);
            this.txtMaNVDangKy.Name = "txtMaNVDangKy";
            this.txtMaNVDangKy.Size = new System.Drawing.Size(198, 26);
            this.txtMaNVDangKy.TabIndex = 20;
            // 
            // txtUserNVDangKy
            // 
            this.txtUserNVDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserNVDangKy.Location = new System.Drawing.Point(213, 193);
            this.txtUserNVDangKy.Name = "txtUserNVDangKy";
            this.txtUserNVDangKy.Size = new System.Drawing.Size(198, 26);
            this.txtUserNVDangKy.TabIndex = 21;
            // 
            // txtPassNVDangKy
            // 
            this.txtPassNVDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassNVDangKy.Location = new System.Drawing.Point(625, 191);
            this.txtPassNVDangKy.Name = "txtPassNVDangKy";
            this.txtPassNVDangKy.Size = new System.Drawing.Size(212, 26);
            this.txtPassNVDangKy.TabIndex = 27;
            // 
            // txtHoTenNVDangKy
            // 
            this.txtHoTenNVDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTenNVDangKy.Location = new System.Drawing.Point(625, 132);
            this.txtHoTenNVDangKy.Name = "txtHoTenNVDangKy";
            this.txtHoTenNVDangKy.Size = new System.Drawing.Size(212, 26);
            this.txtHoTenNVDangKy.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(472, 177);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2);
            this.label2.Size = new System.Drawing.Size(145, 53);
            this.label2.TabIndex = 25;
            this.label2.Text = "Mật Khẩu :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // lblCaTrucNVDangKy
            // 
            this.lblCaTrucNVDangKy.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblCaTrucNVDangKy.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaTrucNVDangKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCaTrucNVDangKy.Image = ((System.Drawing.Image)(resources.GetObject("lblCaTrucNVDangKy.Image")));
            this.lblCaTrucNVDangKy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCaTrucNVDangKy.Location = new System.Drawing.Point(472, 239);
            this.lblCaTrucNVDangKy.Margin = new System.Windows.Forms.Padding(0);
            this.lblCaTrucNVDangKy.Name = "lblCaTrucNVDangKy";
            this.lblCaTrucNVDangKy.Padding = new System.Windows.Forms.Padding(2);
            this.lblCaTrucNVDangKy.Size = new System.Drawing.Size(145, 53);
            this.lblCaTrucNVDangKy.TabIndex = 24;
            this.lblCaTrucNVDangKy.Text = "Ca Trực :";
            this.lblCaTrucNVDangKy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCaTrucNVDangKy.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(472, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2);
            this.label5.Size = new System.Drawing.Size(145, 54);
            this.label5.TabIndex = 23;
            this.label5.Text = "Họ Tên :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.UseCompatibleTextRendering = true;
            // 
            // rdAdminDangKy
            // 
            this.rdAdminDangKy.AutoSize = true;
            this.rdAdminDangKy.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAdminDangKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdAdminDangKy.Location = new System.Drawing.Point(213, 261);
            this.rdAdminDangKy.Name = "rdAdminDangKy";
            this.rdAdminDangKy.Size = new System.Drawing.Size(80, 25);
            this.rdAdminDangKy.TabIndex = 28;
            this.rdAdminDangKy.TabStop = true;
            this.rdAdminDangKy.Text = "Admin";
            this.rdAdminDangKy.UseVisualStyleBackColor = true;
            this.rdAdminDangKy.CheckedChanged += new System.EventHandler(this.rdAdminDangKy_CheckedChanged);
            // 
            // rdThuThuDangKy
            // 
            this.rdThuThuDangKy.AutoSize = true;
            this.rdThuThuDangKy.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdThuThuDangKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdThuThuDangKy.Location = new System.Drawing.Point(326, 261);
            this.rdThuThuDangKy.Name = "rdThuThuDangKy";
            this.rdThuThuDangKy.Size = new System.Drawing.Size(86, 25);
            this.rdThuThuDangKy.TabIndex = 29;
            this.rdThuThuDangKy.TabStop = true;
            this.rdThuThuDangKy.Text = "Thủ Thư";
            this.rdThuThuDangKy.UseVisualStyleBackColor = true;
            this.rdThuThuDangKy.CheckedChanged += new System.EventHandler(this.rdThuThuDangKy_CheckedChanged);
            // 
            // txtCaNVDangKy
            // 
            this.txtCaNVDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaNVDangKy.Location = new System.Drawing.Point(625, 252);
            this.txtCaNVDangKy.Name = "txtCaNVDangKy";
            this.txtCaNVDangKy.Size = new System.Drawing.Size(212, 26);
            this.txtCaNVDangKy.TabIndex = 30;
            // 
            // btnHuyDangKy
            // 
            this.btnHuyDangKy.BackColor = System.Drawing.Color.SeaGreen;
            this.btnHuyDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyDangKy.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnHuyDangKy.FlatAppearance.BorderSize = 0;
            this.btnHuyDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyDangKy.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyDangKy.ForeColor = System.Drawing.Color.White;
            this.btnHuyDangKy.Location = new System.Drawing.Point(213, 365);
            this.btnHuyDangKy.Name = "btnHuyDangKy";
            this.btnHuyDangKy.Size = new System.Drawing.Size(172, 41);
            this.btnHuyDangKy.TabIndex = 32;
            this.btnHuyDangKy.Text = "Quay Về";
            this.btnHuyDangKy.UseVisualStyleBackColor = false;
            this.btnHuyDangKy.Click += new System.EventHandler(this.btnHuyDangKy_Click);
            // 
            // GUI_DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(894, 454);
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
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCopyright);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClosed);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbTittle);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GUI_DangKy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTittle;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Button btnClosed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtMaNVDangKy;
        private System.Windows.Forms.TextBox txtUserNVDangKy;
        private System.Windows.Forms.TextBox txtPassNVDangKy;
        private System.Windows.Forms.TextBox txtHoTenNVDangKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCaTrucNVDangKy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdAdminDangKy;
        private System.Windows.Forms.RadioButton rdThuThuDangKy;
        private System.Windows.Forms.TextBox txtCaNVDangKy;
        private System.Windows.Forms.Button btnHuyDangKy;
    }
}

