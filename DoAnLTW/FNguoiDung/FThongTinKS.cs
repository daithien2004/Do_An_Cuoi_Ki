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
    public partial class FThongTinKS : Form
    {
        public FThongTinKS()
        {
            InitializeComponent();
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = imageList1.Images[count];
            count++;
            if (count > 3)
            {
                count = 0;
            }
        }

        private void FThongTinKS_Load(object sender, EventArgs e)
        {

        }
    }
}
