using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTW.DTO
{
    public class GiamGia
    {
        private string giamGiaID;
        private string khachSanID;
        private string phongID;
        private DateTime ngayBD;
        private DateTime ngayKT;
        private decimal phanTram;

        public GiamGia(string giamGiaID, string khachSanID, string phongID)
        {
            this.giamGiaID = giamGiaID;
            this.khachSanID = khachSanID;
            this.phongID = phongID;
        }

        public GiamGia(string giamGiaID, string khachSanID, string phongID, DateTime ngayBD, DateTime ngayKT, decimal phanTram)
        {
            this.GiamGiaID = giamGiaID;
            this.KhachSanID = khachSanID;
            this.PhongID = phongID;
            this.NgayBD = ngayBD;
            this.NgayKT = ngayKT;
            this.PhanTram = phanTram;
        }

        public string GiamGiaID { get => giamGiaID; set => giamGiaID = value; }
        public string KhachSanID { get => khachSanID; set => khachSanID = value; }
        public string PhongID { get => phongID; set => phongID = value; }
        public DateTime NgayBD { get => ngayBD; set => ngayBD = value; }
        public DateTime NgayKT { get => ngayKT; set => ngayKT = value; }
        public decimal PhanTram { get => phanTram; set => phanTram = value; }

        public string KiemTraThongTin()
        {
            if (string.IsNullOrEmpty(giamGiaID))
            {
                return "Mã giảm giá không được để trống.";
            }

            if (string.IsNullOrEmpty(khachSanID))
            {
                return "Mã khách sạn không được để trống.";
            }

            if (string.IsNullOrEmpty(phongID))
            {
                return "Mã phòng không được để trống.";
            }

            if (ngayKT < ngayBD)
            {
                return "Ngày kết thúc phải lớn hơn ngày bắt đầu.";
            }

            if (ngayBD < DateTime.Now.Date)
            {
                return "Ngày bắt đầu không được trước ngày hiện tại";
            }
            if (phanTram <= 0 || phanTram > 100)
            {
                return "Phần trăm giảm giá phải lớn hơn 0 và nhỏ hơn hoặc bằng 100.";
            }

            return "Thông tin hợp lệ!";
        }
    }
}
