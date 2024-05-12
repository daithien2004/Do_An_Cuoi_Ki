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
    public partial class UCTimDonDat : UserControl
    {
        public UCTimDonDat()
        {
            InitializeComponent();
        }
        public List<UCTimDonDat> TimPhongDat(string key)
        {
            List<UCTimDonDat> listucPhong = new List<UCTimDonDat>();
            List<DatPhong> dp = DatPhongDAO.Instance.TimPhongDat(key);
            foreach (DatPhong dp2 in dp)
            {
                UCTimDonDat ucPhong = new UCTimDonDat();
                ucPhong.lblIDDat.Text = dp2.DatPhongID;
                listucPhong.Add(ucPhong);
            }
            return listucPhong;
        }
    }
}
