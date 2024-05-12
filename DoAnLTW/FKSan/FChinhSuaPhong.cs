using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnLTW.DAL;
using DoAnLTW.DTO;
using DoAnLTW.FKhach;

namespace DoAnLTW
{
    public partial class FChinhSuaPhong : Form
    {
        public FChinhSuaPhong()
        {
            InitializeComponent();
        }
        public void LayThongTin()
        {
            try
            {
                txtIDPhong.Text = BienDungChung.PhongDat.PhongID;
                txtIDKS.Text = BienDungChung.PhongDat.KhachSanID;
                txtHoVaTen.Text = BienDungChung.NguoiDung.Hoten;
                txtEmail.Text = BienDungChung.NguoiDung.Email;
                txtSoDienThoai.Text = BienDungChung.NguoiDung.Dienthoai;
                cbThanhToan.SelectedItem = BienDungChung.PhongDat.HinhThucThanhToan;
                dtNgayDat.Value = BienDungChung.PhongDat.NgayDat;
                dtNgayTra.Value = BienDungChung.PhongDat.NgayTra;
                lblGia.Text = BienDungChung.PhongDat.Gia + "";
                KhachSan ks = KhachSanDAO.Instance.LayThongTinRieng(BienDungChung.PhongDat.KhachSanID);
                string[] phanTuArray = ks.HinhThucThanhToan.Split(',');
                cbThanhToan.DataSource = phanTuArray;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                if (BienDungChung.PhongDat.TrangThai == "Đang Chờ")
                {
                    FLyDoHuyPhong fLyDoHuyPhong = new FLyDoHuyPhong();
                    fLyDoHuyPhong.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không thể hủy đơn đã trả phòng hoặc đã hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FChinhSuaPhong_Load(object sender, EventArgs e)
        {
            LayThongTin();
        }
    }
}
