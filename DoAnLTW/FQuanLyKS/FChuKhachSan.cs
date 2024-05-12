using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnLTW.FKSan;
using DoAnLTW.FQuanLyKS;

namespace DoAnLTW
{
    public partial class FChuKhachSan : Form
    {       
        FPhong fphong = new FPhong();
        FThemUuDai fthemUuDai = new FThemUuDai();
        FDanhSachPhong fDanhSachPhong = new FDanhSachPhong();
        FKhachHang fkhachHang = new FKhachHang();
        FDanhSachDon fdondat = new FDanhSachDon();
        FThemGiamGia fthemGiamGia = new FThemGiamGia();
        FLyDoHuyDon fdonhuy = new FLyDoHuyDon();
        FChuTrangChu ftrangchu = new FChuTrangChu();
        FChuThongTin fthongtin = new FChuThongTin();
        FThongTinKhachSan fttks = new FThongTinKhachSan();
        public FChuKhachSan()
        {
            InitializeComponent();
            AddFormToPanel(ftrangchu);
        }

        private void AddFormToPanel(Form form)
        {
            pnlHienThi.Controls.Clear();
            form.TopLevel = false;
            form.Visible = true;
            pnlHienThi.Controls.Add(form);
            form.Size = pnlHienThi.Size;
        }
        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            AddFormToPanel(fthongtin);
        }

        private void btnThongTinKhachSan_Click(object sender, EventArgs e)
        {

            AddFormToPanel(fttks);
        }
        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            FChuTrangChu ftrangchu = new FChuTrangChu();
            AddFormToPanel(ftrangchu);
        }
        private void btnUuDai_Click(object sender, EventArgs e)
        {
            AddFormToPanel(fthemUuDai);
        }

        private void btnDang_Click(object sender, EventArgs e)
        {
            AddFormToPanel(fphong);
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            AddFormToPanel(fDanhSachPhong);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            AddFormToPanel(fkhachHang);
        }

        private void btnDonDat_Click(object sender, EventArgs e)
        {
            AddFormToPanel(fdondat);
        }

        private void btnGiamGia_Click(object sender, EventArgs e)
        {
            AddFormToPanel(fthemGiamGia);
        }

        private void btnDonHuy_Click(object sender, EventArgs e)
        {
            AddFormToPanel(fdonhuy);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            FDangNhap fDangnhap = new FDangNhap();
            fDangnhap.Show();
            this.Hide();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FDangNhap fDangnhap = new FDangNhap();
            fDangnhap.Show();
            this.Hide();
        }
    }
}
