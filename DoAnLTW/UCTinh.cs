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
using DoAnLTW.DTO;

namespace DoAnLTW
{
    public partial class UCTinh : UserControl
    {
        public UCTinh()
        {
            InitializeComponent();
        }
        public List<UCTinh> TimTinh(string key)
        {
            List<UCTinh> listucTinh = new List<UCTinh>();
            List<string> dstinh = DatPhongDAO.Instance.TimTinh(key);
            foreach (string tinh in dstinh)
            {
                UCTinh ucTinh = new UCTinh();
                ucTinh.lblTinh.Text = tinh;
                listucTinh.Add(ucTinh);
            }
            return listucTinh;
        }

        private void UCTinh_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Gainsboro;
        }

        private void UCTinh_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void UCTinh_Click(object sender, EventArgs e)
        {
            BienDungChung.Tinh = this.lblTinh.Text;
        }
    }
}
