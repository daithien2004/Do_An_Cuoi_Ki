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

namespace DoAnLTW.FKhach
{
    public partial class FLyDoHuyPhong : Form
    {
        public FLyDoHuyPhong()
        {
            InitializeComponent();
        }
        private void btnXacNhanHuy_Click(object sender, EventArgs e)
        {
            try
            {
                HuyPhong hp = new HuyPhong(txtLyDo.Text, BienDungChung.PhongDat.DatPhongID, BienDungChung.PhongDat.KhachSanID, DateTime.Now);
                if (hp.KiemTraThongTin() == "Thông tin hợp lệ!")
                {
                    if (DatPhongDAO.Instance.Huy(hp)) 
                    {
                        MessageBox.Show("Hủy phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BienDungChung.PhongDat = null;
                        this.Close();
                    }
                    else
                        MessageBox.Show("Hủy phòng thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(hp.KiemTraThongTin(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Close();
        }
    }
}
