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

namespace DoAnLTW.FKSan
{
    public partial class FUuDai : Form
    {
        List<UCUuDai> listUCUd = new List<UCUuDai>();
        public FUuDai()
        {
            InitializeComponent();
            LayThongTin();
        }
        public void LayThongTin()
        {
            foreach (UuDai ud in UuDaiDAO.Instance.LayUDTheoKS(BienDungChung.KhachSan.KhachSanID))
            {
                UCUuDai uCUuDai = new UCUuDai();
                uCUuDai.lblHsd.Text = uCUuDai.lblHsd.Text +" "+ ud.HSD;
                uCUuDai.lblMa.Text = uCUuDai.lblMa.Text + ud.MaUuDai;
                uCUuDai.lblPhanTram.Text = ud.PhanTram.ToString() + "%";
                listUCUd.Add(uCUuDai);
                flpUuDai.Controls.Add(uCUuDai);             
            }
        }
    }
}
