using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTW
{
    public partial class FChuKhachSan : Form
    {
        public FChuKhachSan()
        {
            InitializeComponent();
            ucQuanLy.btnChoO.Click += btnChoO_Click;
            ucQuanLy.btnTinNhan.Click += btnTinNhan_Click;
            ucQuanLy.btnDatPhong.Click += btnDatPhong_Click;
        }
        private void btnChoO_Click(object sender, EventArgs e)
        {
            FChuChoO fchild = new FChuChoO();
            fchild.Show();
            this.Hide();
        }
        private void btnTinNhan_Click(object sender, EventArgs e)
        {
            FChuTinNhan fchild = new FChuTinNhan();
            fchild.Show();
            this.Hide();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            FChuDatPhong fchild = new FChuDatPhong();
            fchild.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FDangNhap fchild = new FDangNhap();
            fchild.Show();
            this.Hide();    
        }

        private void btnThongTinChuKhach_Click(object sender, EventArgs e)
        {
            FChuThongTinCaNhan fchild = new FChuThongTinCaNhan();
            fchild.Show();
            this.Hide();
        }

        private void btnThemchoo_Click(object sender, EventArgs e)
        {
            FChuThemChoO fChuThemChoO = new FChuThemChoO();
            fChuThemChoO.Show();
            this.Hide();
        }
    }
}
