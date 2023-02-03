﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DTO_QuanLy;
using BUS_QuanLy;
using DAL_QuanLy;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using CrystalDecisions.CrystalReports.Engine;
namespace GUI_QuanLy
{

    public partial class GUI_Home : Form
    {
        [DllImport("Kernel32.dll")]
        static extern Boolean AllocConsole();
        public delegate void delPassData(string loai);
        BUS_NhanVien busUP = new BUS_NhanVien();
        BUS_TaiLieu TL = new BUS_TaiLieu();

        public string pathReport = @"C:\\Users\\Windows 8.1 Ultimate\\Desktop\\QLTV_Offical\\QuanLyThuVien\\GUI_QuanLy\\";
        /*
         * PHẦN XỬ LÝ GIAO DIỆN FORM
         */

        string Quyen = "";
        string maNVHienTai = "";
        public GUI_Home()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            setVisiblePannel();
            Add_IconTab();

        }
        private void tab_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void tab_DrawItem(object sender, DrawItemEventArgs e)
        {        
        }

        /*
         * fuction nhận dữ liệu từ Form Đăng Nhập gửi qua (Tên NV, Quyền)
         */
        public void funData(string ten, string quyen)
        {
            userName.Text = ten;
            label1.Text = quyen;
            Quyen = quyen;
            if(Quyen == "Admin")
            {
                btnQuanTriAdmin.Visible = true;
            }
            BUS_NhanVien busNhanVien = new BUS_NhanVien();
            maNVHienTai = busNhanVien.getMaNhanVienHienTai(userName.Text.ToString()).Trim();
            try
            {
                Image img = Image.FromFile(@"" + maNVHienTai + ".png");
                if (img != null)
                {
                    ptB_AnhNhanVien.Image = img;
                }
                return;
            }
            catch
            {

            }
        }
        /*
         * fuction add icon vào các Tab
         */
        void Add_IconTab()
        {
            tbcDocGia.Dock = DockStyle.Fill;
            tbcDocGia.ImageList = imageList1;
            tbcDocGia.TabPages[0].ImageIndex = 0;
            tbcDocGia.TabPages[1].ImageIndex = 1;


            tbcQuanLiSach.Dock = DockStyle.Fill;
            tbcQuanLiSach.ImageList = imageList2;
            tbcQuanLiSach.TabPages[0].ImageIndex = 4;
            tbcQuanLiSach.TabPages[1].ImageIndex = 2;
            tbcQuanLiSach.TabPages[2].ImageIndex = 3;


            tbcQuanLiPhieu.Dock = DockStyle.Fill;
            tbcQuanLiPhieu.ImageList = imageList4;
            tbcQuanLiPhieu.TabPages[0].ImageIndex = 0;
            tbcQuanLiPhieu.TabPages[1].ImageIndex = 1;
            tbcQuanLiPhieu.TabPages[2].ImageIndex = 3;
            tbcQuanLiPhieu.TabPages[3].ImageIndex = 2;

            tbcPhieuMuon.Dock = DockStyle.Fill;
            tbcPhieuMuon.ImageList = imageList5;
            tbcPhieuMuon.TabPages[0].ImageIndex = 1;
            tbcPhieuMuon.TabPages[1].ImageIndex = 0;

            tbcPhieuTra.Dock = DockStyle.Fill;
            tbcPhieuTra.ImageList = imageList5;
            tbcPhieuTra.TabPages[0].ImageIndex = 2;
            tbcPhieuTra.TabPages[1].ImageIndex = 3;

            tbcQuanTriAdmin.Dock = DockStyle.Fill;
            tbcQuanTriAdmin.ImageList = imageList6;
            tbcQuanTriAdmin.TabPages[0].ImageIndex = 1;
            tbcQuanTriAdmin.TabPages[1].ImageIndex = 0;



        }
        // xử lý ảnh của nhân viên trên picturebox khi onclick
        private void ptB_AnhNhanVien_Click(object sender, EventArgs e)
        {
            // Show hộp thoại open file ra
            // Nhận kết quả trả về qua biến kiểu DialogResult
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;  *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            DialogResult result = openFileDialog1.ShowDialog();

            //Kiểm tra xem người dùng đã chọn file chưa
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                if (FileExtension == "jpeg" || FileExtension == "png" ||
                    FileExtension == "gif" || FileExtension == "jpg")
                {
                    if (System.IO.File.Exists(@"" + maNVHienTai + "_tem.png"))
                    {
                        try
                        {
                            System.IO.File.Delete(@"" + maNVHienTai + "_tem.png");
                        }
                        catch { }
                    }
                    if (File.Exists(@"" + maNVHienTai + ".png"))
                    {

                        Image img = Image.FromFile(openFileDialog1.FileName);
                        ResizeImage r = new ResizeImage();
                        ptB_AnhNhanVien.ImageLocation = openFileDialog1.FileName;


                        ptB_AnhNhanVien.Image = r.ResizeImg(ptB_AnhNhanVien.Width, ptB_AnhNhanVien.Height, img);
                        ptB_AnhNhanVien.Image.Save(@"" + maNVHienTai + "_tem.png", ImageFormat.Png);


                        FileInfo infoOld = new FileInfo(@"" + maNVHienTai + ".png");
                        FileInfo infoNew = new FileInfo(@"" + maNVHienTai + "_tem.png");


                        try
                        {
                            if (infoNew.LastWriteTime > infoOld.LastWriteTime)
                            {
                                infoNew.CopyTo(infoOld.Name, true);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Hãy chọn lại Ảnh !");
                        }

                        ptB_AnhNhanVien.ImageLocation = @"" + maNVHienTai + ".png";
                        System.IO.File.Delete(@"" + maNVHienTai + "_tem.png");
                        return;
                    }
                    else
                    {
                        // Lấy hình ảnh
                        Image img = Image.FromFile(openFileDialog1.FileName);
                        ResizeImage r = new ResizeImage();
                        ptB_AnhNhanVien.Image = r.ResizeImg(ptB_AnhNhanVien.Width, ptB_AnhNhanVien.Height, img);
                        ptB_AnhNhanVien.Image.Save(@"" + maNVHienTai + ".png", ImageFormat.Jpeg);
                    }
                }
                else
                    MessageBox.Show("Vui lòng chọn file ảnh ");
            }
        }

