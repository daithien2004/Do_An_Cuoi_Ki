using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnLTW.DAL;

namespace DoAnLTW.Admin
{
    public partial class FAdmin : Form
    {
        public FAdmin()
        {
            InitializeComponent();
        }
        private void AddFormToPanel(Form form)
        {
            pnlHienThi.Controls.Clear();
            form.TopLevel = false;
            form.Visible = true;
            pnlHienThi.Controls.Add(form);
            form.Size = pnlHienThi.Size;
        }
        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            FDoanhThuKS fdt = new FDoanhThuKS();
            AddFormToPanel(fdt);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FNguoiDungVip fcon = new FNguoiDungVip();
            AddFormToPanel(fcon);
        }

        private void FAdmin_Load(object sender, EventArgs e)
        {
            FDoanhThuKS fdt = new FDoanhThuKS();
            AddFormToPanel(fdt);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FDangNhap fDangnhap = new FDangNhap();
            fDangnhap.Show();
            this.Hide();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            FDSTaiKhoan fDS = new FDSTaiKhoan();
            AddFormToPanel(fDS);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FDangNhap fDangnhap = new FDangNhap();
            fDangnhap.Show();
            this.Hide();
        }

        private void btnKHTiemNang_Click(object sender, EventArgs e)
        {
            FKSTiemNang fks = new FKSTiemNang();
            AddFormToPanel(fks);
        }
    }
}
