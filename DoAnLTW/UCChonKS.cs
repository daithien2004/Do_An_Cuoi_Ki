using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnLTW.DAL;

namespace DoAnLTW
{
    public partial class UCChonKS : UserControl
    {
        public UCChonKS()
        {
            InitializeComponent();
        }

        private void btnChonkhachsan_Click(object sender, EventArgs e)
        {
            BienDungChung.KhachSan = KhachSanDAO.Instance.LayThongTinRieng(lblIdKS.Text);
            FKhachSan fkhachsan = new FKhachSan();
            foreach (Form form in Application.OpenForms)
            {
                if (form != fkhachsan)
                {
                    form.Hide();
                }
            }
            fkhachsan.Show();
        }
    }
}
