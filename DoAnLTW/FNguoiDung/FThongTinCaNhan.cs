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
    public partial class FThongTinCaNhan : Form
    {
        public FThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            FDangNhap fDangnhap = new FDangNhap();
            fDangnhap.Show();
            this.Hide();
        }

        private void btnCanhan_Click(object sender, EventArgs e)
        {
            if (!bunifuCards4.Visible) bunifuTransition1.ShowSync(bunifuCards4);
            else bunifuTransition1.HideSync(bunifuCards4);
        }

        private void btnTrangchu_Click(object sender, EventArgs e)
        {
            FTrangChu fTrangChu = new FTrangChu();
            fTrangChu.Show();
            this.Hide();
        }

        private void btnDondat_Click(object sender, EventArgs e)
        {
            FThongTinDatPhong fthongtindatphong = new FThongTinDatPhong();
            fthongtindatphong.Show();
            this.Hide();
        }
    }
}
