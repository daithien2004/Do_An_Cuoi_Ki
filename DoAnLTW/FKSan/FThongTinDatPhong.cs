using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DoAnLTW.DAL;
using DoAnLTW.DTO;

namespace DoAnLTW
{
    public partial class FThongTinDatPhong : Form
    {
        List<UCDonDatPhong> listUCDP;
        public FThongTinDatPhong()
        {
            InitializeComponent();
            
        }
        private void FThongTinDatPhong_Load(object sender, EventArgs e)
        {
            pnlKQTim.Height = 0;
            LoadDonDat();
        }
        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            FDangNhap fDangnhap = new FDangNhap();
            fDangnhap.Show();
            this.Hide();
        }

        private void btnThongtincanhan_Click(object sender, EventArgs e)
        {
            FThongTinCaNhan fthongtincanhan = new FThongTinCaNhan();
            fthongtincanhan.Show();
            this.Hide();
        }
        public void LoadDonDat()
        {
            pnlDP.Controls.Clear();
            listUCDP = new List<UCDonDatPhong>();
            foreach (DatPhong dp in DatPhongDAO.Instance.LayThongTinChung())
            {
                Phong p = PhongDAO.Instance.LayThongTinRieng(dp.PhongID, dp.KhachSanID);
                KhachSan ks = KhachSanDAO.Instance.LayThongTinRieng(dp.KhachSanID);
                UCDonDatPhong uCDonDatPhong = new UCDonDatPhong();
                uCDonDatPhong.lblTenKS.Text = ks.TenKhachSan;
                uCDonDatPhong.lblIDdat.Text = dp.DatPhongID;
                uCDonDatPhong.dtNgaydat.Value = dp.NgayDat;
                uCDonDatPhong.dtNgaytra.Value = dp.NgayTra;
                uCDonDatPhong.lblTinhTrang.Text = dp.TrangThai;
                uCDonDatPhong.pbAnh.Image = ThaoTacAnh.LayAnh(p.DSHinhAnh);
                uCDonDatPhong.lblIDKS.Text = dp.KhachSanID;
                listUCDP.Add(uCDonDatPhong);
                pnlDP.Controls.Add(uCDonDatPhong);
            }
        }

        public void LoadDonDatDK(string dieukien)
        {
            LoadDonDat();
            foreach (UCDonDatPhong dp in pnlDP.Controls)
            {
                if (dp.lblTinhTrang.Text != dieukien)
                {
                    dp.Visible = false;
                }
            }
        }
        private void btnTatca_Click(object sender, EventArgs e)
        {
            pnlDP.Controls.Clear();
            LoadDonDat();       
        }

        private void btnHoantat_Click(object sender, EventArgs e)
        {
            pnlDP.Controls.Clear();
            LoadDonDatDK("Đã Trả Phòng");
        }
        private void btnDangcho_Click(object sender, EventArgs e)
        {
            pnlDP.Controls.Clear();
            LoadDonDatDK("Đang Chờ");
        }

        private void btnTrangChu_Click_1(object sender, EventArgs e)
        {
            FTrangChu fTrangChu = new FTrangChu();
            fTrangChu.Show();
            this.Hide();
        }

        private void btnThongTinChuKhach_Click(object sender, EventArgs e)
        {
            if (!bcCanhan.Visible) bunifuTransition1.ShowSync(bcCanhan);
            else bunifuTransition1.HideSync(bcCanhan);
        }
        public void UCTimDonDat_Click(object sender, EventArgs e)
        {
            UCTimDonDat uCTimDonDat = sender as UCTimDonDat;
            if (uCTimDonDat != null)
            {
                pnlDP.Controls.Clear();
                foreach (UCDonDatPhong uc in listUCDP)
                {
                    if (uc.lblIDdat.Text == uCTimDonDat.lblIDDat.Text)
                    {
                        pnlDP.Controls.Add(uc);
                    }
                }
            }
        }
        private void txtDatphong_TextChanged(object sender, EventArgs e)
        {
            LoadDonDat();
            if (txtDatPhong.TextLength >= 1)
            {
                UCTimDonDat uCTimDonDat = new UCTimDonDat();
                List<UCTimDonDat> listucDonDatPhong = uCTimDonDat.TimPhongDat(txtDatPhong.Text);
                pnlKQTim.Controls.Clear();
                foreach (UCTimDonDat ucDon in listucDonDatPhong)
                {
                    ucDon.Click += UCTimDonDat_Click;
                    pnlKQTim.Controls.Add(ucDon);
                    pnlKQTim.Height = pnlKQTim.Controls.Count * 41;
                }
            }
            else
            {
                pnlKQTim.Height = 0;
                foreach (UCDonDatPhong uc in listUCDP)
                {
                    pnlDP.Controls.Add(uc);
                }
            }
        }

        private void btnDaHuy_Click(object sender, EventArgs e)
        {
            pnlDP.Controls.Clear();
            LoadDonDatDK("Đã Hủy");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FTrangChu ftrangChu = new FTrangChu();
            ftrangChu.Show();
            this.Hide();
        }
    }
}
