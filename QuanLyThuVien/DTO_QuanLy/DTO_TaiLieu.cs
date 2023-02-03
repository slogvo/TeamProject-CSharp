﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO_QuanLy
{
    public class DTO_TaiLieu
    {
        private string _MaTL;
        private string _TenTL;
        private string _LoaiTL;
        private string _SoLuong;
        private string _TLDacBiet;

        public string _maTL
        {
            get
            {
                return _MaTL;
            }

            set
            {
                _MaTL = value;
            }
        }
        public string _tenTL
        {
            get
            {
                return _TenTL;
            }

            set
            {
                _TenTL = value;
            }
        }
        public string _loaiTL
        {
            get
            {
                return _LoaiTL;
            }

            set
            {
                _LoaiTL = value;
            }
        }
        public string _soLuong
        {
            get
            {
                return _SoLuong;
            }

            set
            {
                _SoLuong = value;
            }
        }

         public string _tLDacBiet
        {
            get
            {
                return _TLDacBiet;
            }

            set
            {
                _TLDacBiet = value;
            }
        }
        /* === Constructor === */
        // Constructor đủ 5 tham số truyền vào --> Lưu Tài Liệu
        public DTO_TaiLieu(string maTL, string tenTL, string loaiTL, string soLong, string tldb)
        {
            this._maTL = maTL;
            this._tenTL = tenTL;
            this._loaiTL = loaiTL;
            this._soLuong = soLong;
            this._tLDacBiet = tldb;
        }
        // Constructor đủ 4 tham số truyền vào --> Thêm Tài Liệu
        public DTO_TaiLieu(string tenTL, string loaiTL, string soLuong, string TLDB)
        {
            this._tenTL = tenTL;
            this._loaiTL = loaiTL;
            this._soLuong = soLuong;
            this._tLDacBiet = TLDB;
        }
    }
}
