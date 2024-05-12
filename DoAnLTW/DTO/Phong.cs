using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DoAnLTW.DTO
{
    public class Phong
    {
        private string phongID;
        private string khachSanID;
        private string thongTinChung;
        private string phanLoai;
        private string tienNghi;
        private int gia;
        private decimal dienTich;
        private int nguoiLon;
        private int treEm;
        private int giuongLon;
        private int giuongNho;
        private string dSHinhAnh;

        public Phong(string phongID)
        {
            this.PhongID = phongID;
        }

        public Phong(string phongID, string khachSanID)
        {
            this.phongID = phongID;
            this.khachSanID = khachSanID;
        }

        public Phong(string phongID, string khachSanID, string thongTinChung, string phanLoai, string tienNghi, int gia, decimal dienTich, int nguoiLon, 
            int treEm, int giuongLon, int giuongNho, string dSHinhAnh)
        {
            this.phongID = phongID;
            this.khachSanID = khachSanID;
            this.thongTinChung = thongTinChung;
            this.phanLoai = phanLoai;
            this.tienNghi = tienNghi;
            this.gia = gia;
            this.dienTich = dienTich;
            this.nguoiLon = nguoiLon;
            this.treEm = treEm;
            this.giuongLon = giuongLon;
            this.giuongNho = giuongNho;
            this.dSHinhAnh = dSHinhAnh;
        }

        public string PhongID { get => phongID; set => phongID = value; }
        public string KhachSanID { get => khachSanID; set => khachSanID = value; }
        public string ThongTinChung { get => thongTinChung; set => thongTinChung = value; }
        public string PhanLoai { get => phanLoai; set => phanLoai = value; }
        public string TienNghi { get => tienNghi; set => tienNghi = value; }
        public int Gia { get => gia; set => gia = value; }
        public int NguoiLon { get => nguoiLon; set => nguoiLon = value; }
        public int TreEm { get => treEm; set => treEm = value; }
        public int GiuongLon { get => giuongLon; set => giuongLon = value; }
        public int GiuongNho { get => giuongNho; set => giuongNho = value; }
        public decimal DienTich { get => dienTich; set => dienTich = value; }
        public string DSHinhAnh { get => dSHinhAnh; set => dSHinhAnh = value; }

        public string KTraThongTin()
        {
            if (string.IsNullOrEmpty(PhongID))
                return "Chưa Nhập ID Phòng!";
            if (string.IsNullOrEmpty(KhachSanID))
                return "Chưa Nhập ID Khách Sạn!";
            if (string.IsNullOrEmpty(ThongTinChung))
                return "Chưa Nhập Thông Tin Chung!";
            if (string.IsNullOrEmpty(PhanLoai))
                return "Chưa Nhập Phân Loại!";
            if (string.IsNullOrEmpty(TienNghi))
                return "Chưa Nhập Tiện Nghi!";
            if (Gia <= 0)
                return "Giá phòng không hợp lệ!";
            if (NguoiLon <= 0 && TreEm <= 0)
                return "Số lượng người lớn hoặc trẻ em không hợp lệ!";
            if (GiuongLon <= 0 && GiuongNho <= 0)
                return "Số lượng giường lớn hoặc giường nhỏ không hợp lệ!";
            if (DienTich <= 0)
                return "Diện tích không hợp lệ!";
            if (string.IsNullOrEmpty(DSHinhAnh))
                return "Chưa Nhập Danh Sách Hình Ảnh!";

            return "Thông tin hợp lệ!";
        }
    }
}
