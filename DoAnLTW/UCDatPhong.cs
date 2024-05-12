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
    public partial class UCDatPhong : UserControl
    {
        public UCDatPhong()
        {
            InitializeComponent();
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            FDatPhong fDatPhong = new FDatPhong();
            fDatPhong.ShowDialog();
        }
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            BienDungChung.PhongChon = PhongDAO.Instance.LayThongTinRieng(this.lblIDPhong.Text, BienDungChung.KhachSan.KhachSanID);
            FDatPhong fDatPhong = new FDatPhong();
            fDatPhong.ShowDialog();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            BienDungChung.PhongChon = PhongDAO.Instance.LayThongTinRieng(this.lblIDPhong.Text, BienDungChung.KhachSan.KhachSanID);
            FChiTietPhong fchiTiet = new FChiTietPhong();
            fchiTiet.ShowDialog();
        }
    }
}
