using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTW.DTO
{
    public class DanhGia
    {
        private string danhGiaID;
        private string khachSanID;
        private string phongID;
        private string nguoiDungID;
        private int sao;
        private string noiDung;
        private DateTime ngay;

        public DanhGia(string danhGiaID, string khachSanID, 
            string phongID, string nguoiDungID, int sao, string noiDung, DateTime ngay)
        {
            this.danhGiaID = danhGiaID;
            this.khachSanID = khachSanID;
            this.phongID = phongID;
            this.nguoiDungID = nguoiDungID;
            this.sao = sao;
            this.noiDung = noiDung;
            this.ngay = ngay;
        }

        public string DanhGiaID { get => danhGiaID; set => danhGiaID = value; }
        public string KhachSanID { get => khachSanID; set => khachSanID = value; }
        public string PhongID { get => phongID; set => phongID = value; }
        public string NguoiDungID { get => nguoiDungID; set => nguoiDungID = value; }
        public int Sao { get => sao; set => sao = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public DateTime Ngay { get => ngay; set => ngay = value; }

        public string KiemTraThongTin()
        {
            if (Sao < 1 || Sao > 5)
            {
                return "Sao phải nằm trong khoảng từ 1 đến 5.";
            }
            if (string.IsNullOrEmpty(noiDung))
            {
                return "Vui lòng nhập nội dung.";
            }
            return "Thông tin hợp lệ!";
        }
    }
}
