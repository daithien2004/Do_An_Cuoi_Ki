using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTW.DTO
{
    public class NguoiDung
    {
        private string nguoidungid;
        private string hoten;
        private string cmnd;
        private DateTime ngaysinh;
        private string gioitinh;
        private string diachi;
        private string dienthoai;
        private string email;
        private string tendangnhap;
        private string matkhau;
        private string hinhanh;
        private string khachsanid;

        public NguoiDung(string nguoidungid)
        {
            this.nguoidungid = nguoidungid;
        }

        public NguoiDung(string nguoidungid, string hoten, string cmnd, DateTime ngaysinh, string gioitinh, string diachi, string dienthoai, string email, 
            string tendangnhap, string matkhau, string hinhanh)
        {
            this.nguoidungid = nguoidungid;
            this.hoten = hoten;
            this.cmnd = cmnd;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.dienthoai = dienthoai;
            this.email = email;
            this.tendangnhap = tendangnhap;
            this.matkhau = matkhau;
            this.hinhanh = hinhanh;
        }

        public NguoiDung(string nguoidungid, string hoten, string cmnd, DateTime ngaysinh, string gioitinh, string diachi, string dienthoai, 
            string email, string tendangnhap, string matkhau, string hinhanh, string khachsanid)
        {
            this.nguoidungid = nguoidungid;
            this.hoten = hoten;
            this.cmnd = cmnd;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.dienthoai = dienthoai;
            this.email = email;
            this.tendangnhap = tendangnhap;
            this.matkhau = matkhau;
            this.hinhanh = hinhanh;
            this.khachsanid = khachsanid;
        }

        public string Nguoidungid { get => nguoidungid; set => nguoidungid = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Dienthoai { get => dienthoai; set => dienthoai = value; }
        public string Email { get => email; set => email = value; }
        public string Tendangnhap { get => tendangnhap; set => tendangnhap = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string Hinhanh { get => hinhanh; set => hinhanh = value; }
        public string Khachsanid { get => khachsanid; set => khachsanid = value; }

        public string KTraThongTin()
        {
            if (string.IsNullOrEmpty(Hoten))
            {
                return "Họ tên không được để trống!";
            }

            if (string.IsNullOrEmpty(Cmnd))
            {
                return "Số CMND không được để trống!";
            }

            if (Ngaysinh >= DateTime.Now)
            {
                return "Ngày sinh không hợp lệ!";
            }

            if (string.IsNullOrEmpty(Gioitinh))
            {
                return "Giới tính không được để trống!";
            }

            if (string.IsNullOrEmpty(Dienthoai))
            {
                return "Số điện thoại không được để trống!";
            }

            if (!Regex.IsMatch(Dienthoai, @"^\d{3}\d{4}\d{3}$"))
            {
                return "Số điện thoại không hợp lệ!";
            }

            if (string.IsNullOrEmpty(Email))
            {
                return "Email không được đểtrống!";
            }

            if (!Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                return "Email không hợp lệ!";
            }

            if (string.IsNullOrEmpty(Tendangnhap))
            {
                return "Tên đăng nhập không được để trống!";
            }

            if (string.IsNullOrEmpty(Matkhau))
            {
                return "Mật khẩu không được để trống!";
            }

            if (string.IsNullOrEmpty(Diachi))
            {
                return "Địa chỉ không được để trống!";
            }

            return "Thông tin hợp lệ!";
        }
    }
}
