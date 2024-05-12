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

namespace DoAnLTW
{
    public partial class UCDonDatPhong : UserControl
    {
        public UCDonDatPhong()
        {
            InitializeComponent();
        }
        private void UCDonDatPhong_Load(object sender, EventArgs e)
        {

        }
        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            BienDungChung.PhongDat = DatPhongDAO.Instance.LayThongTinRieng(this.lblIDdat.Text, this.lblIDKS.Text);
            FChinhSuaPhong fSuaThongTinDat = new FChinhSuaPhong();
            fSuaThongTinDat.FormClosed += UCDonDatPhong_Load;
            fSuaThongTinDat.ShowDialog();
        }

        private void btnĐanhGia_Click(object sender, EventArgs e)
        {
            BienDungChung.PhongDat = DatPhongDAO.Instance.LayThongTinRieng(this.lblIDdat.Text, this.lblIDKS.Text);
            FDanhGia fdanhgia = new FDanhGia();
            fdanhgia.ShowDialog();
        }        
    }
}
