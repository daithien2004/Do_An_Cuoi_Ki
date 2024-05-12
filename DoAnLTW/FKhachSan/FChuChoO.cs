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
    public partial class FChuChoO : Form
    {
        public FChuChoO()
        {
            InitializeComponent();
            ucQuanLy.btnTongQuan.Click += btnTongQuan_Click;
            ucQuanLy.btnTinNhan.Click += btnTinNhan_Click;
            ucQuanLy.btnDatPhong.Click += btnDatPhong_Click;
        }
        private void btnTongQuan_Click(object sender, EventArgs e)
        {          
            FChuKhachSan fchild = new FChuKhachSan();
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
            Application.Exit();
        }
    }
}
