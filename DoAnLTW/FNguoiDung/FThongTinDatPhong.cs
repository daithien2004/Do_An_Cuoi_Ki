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

namespace DoAnLTW
{
    public partial class FThongTinDatPhong : Form
    {
        PhongKS[] phong = new PhongKS[3];
        public FThongTinDatPhong()
        {
            InitializeComponent();
            DateTime dated = Convert.ToDateTime("1 / 1 / 1");
            DateTime dateh = Convert.ToDateTime("1 / 2 / 1");
            phong[0] = new PhongKS("1", "1", dated, dateh, "1", "Hoàn Tất");
            phong[1] = new PhongKS("1", "1", dated, dateh, "1", "Đang Chờ");
            phong[2] = new PhongKS("1", "1", dated, dateh, "1", "Đã Hủy");
        }
       
        private void btnTrangchu_Click(object sender, EventArgs e)
        {
            FTrangChu fTrangChu = new FTrangChu();
            fTrangChu.Show();
            this.Hide();
        }

        private void btnCanhan_Click(object sender, EventArgs e)
        {
            if (!bunifuCards1.Visible) bunifuTransition1.ShowSync(bunifuCards1);
            else bunifuTransition1.HideSync(bunifuCards1);
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

        private void btnChonkhachsan_Click(object sender, EventArgs e)
        {
            FSuaThongTinDat fSuaThongTinDat = new FSuaThongTinDat();
            fSuaThongTinDat.Show();
            this.Hide();
        }

        private void btnTatca_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 3; i++)
            {
                UCDonDatPhong uCDonDatPhong = new UCDonDatPhong();
                uCDonDatPhong.txtMa.Text = phong[i].Bookingid;
                uCDonDatPhong.dtNgaydat.Value = phong[i].Ngaydat;
                uCDonDatPhong.dtNgaytra.Value = phong[i].Ngayhuy;
                uCDonDatPhong.txtTinhtrang.Text = phong[i].Tinhtrang;
                if (uCDonDatPhong.txtTinhtrang.Text == "Hoàn Tất")
                    uCDonDatPhong.txtTinhtrang.FillColor = Color.Green;
                if (uCDonDatPhong.txtTinhtrang.Text == "Đang Chờ")
                    uCDonDatPhong.txtTinhtrang.FillColor = Color.Yellow;
                if (uCDonDatPhong.txtTinhtrang.Text == "Đã Hủy")
                    uCDonDatPhong.txtTinhtrang.FillColor = Color.Red;
                flowLayoutPanel1.Controls.Add(uCDonDatPhong);
            }
        }

        private void btnHoantat_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 3; i++)
            {
                if (phong[i].Tinhtrang == "Hoàn Tất")
                {
                    UCDonDatPhong uCDonDatPhong = new UCDonDatPhong();
                    uCDonDatPhong.txtMa.Text = phong[i].Bookingid;
                    uCDonDatPhong.dtNgaydat.Value = phong[i].Ngaydat;
                    uCDonDatPhong.dtNgaytra.Value = phong[i].Ngayhuy;
                    uCDonDatPhong.txtTinhtrang.Text = phong[i].Tinhtrang;
                    if (uCDonDatPhong.txtTinhtrang.Text == "Hoàn Tất")
                        uCDonDatPhong.txtTinhtrang.FillColor = Color.Green;
                    if (uCDonDatPhong.txtTinhtrang.Text == "Đang Chờ")
                        uCDonDatPhong.txtTinhtrang.FillColor = Color.Yellow;
                    if (uCDonDatPhong.txtTinhtrang.Text == "Đã Hủy")
                        uCDonDatPhong.txtTinhtrang.FillColor = Color.Red;
                    flowLayoutPanel1.Controls.Add(uCDonDatPhong);
                }                   
            }
        }

        private void btnDahuy_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 3; i++)
            {
                if (phong[i].Tinhtrang == "Đã Hủy")
                {
                    UCDonDatPhong uCDonDatPhong = new UCDonDatPhong();
                    uCDonDatPhong.txtMa.Text = phong[i].Bookingid;
                    uCDonDatPhong.dtNgaydat.Value = phong[i].Ngaydat;
                    uCDonDatPhong.dtNgaytra.Value = phong[i].Ngayhuy;
                    uCDonDatPhong.txtTinhtrang.Text = phong[i].Tinhtrang;
                    if (uCDonDatPhong.txtTinhtrang.Text == "Hoàn Tất")
                        uCDonDatPhong.txtTinhtrang.FillColor = Color.Green;
                    if (uCDonDatPhong.txtTinhtrang.Text == "Đang Chờ")
                        uCDonDatPhong.txtTinhtrang.FillColor = Color.Yellow;
                    if (uCDonDatPhong.txtTinhtrang.Text == "Đã Hủy")
                        uCDonDatPhong.txtTinhtrang.FillColor = Color.Red;
                    flowLayoutPanel1.Controls.Add(uCDonDatPhong);
                }
            }
        }

        private void btnDangcho_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 3; i++)
            {
                if (phong[i].Tinhtrang == "Đang Chờ")
                {
                    UCDonDatPhong uCDonDatPhong = new UCDonDatPhong();
                    uCDonDatPhong.txtMa.Text = phong[i].Bookingid;
                    uCDonDatPhong.dtNgaydat.Value = phong[i].Ngaydat;
                    uCDonDatPhong.dtNgaytra.Value = phong[i].Ngayhuy;
                    uCDonDatPhong.txtTinhtrang.Text = phong[i].Tinhtrang;
                    if (uCDonDatPhong.txtTinhtrang.Text == "Hoàn Tất")
                        uCDonDatPhong.txtTinhtrang.FillColor = Color.Green;
                    if (uCDonDatPhong.txtTinhtrang.Text == "Đang Chờ")
                        uCDonDatPhong.txtTinhtrang.FillColor = Color.Yellow;
                    if (uCDonDatPhong.txtTinhtrang.Text == "Đã Hủy")
                        uCDonDatPhong.txtTinhtrang.FillColor = Color.Red;
                    flowLayoutPanel1.Controls.Add(uCDonDatPhong);
                }
            }
        }
    }
}
