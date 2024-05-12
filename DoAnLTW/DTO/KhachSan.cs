using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTW.DTO
{
    public class KhachSan
    {
        private string khachSanID;
        private string tenKhachSan;
        private string diaChi;
        private string tongQuan;
        private int sao;
        private string tienNghi;
        private string hinhAnh;
        private string hinhThucThanhToan;
        private string loai;
        private string tinh;

        public KhachSan(string khachSanID)
        {
            this.KhachSanID = khachSanID;
        }

        public KhachSan(string khachSanID, string tenKhachSan, string diaChi, string tongQuan, 
            int sao, string tienNghi, string hinhAnh, string hinhThucThanhToan, string loai, string tinh)
        {
            this.KhachSanID = khachSanID;
            this.TenKhachSan = tenKhachSan;
            this.DiaChi = diaChi;
            this.TongQuan = tongQuan;
            this.Sao = sao;
            this.TienNghi = tienNghi;
            this.HinhAnh = hinhAnh;
            this.HinhThucThanhToan = hinhThucThanhToan;
            this.Loai = loai;
            this.Tinh = tinh;
        }

        public string KhachSanID { get => khachSanID; set => khachSanID = value; }
        public string TenKhachSan { get => tenKhachSan; set => tenKhachSan = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string TongQuan { get => tongQuan; set => tongQuan = value; }
        public int Sao { get => sao; set => sao = value; }
        public string TienNghi { get => tienNghi; set => tienNghi = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public string HinhThucThanhToan { get => hinhThucThanhToan; set => hinhThucThanhToan = value; }
        public string Loai { get => loai; set => loai = value; }
        public string Tinh { get => tinh; set => tinh = value; }

        public string KTraThongTin()
        {
            if (string.IsNullOrEmpty(KhachSanID))
                return "ID khách sạn không được để trống.\n";

            if (string.IsNullOrEmpty(TenKhachSan))
                return "Tên khách sạn không được để trống.\n";

            if (string.IsNullOrEmpty(DiaChi))
                return "Địa chỉ không được để trống.\n";

            if (string.IsNullOrEmpty(TongQuan))
                return "Tổng quan không được để trống.\n";

            if (Sao < 1 || Sao > 5)
                return "Số sao không hợp lệ. Vui lòng chọn từ 1 đến 5 sao.\n";

            if (string.IsNullOrEmpty(TienNghi))
                return "Tiện nghi không được để trống.\n";

            if (string.IsNullOrEmpty(HinhAnh))
                return "Hình ảnh không được để trống.\n";

            if (string.IsNullOrEmpty(HinhThucThanhToan))
                return "Hình thức thanh toán không được để trống.\n";

            if (string.IsNullOrEmpty(Loai))
                return "Loại không được để trống.\n";

            if (string.IsNullOrEmpty(Tinh))
                return "Tỉnh không được để trống.\n";

            return "Thông tin hợp lệ!";
        }

        public string KTraThongTinTaoTK()
        {
            if (string.IsNullOrEmpty(KhachSanID))
                return "ID khách sạn không được để trống.\n";

            if (string.IsNullOrEmpty(TenKhachSan))
                return "Tên khách sạn không được để trống.\n";

            if (string.IsNullOrEmpty(DiaChi))
                return "Địa chỉ không được để trống.\n";

            if (Sao < 1 || Sao > 5)
                return "Số sao không hợp lệ. Vui lòng chọn từ 1 đến 5 sao.\n";

            if (string.IsNullOrEmpty(HinhThucThanhToan))
                return "Hình thức thanh toán không được để trống.\n";

            if (string.IsNullOrEmpty(Loai))
                return "Loại không được để trống.\n";

            if (string.IsNullOrEmpty(Tinh))
                return "Tỉnh không được để trống.\n";

            return "Thông tin hợp lệ!";
        }
    }
}
