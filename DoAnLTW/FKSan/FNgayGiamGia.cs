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

namespace DoAnLTW.FKSan
{
    public partial class FNgayGiamGia : Form
    {
        public FNgayGiamGia()
        {
            InitializeComponent();
        }
        public void LayTTGiamGia()
        {
            dtGiamGia.DataSource = null;
            dtGiamGia.DataSource = GiamGiaDAO.Instance.LayGGTheoP(BienDungChung.PhongChon.PhongID, BienDungChung.KhachSan.KhachSanID);
            dtGiamGia.Columns["KhachSanID"].Visible = false;
            dtGiamGia.Columns["GiamGiaID"].Visible = false;
        }
        private void FNgayGiamGia_Load(object sender, EventArgs e)
        {
            LayTTGiamGia();
        }
    }
}