        /*
         * fuction chỉ hiện panel chính , ẩn các panel còn lại
         */
        void setVisiblePannel()
        {
            pnThongKe.Visible = false;        
            panelDocGia.Visible = false;
            panelReport.Visible = false;
            this.panelQLSach.Location = new System.Drawing.Point(217, 93);
            panelQLSach.Visible = true;
            panelQLSach.Size = new Size(910, 470);
        }
        private void tab_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle mouseRect = new Rectangle(e.X, e.Y, 1, 1);
            for (int i = 0; i < tbcDocGia.TabCount; i++)
            {
                if (tbcDocGia.GetTabRect(i).IntersectsWith(mouseRect))
                {
                    tbcDocGia.SelectedIndex = i;
                    break;
                }
            }
        }

        /*
         * fuction : Form1_MouseDown(), Form1_MouseMove()
         * Di chuyển form trên màn hình
         */
        private bool drag = false;
        private Point dragCursor, dragForm;

        public Font Arial { get; private set; }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            dragCursor = Cursor.Position;
            dragForm = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int wid = SystemInformation.VirtualScreen.Width;
            int hei = SystemInformation.VirtualScreen.Height;
            if (drag)
            {
                // Phải using System.Drawing;
                Point change = Point.Subtract(Cursor.Position, new Size(dragCursor));
                Point newpos = Point.Add(dragForm, new Size(change));             
                this.Location = newpos;
            }
        }

        /* 
         * Kết thúc di chuyển form
         */

        /*
        * fuction : thu nhỏ form và đóng ứng dụng
        * Di chuyển form trên màn hình
        */
        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Xác nhận Đăng Xuất Tài Khoản "+ userName.Text.ToUpper()), "Xác nhận ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GUI_DangNhap f_DN = new GUI_DangNhap();
                f_DN.Show();
                this.Close();
                return;
            }
           
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            BUS_DocGia busDocGia = new BUS_DocGia();
            pnThongKe.Visible = false;
            rdMaDGSearch.Checked = true;       
            panelQLSach.Visible = false;
            panelReport.Visible = false;
            panelQuanTriAdmin.Visible = false;
            this.panelDocGia.Location = new System.Drawing.Point(217, 93);
            panelDocGia.Visible = true;
            if (dgvDGSearch.RowCount > 1)
            {
                btnXemChiTiet.Show();              
                btnLapPhieMuon.Show();
                btnLapPhieuCanhCao.Show();
                btnLapPhieuTra.Show();
                btnXoaDocGia.Show();
            
            }
            // Tìm mã Độc Giả Tiếp theo để Thêm Mới
            txtMaDG.Text = busDocGia.TimMaDocGiaTiepTheo();
            Hide_ChiTietDG();
        }

        private void lbTittle_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            Hide_ChiTietTaiLieu();

            txtCapNhatCTPM.Hide();
            lbDanhSachSachTraHide.Hide();
            dgvDGSearch.RowHeadersVisible = false;
            dgvNhanVien.RowHeadersVisible = false;
            dgvPhieuMuon.RowHeadersVisible = false;
            dgvPhieuTra.RowHeadersVisible = false;
            dgvSearchTaiLieu.RowHeadersVisible = false;
            dgvYeuCauTaiLieu.RowHeadersVisible = false;

            dgvDGSearch.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvPhieuMuon.AllowUserToAddRows = false;
            dgvPhieuTra.AllowUserToAddRows = false;
            dgvSearchTaiLieu.AllowUserToAddRows = false;
            dgvYeuCauTaiLieu.AllowUserToAddRows = false;
            lbListSachMuonHide.Hide();

            // gán mã Tài Liệu Lúc Thêm Mới Tài Liệu
            BUS_TaiLieu busTL = new BUS_TaiLieu();
            txtMaTL.Enabled = false;
            txtMaTL.Text = busTL.TimMaTLTiepTheo();

            btnChinhSuaTL.Hide();
            btnLuuTL.Hide();
            btnHuyTL.Hide();
            btnXemChiTietTL.Hide();
            btnXoaTL.Hide();
            btnLapPhieuMuonTL.Hide();
            btnYeuCauTL.Hide();


            txtSearchTaiLieu.Hide();
            lblTenTaiLieu.Hide();
            lblMaTaiLieu.Hide();
            txtSearchTaiLieu.ReadOnly = false;
            btnXemChiTiet.Hide();
            btnXoaDocGia.Hide();
            btnLapPhieMuon.Hide();
            btnLapPhieuCanhCao.Hide();
            btnLapPhieuTra.Hide();

            BUS_TaiLieu tl = new BUS_TaiLieu();
            cbxLoaiTaiLieu.DataSource = tl.LoadTheLoaiTaiLieu();
            cbxLoaiTaiLieu.DisplayMember = "LoaiTaiLieu";
            cbxLoaiTaiLieu.ValueMember = "LoaiTaiLieu";

            txtMaDG.Enabled = false;
            cbxDinhDanh.Hide();

            this.cbxDinhDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbxDinhDanh.Text = "CMND";
            cbxDinhDanh.Items.Add("CMND");
            cbxDinhDanh.Items.Add("MSSV");
            cbxDinhDanh.Items.Add("MCB");

            btnLuu.Hide();
            btnHuy.Hide();
            btnChinhSua.Hide();

            BUS_Phieu bp = new BUS_Phieu();

            cbxMaDGPM.DataSource = bp.LayDanhSachMaDocGia();
            cbxMaDGPM.DisplayMember = "HoTen";
            cbxMaDGPM.ValueMember = "MaDocGia";

            cbxMaTLPM.DataSource = bp.LayDanhSachMaTailieu();
            cbxMaTLPM.DisplayMember = "TenTaiLieu";
            cbxMaTLPM.ValueMember = "MaTaiLieu";

            cbxMaPMCuaPT.DataSource = bp.getListPhieuMuon();
            cbxMaPMCuaPT.DisplayMember = "MaPhieuMuon";
            cbxMaPMCuaPT.ValueMember = "MaPhieuMuon";


        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void rdSinhVien_CheckedChanged(object sender, EventArgs e)
        {
            txtMSSVDG.Show();
            lblMSSVDangKy.Show();
            txtMSCBDG.Hide();
            //txtCMNDDG.Hide();
            lblMSCBDangKy.Hide();
        }

        private void rdCanBo_CheckedChanged(object sender, EventArgs e)
        {
            txtMSCBDG.Show();
            lblMSCBDangKy.Show();
            txtMSSVDG.Hide();
            //txtCMNDDG.Hide();
            lblMSSVDangKy.Hide();
        }

        private void rdKhac_CheckedChanged(object sender, EventArgs e)
        {
            txtCMNDDG.Show();
            txtMSSVDG.Hide();
            txtMSCBDG.Hide();
            lblMSSVDangKy.Hide();
            lblMSCBDangKy.Hide();
        }

        /*
         * PHẦN XỬ LÝ NHÂN VIÊN
         */

        //xem danh sách nhân viên
        private void btnCapNhatNV_Click(object sender, EventArgs e)
        {
            if (Quyen == "Admin")
            {
                int rowindex = dgvNhanVien.CurrentRow.Index;
                string manvxoa = dgvNhanVien[0, dgvNhanVien.CurrentRow.Index].Value.ToString();
                if (manvxoa == "")
                {
                    MessageBox.Show("Vui lòng Chọn Nhân Viên !");
                    return;
                }
                else
                {
                    if (MessageBox.Show(string.Format("Xác nhận Cập nhật Nhân Viên {0}", manvxoa), "Xác nhận ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtSearchPhieuMuon.Text = dgvNhanVien[0, dgvNhanVien.CurrentRow.Index].Value.ToString().Trim();
                        txtSearchPhieuMuon.Enabled = false;
                        txtHoTenNVCapNhat.Text = dgvNhanVien[4, dgvNhanVien.CurrentCell.RowIndex].Value.ToString().ToUpper().Trim();
                        txtTenDangNhapNVCapNhat.Text = dgvNhanVien[2, dgvNhanVien.CurrentCell.RowIndex].Value.ToString().Trim();
                        txtMatKhauNVCapNhat.Text = "********";
                        txtCaTrucNVCapNhat.Text = dgvNhanVien[1, dgvNhanVien.CurrentCell.RowIndex].Value.ToString().Trim();

                        string loaiNV = dgvNhanVien[6, dgvNhanVien.CurrentCell.RowIndex].Value.ToString().Trim();
                        if (loaiNV == "AD")
                            rdAdminCapNhat.Checked = true;
                        else if (loaiNV == "TT")
                            rdThuThuCapNhat.Checked = true;

                    }

                }
            }
            else
            {
                MessageBox.Show("Bạn Không Phải ADMIN, Bạn Không Có Quyền Cập Nhật Nhân Viên !!!");
            }
        }
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            BUS_NhanVien busNhanVien = new BUS_NhanVien();
            if (Quyen == "Admin")
            {
                try
                {
                    int rowindex = dgvNhanVien.CurrentRow.Index;
                    string manvxoa = dgvNhanVien[0, dgvNhanVien.CurrentRow.Index].Value.ToString().Trim();


                    if (manvxoa == maNVHienTai)
                    {
                        MessageBox.Show("Tài Khoản Nhân Viên Đang Được Sử Dụng !");
                        return;
                    }
                    if (manvxoa == "")
                    {
                        MessageBox.Show("Vui lòng Chọn Nhân Viên Cần Xóa");
                        return;
                    }
                    if (MessageBox.Show(string.Format("Xác nhận xóa Nhân Viên {0}", manvxoa), "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        busNhanVien.XoaNhanVien(manvxoa);
                        MessageBox.Show("Xóa Nhân Viên Thành Công");
                    }
                    dgvNhanVien.DataSource = busUP.getNV();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi");
                    throw ex;
                }

            }
            else MessageBox.Show("Bạn Không Phải ADMIN, Bạn Không Có Quyền Xóa Nhân Viên !!!");
        }
        /*
         * Hàm kiểm tra dữ liệu đầu vào là số
         */
        static public bool CheckNumber(string pValue)
        {
            if (pValue == "")
            {
                return false;
            }
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        /*
        * Hàm băm SHA
        */
        private string EncodeSHA1(string pass)
        {

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
            bs = sha1.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x").ToLower());
            }
            pass = s.ToString();
            return pass;
        }
        private void btnCapNhatNhanVien_Click(object sender, EventArgs e)
        {
            if (txtMatKhauNVCapNhat.Text == "********" || txtMatKhauNVCapNhat.Text == "")
            {
                MessageBox.Show("Vui lòng nhập lại Mật Khẩu Mới !");
                return;
            }
            if (txtSearchPhieuMuon.Text != "" && txtHoTenNVCapNhat.Text != "" && txtTenDangNhapNVCapNhat.Text != "" && (txtMatKhauNVCapNhat.Text != "********" && txtMatKhauNVCapNhat.Text != "")
                && txtCaTrucNVCapNhat.Text != "")
            {
                if (Quyen == "Admin")
                {

                    if (CheckNumber(txtCaTrucNVCapNhat.Text) == false)
                    {
                        MessageBox.Show("Ca Trực Phải là Số Nguyên !");
                        return;
                    }
                    try
                    {
                        string manv = txtSearchPhieuMuon.Text;
                        string hotennv = txtHoTenNVCapNhat.Text;
                        string tendangnhapnv = txtTenDangNhapNVCapNhat.Text;
                        string salt = "QUYETDAICA1997";
                        string mkhaudangnhapnv = EncodeSHA1(txtMatKhauNVCapNhat.Text + salt);
                        string catruc = txtCaTrucNVCapNhat.Text;
                        string loai = "";
                        if (rdAdminCapNhat.Checked == true)
                            loai = "AD";
                        else if (rdThuThuCapNhat.Checked == true)
                        {
                            loai = "TT";
                        }


                        // Tạo DTo
                        DTO_NhanVien up = new DTO_NhanVien(manv, tendangnhapnv, hotennv, mkhaudangnhapnv, loai, catruc); // Vì ID tự tăng nên để ID số gì cũng dc
                        BUS_NhanVien nv = new BUS_NhanVien();
                        if (nv.updateNV(up))
                        {
                            BUS_NhanVien nhv = new BUS_NhanVien();
                            dgvNhanVien.DataSource = nhv.getNV();
                            MessageBox.Show("Cập Nhật Nhân Viên Thành Công!!!");

                        }
                        else MessageBox.Show("Cập Nhật Nhân Viên Không Thành Công!!!");

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi");
                        throw ex;
                    }

                    txtSearchPhieuMuon.Text = null;
                    txtHoTenNVCapNhat.Text = null;
                    txtTenDangNhapNVCapNhat.Text = null;
                    txtMatKhauNVCapNhat.Text = null;
                    txtCaTrucNVCapNhat.Text = null;
                    rdAdminCapNhat.Checked = false;
                    rdThuThuCapNhat.Checked = false;

                }
                else MessageBox.Show("Bạn Không Phải ADMIN, Bạn Không Có Quyền Cập Nhật Nhân Viên !!!");
            }

            else
            {
                MessageBox.Show("Xin hãy nhập đầy đủ");
            }

        }
        private void btnHuyCapNhapNV_Click(object sender, EventArgs e)
        {
            txtSearchPhieuMuon.Text = null;
            txtHoTenNVCapNhat.Text = null;
            txtTenDangNhapNVCapNhat.Text = null;
            txtMatKhauNVCapNhat.Text = null;
            txtCaTrucNVCapNhat.Text = null;
            rdAdminCapNhat.Checked = false;
            rdThuThuCapNhat.Checked = false;
        }

        /*
         * PHẦN XỬ LÝ ĐỘC GIẢ
         */
        // kiểm tra dữ liệu Ngày
        protected bool CheckDate(String date)
        {
            try
            {
                // convert dữ liệu từ datetime 
                DateTime dt2 = Convert.ToDateTime(date);
                date = dt2.ToString("yyyy-MM-dd");
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void btnDangKyDocGia_Click(object sender, EventArgs e)
        {
            BUS_DocGia busDocGia = new BUS_DocGia();
            try
            {
                txtMaDG.Enabled = false;

                string tendocgia = txtTenDG.Text;
                string ngaysinh = "";
                string diachi = txtDiaChiDG.Text;
                string sdt = txtSDTDG.Text;
                string email = txtEmailDG.Text;
                string cmnd = txtCMNDDG.Text;
                string mscb = txtMSCBDG.Text;
                string mssv = txtMSSVDG.Text;

                ngaysinh = dtpk_ngaysinhDocGia.Value.ToString();
                // convert dữ liệu từ datetime picker
                DateTime dt2 = Convert.ToDateTime(ngaysinh);
                ngaysinh = dt2.ToString("yyyy-MM-dd");

                string loai;
                if (rdSinhVien.Checked == true)
                    loai = "SV";
                else if (rdCanBo.Checked == true)
                    loai = "CBNV";
                else
                    loai = "K";

                if (tendocgia == "" || ngaysinh == "" || diachi == "" || sdt == "" || email == "")
                {
                    MessageBox.Show("Vui lòng điền đủ thông tin trước khi Thêm Độc Giả!");
                    return;
                }
                if (cmnd == "" && mscb == "" && mssv == "")
                {
                    MessageBox.Show("Vui lòng chọn Loại Độc Giả !");
                    return;
                }
                if (rdSinhVien.Checked == false && rdCanBo.Checked == false && rdKhac.Checked == false)
                {
                    MessageBox.Show("Vui lòng chọn Loại Độc Giả !");
                    return;
                }
                if ((CheckNumber(cmnd) == false || cmnd == "") && rdKhac.Checked == true)
                {
                    MessageBox.Show("Vui lòng nhập lại Số CMND !");
                    return;
                }
                if (mssv == "" && rdSinhVien.Checked == true)
                {
                    MessageBox.Show("Vui lòng nhập lại MSSV !");
                    return;
                }
                if (mscb == "" && rdCanBo.Checked == true)
                {
                    MessageBox.Show("Vui lòng nhập lại Mã Số CB !");
                    return;
                }
                if (CheckNumber(sdt) == false)
                {
                    MessageBox.Show("Vui lòng Nhập lại Số Điện Thoại!");
                    return;
                }

                DTO_DocGia DTO = new DTO_DocGia(txtMaDG.Text, tendocgia, ngaysinh, diachi, sdt, email, cmnd, mssv, mscb, loai);
                if (busDocGia.ThemDocGia(DTO))
                    MessageBox.Show("Đăng ký Độc Giả Thành Công!!!");
                else
                    MessageBox.Show("Đăng Ký không Thành Công\n Lỗi Dữ Liệu Nhập!!!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi");
                throw ex;
            }
            txtTenDG.Text = null;
            txtDiaChiDG.Text = null;
            txtSDTDG.Text = null;
            txtEmailDG.Text = null;
            txtCMNDDG.Text = null;
            txtMSCBDG.Text = null;
            txtMSSVDG.Text = null;
            rdSinhVien.Checked = false;
            rdCanBo.Checked = false;
            rdKhac.Checked = false;
            txtMaDG.Text = busDocGia.TimMaDocGiaTiepTheo();
        }

        private void btnSearchDocGia_Click(object sender, EventArgs e)
        {
           
            BUS_DocGia busDocGia = new BUS_DocGia();
            btnLuu.Hide();
            btnHuy.Hide();
            btnChinhSua.Hide();

            btnXemChiTiet.Show();
            btnXoaDocGia.Show();
            btnLapPhieMuon.Show();
            btnLapPhieuCanhCao.Show();
            btnLapPhieuTra.Show();



            string select = cbxDinhDanh.GetItemText(this.cbxDinhDanh.SelectedItem);
            if ((rdMaDGSearch.Checked == false && rdMaDinhDanhSearch.Checked == false && rdHoTenSearch.Checked == false) || (rdMaDinhDanhSearch.Checked == true && select == "") || (txtSearchDG.Text == ""))
            {
                MessageBox.Show("Lỗi Rồi Bạn Êi :( \nTìm Kiếm Gì Thì Nhớ Điền Đầy Đủ Nha");
                return;
            }
            else
            {
                string strSql = "";
                string Search = txtSearchDG.Text;
                if (rdMaDGSearch.Checked == true)
                {
                    strSql = "exec usp_TimKiemDocGiaTheoMaDocGia " + Search;
                }

                else if (rdMaDinhDanhSearch.Checked == true)
                {
                    if (select == "MSSV")
                    {
                        strSql = "exec usp_TimKiemDocGiaTheoMSSV " + Search;
                    }

                    else if (select == "MSCB")
                    {
                        strSql = "exec usp_TimKiemDocGiaTheoMSCB " + Search;
                    }

                    else if (select == "CMND")
                    {
                        strSql = "exec usp_TimKiemDocGiaTheoCMND " + Search;
                    }
                }
                else if (rdHoTenSearch.Checked == true)
                {
                    strSql = "exec usp_TimKiemDocGiaTheoHoTen N'" + Search + "'";
                }

                dgvDGSearch.DataSource = busDocGia.SearchDocGiaTheoTieuChi(strSql);
                dgvDGSearch.ReadOnly = true;

                dgvDGSearch.Columns[0].HeaderText = "Mã Độc Giả";
                dgvDGSearch.Columns[1].HeaderText = "Họ Tên";
                dgvDGSearch.Columns[3].HeaderText = "Loại Độc Giả";
                Hide_ChiTietDG();
            }

        }
        private void cbxDinhDanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDinhDanh.SelectedIndex == 0)
            {
                lblDinhDanhSearch.Text = "CMND";
            }
            if (cbxDinhDanh.SelectedIndex == 1)
            {
                lblDinhDanhSearch.Text = "MSSV";
            }
            if (cbxDinhDanh.SelectedIndex == 2)
            {
                lblDinhDanhSearch.Text = "MSCB";
            }
        }
        private void rdMaDGSearch_CheckedChanged(object sender, EventArgs e)
        {
            lblMaDGSearch.Show();
            lblDinhDanhSearch.Hide();
            lblHoTenSearch.Hide();
            txtSearchDG.Show();
            cbxDinhDanh.Hide();
        }

        private void rdMaDinhDanhSearch_CheckedChanged(object sender, EventArgs e)
        {
            cbxDinhDanh.Text = "CMND";
            lblMaDGSearch.Hide();
            lblDinhDanhSearch.Show();
            lblHoTenSearch.Hide();
            txtSearchDG.Show();
            cbxDinhDanh.Show();
        }

        private void rdHoTenSearch_CheckedChanged(object sender, EventArgs e)
        {
            lblMaDGSearch.Hide();
            lblDinhDanhSearch.Hide();
            lblHoTenSearch.Show();
            txtSearchDG.Show();
            cbxDinhDanh.Hide();
        }

        private void btnXemAllDocGia_Click(object sender, EventArgs e)
        {
            Hide_ChiTietDG();
            BUS_DocGia busDocGia = new BUS_DocGia();
            btnLuu.Hide();
            btnHuy.Hide();
            btnChinhSua.Hide();

            btnXemChiTiet.Show();
            btnXoaDocGia.Show();
            btnLapPhieMuon.Show();
            btnLapPhieuCanhCao.Show();
            btnLapPhieuTra.Show();

            //dgvDGSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDGSearch.DataSource = busDocGia.getAllDocGia();


            dgvDGSearch.ReadOnly = true;
            dgvDGSearch.Columns[0].ReadOnly = true;
            dgvDGSearch.Columns[0].HeaderText = "Mã Độc Giả";
            dgvDGSearch.Columns[1].HeaderText = "Họ Tên";
            dgvDGSearch.Columns[3].HeaderText = "Loại Độc Giả";

        }
        void ReadOnly_ChiTietDG() {

            rdCTCB_DG.Enabled = false;
            rdCTKhach_DG.Enabled = false;
            rdCTSV_DG.Enabled = false;
            dtkCTNgaySinhDG.Enabled = false;

            txtCTCMNDDG.ReadOnly = true;
            txtCTDiaChiDG.ReadOnly = true;
            txtCTEmailDG.ReadOnly = true;
            txtCTMaDG.ReadOnly = true;
            txtCTMSCB_DG.ReadOnly = true;
            txtCTMSSV_DG.ReadOnly = true;
            txtCTPhoneDG.ReadOnly = true;
            txtCTTenDG.ReadOnly = true;

        }
        void UnReadOnly_ChiTietDG()
        {
            rdCTCB_DG.Enabled = true;
            rdCTKhach_DG.Enabled = true;
            rdCTSV_DG.Enabled = true;
            dtkCTNgaySinhDG.Enabled = true;

            txtCTCMNDDG.ReadOnly = false;
            txtCTDiaChiDG.ReadOnly = false;
            txtCTEmailDG.ReadOnly = false;
            txtCTMaDG.ReadOnly = true;
            txtCTMSCB_DG.ReadOnly = false;
            txtCTMSSV_DG.ReadOnly = false;
            txtCTPhoneDG.ReadOnly = false;
            txtCTTenDG.ReadOnly = false;
        }
        void Hide_ChiTietDG()
        {

            lbCTCMNDDG.Hide();
            lbCTDiaChiDG.Hide();
            lbCTEmailDG.Hide();
            lbCTLoaiDG.Hide();
            lbCTMaDG.Hide();
            lbCTNgaySinhDG.Hide();
            lbCTPhoneDG.Hide();
            lbCTTenDG.Hide();
            lbCTMSCB_DG.Hide();
            lbCTMSSV_DG.Hide();

            rdCTCB_DG.Hide();
            rdCTKhach_DG.Hide();
            rdCTSV_DG.Hide();

            dtkCTNgaySinhDG.Hide();

            txtCTCMNDDG.Hide();
            txtCTDiaChiDG.Hide();
            txtCTEmailDG.Hide();
            txtCTMaDG.Hide();
            txtCTMSCB_DG.Hide();
            txtCTMSSV_DG.Hide();
            txtCTPhoneDG.Hide();
            txtCTTenDG.Hide();

            dgvDGSearch.Show();
        }
        void Show_ChiTietDG()
        {

            lbCTCMNDDG.Show();
            lbCTDiaChiDG.Show();
            lbCTEmailDG.Show();
            lbCTLoaiDG.Show();
            lbCTMaDG.Show();
            lbCTNgaySinhDG.Show();
            lbCTPhoneDG.Show();
            lbCTTenDG.Show();
            lbCTMSCB_DG.Show();
            lbCTMSSV_DG.Show();

            rdCTCB_DG.Show();
            rdCTKhach_DG.Show();
            rdCTSV_DG.Show();

            dtkCTNgaySinhDG.Show();

            txtCTCMNDDG.Show();
            txtCTDiaChiDG.Show();
            txtCTEmailDG.Show();
            txtCTMaDG.Show();
            txtCTMSCB_DG.Show();
            txtCTMSSV_DG.Show();
            txtCTPhoneDG.Show();
            txtCTTenDG.Show();

            dgvDGSearch.Hide();
        }
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            BUS_DocGia busDocGia = new BUS_DocGia();
            DataGridView dgvTemp = new DataGridView();
            string secondCellValue = dgvDGSearch[0, dgvDGSearch.CurrentRow.Index].Value.ToString();
            //dgvDGSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDGSearch.DataSource = busDocGia.XemChiTietDocGia(secondCellValue);

            string loai = dgvDGSearch[9, dgvDGSearch.CurrentRow.Index].Value.ToString().Trim();          
            if (loai == "K")
            {
                rdCTKhach_DG.Checked = true;
                rdCTKhach_DG_CheckedChanged(sender, e);
            }
               
            if (loai == "SV")
            {
                rdCTSV_DG_CheckedChanged(sender, e);
                rdCTSV_DG.Checked = true;
            }
                
            if (loai == "CBNV")
            {
                rdCTCB_DG_CheckedChanged(sender, e);
                rdCTCB_DG.Checked = true;
            }
               


            dtkCTNgaySinhDG.Text = dgvDGSearch[2, dgvDGSearch.CurrentRow.Index].Value.ToString();

            txtCTCMNDDG.Text = dgvDGSearch[6, dgvDGSearch.CurrentRow.Index].Value.ToString().Trim();
            txtCTDiaChiDG.Text = dgvDGSearch[3, dgvDGSearch.CurrentRow.Index].Value.ToString().Trim();
            txtCTEmailDG.Text = dgvDGSearch[5, dgvDGSearch.CurrentRow.Index].Value.ToString().Trim();
            txtCTMaDG.Text = dgvDGSearch[0, dgvDGSearch.CurrentRow.Index].Value.ToString().Trim();
            txtCTMSCB_DG.Text = dgvDGSearch[8, dgvDGSearch.CurrentRow.Index].Value.ToString().Trim();
            txtCTMSSV_DG.Text = dgvDGSearch[7, dgvDGSearch.CurrentRow.Index].Value.ToString().Trim();
            txtCTPhoneDG.Text = dgvDGSearch[4, dgvDGSearch.CurrentRow.Index].Value.ToString().Trim();
            txtCTTenDG.Text = dgvDGSearch[1, dgvDGSearch.CurrentRow.Index].Value.ToString().Trim();
            Show_ChiTietDG();

            btnXemChiTiet.Hide();
            btnXoaDocGia.Hide();
            btnLapPhieMuon.Hide();
            btnLapPhieuCanhCao.Hide();
            btnLapPhieuTra.Hide();

            ReadOnly_ChiTietDG();

            btnHuy.Show();
            btnLuu.Show();
            btnChinhSua.Show();
            btnHuy.Text = "Hủy";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ReadOnly_ChiTietDG();
            //BUS_DocGia busDocGia = new BUS_DocGia();
            //try
            //{
            //    string madocgia = dgvDGSearch[0, dgvDGSearch.CurrentRow.Index].Value.ToString();
            //    string hoten = dgvDGSearch[1, dgvDGSearch.CurrentCell.RowIndex].Value.ToString().ToUpper();
            //    string ngaysinh = dgvDGSearch[2, dgvDGSearch.CurrentCell.RowIndex].Value.ToString();
            //    if (CheckDate(ngaysinh) == false)
            //    {
            //        MessageBox.Show("Vui lòng Nhập lại Ngày Sinh !");
            //        return;
            //    }
            //    try
            //    {
            //        // convert dữ liệu từ datetime 
            //        DateTime dt2 = Convert.ToDateTime(ngaysinh);
            //        ngaysinh = dt2.ToString("yyyy-MM-dd");
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Vui lòng Nhập lại Ngày Sinh !");
            //        return;
            //    }
            //    string diachi = dgvDGSearch[3, dgvDGSearch.CurrentCell.RowIndex].Value.ToString();
            //    string sdt = dgvDGSearch[4, dgvDGSearch.CurrentCell.RowIndex].Value.ToString();
            //    string email = dgvDGSearch[5, dgvDGSearch.CurrentCell.RowIndex].Value.ToString().ToUpper();
            //    string cmnd = dgvDGSearch[6, dgvDGSearch.CurrentCell.RowIndex].Value.ToString();
            //    string mssv = dgvDGSearch[7, dgvDGSearch.CurrentCell.RowIndex].Value.ToString();
            //    string mcb = dgvDGSearch[8, dgvDGSearch.CurrentCell.RowIndex].Value.ToString();
            //    string loai = dgvDGSearch[9, dgvDGSearch.CurrentCell.RowIndex].Value.ToString();

            //    //string[] ns = ngaysinh.Split(' ');

            //    DTO_DocGia DTO_DocGia = new DTO_DocGia(madocgia, hoten, ngaysinh, diachi, sdt, email, cmnd, mssv, mcb, loai);
            //    busDocGia.CapNhatDocGia(DTO_DocGia);

            //    MessageBox.Show("Cập Nhật Độc Giả Thành Công!!!");
            //    btnHuy.Text = "Thoát";
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show("Cập Nhật Thất Bại :(");
            //    MessageBox.Show("Cập Nhật Thất Bại :(" + ex.ToString());
            //    return;
            //    throw ex;
            //}
            BUS_DocGia busDocGia = new BUS_DocGia();
            try
            {
               
                string tendocgia = txtCTTenDG.Text;
                string ngaysinh = "";
                string diachi = txtCTDiaChiDG.Text;
                string sdt = txtCTPhoneDG.Text;
                string email = txtCTEmailDG.Text;
                string cmnd = txtCTCMNDDG.Text;
                string mscb = txtCTMSCB_DG.Text;
                string mssv = txtCTMSSV_DG.Text;

                ngaysinh = dtkCTNgaySinhDG.Value.ToString();
                // convert dữ liệu từ datetime picker
                DateTime dt2 = Convert.ToDateTime(ngaysinh);
                ngaysinh = dt2.ToString("yyyy-MM-dd");

                string loai;
                if (rdCTSV_DG.Checked == true)
                    loai = "SV";
                else if (rdCTCB_DG.Checked == true)
                    loai = "CBNV";
                else
                    loai = "K";

                if (tendocgia == "" || ngaysinh == "" || diachi == "" || sdt == "" || email == "")
                {
                    MessageBox.Show("Vui lòng điền đủ thông tin trước khi Thêm Độc Giả!");
                    return;
                }
                if (cmnd == "" && mscb == "" && mssv == "")
                {
                    MessageBox.Show("Vui lòng chọn Loại Độc Giả !");
                    return;
                }
                if (rdCTSV_DG.Checked == false && rdCTCB_DG.Checked == false && rdCTKhach_DG.Checked == false)
                {
                    MessageBox.Show("Vui lòng chọn Loại Độc Giả !");
                    return;
                }
                if ((CheckNumber(cmnd) == false || cmnd == "") && rdCTKhach_DG.Checked == true)
                {
                    MessageBox.Show("Vui lòng nhập lại Số CMND !");
                    return;
                }
                if (mssv == "" && rdCTSV_DG.Checked == true)
                {
                    MessageBox.Show("Vui lòng nhập lại MSSV !");
                    return;
                }
                if (mscb == "" && rdCTCB_DG.Checked == true)
                {
                    MessageBox.Show("Vui lòng nhập lại Mã Số CB !");
                    return;
                }
                if (CheckNumber(sdt) == false)
                {
                    MessageBox.Show("Vui lòng Nhập lại Số Điện Thoại!");
                    return;
                }

                DTO_DocGia DTO = new DTO_DocGia(txtCTMaDG.Text, tendocgia, ngaysinh, diachi, sdt, email, cmnd, mssv, mscb, loai);
                busDocGia.CapNhatDocGia(DTO);
                MessageBox.Show("Cập Nhật Độc Giả Thành Công!!!");
                btnHuy.Text = "Thoát";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cập Nhật Thất Bại :(");
                return;
                throw ex;
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnXemChiTiet.Hide();
            btnXoaDocGia.Hide();
            btnLapPhieMuon.Hide();
            btnLapPhieuCanhCao.Hide();
            btnLapPhieuTra.Hide();
            btnHuy.Hide();
            btnLuu.Hide();
            btnChinhSua.Hide();
            Hide_ChiTietDG();

            dgvDGSearch.DataSource = null;
            // load lại danh sách
            btnXemAllDocGia_Click(sender, e);
            ReadOnly_ChiTietDG();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            dgvDGSearch.ReadOnly = false;
            dgvDGSearch.Columns[0].ReadOnly = true;
            UnReadOnly_ChiTietDG();

        }

        private void btnXoaDocGia_Click(object sender, EventArgs e)
        {
            BUS_DocGia busDocGia = new BUS_DocGia();
            string madocgia = dgvDGSearch[0, dgvDGSearch.CurrentRow.Index].Value.ToString();
            if (MessageBox.Show(string.Format("Xác nhận xóa độc giả {0}", madocgia), "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (busDocGia.XoaDocGia(madocgia))
                    MessageBox.Show("Xóa Độc Giả Thành Công!!!");
                else
                    MessageBox.Show("Không thể Xóa Độc Giả Này!!!");
            }
            btnXemAllDocGia_Click(sender, e);

        }
        private void btnLapPhieMuon_Click(object sender, EventArgs e)
        {
            string maDocGia = dgvDGSearch[0, dgvDGSearch.CurrentRow.Index].Value.ToString().Trim();
            string tenDG = dgvDGSearch[1, dgvDGSearch.CurrentRow.Index].Value.ToString();
            string loaiDG = dgvDGSearch[3, dgvDGSearch.CurrentRow.Index].Value.ToString().Trim();     
            BUS_DocGia busDG = new BUS_DocGia();
            if (busDG.GetNgayHetHan(maDocGia) == false)
            {
                if (MessageBox.Show(string.Format("Vui Lòng Đóng Phí Để Có Thể Mượn Tài Liệu !"), "Bạn Chưa Đóng Phí ! ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show(string.Format("Đóng Lệ Phí Thành Công !"));
                    busDG.UpdateNgayHetHan(maDocGia, loaiDG);
                }
                else
                {
                    return;
                }
            }

            BUS_Phieu p = new BUS_Phieu();
            int slvp = p.SoLanViPham(maDocGia);
            int sosachdangmuon = Int32.Parse(p.SoSachDangMuon(maDocGia).ToString());
            int sosachmuontoida = p.SoSachMuonToiDa(maDocGia);
            if (slvp < 5)
            {
                if (sosachdangmuon < sosachmuontoida)
                {
                    int rowindex = dgvDGSearch.CurrentRow.Index;
                    btnThongKe_Click(sender, e);
                    cbxMaDGPM.Text = tenDG;
                    cbxMaDGPM.SelectedValue = maDocGia;
                    lbMaDocGia.Text = maDocGia;
                    tbcQuanLiPhieu.SelectedTab = tbcQuanLiPhieu.TabPages[0];
                    tbcPhieuMuon.SelectedTab = tbcPhieuMuon.TabPages[1];
                }
                else MessageBox.Show("Độc giả đã mượn tối đa sách được mượn");
            }
            else MessageBox.Show("Độc giả " + tenDG + " đã quá số lần vi phạm\n Không được sử dụng dịch vụ nữa :(");
        }
        private void btnLapPhieuTra_Click(object sender, EventArgs e)
        {
            int rowindex = dgvDGSearch.CurrentRow.Index;
            string maDG = dgvDGSearch[0, dgvDGSearch.CurrentRow.Index].Value.ToString();
            btnThongKe_Click(sender, e);
            txtSearchPT.Text = maDG;
            tbcQuanLiPhieu.SelectedTab = tbcQuanLiPhieu.TabPages[1];
            tbcPhieuTra.SelectedTab = tbcPhieuTra.TabPages[1];
        }

        private void btnLapPhieuCanhCao_Click(object sender, EventArgs e)
        {
            // chưa xử lý
           // MessageBox.Show("Chưa Xử Lý!!!");

            int rowindex = dgvDGSearch.CurrentRow.Index;
            string maDG = dgvDGSearch[0, dgvDGSearch.CurrentRow.Index].Value.ToString();
            btnThongKe_Click(sender, e);
            cbxmaDocGiaNN.Text = maDG;
            // kéo lại cái tab admin đi
            tbcQuanLiPhieu.SelectedTab = tbcQuanLiPhieu.TabPages[3];
       



        }
        /*
         * PHẦN XỬ LÝ TÀI LIỆU
         */

        private void btnPanelSach_Click(object sender, EventArgs e)
        {
            Hide_ChiTietTaiLieu();
            panelQuanTriAdmin.Visible = false;
            panelQLSach.Visible = true;
            panelDocGia.Visible = false;
            pnThongKe.Visible = false;
            this.panelQLSach.Location = new System.Drawing.Point(217, 93);

            BUS_TaiLieu busTaiLieu = new BUS_TaiLieu();

            // load danh sách yêu cầu tài liệu mới           
            dgvYeuCauTaiLieu.DataSource = busTaiLieu.XemTatCaTaiLieuYeuCauMoi();
            dgvYeuCauTaiLieu.ReadOnly = true;
            if (dgvSearchTaiLieu.RowCount > 1)
            {
                btnXemChiTietTL.Show();
                btnXoaTL.Show();
                btnLapPhieuMuonTL.Show();
            }
          

        }
        private void tbcQuanLiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcQuanLiSach.SelectedTab == tbcQuanLiSach.TabPages[2])
            {
                BUS_TaiLieu busTaiLieu = new BUS_TaiLieu();
                // load danh sách yêu cầu tài liệu mới           
                dgvYeuCauTaiLieu.DataSource = busTaiLieu.XemTatCaTaiLieuYeuCauMoi();
                dgvYeuCauTaiLieu.ReadOnly = true;
                dgvYeuCauTaiLieu.Columns[0].HeaderText = "STT";
                dgvYeuCauTaiLieu.Columns[0].Width = 40;
                dgvYeuCauTaiLieu.Columns[1].HeaderText = "Tên Tài Liệu";

            }
        }
        
        private void btnXemTheoLoai_Click(object sender, EventArgs e)
        {
            Hide_ChiTietTaiLieu();

            string loaitl = cbxLoaiTaiLieu.Text;

            DAL_TaiLieu a = new DAL_TaiLieu();
            delPassData del = new delPassData(a.loai);
            del(loaitl);

            dgvSearchTaiLieu.DataSource = TL.gettheloai();

            dgvSearchTaiLieu.ReadOnly = true;
            dgvSearchTaiLieu.Columns[0].Width = 90;
            dgvSearchTaiLieu.Columns[1].Width = 420;
            dgvSearchTaiLieu.Columns[2].Width = 90;
            dgvSearchTaiLieu.Columns[3].Width = 90;

            dgvSearchTaiLieu.Columns[0].HeaderText = "Mã Tài Liệu";
            dgvSearchTaiLieu.Columns[1].HeaderText = "Tên Tài Liệu";
            dgvSearchTaiLieu.Columns[2].HeaderText = "Loại Tài Liệu";
            dgvSearchTaiLieu.Columns[3].HeaderText = "Số Lượng";

            btnXemChiTietTL.Show();
            btnXoaTL.Show();
            btnLapPhieuMuonTL.Show();
            btnYeuCauTL.Hide();

            btnChinhSuaTL.Hide();
            btnLuuTL.Hide();
            btnHuyTL.Hide();
        }

       

        private void btnSearchTaiLieu_Click(object sender, EventArgs e)
        {
            Hide_ChiTietTaiLieu();
            if (rdTimTLCoBan.Checked == true)
            {
                string matl = txtSearchTaiLieu.Text;
                if (matl == "")
                {
                    MessageBox.Show(string.Format("Vui lòng Nhập Mã Tài Liệu"));
                    return;
                }

                DAL_TaiLieu a = new DAL_TaiLieu();
                delPassData del = new delPassData(a.ma);
                del(matl);

                dgvSearchTaiLieu.DataSource = TL.getTheoMa();

                btnXemChiTietTL.Visible = true;
                btnXoaTL.Visible = true;
                btnLapPhieuMuonTL.Visible = true;

                btnChinhSuaTL.Hide();
                btnLuuTL.Hide();
                btnHuyTL.Hide();
            }

            if (rdTimTLNangCao.Checked == true)
            {

                string tentl = txtSearchTaiLieu.Text;
                if (tentl == "")
                {
                    MessageBox.Show(string.Format("Vui lòng Nhập Tên Tài Liệu"));
                    return;
                }
                DAL_TaiLieu a = new DAL_TaiLieu();
                delPassData del = new delPassData(a.ten);
                del(tentl);

                dgvSearchTaiLieu.DataSource = TL.getTheoTen();

                if (dgvSearchTaiLieu.Rows.Count < 1)
                {
                    btnYeuCauTL.Show();
                }
                else
                {
                    btnYeuCauTL.Hide();
                }


                btnXemChiTietTL.Show();
                btnXoaTL.Show();
                btnLapPhieuMuonTL.Show();


                btnChinhSuaTL.Hide();
                btnLuuTL.Hide();
                btnHuyTL.Hide();
            }
            if (rdTimTLNangCao.Checked == false && rdTimTLCoBan.Checked == false)
            {
                MessageBox.Show(string.Format("Vui lòng chọn Gía trị Tìm Kiếm !"));
                return;
            }
        }

        private void rdTimTLNangCao_CheckedChanged(object sender, EventArgs e)
        {
            lblMaTaiLieu.Hide();
            lblTenTaiLieu.Show();
            txtSearchTaiLieu.Show();
        }

        private void rdTimTLCoBan_CheckedChanged(object sender, EventArgs e)
        {
            lblMaTaiLieu.Show();
            lblTenTaiLieu.Hide();
            txtSearchTaiLieu.Show();
        }

        private void btnThemTaiLieu_Click(object sender, EventArgs e)
        {
            BUS_TaiLieu busTL = new BUS_TaiLieu();
            try
            {
                string tentailieu = txtTenTL.Text;
                string loaitailieu = txtLoaiTL.Text;
                string soluongtailieu = txtSoLuongTL.Text;
                string tldb;
                if (ckbTLDB.Checked)
                    tldb = "True";
                else
                    tldb = "False";
                if (tentailieu == "" || loaitailieu == "" || soluongtailieu == "")
                {
                    MessageBox.Show("Vui lòng điền đủ thông tin trước khi Thêm Tài Liệu !");
                    return;
                }
                if (CheckNumber(soluongtailieu) == false)
                {
                    MessageBox.Show("Vui lòng Nhập lại Số Lượng !");
                    return;
                }

                else
                {
                    DTO_TaiLieu dto = new DTO_TaiLieu(tentailieu, loaitailieu, soluongtailieu, tldb);
                    busTL.ThemTaiLieuMoi(dto);
                    MessageBox.Show("Thêm Tài Liệu Thành Công!!!");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi");
                throw ex;
            }

            txtTenTL.Text = null;
            txtLoaiTL.Text = null;
            txtSoLuongTL.Text = null;
            txtMaTL.Text = busTL.TimMaTLTiepTheo();

        }
        void Hide_ChiTietTaiLieu()
        {
            lbCTMaTL.Hide();
            lbCTSoLuongTL.Hide();
            lbCTTenTaiLieu.Hide();
            lbCTLoaiTaiLieu.Hide();
            cbxCTTLDB.Hide();

            txtCTMaTaiLieu.Hide();
            txtCTSoLuongTL.Hide();
            txtCTTenTaiLieu.Hide();
            cbbCTLoaiTL.Hide();

            dgvSearchTaiLieu.Show();

        }
        void Show_ChiTietTaiLieu()
        {
            lbCTMaTL.Show();
            lbCTSoLuongTL.Show();
            lbCTTenTaiLieu.Show();
            lbCTLoaiTaiLieu.Show();

            cbxCTTLDB.Show();
            txtCTMaTaiLieu.Show();
            txtCTSoLuongTL.Show();
            txtCTTenTaiLieu.Show();
            cbbCTLoaiTL.Show();

            BUS_TaiLieu tl = new BUS_TaiLieu();
            cbbCTLoaiTL.DataSource = tl.LoadTheLoaiTaiLieu();
            cbbCTLoaiTL.DisplayMember = "LoaiTaiLieu";
            cbbCTLoaiTL.ValueMember = "LoaiTaiLieu";
            dgvSearchTaiLieu.Hide();

        }
        private void btnXemChiTietTL_Click(object sender, EventArgs e)
        {
            Show_ChiTietTaiLieu();
            ReadOnly_ChiTietTaiLieu();
            BUS_TaiLieu busTL = new BUS_TaiLieu();
            if (dgvSearchTaiLieu.RowCount < 1)
            {
                return;
            }
            string secondCellValue = dgvSearchTaiLieu[0, dgvSearchTaiLieu.CurrentRow.Index].Value.ToString();
            dgvSearchTaiLieu.ReadOnly = true;

            /*  chỉnh sửa trên nhiều dòng dữ liệu or chỉ 1 dòng dữ liệu   
             *  comment dòng  dgvSearchTaiLieu.DataSource = busTL.XemChitietTaiLieu(secondCellValue);        
             */
            // dgvSearchTaiLieu.DataSource = busTL.XemChitietTaiLieu(secondCellValue);

            //dgvDGSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            string check = dgvSearchTaiLieu[4, dgvSearchTaiLieu.CurrentRow.Index].Value.ToString().Trim();
            if(check == "True")
                cbxCTTLDB.Checked = true;
            else
                cbxCTTLDB.Checked = false;
            txtCTMaTaiLieu.Text = dgvSearchTaiLieu[0, dgvSearchTaiLieu.CurrentRow.Index].Value.ToString().Trim();
            txtCTSoLuongTL.Text = dgvSearchTaiLieu[3, dgvSearchTaiLieu.CurrentRow.Index].Value.ToString().Trim();
            txtCTTenTaiLieu.Text = dgvSearchTaiLieu[1, dgvSearchTaiLieu.CurrentRow.Index].Value.ToString().Trim();
            cbbCTLoaiTL.Text = dgvSearchTaiLieu[2, dgvSearchTaiLieu.CurrentRow.Index].Value.ToString().Trim();

            btnChinhSuaTL.Show();
            btnLuuTL.Show();
            btnHuyTL.Text = "Hủy";
            btnHuyTL.Show();

            btnXemChiTietTL.Hide();
            btnXoaTL.Hide();
            btnLapPhieuMuonTL.Hide();
            btnYeuCauTL.Hide();
        }
        private void btnXoaTL_Click(object sender, EventArgs e)
        {
            if (dgvSearchTaiLieu.RowCount < 1)
            {
                return;
            }
            int rowindex = dgvSearchTaiLieu.CurrentRow.Index;
            string matailieu = dgvSearchTaiLieu[0, dgvSearchTaiLieu.CurrentRow.Index].Value.ToString();
            if (matailieu == "")
            {
                MessageBox.Show(string.Format("Vui lòng chọn Tài Liệu Cần Xóa"));
                return;
            }
            if (MessageBox.Show(string.Format("Xác nhận xóa Tài Liệu {0}", matailieu), "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BUS_TaiLieu busTL = new BUS_TaiLieu();
                if (busTL.XoaChitietTaiLieu(matailieu))
                {
                    MessageBox.Show("Xóa Tài Liệu Thành Công!!!");
                    dgvSearchTaiLieu.Rows.RemoveAt(rowindex);
                }
                else
                {
                    MessageBox.Show("Xóa Tài Liệu Không Thành Công!!!");
                }
                // load lại danh sách tài liều sau khi xóa
                btnXemAllTaiLieu_Click(sender, e);

            }
        }
        private void btnChinhSuaTL_Click(object sender, EventArgs e)
        {
            dgvSearchTaiLieu.ReadOnly = false;
            dgvSearchTaiLieu.Columns[0].ReadOnly = true;
            UnReadOnly_ChiTietTaiLieu();
        }
        void ReadOnly_ChiTietTaiLieu()
        {
          
            cbxCTTLDB.Enabled = false;

            txtCTMaTaiLieu.ReadOnly = true;
            txtCTSoLuongTL.ReadOnly = true;
            txtCTTenTaiLieu.ReadOnly = true;
            cbbCTLoaiTL.Enabled = false;
        }
        void UnReadOnly_ChiTietTaiLieu()
        {
            cbxCTTLDB.Enabled = true;
            txtCTSoLuongTL.ReadOnly = false;
            txtCTTenTaiLieu.ReadOnly = false;
            cbbCTLoaiTL.Enabled = true;
        }
        private void btnLuuTL_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string matailieu = dgvSearchTaiLieu[0, dgvSearchTaiLieu.CurrentRow.Index].Value.ToString();
            //    string tentailieu = dgvSearchTaiLieu[1, dgvSearchTaiLieu.CurrentCell.RowIndex].Value.ToString().ToUpper();
            //    string loaitailieu = dgvSearchTaiLieu[2, dgvSearchTaiLieu.CurrentCell.RowIndex].Value.ToString();
            //    string soluong = dgvSearchTaiLieu[3, dgvSearchTaiLieu.CurrentCell.RowIndex].Value.ToString();
            //    string tldb = dgvSearchTaiLieu[4, dgvSearchTaiLieu.CurrentCell.RowIndex].Value.ToString();
            //    if (matailieu == "" || tentailieu == "" || loaitailieu == "" || soluong == "" || tldb =="")
            //    {
            //        MessageBox.Show("Vui lòng Điền đủ thông tin trước khi Lưu !");
            //        return;
            //    }
            //    else
            //    {
            //        DTO_TaiLieu dto = new DTO_TaiLieu(matailieu, tentailieu, loaitailieu, soluong, tldb);
            //        BUS_TaiLieu busTL = new BUS_TaiLieu();
            //        busTL.LuuChitietTaiLieu(dto);
            //        btnHuyTL.Text = "Thoát";
            //        MessageBox.Show("Cập Nhật Tài Liệu Thành Công!!!");
            //    }

            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show("Cập Nhật Tài Liệu Thất Bại :(");
            //    throw ex;
            //}


            BUS_TaiLieu busTL = new BUS_TaiLieu();
            try
            {
                string tentailieu = txtCTTenTaiLieu.Text;
                string loaitailieu = cbbCTLoaiTL.Text.Trim();
                string soluongtailieu = txtCTSoLuongTL.Text;
                string tldb;
                if (cbxCTTLDB.Checked)
                    tldb = "True";
                else
                    tldb = "False";
                if (tentailieu == "" || loaitailieu == "" || soluongtailieu == "")
                {
                    MessageBox.Show("Vui lòng điền đủ thông tin trước khi Thêm Tài Liệu !");
                    return;
                }
                if (CheckNumber(soluongtailieu) == false)
                {
                    MessageBox.Show("Vui lòng Nhập lại Số Lượng !");
                    return;
                }

                else
                {
                    DTO_TaiLieu dto = new DTO_TaiLieu(txtCTMaTaiLieu.Text, tentailieu, loaitailieu, soluongtailieu, tldb);                   
                    busTL.LuuChitietTaiLieu(dto);
                    btnHuyTL.Text = "Thoát";
                    MessageBox.Show("Cập Nhật Tài Liệu Thành Công!!!");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cập Nhật Tài Liệu Thất Bại :(");
                throw ex;
            }
            ReadOnly_ChiTietTaiLieu();

        }
        private void btnHuyTL_Click(object sender, EventArgs e)
        {
            Hide_ChiTietTaiLieu();
            btnXemChiTietTL.Hide();
            btnXoaTL.Hide();
            btnLapPhieuMuonTL.Hide();
            btnYeuCauTL.Hide();

            btnChinhSuaTL.Hide();
            btnLuuTL.Hide();
            btnHuyTL.Hide();

            dgvSearchTaiLieu.DataSource = null;
            btnXemAllTaiLieu_Click(sender, e);
            ReadOnly_ChiTietTaiLieu();
        }


        private void btnLapPhieuMuonTL_Click(object sender, EventArgs e)
        {
            int soluong = Int32.Parse(dgvSearchTaiLieu[3, dgvSearchTaiLieu.CurrentRow.Index].Value.ToString());
            if (soluong > 0)
            {
                if (dgvSearchTaiLieu.RowCount < 1)
                {
                    return;
                }
                int rowindex = dgvSearchTaiLieu.CurrentRow.Index;
                string matailieu = dgvSearchTaiLieu[0, dgvSearchTaiLieu.CurrentRow.Index].Value.ToString();
                string tentailieu = dgvSearchTaiLieu[1, dgvSearchTaiLieu.CurrentRow.Index].Value.ToString();
                btnThongKe_Click(sender, e);
                lbListSachMuon.Items.Add(tentailieu);
                lbListSachMuonHide.Items.Add(matailieu);
                tbcQuanLiPhieu.SelectedTab = tbcQuanLiPhieu.TabPages[0];
                tbcPhieuMuon.SelectedTab = tbcPhieuMuon.TabPages[1];
            }
            else MessageBox.Show("Tài liệu này hiện đang tạm hết");
        }
        private void btnYeuCauTL_Click(object sender, EventArgs e)
        {
            BUS_TaiLieu busTaiLieu = new BUS_TaiLieu();
            string TenTLYeuCau = txtSearchTaiLieu.Text;
            if (TenTLYeuCau == "")
            {
                MessageBox.Show(" Nhập Tên Tài Liệu Yêu cầu");
                return;
            }
            if (MessageBox.Show(string.Format("Xác nhận Thêm Tài Liệu Mới :  {0}", TenTLYeuCau), "Xác nhận Thêm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // gọi proc thêm tài liệu mới xuống database
                if (busTaiLieu.YeuCauThemTaiLieu(TenTLYeuCau) == true)
                {
                    MessageBox.Show("Yêu Cầu Tài Liệu Mới Thành Công");
                }
                else
                {
                    MessageBox.Show("Tên Tài Liệu Đã Tồn Tại !");
                }

            }

        }
        private void btnYeuCauTaiLieuMoi_Click(object sender, EventArgs e)
        {
            if (txtYeuCauTaiLieuMoi.Visible == true)
            {
                // thực hiện thêm
                BUS_TaiLieu busTaiLieu = new BUS_TaiLieu();
                string TenTLYeuCau = txtYeuCauTaiLieuMoi.Text;
                if (TenTLYeuCau.Trim() == "" || TenTLYeuCau.Trim() ==" ")
                {
                    MessageBox.Show(" Nhập Tên Tài Liệu Yêu cầu");
                    return;
                }

                // gọi proc thêm tài liệu mới xuống database
                if (busTaiLieu.YeuCauThemTaiLieu(TenTLYeuCau) == true)
                {
                    MessageBox.Show("Yêu Cầu Tài Liệu Mới Thành Công");
                    txtYeuCauTaiLieuMoi.Text = "";
                    txtYeuCauTaiLieuMoi.Visible = false;
                    lbTenTaiLieuYeuCauMoi.Visible = false;
                    btnYeuCauTaiLieuMoi.Text = "Yêu Cầu Tài Liệu Mới";
                    dgvYeuCauTaiLieu.DataSource = busTaiLieu.XemTatCaTaiLieuYeuCauMoi();
                    dgvYeuCauTaiLieu.Columns[0].HeaderText = "STT";
                    dgvYeuCauTaiLieu.Columns[0].Width = 40;
                    dgvYeuCauTaiLieu.Columns[1].HeaderText = "Tên Tài Liệu";
                }
                else
                {
                    MessageBox.Show("Tên Tài Liệu Đã Tồn Tại !");
                }


                return;
            }
            lbTenTaiLieuYeuCauMoi.Visible = true;
            txtYeuCauTaiLieuMoi.Visible = true;
            btnYeuCauTaiLieuMoi.Text = "Thêm";
        }
        private void btnXoaYeuCauTaiLieuMoi_Click(object sender, EventArgs e)
        {
            if (dgvYeuCauTaiLieu.RowCount < 1)
            {
                return;
            }
            BUS_TaiLieu busTL = new BUS_TaiLieu();
            int rowindex = dgvYeuCauTaiLieu.CurrentRow.Index;
            string tenTaiLieuYeuCau = dgvYeuCauTaiLieu[1, dgvYeuCauTaiLieu.CurrentRow.Index].Value.ToString().Trim();
            if (tenTaiLieuYeuCau == "")
            {
                MessageBox.Show(string.Format("Vui lòng chọn Tài Liệu Cần Xóa"));
                return;
            }
            if (MessageBox.Show(string.Format("Xác nhận xóa Tài Liệu : {0}", tenTaiLieuYeuCau), "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (busTL.XoaTaiLieuYeuCauMoi(tenTaiLieuYeuCau) == true)
                {
                    MessageBox.Show("Xóa Tài Liệu Yêu Cầu Thành Công!!!");
                    dgvYeuCauTaiLieu.DataSource = busTL.XemTatCaTaiLieuYeuCauMoi();
                    dgvYeuCauTaiLieu.Columns[0].HeaderText = "STT";
                    dgvYeuCauTaiLieu.Columns[0].Width = 40;
                    dgvYeuCauTaiLieu.Columns[1].HeaderText = "Tên Tài Liệu";

                    return;
                }
                else
                {
                    MessageBox.Show("Xóa Tài Liệu Yêu Cầu Không Thành Công!!!");
                }
            }
        }
        
        /*
         * PHẦN XỬ LÝ PHIẾU 
         */

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            lbMaDocGia.Text = "Mã Độc Giả";
            lbMaTaiLieuPhieuMuon.Text = "Mã Tài Liệu";
            panelDocGia.Visible = false;
            panelReport.Visible = false;
            panelQLSach.Visible = false;
            panelQuanTriAdmin.Visible = false;
            pnThongKe.Visible = true;
            this.pnThongKe.Location = new System.Drawing.Point(217, 93);

            // ẩn button phiếu mượn
            btnChinhSua_CTPM.Visible = false;
            btnLuuCTPM.Visible = false;
            btnHuy_PhieuMuon.Visible = false;

            btnXemChiTiet_PhieuMuon.Visible = false;
            btnXoaPhieuMuon.Visible = false;

            // ẩn button phiếu trả
            btnXemChiTietPhieuTra.Visible = false;
            btnXoaPhieuTra.Visible = false;

            btnChinhSua_PhieuTra.Visible = false;
            btnLuuPhieuTra.Visible = false;
            btnHuy_PhieuTra.Visible = false;

            if (dgvPhieuMuon.RowCount > 1)
            {
                btnChinhSua_CTPM.Visible = false;
                btnLuuCTPM.Visible = false;
                btnHuy_PhieuMuon.Visible = false;

                btnXemChiTiet_PhieuMuon.Visible = true;
                btnXoaPhieuMuon.Visible = true;
            }

        }
        /*
         * Phiếu Mượn
         */
        private void btnXemTatcaPhieuMuon_Click(object sender, EventArgs e)
        {
            BUS_Phieu busPhieu = new BUS_Phieu();
            dgvPhieuMuon.DataSource = busPhieu.XemTatCaPhieuMuon();
            dgvPhieuMuon.ReadOnly = true;

            dgvPhieuMuon.Columns[0].HeaderText = "Mã Phiếu Mượn";
            dgvPhieuMuon.Columns[1].HeaderText = "Mã Nhân Viên Lập";
            dgvPhieuMuon.Columns[2].HeaderText = "Mã Độc Giả";
            dgvPhieuMuon.Columns[3].HeaderText = "Ngày Lập";


            btnXemChiTiet_PhieuMuon.Visible = true;
            btnXoaPhieuMuon.Visible = true;

            btnChinhSua_CTPM.Visible = false;
            btnLuuCTPM.Visible = false;
            btnHuy_PhieuMuon.Visible = false;
        }
        // chưa có proc tìm kiếm phiếu mượn
        private void btnTimKiemPhieuMuon_Click(object sender, EventArgs e)
        {
            dgvPhieuMuon.AllowUserToAddRows = false;
            if (txtSearchPM.Text == "" || (rdMaDG_PhieuMuon.Checked == false && rdMaPhieuMuon.Checked == false))
            {
                MessageBox.Show("Vui lòng chọn và điền đầy đủ thông tin !!!");
            }
            else
            {

                BUS_Phieu busPhieu = new BUS_Phieu();
                string maDocGia;
                string maPhieuMuon;
                if (rdMaDG_PhieuMuon.Checked)
                {
                    maDocGia = txtSearchPM.Text;
                    dgvPhieuMuon.DataSource = busPhieu.SearchPhieuMuonTheoMaDocGia(maDocGia);
                    dgvPhieuMuon.ReadOnly = true;
                }
                else if (rdMaPhieuMuon.Checked)
                {
                    maPhieuMuon = txtSearchPM.Text;
                    dgvPhieuMuon.DataSource = busPhieu.SearchPhieuMuonTheoMaPhieuMuon(maPhieuMuon);
                    dgvPhieuMuon.ReadOnly = true;
                }

                if (dgvPhieuMuon.RowCount > 0)
                {
                    btnChinhSua_CTPM.Visible = false;
                    btnLuuCTPM.Visible = false;
                    btnHuy_PhieuMuon.Visible = false;

                    btnXemChiTiet_PhieuMuon.Visible = true;
                    btnXoaPhieuMuon.Visible = true;
                }
                if (dgvPhieuMuon.RowCount == 0)
                    MessageBox.Show("Không tìm thấy thông tin");

            }
        }
        // chưa có proc xem chi tiết phiếu mượn
        private void btnXemChiTiet_PhieuMuon_Click(object sender, EventArgs e)
        {
            btnChinhSua_CTPM.Visible = true;
            btnLuuCTPM.Visible = true;
            btnHuy_PhieuMuon.Visible = true;

            btnXemChiTiet_PhieuMuon.Visible = false;
            btnXoaPhieuMuon.Visible = false;
      
            if (dgvPhieuMuon.RowCount < 1)
            {
                return;
            }
            BUS_Phieu busPhieu = new BUS_Phieu();
            string maPhieuMuon = dgvPhieuMuon[0, dgvPhieuMuon.CurrentRow.Index].Value.ToString();
            dgvPhieuMuon.DataSource = null;
            dgvPhieuMuon.DataSource = busPhieu.XemChiTietPhieuMuon(maPhieuMuon);
            dgvPhieuMuon.ReadOnly = true;
            dgvPhieuMuon.Columns[0].HeaderText = "Chi Tiết Phiếu Mượn";
            dgvPhieuMuon.Columns[1].HeaderText = "Mã Tài Liệu";
            dgvPhieuMuon.Columns[2].HeaderText =  "Mã Phiếu Mượn";
            btnHuy_PhieuMuon.Text = "Hủy";

        }
        // chưa có proc Xóa Phiếu Mượn
        private void btnXoaPhieuMuon_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.RowCount < 1)
            {
                return;
            }
            BUS_Phieu busPhieu = new BUS_Phieu();
            string maPhieuMuon = dgvPhieuMuon[0, dgvPhieuMuon.CurrentRow.Index].Value.ToString();
            if (MessageBox.Show(string.Format("Xác nhận xóa Phiếu Mượn : {0}", maPhieuMuon), "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (busPhieu.XoaPhieuMuon(maPhieuMuon))
                {
                    MessageBox.Show("Xóa Phiếu Mượn Thành Công");
                    dgvPhieuMuon.DataSource = busPhieu.XemTatCaPhieuMuon();
                    dgvPhieuMuon.ReadOnly = true;
                }
                else
                    MessageBox.Show("Không Thể Xóa Phiếu Mượn Này !");
            }

        }

        private void btnChinhSua_PhieuMuon_Click(object sender, EventArgs e)
        {
            dgvPhieuMuon.ReadOnly = false;
            dgvPhieuMuon.Columns[0].ReadOnly = true;
        }

        private void btnLuuPhieuMuon_Click(object sender, EventArgs e)
        {
            btnHuy_PhieuMuon.Text = "Thoát";
            string maCTPM = dgvPhieuMuon[0, dgvPhieuMuon.CurrentRow.Index].Value.ToString();
            string maTaiLieu = dgvPhieuMuon[1, dgvPhieuMuon.CurrentRow.Index].Value.ToString();
            string maTaiLieuCu = txtCapNhatCTPM.Text;
            string maPhieuMuon = dgvPhieuMuon[2, dgvPhieuMuon.CurrentRow.Index].Value.ToString();

            DTO_PhieuMuon x = new DTO_PhieuMuon(maCTPM, maTaiLieu, maTaiLieuCu, maPhieuMuon);
            BUS_Phieu p = new BUS_Phieu();
            p.UpdatePhieuMuon(x);
        }

        private void btnHuy_PhieuMuon_Click(object sender, EventArgs e)
        {
            // load lại danh sách phiếu mượn
            btnXemTatcaPhieuMuon_Click(sender, e);
        }

        private void btnThem_PhieuMuon_Click(object sender, EventArgs e)
        {
            if (lbListSachMuon.Items.Count > 0)
            {
                string madocgia = cbxMaDGPM.SelectedValue.ToString().Trim();
                string matailieu = lbListSachMuonHide.Items[0].ToString().Trim();

                BUS_Phieu mpm = new BUS_Phieu();
                string maphieumuon = mpm.LayMaPhieuMuonTiepTheo().Trim();
                string mactpm = mpm.LayMaChiTietPhieuMuonTiepTheo().Trim();

                BUS_Phieu busPhieu = new BUS_Phieu();
                DTO_PhieuMuon DTO = new DTO_PhieuMuon(maNVHienTai.Trim(), madocgia, matailieu, maphieumuon, mactpm);

                if (busPhieu.ThemPhieuMuon(DTO) == 1)
                {
                    for (int i = 0; i < Int32.Parse(lbListSachMuon.Items.Count.ToString()); i++)
                    {
                        string matailieuCT = lbListSachMuonHide.Items[i].ToString().Trim();
                        BUS_Phieu busPhieuCT = new BUS_Phieu();
                        DTO_PhieuMuon DTOCT = new DTO_PhieuMuon(maNVHienTai, madocgia, matailieuCT, maphieumuon, mactpm);
                        busPhieu.ThemChiTietPhieuMuon(DTOCT);
                    }
                    MessageBox.Show("Lập Phiếu Mượn Thành Công !!!");

                    lbListSachMuon.Items.Clear();
                    lbListSachMuonHide.Items.Clear();
                }
                else
                {
                    lbListSachMuon.Items.Clear();
                    lbListSachMuonHide.Items.Clear();
                    MessageBox.Show("Độc giả không được sử dụng dịch vụ nữa :(");
                }
            }
            else MessageBox.Show("Vui lòng chọn tài liệu mượn");

        }

        private void cbxMaDGPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbMaDocGia.Text = cbxMaDGPM.SelectedValue.ToString();
        }
        private void cbxMaDGPM_TextChanged(object sender, EventArgs e)
        {
        }


        /*
         * Phiếu Trả
         */

        private void btnXemTatCaPhieuTra_Click(object sender, EventArgs e)
        {
            BUS_Phieu busPhieu = new BUS_Phieu();
            dgvPhieuTra.DataSource = busPhieu.XemTatCaPhieuTra();
            dgvPhieuTra.ReadOnly = true;

            dgvPhieuTra.Columns[0].HeaderText = "Mã Phiếu Trả";
            dgvPhieuTra.Columns[1].HeaderText = "Mã Nhân Viên Lập";

            btnXemChiTietPhieuTra.Visible = true;
            btnXoaPhieuTra.Visible = true;

            btnChinhSua_PhieuTra.Visible = false;
            btnLuuPhieuTra.Visible = false;
            btnHuy_PhieuTra.Visible = false;
        }
        // chưa có proc tìm kiếm phiếu mượn
        private void btnTimKiemPhieuTra_Click(object sender, EventArgs e)
        {
            if ((rdMaDG_PhieuTra.Checked == false && rdMaPhieuMuon_PhieuTraTK.Checked == false && rdMaPhieuTra.Checked == false) || (txtSearchPT.Text == ""))
            {
                MessageBox.Show("Vui lòng chọn điều kiện để tìm kiếm!!!");
            }
            else
            {
                BUS_Phieu p = new BUS_Phieu();
                if (rdMaDG_PhieuTra.Checked)
                {
                    dgvPhieuTra.DataSource = p.SearchPT_DG(txtSearchPT.Text);
                }
                if (rdMaPhieuMuon_PhieuTraTK.Checked)
                {
                    dgvPhieuTra.DataSource = p.SearchPT_PM(txtSearchPT.Text);
                }
                if (rdMaPhieuTra.Checked)
                {
                    dgvPhieuTra.DataSource = p.SearchPT_PT(txtSearchPT.Text);
                }
                btnXemChiTietPhieuTra.Visible = true;
                btnXoaPhieuTra.Visible = true;

                btnChinhSua_PhieuTra.Visible = false;
                btnLuuPhieuTra.Visible = false;
                btnHuy_PhieuTra.Visible = false;
            }
        }
        // chưa có proc xem chi tiết phiếu mượn
        private void btnXemChiTietPhieuTra_Click(object sender, EventArgs e)
        {
            btnXemChiTietPhieuTra.Visible = false;
            btnXoaPhieuTra.Visible = false;

            btnChinhSua_PhieuTra.Visible = true;
            btnLuuPhieuTra.Visible = true;
            btnHuy_PhieuTra.Visible = true;
            if (dgvPhieuTra.RowCount < 1)
            {
                return;
            }
            BUS_Phieu busPhieu = new BUS_Phieu();
            string maPhieuTra = dgvPhieuTra[0, dgvPhieuTra.CurrentRow.Index].Value.ToString();
            dgvPhieuTra.DataSource = null;
            dgvPhieuTra.DataSource = busPhieu.XemChiTietPhieuTra(maPhieuTra);
            dgvPhieuTra.ReadOnly = true;

            dgvPhieuTra.Columns[0].HeaderText = "Chi Tiết Phiểu Trả";
            dgvPhieuTra.Columns[1].HeaderText = "Mã Phiếu Trả";
            dgvPhieuTra.Columns[2].HeaderText = "Mã Phiếu Mượn";
            dgvPhieuTra.Columns[3].HeaderText = "Mã Tài Liệu";
            btnHuy_PhieuTra.Text = "Hủy";

        }
        // chưa có proc Xóa Phiếu Mượn
        private void btnXoaPhieuTra_Click(object sender, EventArgs e)
        {

            if (dgvPhieuTra.RowCount < 1)
            {
                return;
            }
            BUS_Phieu busPhieu = new BUS_Phieu();
            string maPhieuMuon = dgvPhieuTra[0, dgvPhieuTra.CurrentRow.Index].Value.ToString();
            if (MessageBox.Show(string.Format("Xác nhận xóa Phiếu Trả {0}", maPhieuMuon), "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (busPhieu.XoaPhieuTra(maPhieuMuon)){
                    MessageBox.Show("Xóa Phiếu Trả Thành Công");
                    btnXemTatCaPhieuTra_Click(sender, e);
                }
                    
                else
                    MessageBox.Show("Không Thể Xóa Phiếu Trả Này !");
            }

        }

        private void btnChinhSua_PhieuTra_Click(object sender, EventArgs e)
        {
            dgvPhieuTra.ReadOnly = false;
            dgvPhieuTra.Columns[0].ReadOnly = true;
        }
        // chưa có proc update phiếu mượn
        private void btnLuuPhieuTra_Click(object sender, EventArgs e)
        {
            btnHuy_PhieuTra.Text = "Thoát";
            string maCTPT = dgvPhieuTra[0, dgvPhieuTra.CurrentRow.Index].Value.ToString().Trim();
            string maPhieuTra = dgvPhieuTra[1, dgvPhieuTra.CurrentRow.Index].Value.ToString().Trim();
            string maPhieuMuon = dgvPhieuTra[2, dgvPhieuTra.CurrentRow.Index].Value.ToString().Trim();
            string maTaiLieu = dgvPhieuTra[3, dgvPhieuTra.CurrentRow.Index].Value.ToString().Trim();
            BUS_Phieu p = new BUS_Phieu();
            p.ChinhSuaCTPhieuTra(maCTPT, maPhieuTra, maPhieuMuon, maTaiLieu);
            MessageBox.Show("Chỉnh sửa thành công!!!");
        }

        private void btnHuy_PhieuTra_Click(object sender, EventArgs e)
        {
            // load lại danh sách phiếu mượn
            btnXemTatCaPhieuTra_Click(sender, e);
        }

        private void btnThemPhieuTra_Click(object sender, EventArgs e)
        {
            if (lbDanhSachSachTra.Items.Count > 0)
            {
                BUS_Phieu mpt = new BUS_Phieu();
                string maphieutra = mpt.LayMaPhieuTraTiepTheo();
                string mactpt = mpt.LayMaChiTietPhieuTraTiepTheo();

                for (int i = 0; i < Int32.Parse(lbDanhSachSachTraHide.Items.Count.ToString()); i++)
                {
                    string[] listsachtra = lbDanhSachSachTraHide.Items[i].ToString().Split('|');
                    string maphieumuon = listsachtra[0].Trim();
                    string matailieuCT = listsachtra[1].Trim();
                    if (i == 0)
                    {
                        BUS_Phieu busPhieu = new BUS_Phieu();
                        DTO_PhieuTra DTO = new DTO_PhieuTra(maNVHienTai, maphieumuon, maphieutra, mactpt, matailieuCT);
                        busPhieu.ThemPhieuTra(DTO);
                    }
                    BUS_Phieu busPhieuCT = new BUS_Phieu();
                    DTO_PhieuTra DTOCT = new DTO_PhieuTra(maNVHienTai, maphieumuon, maphieutra, mactpt, matailieuCT);
                    busPhieuCT.ThemChiTietPhieuTra(DTOCT);
                    if(mpt.LaySoSachCuaPM(maphieumuon) > lbDanhSachSachTra.Items.Count)
                    {
                        if(mpt.LaySoLanViPhamCuaPhieuMuon(maphieumuon) >= 0 && mpt.LaySoLanViPhamCuaPhieuMuon(maphieumuon) < 2)
                        {
                            
                            if (MessageBox.Show(string.Format("Có Lập Phiểu Nhắc Nhở Không?"), "Độc Giả Trả Sách Không Đủ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                cbxmaDocGiaNN.Visible = true;
                                cbxmaDocGiaNN.Text = mpt.LayMaDocGiaDePhat(maphieumuon);
                                tbcQuanLiPhieu.SelectedTab = tbcQuanLiPhieu.TabPages[3];
                                return;
                                
                            }
                        }

                        if (mpt.LaySoLanViPhamCuaPhieuMuon(maphieumuon) >= 2 && mpt.LaySoLanViPhamCuaPhieuMuon(maphieumuon) < 5)
                        {
                            if (MessageBox.Show(string.Format("Có Lập Phiểu Phạt Không?"), "Độc Giả Trả Sách Không Đủ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                cbxMaPMcuaPP.Visible = true;
                                lbMaPM_PP.Visible = true;
                                cbxMaPMcuaPP.Text = maphieumuon;
                                tbcQuanLiPhieu.SelectedTab = tbcQuanLiPhieu.TabPages[2];
                                return;

                            }
                        }

                    }


                    else if (mpt.LaySoNgayQuaHan(maphieumuon) > 0)
                    {

                        if (mpt.LaySoLanViPhamCuaPhieuMuon(maphieumuon) >= 0 && mpt.LaySoLanViPhamCuaPhieuMuon(maphieumuon) < 2)
                        {
                            if (MessageBox.Show(string.Format("Có Lập Phiểu Nhắc Nhở Không?"), "Độc Giả Trả Sách Quá Hạn", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                cbxmaDocGiaNN.Visible = true;
                                cbxmaDocGiaNN.Text = mpt.LayMaDocGiaDePhat(maphieumuon);
                                tbcQuanLiPhieu.SelectedTab = tbcQuanLiPhieu.TabPages[3];
                                return;
                            }
                        }

                        if (mpt.LaySoLanViPhamCuaPhieuMuon(maphieumuon) >= 2 && mpt.LaySoLanViPhamCuaPhieuMuon(maphieumuon) < 5)
                        {
                            if (MessageBox.Show(string.Format("Có Lập Phiểu Phạt Không?"), "Độc Giả Trả Sách Quá Hạn", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                cbxMaPMcuaPP.Visible = true;
                                lbMaPM_PP.Visible = true;
                                cbxMaPMcuaPP.Text = maphieumuon;
                                tbcQuanLiPhieu.SelectedTab = tbcQuanLiPhieu.TabPages[2];
                                return;
                            }
                        }

                    }
                }
                lbDanhSachSachTra.Items.Clear();
                lbDanhSachSachTra.Items.Clear();
                MessageBox.Show("Lập Phiếu Trả Thành Công !!!");
            }
            else MessageBox.Show("Vui lòng chọn sách để trả");
        }

        private void btnAddMTLVaoList_Click(object sender, EventArgs e)
        {
            string maDocGia = cbxMaDGPM.SelectedValue.ToString();
            BUS_Phieu p = new BUS_Phieu();
            for (int i = 0; i < Int32.Parse(lbListSachMuon.Items.Count.ToString()); i++)
            {
                string value = lbListSachMuon.Items[i].ToString().Trim();
                if (value == cbxMaTLPM.Text.ToString().Trim())
                {
                    MessageBox.Show("Tài Liệu Này Đã Có !!!");
                    return;
                }
            }
            if ((p.SoSachDangMuon(maDocGia) + lbListSachMuon.Items.Count) < p.SoSachMuonToiDa(maDocGia))
            {
                if (p.KiemTraMuonTaiLieuDacBiet(maDocGia, cbxMaTLPM.SelectedValue.ToString()))
                {
                    lbListSachMuon.Items.Add(cbxMaTLPM.Text);
                    lbListSachMuonHide.Items.Add(cbxMaTLPM.SelectedValue);
                }
                else MessageBox.Show("Độc giả không được mượn tài liệu đặc biệt");
            }
            else MessageBox.Show("Đã quá số sách mượn tối đa");
        }

        private void btnXoaMTLTrongList_Click(object sender, EventArgs e)
        {
            int index = lbListSachMuon.SelectedIndex;
            if (index >= 0)
            {
                lbListSachMuon.Items.RemoveAt(index);
                lbListSachMuonHide.Items.RemoveAt(index);
            }
        }
        private void cbxMaPMCuaPT_TextChanged(object sender, EventArgs e)
        {

        }


        private void cbxMaPMCuaPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUS_Phieu phieu = new BUS_Phieu();
            string MPM = cbxMaPMCuaPT.Text;
            cbxSachPT.DataSource = phieu.LayDanhSachMaTaiLieuCuaPhieuMuon(MPM);
            cbxSachPT.DisplayMember = "TenTaiLieu";
            cbxSachPT.ValueMember = "MaTaiLieu";
        }

        private void btnAddSachTra_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Int32.Parse(lbDanhSachSachTra.Items.Count.ToString()); i++)
            {
                string value = lbDanhSachSachTra.Items[i].ToString().Trim();
                if (value == cbxSachPT.Text.ToString().Trim())
                {
                    MessageBox.Show("Tài Liệu Này Đã Có !!!");
                    return;
                }
            }
            lbDanhSachSachTra.Items.Add(cbxSachPT.Text);
            //lbDanhSachSachTraHide.Items.Add(cbxSachPT.SelectedValue);
            //lbDanhSachSachTra.Items.Add(string.Format("{0} | {1}", cbxMaPMCuaPT.Text, cbxSachPT.Text));
            lbDanhSachSachTraHide.Items.Add(string.Format("{0} | {1}", cbxMaPMCuaPT.Text, cbxSachPT.SelectedValue));
        }

        private void btnXoaSachTra_Click(object sender, EventArgs e)
        {
            int index = lbDanhSachSachTra.SelectedIndex;
            if (index >= 0)
            {
                lbDanhSachSachTra.Items.RemoveAt(index);
                lbDanhSachSachTraHide.Items.RemoveAt(index);
            }
        }
        /*
         * Phiếu Phạt
         */

        // viết proc hiển thị chi tiết của phiếu phạt lên dgvPhieuPhat
        private void btnXemTatCaPhieuPhat_Click(object sender, EventArgs e)
        {

            BUS_Phieu busPhieu = new BUS_Phieu();
            dgvPhieuPhat.DataSource = busPhieu.XemTatCaPhieuPhat();
            dgvPhieuPhat.ReadOnly = true;

            dgvPhieuPhat.Columns[0].HeaderText = "Mã Phiếu Phạt";
            dgvPhieuPhat.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvPhieuPhat.Columns[2].HeaderText = "Mã Phiếu Mượn";
            dgvPhieuPhat.Columns[3].HeaderText = "Số Sách Quá Hạn";
            dgvPhieuPhat.Columns[4].HeaderText = "Số Ngày Quá Hạn";
            dgvPhieuPhat.Columns[5].HeaderText = "Số Tiền Phạt";

            //btnXemChiTietPhieuTra.Visible = true;
            //btnXoaPhieuTra.Visible = true;

            //btnChinhSua_PhieuTra.Visible = false;
            //btnLuuPhieuTra.Visible = false;
            //btnHuy_PhieuTra.Visible = false;

        }

        private void btnXemTatCaPhieuNhacNho_Click(object sender, EventArgs e)
        {
            BUS_Phieu busPhieu = new BUS_Phieu();
            dgvPhieuNhacNho.DataSource = busPhieu.XemPhieuNhacNho();
            dgvPhieuNhacNho.ReadOnly = false;
            dgvPhieuNhacNho.Columns[0].HeaderText = "Mã Độc Giả ";
            dgvPhieuNhacNho.Columns[1].HeaderText = "Số Lần Vi Phạm";

        }
        bool checkThemPhieuPhat = true;
        private void btn_LapPhieuPhat_Click(object sender, EventArgs e)
        {
            BUS_Phieu busPhieu = new BUS_Phieu();
            if (checkThemPhieuPhat == true)
            {
                btn_LapPhieuPhat.Text = "Thêm";
                lbMaPM_PP.Visible = true;
                cbxMaPMcuaPP.Visible = true;
                cbxMaPMcuaPP.DataSource = busPhieu.getListPhieuMuon();
                cbxMaPMcuaPP.DisplayMember = "MaPhieuMuon";
                cbxMaPMcuaPP.ValueMember = "MaPhieuMuon";
                checkThemPhieuPhat = false;
            }
            else
            {
                string maphieumuon = cbxMaPMcuaPP.SelectedValue.ToString();
                string MaNVLapPhieuPhat = maNVHienTai;
                DTO_PhieuPhat DTO = new DTO_PhieuPhat(maphieumuon, MaNVLapPhieuPhat);
                int result = busPhieu.ThemPhieuPhat(DTO);          
                lbMaPM_PP.Visible = false;
                cbxMaPMcuaPP.Visible = false;
                btn_LapPhieuPhat.Text = "Lập Phiếu Phạt";
                if(result == 1)
                {
                    btnXemTatCaPhieuPhat_Click(sender, e);
                    MessageBox.Show("Lập Phiếu Phạt Thành Công !!!");
                }
                
                else MessageBox.Show("Lập Phiếu Phạt Không Thành Công !!!");
                checkThemPhieuPhat = true;
            }

        }
        /*
        * PHẦN THỐNG KÊ - REPORT
        * 
        */

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            panelReport.Visible = true;         
            panelDocGia.Visible = false;
            pnThongKe.Visible = false;
            panelQuanTriAdmin.Visible = false;
            panelQLSach.Visible = false;
            this.panelReport.Location = new System.Drawing.Point(217, 93);

        }
        ReportDocument cryRpt;
        private void btnReport_TongSoSach_Click(object sender, EventArgs e)
        {
            cryReportViewer.Visible = true;
            cryRpt = new ReportDocument();
            try
            {
                cryRpt.Load(pathReport+ "Report_TaiLieu.rpt");
                cryReportViewer.ReportSource = cryRpt;
                cryReportViewer.Refresh();
            }
            catch
            {
                MessageBox.Show("Dữ Liệu Không Tìm Thấy !");
                return;
            }
         
        }

        private void btnReport_TongSoDocGia_Click(object sender, EventArgs e)
        {
            cryReportViewer.Visible = true;
            cryRpt = new ReportDocument();
            try
            {
                cryRpt.Load(pathReport+ "Report_DocGia.rpt");
                cryReportViewer.ReportSource = cryRpt;
                cryReportViewer.Refresh();
            }
            catch
            {
                MessageBox.Show("Dữ Liệu Không Tìm Thấy !");
                return;
            }
          
        }
        private void btnReport_SoSachMuonNhieuNhat_Click(object sender, EventArgs e)
        {
            cryReportViewer.Visible = true;
            cryRpt = new ReportDocument();
            try
            {
                cryRpt.Load(pathReport +"Report_SoTaiLieuMuonNhieuNhat.rpt");
                cryReportViewer.ReportSource = cryRpt;
                cryReportViewer.Refresh();
            }
            catch
            {
                MessageBox.Show("Dữ Liệu Không Tìm Thấy !");
                return;

            }

        }
        private void btnSaveReport_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Files PDF (*.pdf)|*.pdf|Microsoft Excel(*.xls)|*.xls|Microsoft Word(*.doc)|*.doc|XML (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;

                string FileExtension = FileName.Substring(FileName.LastIndexOf('.') + 1).ToLower();
                if (FileExtension == "pdf")
                {
                    cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"" + FileName + "");

                }
                if (FileExtension == "xls")
                {
                    cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, @"" + FileName + "");

                }
                if (FileExtension == "doc")
                {
                    cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, @"" + FileName + "");

                }
                if (FileExtension == "xml")
                {
                    cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Xml, @"" + FileName + "");

                }
                MessageBox.Show("Lưu file Thành Công : " + FileName);
            }
        }
        private void btnXemAllTaiLieu_Click(object sender, EventArgs e)
        {
            Hide_ChiTietTaiLieu();

            dgvSearchTaiLieu.ReadOnly = true;
            dgvSearchTaiLieu.DataSource = TL.getTL();
            dgvSearchTaiLieu.Columns[0].Width = 90;
            dgvSearchTaiLieu.Columns[1].Width = 420;
            dgvSearchTaiLieu.Columns[2].Width = 90;
            dgvSearchTaiLieu.Columns[3].Width = 90;

            dgvSearchTaiLieu.Columns[0].HeaderText = "Mã Tài Liệu";
            dgvSearchTaiLieu.Columns[1].HeaderText = "Tên Tài Liệu";
            dgvSearchTaiLieu.Columns[2].HeaderText = "Loại Tài Liệu";
            dgvSearchTaiLieu.Columns[3].HeaderText = "Số Lượng";
            dgvSearchTaiLieu.Columns[4].HeaderText = "Đặc Biệt";

            btnXemChiTietTL.Show();
            btnXoaTL.Show();
            btnLapPhieuMuonTL.Show();
            btnYeuCauTL.Hide();

            btnChinhSuaTL.Hide();
            btnLuuTL.Hide();
            btnHuyTL.Hide();
        }
       

        /*
        * PHẦN QUẢN TRỊ ADMIN
        */
        private void btnQuanTriAdmin_Click(object sender, EventArgs e)
        {
            panelQuanTriAdmin.Visible = true;
            panelReport.Visible = false;
          
            panelDocGia.Visible = false;
            pnThongKe.Visible = false;
            panelQLSach.Visible = false;
            this.panelQuanTriAdmin.Location = new System.Drawing.Point(217, 93);

            BUS_DocGia dg = new BUS_DocGia();
            dgvLoaiDocGia.DataSource = dg.LoadLoaiDocGia();
            dgvLoaiDocGia.ReadOnly = true;

            dgvLoaiDocGia.Columns[0].HeaderText = "Mã Độc Giả";
            dgvLoaiDocGia.Columns[1].HeaderText = "Số Ngày Mượn Tối Đa";
            dgvLoaiDocGia.Columns[2].HeaderText = "Số Sách Mượn Tối Đa";
            dgvLoaiDocGia.Columns[3].HeaderText = "Tên Loại Độc Giả";
            dgvLoaiDocGia.Columns[4].HeaderText = "Phí Thường Niên";
            dgvLoaiDocGia.Columns[5].HeaderText = "Tài Liệu Đặc Biệt";

        }

        private void btnXoaPP_Click(object sender, EventArgs e)
        {
            if (dgvPhieuPhat.RowCount < 2)
            {
                return;
            }
            string maphieuphat = dgvPhieuPhat[0, dgvPhieuPhat.CurrentRow.Index].Value.ToString();
            BUS_Phieu p = new BUS_Phieu();
            if (MessageBox.Show(string.Format("Xác nhận xóa Phiếu Phạt {0}", maphieuphat), "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (p.XoaPhieuPhat(maphieuphat) == 1)
                {
                    btnXemTatCaPhieuPhat_Click(sender, e);
                    MessageBox.Show("Xóa thành công phiếu Phạt " + maphieuphat);
                }
                else
                    MessageBox.Show("Chưa Thể Xóa Phiếu Này !");
            }


          
        }

        private void btnThemPhieuNhacNho_Click(object sender, EventArgs e)
        {
            string mdg = cbxmaDocGiaNN.Text;
            if (mdg != "")
            {
                BUS_Phieu p = new BUS_Phieu();
                p.ThemPhieuNhacNho(mdg);
                
                MessageBox.Show("Thêm Phiếu Nhắc Nhở Thành Công !!!");
                btnXemTatCaPhieuNhacNho_Click(sender, e);
            }
            else MessageBox.Show("Lỗi, Nhập đúng mã độc giả !!!");
        }

        private void btnXoaPhieuNN_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhacNho.RowCount < 2)
            {
                return;
            }
            string mdg = dgvPhieuNhacNho[0, dgvPhieuNhacNho.CurrentRow.Index].Value.ToString();
            BUS_Phieu p = new BUS_Phieu();
            if (MessageBox.Show(string.Format("Xác nhận xóa Phiếu Nhắc Nhở Độc Giả  {0}", mdg), "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (p.XoaPhieuNhacNho(mdg) == 1)
                {
                    MessageBox.Show("Xóa thành công phiếu nhắc nhở của độc giả " + mdg);
                    btnXemTatCaPhieuNhacNho_Click(sender, e);
                }                   
                else
                    MessageBox.Show("Chưa Thể Xóa Phiếu Này !");
            }
           
        }

        private void cbxMaTLPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbMaTaiLieuPhieuMuon.Text = cbxMaTLPM.SelectedValue.ToString();
        }

        private void btnSearchPP_Click(object sender, EventArgs e)
        {
            if (txtSearchMaPP.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Thông Tin Tìm Kiếm !");
                return;
            }
            BUS_Phieu p = new BUS_Phieu();
            if (rdMaPM_PP.Checked)
            {
                dgvPhieuPhat.DataSource = p.SearchPP_PM(txtSearchMaPP.Text);
            }
            if (rdMDG_PP.Checked)
            {
                dgvPhieuPhat.DataSource = p.SearchPP_DG(txtSearchMaPP.Text);
            }
            if (rdMPP_PP.Checked)
            {
                dgvPhieuPhat.DataSource = p.SearchPP_PP(txtSearchMaPP.Text);
            }
            dgvPhieuPhat.Columns[0].HeaderText = "Mã Phiếu Phạt";
            dgvPhieuPhat.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvPhieuPhat.Columns[2].HeaderText = "Mã Phiếu Mượn";
            dgvPhieuPhat.Columns[3].HeaderText = "Số Sách Quá Hạn";
            dgvPhieuPhat.Columns[4].HeaderText = "Số Ngày Quá Hạn";
            dgvPhieuPhat.Columns[5].HeaderText = "Số Tiền Phạt";
        }

        private void btnSearchPNN_Click(object sender, EventArgs e)
        {
            if (txtMaPNN.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Mã Độc Giả !");
                return;
            }
            BUS_Phieu p = new BUS_Phieu();
            dgvPhieuNhacNho.DataSource = p.SearchPNN(txtMaPNN.Text);
        }

        private void btnChinhSuaPNN_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhacNho.RowCount < 2)
            {
                return;
            }
            string mdg = dgvPhieuNhacNho[0, dgvPhieuNhacNho.CurrentRow.Index].Value.ToString();
            int solanvipham = Int32.Parse(dgvPhieuNhacNho[1, dgvPhieuNhacNho.CurrentRow.Index].Value.ToString());
            BUS_Phieu p = new BUS_Phieu();
            p.UpdatePNN(mdg, solanvipham);
            btnXemTatCaPhieuNhacNho_Click(sender, e);
        }

        private void btnADCNLDG_Click(object sender, EventArgs e)
        {
            if (txtADMaLoai.Text == "" || txtADSoNM.Text == "" || txtADSSM.Text == "" || txtADTDG.Text == "" || txtADPTN.Text == "" || txtADTLDB.Text == "")
            {
                MessageBox.Show("Không có Dữ Liệu Vui lòng Chọn Trên Danh Sách !");
                return;
            }
            string MaLoaiDG = txtADMaLoai.Text;
            int SoNgayMuonToiDa = Int32.Parse(txtADSoNM.Text);
            int SoSachMuonToiDa = Int32.Parse(txtADSSM.Text);
            string TenLoaiDG = txtADTDG.Text;
            int PhiThuongNien = Int32.Parse(txtADPTN.Text);
            string TaiLieuDB = txtADTLDB.Text;
          
            BUS_DocGia dg = new BUS_DocGia();
            dg.ADMIN_UD_LDG(MaLoaiDG, SoNgayMuonToiDa, SoSachMuonToiDa, TenLoaiDG, PhiThuongNien, TaiLieuDB);
            MessageBox.Show("Cập Nhật Loại Độc Giả Thành Công");
            btnQuanTriAdmin_Click(sender, e);
        }

        private void btnADTLDG_Click(object sender, EventArgs e)
        {
            if (txtADMaLoai.Text == "" || txtADSoNM.Text == "" || txtADSSM.Text == "" || txtADTDG.Text == "" || txtADPTN.Text == "" || txtADTLDB.Text == "")
            {
                MessageBox.Show("Vui lòng Điển đầy đủ Thông Tin !");
                return;
            }
            string MaLoaiDG = txtADMaLoai.Text;
            int SoNgayMuonToiDa = Int32.Parse(txtADSoNM.Text);
            int SoSachMuonToiDa = Int32.Parse(txtADSSM.Text);
            string TenLoaiDG = txtADTDG.Text;
            int PhiThuongNien = Int32.Parse(txtADPTN.Text);
            string TaiLieuDB = txtADTLDB.Text;
          
            BUS_DocGia dg = new BUS_DocGia();
            dg.ADMIN_AD_LDG(MaLoaiDG, SoNgayMuonToiDa, SoSachMuonToiDa, TenLoaiDG, PhiThuongNien, TaiLieuDB);
            MessageBox.Show("Thêm Loại Độc Giả Thành Công");
            btnQuanTriAdmin_Click(sender, e);
        }

        private void tbcQuanTriAdmin_Click(object sender, EventArgs e)
        {
            if (tbcQuanTriAdmin.SelectedTab == tbcQuanTriAdmin.TabPages[1])
            {
                BUS_NhanVien nv = new BUS_NhanVien();
                dgvNhanVien.DataSource = nv.getNV();
                dgvNhanVien.Columns[3].Visible = false;
                dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
                dgvNhanVien.Columns[1].HeaderText = "Ca Trực";
                dgvNhanVien.Columns[2].HeaderText = "Tên Đăng Nhập";
                dgvNhanVien.Columns[4].HeaderText = "Họ Tên";
                dgvNhanVien.Columns[5].HeaderText = "Login Gần Nhất";
                dgvNhanVien.Columns[6].HeaderText = "Loại Nhân Viên";                
                dgvNhanVien.ReadOnly = true;
            }

        }

        private void dgvPhieuMuon_DoubleClick(object sender, EventArgs e)
        {
            txtCapNhatCTPM.Text = dgvPhieuMuon[dgvPhieuMuon.CurrentCell.ColumnIndex, dgvPhieuMuon.CurrentRow.Index].Value.ToString().Trim();
        }

        private void dgvLoaiDocGia_Click(object sender, EventArgs e)
        {
            txtADMaLoai.Text = dgvLoaiDocGia[0, dgvLoaiDocGia.CurrentRow.Index].Value.ToString();
            txtADSoNM.Text = dgvLoaiDocGia[1, dgvLoaiDocGia.CurrentRow.Index].Value.ToString();
            txtADSSM.Text = dgvLoaiDocGia[2, dgvLoaiDocGia.CurrentRow.Index].Value.ToString();
            txtADTDG.Text = dgvLoaiDocGia[3, dgvLoaiDocGia.CurrentRow.Index].Value.ToString();
            txtADPTN.Text = dgvLoaiDocGia[4, dgvLoaiDocGia.CurrentRow.Index].Value.ToString();
            txtADTLDB.Text = dgvLoaiDocGia[5, dgvLoaiDocGia.CurrentRow.Index].Value.ToString();
        }

        private void rdCTSV_DG_CheckedChanged(object sender, EventArgs e)
        {
            lbCTMSSV_DG.Show();
            txtCTMSSV_DG.Show();
            lbCTMSCB_DG.Hide();
            txtCTMSCB_DG.Hide();
        }

        private void rdCTCB_DG_CheckedChanged(object sender, EventArgs e)
        {
            lbCTMSSV_DG.Hide();
            txtCTMSSV_DG.Hide();
            lbCTMSCB_DG.Show();
            txtCTMSCB_DG.Show();
        }

        private void rdCTKhach_DG_CheckedChanged(object sender, EventArgs e)
        {
            lbCTMSSV_DG.Hide();
            txtCTMSSV_DG.Hide();
            lbCTMSCB_DG.Hide();
            txtCTMSCB_DG.Hide();
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            txtSearchPhieuMuon.Text = dgvNhanVien[0, dgvNhanVien.CurrentRow.Index].Value.ToString().Trim();
            txtSearchPhieuMuon.Enabled = false;
            txtTenDangNhapNVCapNhat.Enabled = false;
            txtHoTenNVCapNhat.Text = dgvNhanVien[4, dgvNhanVien.CurrentCell.RowIndex].Value.ToString().ToUpper().Trim();
            txtTenDangNhapNVCapNhat.Text = dgvNhanVien[2, dgvNhanVien.CurrentCell.RowIndex].Value.ToString().Trim();
            txtMatKhauNVCapNhat.Text = "********";
            txtCaTrucNVCapNhat.Text = dgvNhanVien[1, dgvNhanVien.CurrentCell.RowIndex].Value.ToString().Trim();

            string loaiNV = dgvNhanVien[6, dgvNhanVien.CurrentCell.RowIndex].Value.ToString().Trim();
            if (loaiNV == "AD")
                rdAdminCapNhat.Checked = true;
            else if (loaiNV == "TT")
                rdThuThuCapNhat.Checked = true;
        }
    }

}
