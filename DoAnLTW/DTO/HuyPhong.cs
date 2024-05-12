using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTW.DTO
{
    public class HuyPhong
    {
        private string lyDo;
        private string datPhongID;
        private string khachSanID;
        private DateTime thoiGian;

        public HuyPhong(string lyDo, string datPhongID, string khachSanID, DateTime thoiGian)
        {
            this.LyDo = lyDo;
            this.DatPhongID = datPhongID;
            this.KhachSanID = khachSanID;
            this.ThoiGian = thoiGian;
        }

        public string LyDo { get => lyDo; set => lyDo = value; }
        public string DatPhongID { get => datPhongID; set => datPhongID = value; }
        public string KhachSanID { get => khachSanID; set => khachSanID = value; }
        public DateTime ThoiGian { get => thoiGian; set => thoiGian = value; }

        public string KiemTraThongTin()
        {
            if (string.IsNullOrEmpty(LyDo))
            {
                return "Vui lòng cung cấp lý do hủy phòng.";
            }

            if (string.IsNullOrEmpty(DatPhongID))
            {
                return "Vui lòng cung cấp ID đặt phòng.";
            }

            if (string.IsNullOrEmpty(KhachSanID))
            {
                return "Vui lòng cung cấp ID khách sạn.";
            }

            if (ThoiGian < DateTime.Now.Date)
            {
                return "Thời gian không hợp lệ.";
            }

            return "Thông tin hợp lệ!";
        }
    }
}
