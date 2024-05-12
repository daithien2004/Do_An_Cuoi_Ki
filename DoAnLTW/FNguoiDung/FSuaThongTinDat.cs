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
    public partial class FSuaThongTinDat : Form
    {
        public FSuaThongTinDat()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FThongTinDatPhong fThongTinDatPhong = new FThongTinDatPhong();
            fThongTinDatPhong.Show();
            this.Hide();
        }
    }
}
