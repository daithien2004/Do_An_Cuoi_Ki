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
    public partial class FChuThemChoO : Form
    {
        public FChuThemChoO()
        {
            InitializeComponent();
        }

        private void btnTiepTheo_Click(object sender, EventArgs e)
        {
            if (bunifuPages1.SelectedIndex == 6)
            {
                bunifuPages1.SetPage(0);
              
            }   
            else
            {
                bunifuPages1.SetPage(bunifuPages1.SelectedIndex + 1);
          
            }
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            if (bunifuPages1.SelectedIndex == 0)
                bunifuPages1.SetPage(6);
            else
                bunifuPages1.SetPage(bunifuPages1.SelectedIndex - 1);
        }

        private void btnThongTinChuKhach_Click(object sender, EventArgs e)
        {
            FChuThongTinCaNhan fchild = new FChuThongTinCaNhan();
            fchild.Show();
            this.Hide();
        }
    }
}
