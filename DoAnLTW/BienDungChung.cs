using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnLTW.DTO;

namespace DoAnLTW
{
    public static class BienDungChung
    {
        public static KhachSan KhachSan { get; set; }
        public static Phong PhongChon { get; set; }
        public static DatPhong PhongDat { get; set; }
        public static NguoiDung NguoiDung { get; set; }
        public static string Tinh { get; set; }

        public static List<string> PTTT = new List<string>
        {
            "BIDV",
            "VietcomBank",
            "MBBank",
            "Tiền Mặt",
        };
    }
}
