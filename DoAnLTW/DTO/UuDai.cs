using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTW.DTO
{
    public class UuDai
    {
        private string khachSanID;
        private string maUuDai;
        private decimal phanTram;
        private DateTime hSD;
        public UuDai(string maUuDai, decimal phanTram, DateTime hSD)
        {
            this.maUuDai = maUuDai;
            this.phanTram = phanTram;
            this.hSD = hSD;
        }

        public UuDai(string khachSanID, string maUuDai, decimal phanTram, DateTime hSD)
        {
            this.khachSanID = khachSanID;
            this.maUuDai = maUuDai;
            this.phanTram = phanTram;
            this.hSD = hSD;
        }

        public string KhachSanID { get => khachSanID; set => khachSanID = value; }
        public string MaUuDai { get => maUuDai; set => maUuDai = value; }
        public decimal PhanTram { get => phanTram; set => phanTram = value; }
        public DateTime HSD { get => hSD; set => hSD = value; }

        public string KiemTraThongTin()
        {
            if (string.IsNullOrEmpty(maUuDai))
            {
                return "Mã ưu đãi không được để trống.";
            }

            if (phanTram <= 0 || phanTram > 100)
            {
                return "Phần trăm ưu đãi phải lớn hơn 0 và nhỏ hơn hoặc bằng 100.";
            }

            if (hSD <= DateTime.Now.Date)
            {
                return "Hạn sử dụng phải lớn hơn ngày hiện tại.";
            }

            return "Thông tin hợp lệ!";
        }
    }
}
