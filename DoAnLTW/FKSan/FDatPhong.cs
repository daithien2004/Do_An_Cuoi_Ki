using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Windows.Forms;
using DoAnLTW.DAL;
using DoAnLTW.DTO;
using DoAnLTW.FKSan;

namespace DoAnLTW
{
    public partial class FDatPhong : Form
    {
        Random random = new Random();
        public FDatPhong()
        {
            InitializeComponent();
        }
        public void LayThongTin()
        {
            try
            {
                txtPhongID.Text = BienDungChung.PhongChon.PhongID;
                txtHoVaTen.Text = BienDungChung.NguoiDung.Hoten;
                txtEmail.Text = BienDungChung.NguoiDung.Email;
                txtSoDienThoai.Text = BienDungChung.NguoiDung.Dienthoai;
                lblGiaTien.Text = Convert.ToString(BienDungChung.PhongChon.Gia);
                string[] phanTuArray = BienDungChung.KhachSan.HinhThucThanhToan.Split(',');
                cbThanhToan.DataSource = phanTuArray;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public UuDai KiemTraMUD(string mauD)
        {
            foreach (UuDai ud in UuDaiDAO.Instance.LayUDTheoKS(BienDungChung.KhachSan.KhachSanID))
            {
                if (ud.MaUuDai == mauD)
                {
                    return ud;
                }
            }
            return null;
        }
        public bool KiemTraPhong(DatPhong dp)
        {
            List<DatPhong> ldpp = DatPhongDAO.Instance.LayThongTinPhong(BienDungChung.PhongChon.PhongID, BienDungChung.KhachSan.KhachSanID);
            if (ldpp != null)
            {
                foreach (DatPhong dpp in ldpp)
                {
                    if (dpp.TrangThai == "Đã Hủy" || dpp.TrangThai == "Đã Trả Phòng")
                        continue;
                    if ((dp.NgayDat <= dpp.NgayDat && dpp.NgayDat <= dp.NgayTra) || (dp.NgayDat <= dpp.NgayTra && dpp.NgayTra <= dp.NgayTra) ||
                        dp.NgayDat < DateTime.Now.Date || dp.NgayDat > dp.NgayTra || (dp.NgayDat <= dpp.NgayDat && dpp.NgayTra <= dp.NgayTra))
                    {
                        return false;
                    }
                }
            }
            if (dp.NgayDat < DateTime.Now.Date || dp.NgayDat > dp.NgayTra)
                return false;
            return true;
        }
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                int giaTien = Convert.ToInt32(lblGiaTien.Text);
                UuDai ud = KiemTraMUD(txtMaUD.Text);
                if (ud != null)
                {
                    giaTien = Convert.ToInt32(lblGiaTien.Text) * Convert.ToInt32(ud.PhanTram) / 100;
                }
                string iddp = DatPhongDAO.Instance.LayIDTiepTheo(BienDungChung.KhachSan.KhachSanID);
                DatPhong dp = new DatPhong(iddp, BienDungChung.KhachSan.KhachSanID, BienDungChung.PhongChon.PhongID,
                    BienDungChung.NguoiDung.Nguoidungid, dtNgayDat.Value.Date, dtNgayTra.Value.Date.AddDays(1).AddSeconds(-1), "Đang Chờ",
                    cbThanhToan.Text, giaTien, DateTime.Now.Date);                   
                if (KiemTraPhong(dp))
                {
                    if (DatPhongDAO.Instance.DatPhong(dp))
                    {
                        FDatPhong_Load(sender, e);
                        MessageBox.Show("Đặt thành công. " + "Mã đơn của bạn là " + iddp, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Đặt thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Phòng ở ngày hiện tại đã được đặt hoặc ngày đặt không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            FUuDai fud = new FUuDai();
            fud.ShowDialog();
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            try
            {               
                UuDai ud = KiemTraMUD(txtMaUD.Text);
                if (ud != null)
                {
                    if (DateTime.Now.Date > ud.HSD)
                    {
                        MessageBox.Show("Mã đã hết hạn sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (ud != null)
                    {
                        int giaTien = Convert.ToInt32(BienDungChung.PhongChon.Gia) * Convert.ToInt32(ud.PhanTram) / 100;
                        lblGiaTien.Text = Convert.ToString(giaTien);
                    }
                }
                else
                    MessageBox.Show("Mã không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FDatPhong_Load(object sender, EventArgs e)
        {
            LayThongTin();
        }
        public int KiemTraGiamGia(DateTime ngayDat, DateTime ngayTra, string idP)
        {
            List<Tuple<string, string, DateTime, DateTime, decimal>> listNgay = GiamGiaDAO.Instance.LayNgayGiamGiaCuaPhong("-1", idP, BienDungChung.KhachSan.KhachSanID);
            foreach (Tuple<string, string, DateTime, DateTime, decimal> nd in listNgay)
            {
                if ((nd.Item3 <= ngayDat && ngayTra <= nd.Item4))
                    return Convert.ToInt32(nd.Item5);
            }
            return 1;
        }
        private void btnXemNgayGG_Click(object sender, EventArgs e)
        {
            FNgayGiamGia fngg = new FNgayGiamGia();
            fngg.ShowDialog();
        }

        private void dtNgayDat_ValueChanged(object sender, EventArgs e)
        {
            Phong p = PhongDAO.Instance.LayThongTinRieng(txtPhongID.Text, BienDungChung.KhachSan.KhachSanID);
            if (dtNgayDat.Value < DateTime.Now.Date || dtNgayDat.Value > dtNgayTra.Value)
                return;
            decimal gg = KiemTraGiamGia(dtNgayDat.Value, dtNgayTra.Value, txtPhongID.Text);
            if (gg != 1)
            {
                lblGiaTien.Text = Convert.ToString(Convert.ToInt32(p.Gia) * gg / 100);
            }
            else
                lblGiaTien.Text = Convert.ToString(p.Gia);
        }

        private void dtNgayTra_ValueChanged(object sender, EventArgs e)
        {
            Phong p = PhongDAO.Instance.LayThongTinRieng(txtPhongID.Text, BienDungChung.KhachSan.KhachSanID);
            if (dtNgayDat.Value < DateTime.Now.Date || dtNgayDat.Value > dtNgayTra.Value)
                return;
            decimal gg = KiemTraGiamGia(dtNgayDat.Value, dtNgayTra.Value, txtPhongID.Text);
            if (gg != 1)
            {
                lblGiaTien.Text = Convert.ToString(Convert.ToInt32(p.Gia) * gg / 100);
            }
            else
                lblGiaTien.Text = Convert.ToString(p.Gia);
        }
    }
}
