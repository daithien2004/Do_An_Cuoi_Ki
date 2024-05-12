using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using DoAnLTW.DAL;
using DoAnLTW.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DoAnLTW
{
    public partial class FThongTinKS : Form
    {
        KhachSan ks;
        private int currentIndex = 0;
        private List<Image> images = new List<Image>();
        public FThongTinKS()
        {
            InitializeComponent();
        }

        public void LayThongTinKS()
        {
            try
            {
                // Lấy thông tin khách sạn
                ks = KhachSanDAO.Instance.LayThongTinRieng(BienDungChung.KhachSan.KhachSanID);
                lblTenKS.Text = ks.TenKhachSan;
                lblDiaChi.Text = ks.DiaChi;
                lblTienNghi.Text = ks.TienNghi;
                txtMoTa.Text = ks.TongQuan;
                string[] listAnhs = ks.HinhAnh.Split(',');
                // Thêm vào imagelist
                foreach (string listAnh in listAnhs)
                {
                    Image image = ThaoTacAnh.LayAnh(listAnh);
                    images.Add(image);
                }
                HienThiAnh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        List<UCDatPhong> listUCKS;
        public void LayThongTinPhong()
        {
            try
            {
                listUCKS = new List<UCDatPhong>();
                foreach (Phong phong in PhongDAO.Instance.LayThongTinChung())
                {
                    string[] danhSach = phong.DSHinhAnh.Split(',');
                    UCDatPhong uCDatPhong = new UCDatPhong();
                    uCDatPhong.lblLoaiPhong.Text = "Phòng " + phong.PhanLoai;
                    uCDatPhong.lblIDPhong.Text = phong.PhongID;
                    uCDatPhong.lblSucChua.Text = phong.NguoiLon + " Người lớn" + ", " + phong.TreEm + " Trẻ em";
                    uCDatPhong.lblDienTich.Text = Convert.ToString(phong.DienTich) + " m2";
                    uCDatPhong.lblSoGiuong.Text = phong.GiuongLon + " Giường lớn" + ", " + phong.GiuongNho + " Giường nhỏ";

                    string[] mangPhanTu = phong.TienNghi.Split(',');
                    int index = Math.Min(4, mangPhanTu.Length) - 1;
                    uCDatPhong.lblTienNghi.Text = string.Join(",", mangPhanTu.Take(index));

                    uCDatPhong.lblKSID.Text = phong.KhachSanID;
                    uCDatPhong.lblGia.Text = Convert.ToString(phong.Gia);
                    Image image = ThaoTacAnh.LayAnh(danhSach[0]);
                    uCDatPhong.pbAnh.Image = image;
                    listUCKS.Add(uCDatPhong);
                    if (phong.KhachSanID == BienDungChung.KhachSan.KhachSanID)
                        pnlPhong.Controls.Add(uCDatPhong);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public int KiemTraGiamGia(DateTime ngayDat, DateTime ngayTra, UCDatPhong phong)
        {
            List<Tuple<string, string, DateTime, DateTime, decimal>> listNgay = GiamGiaDAO.Instance.LayNgayGiamGiaCuaPhong("-1", phong.lblIDPhong.Text, BienDungChung.KhachSan.KhachSanID);
            foreach (Tuple<string, string, DateTime, DateTime, decimal> nd in listNgay)
            {
                if ((nd.Item3 <= ngayDat && ngayTra <= nd.Item4))
                    return Convert.ToInt32(nd.Item5);
            }
            return 1;
        }
        private void HienThiAnh()
        {
            pbAnh.Image = images[currentIndex];
        }
        List<UCDanhGia> listUCDG = new List<UCDanhGia>();
        public void LayDanhGia()
        {
            try
            {
                foreach (DanhGia dg in DanhGiaDAO.Instance.LayThongTinTheoIDKS(BienDungChung.KhachSan.KhachSanID))
                {
                    UCDanhGia uCDanhGia = new UCDanhGia();
                    uCDanhGia.rtSao.Value = dg.Sao;
                    uCDanhGia.dtNgayDanhGia.Value = dg.Ngay;
                    uCDanhGia.txtDanhGia.Text = dg.NoiDung;
                    NguoiDung nd = NguoiDungDAO.Instance.LayThongTinRieng(dg.NguoiDungID);
                    uCDanhGia.pbNguoiDung.Image = ThaoTacAnh.LayAnh(nd.Hinhanh);
                    listUCDG.Add(uCDanhGia);
                    pnlDanhGia.Controls.Add(uCDanhGia);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnChuyenTrai_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            else
            {
                currentIndex = images.Count - 1;
            }
            if (images.Count > 0)
                HienThiAnh();
        }

        private void btnChuyenPhai_Click(object sender, EventArgs e)
        {
            if (currentIndex < images.Count - 1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
            if (images.Count > 0)
                HienThiAnh();
        }
        private void FThongTinKS_Load(object sender, EventArgs e)
        {
            LayThongTinKS();
            LayThongTinPhong();
            LayDanhGia();
        }
        public List<Tuple<string, string>> LayDonDatTheoNgay(DateTime ngayDat, DateTime ngayTra)
        {
            List<Tuple<string, string>> listPKS = new List<Tuple<string, string>>();
            List<Tuple<string, string>> listidp = DatPhongDAO.Instance.LayIDPhong(BienDungChung.KhachSan.KhachSanID);
            if (listidp != null)
            {
                foreach (Tuple<string, string> pKS in listidp)
                {
                    List<Tuple<string, string, DateTime, DateTime>> listNgay = DatPhongDAO.Instance.LayNgayDatCuaPhong(pKS.Item1, pKS.Item2);
                    if (KiemTraNgay(listNgay, ngayDat, ngayTra))
                    {
                        listPKS.Add(pKS);
                    }
                }
            }
            return listPKS;
        }
        public bool KiemTraNgay(List<Tuple<string, string, DateTime, DateTime>> listNgay, DateTime ngayDat, DateTime ngayTra)
        {
            foreach (Tuple<string, string, DateTime, DateTime> nd in listNgay)
            {
                if ((nd.Item3 <= ngayDat && ngayDat <= nd.Item4) || (nd.Item3 <= ngayTra && ngayTra <= nd.Item4) || ngayDat <= nd.Item3 && nd.Item4 <= ngayTra)
                    return false;
            }
            return true;
        }
        public bool KiemTraLocNgay(UCDatPhong uCP, DateTime ngayDat, DateTime ngayTra)
        {
            List<Tuple<string, string>> listdd = LayDonDatTheoNgay(ngayDat, ngayTra);
            if (listdd != null)
            {
                foreach (Tuple<string, string> dp in listdd)
                {
                    if (uCP.lblIDPhong.Text == dp.Item1 && uCP.lblKSID.Text == BienDungChung.KhachSan.KhachSanID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool KiemTraPhongTrong(UCDatPhong uCP)
        {
            foreach (Phong p in PhongDAO.Instance.LayPhongChuaDuocDat())
            {
                if (uCP.lblIDPhong.Text == p.PhongID && uCP.lblKSID.Text == BienDungChung.KhachSan.KhachSanID)
                {
                    return true;
                }
            }
            return false;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cbTim.Checked)
            {
                if (dtNgayDat.Value.Date < DateTime.Now.Date || dtNgayDat.Value > dtNgayTra.Value)
                {
                    MessageBox.Show("Ngày không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                pnlPhong.Controls.Clear();
                foreach (UCDatPhong control in listUCKS)
                {
                    if (KiemTraLocNgay(control, dtNgayDat.Value, dtNgayTra.Value) || KiemTraPhongTrong(control))
                    {
                        Phong p = PhongDAO.Instance.LayThongTinRieng(control.lblIDPhong.Text, control.lblKSID.Text);
                        decimal gg = KiemTraGiamGia(dtNgayDat.Value, dtNgayTra.Value, control);
                        if (gg != 1)
                        {

                            control.lblGia.Text = Convert.ToString(Convert.ToInt32(p.Gia) * gg / 100);
                        }
                        else
                            control.lblGia.Text = Convert.ToString(p.Gia);
                        pnlPhong.Controls.Add(control);
                    }
                }
            }
            else
            {
                pnlPhong.Controls.Clear();
                LayThongTinPhong();
            }    
        }
    }
}
