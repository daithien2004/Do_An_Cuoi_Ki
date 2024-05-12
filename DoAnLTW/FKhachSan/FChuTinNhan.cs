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
    public partial class FChuTinNhan : Form
    {
        public FChuTinNhan()
        {
            InitializeComponent();
            ucQuanLy.btnChoO.Click += btnChoO_Click;
            ucQuanLy.btnDatPhong.Click += btnDatPhong_Click;
            ucQuanLy.btnTongQuan.Click += btnTongQuan_Click;
        }
        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            FChuKhachSan fchild = new FChuKhachSan();
            fchild.Show();
            this.Hide();
        }
        private void btnChoO_Click(object sender, EventArgs e)
        {
            FChuChoO fchild = new FChuChoO();
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
