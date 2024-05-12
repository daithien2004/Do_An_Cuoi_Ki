using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using DoAnLTW.DAL;
using DoAnLTW.DTO;

namespace DoAnLTW
{
    public partial class FTrangChu : Form
    {
        List<UCChonKS> listUCKS = new List<UCChonKS>();
        public FTrangChu()
        {
            InitializeComponent();
        }

        public void LayKhachSan()
        {
            try
            {
                foreach (KhachSan ks in KhachSanDAO.Instance.LayThongTinChung())
                {
                    UCChonKS uCChonKS = new UCChonKS();
                    string[] danhSach = ks.HinhAnh.Split(',');
                    Image image = ThaoTacAnh.LayAnh(danhSach[0]);
                    uCChonKS.pbAnh.Image = image;
                    uCChonKS.lblIdKS.Text = ks.KhachSanID;
                    uCChonKS.lblTenKS.Text = ks.TenKhachSan;
                    uCChonKS.rtKS.Value = Convert.ToInt32(ks.Sao);
                    uCChonKS.lblDiaChi.Text = ks.DiaChi;

                    string[] mangPhanTu = ks.TienNghi.Split(',');
                    int index = Math.Min(4, mangPhanTu.Length) - 1;
                    uCChonKS.lblTienNghi.Text = string.Join(",", mangPhanTu.Take(index));

                    string[] mangTT = ks.HinhThucThanhToan.Split(',');
                    int indexTT = Math.Min(4, mangTT.Length) - 1;
                    uCChonKS.lblThanhToan.Text = string.Join(",", mangTT.Take(index));

                    uCChonKS.lblGiaPhong.Text = "From " + PhongDAO.Instance.LayMinMaxGia(ks.KhachSanID)[0].ToString("#,##0", culture)
                        + "\n" + "To " + PhongDAO.Instance.LayMinMaxGia(ks.KhachSanID)[1].ToString("#,##0", culture);
                    uCChonKS.lblMinGia.Text = PhongDAO.Instance.LayMinMaxGia(ks.KhachSanID)[0].ToString();
                    uCChonKS.lblMaxGia.Text = PhongDAO.Instance.LayMinMaxGia(ks.KhachSanID)[1].ToString();
                    uCChonKS.lblTinh.Text = ks.Tinh;
                    if (UuDaiDAO.Instance.LayUDTheoKS(ks.KhachSanID).Count > 0)
                        uCChonKS.lblUuDai.Text = "Giảm Đến " + Convert.ToString(UuDaiDAO.Instance.LayUDTheoKS(ks.KhachSanID)[0].PhanTram) + "%";
                    listUCKS.Add(uCChonKS);
                    pnlKS.Controls.Add(uCChonKS);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UCTinh_Click(object sender, EventArgs e)
        {
            UCTinh uCTinh = sender as UCTinh;
            if (uCTinh != null)
            {
                pnlKS.Controls.Clear();
                foreach (UCChonKS uc in listUCKS)
                {
                    if (uc.lblTinh.Text == uCTinh.lblTinh.Text)
                    {
                        pnlKS.Controls.Add(uc);
                    }
                }
            }
        }
        private void btnThongtincanhan_Click(object sender, EventArgs e)
        {
            FThongTinCaNhan fthongtincanhan = new FThongTinCaNhan();
            fthongtincanhan.Show();
            this.Hide();
        }

        private void btnDondat_Click(object sender, EventArgs e)
        {
            FThongTinDatPhong fthongtindatphong = new FThongTinDatPhong();
            fthongtindatphong.Show();
            this.Hide();
        }

        private void btnThongTinChuKhach_Click(object sender, EventArgs e)
        {
            if (!bcCanhan.Visible) bunifuTransition1.ShowSync(bcCanhan);
            else bunifuTransition1.HideSync(bcCanhan);
        }
        private void btnDXuat_Click(object sender, EventArgs e)
        {
            FDangNhap fDangnhap = new FDangNhap();
            fDangnhap.Show();
            this.Hide();
        }
        CultureInfo culture = new CultureInfo("vi-VN");
        private void tbGia_ValueChanged(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ValueChangedEventArgs e)
        {
            lblMinGia.Text = tbMinGia.Value.ToString("C", culture);
        }

        private void tbMaxGia_ValueChanged(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ValueChangedEventArgs e)
        {
            lblMaxGia.Text = tbMaxGia.Value.ToString("C", culture);
        }
        public List<Tuple<string, string>> LayDonDatTheoNgay(DateTime ngayDat, DateTime ngayTra)
        {
            List<Tuple<string, string>> listPKS = new List<Tuple<string, string>>();
            List<Tuple<string, string>> listiDP = DatPhongDAO.Instance.LayIDPhong();
            if (listiDP != null)
            {
                foreach (Tuple<string, string> pKS in listiDP)
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
        public bool KiemTraLocNgay(UCChonKS uCKS, DateTime ngayDat, DateTime ngayTra)
        {
            List<Tuple<string, string>> listdd = LayDonDatTheoNgay(ngayDat, ngayTra);
            if (listdd != null)
            {
                foreach (Tuple<string, string> dp in listdd)
                {
                    if (uCKS.lblIdKS.Text == dp.Item2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool KiemTraPhongTrong(UCChonKS uCKS)
        {
            foreach (Phong ks in PhongDAO.Instance.LayPhongChuaDuocDat())
            {
                if (uCKS.lblIdKS.Text == ks.KhachSanID)
                {
                    return true;
                }
            }
            return false;
        }
        public bool KiemTraKSTheoNguoi(UCChonKS uCKS, int nguoiLon, int treEm)
        {
            foreach (Phong phong in PhongDAO.Instance.LayPhongTheoNguoi(nguoiLon, treEm))
            {
                if (uCKS.lblIdKS.Text == phong.KhachSanID)
                {
                    return true;
                }
            }
            return false;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLocGia.Checked && tbMinGia.Value > tbMaxGia.Value)
                {
                    MessageBox.Show("Giá tiền không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cbLocNgay.Checked && (dtNgayDat.Value.Date < DateTime.Now.Date || dtNgayDat.Value > dtNgayTra.Value))
                {
                    MessageBox.Show("Ngày không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int nguoiLon = Convert.ToInt32(ucDemNL.txtDem.Text);
                int treEm = Convert.ToInt32(ucDemTE.txtDem.Text);
                pnlKS.Controls.Clear();
                foreach (UCChonKS control in listUCKS)
                {
                    bool dk = true;
                    if (cbLocGia.Checked)
                    {

                        int minGia = Convert.ToInt32(control.lblMinGia.Text);
                        int maxGia = Convert.ToInt32(control.lblMaxGia.Text);
                        dk = (minGia <= tbMaxGia.Value) && (tbMaxGia.Value <= maxGia);
                    }

                    if (cbLocNguoi.Checked)
                    {
                        dk = dk && KiemTraKSTheoNguoi(control, nguoiLon, treEm);
                    }
                    if (cbLocNgay.Checked)
                        dk = dk && (KiemTraLocNgay(control, dtNgayDat.Value, dtNgayTra.Value) || KiemTraPhongTrong(control));
                    if (dk)
                    {
                        pnlKS.Controls.Add(control);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTimTinh_TextChange(object sender, EventArgs e)
        {
            try
            {
                if (txtTimTinh.TextLength >= 1 && txtTimTinh.Text != "")
                {
                    UCTinh uCTinh = new UCTinh();
                    List<UCTinh> listucTinh = uCTinh.TimTinh(txtTimTinh.Text);
                    pnlKQTim.Controls.Clear();
                    foreach (UCTinh ucTinh in listucTinh)
                    {
                        ucTinh.Click += UCTinh_Click;
                        pnlKQTim.Controls.Add(ucTinh);
                        pnlKQTim.Height = pnlKQTim.Controls.Count * 38;
                    }
                }
                else
                {
                    pnlKQTim.Height = 0;
                    foreach (UCChonKS uc in listUCKS)
                    {
                        pnlKS.Controls.Add(uc);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FTrangChu_Load(object sender, EventArgs e)
        {          
            pnlKQTim.Height = 0;
            lblMinGia.Text = tbMinGia.Minimum.ToString("C", culture);
            lblMaxGia.Text = tbMaxGia.Minimum.ToString("C", culture);
            LayKhachSan();
        }
        private void AddFormToPanel(Form form)
        {
            pnlKS.Controls.Clear();
            form.TopLevel = false;
            form.Visible = true;
            pnlKS.Controls.Add(form);
            form.Size = pnlKS.Size;
        }
        private void btnDeXuat_Click(object sender, EventArgs e)
        {
            FDeXuat fDeXuat = new FDeXuat();
            fDeXuat.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FDangNhap fDangnhap = new FDangNhap();
            fDangnhap.Show();
            this.Hide();
        }
    }
}
