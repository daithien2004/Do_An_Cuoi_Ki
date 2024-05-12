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

namespace DoAnLTW.FQuanLyKS
{
    public partial class FLyDoHuyDon : Form
    {
        public FLyDoHuyDon()
        {
            InitializeComponent();
        }
        public void LayDH()
        {
            dtHuyDon.DataSource = null;
            dtHuyDon.DataSource = HuyPhongDAO.Instance.LayDHTheoP(BienDungChung.NguoiDung.Khachsanid);
            dtHuyDon.Columns["KhachSanID"].Visible = false;
            dtHuyDon.Columns["LyDo"].Width = 500;
        }
        private void FLyDoHuyDon_Load(object sender, EventArgs e)
        {
            LayDH();
        }
    }
}
