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
    public partial class FDanhGia : Form
    {
        Random random = new Random();
        public FDanhGia()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (BienDungChung.PhongDat.TrangThai == "Đã Trả Phòng")
                {
                    KhachSan ks = KhachSanDAO.Instance.LayThongTinRieng(BienDungChung.PhongDat.KhachSanID);
                    string iDDG = DanhGiaDAO.Instance.LayIDTiepTheo(ks.KhachSanID);
                    DanhGia dg = new DanhGia(iDDG, BienDungChung.PhongDat.KhachSanID,
                        BienDungChung.PhongDat.PhongID, BienDungChung.NguoiDung.Nguoidungid,
                        rtDanhGia.Value, txtMoTa.Text, dtNgayDanhGia.Value);
                    string dk = dg.KiemTraThongTin();
                    if (dk == "Thông tin hợp lệ!")
                    {
                        if (DanhGiaDAO.Instance.DanhGia(dg))
                        {
                            MessageBox.Show("Đánh giá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đánh giá thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(dk, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Chỉ đơn hoàn tất mới được đánh giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FDanhGia_Load(object sender, EventArgs e)
        {
            lblTen.Text = BienDungChung.NguoiDung.Hoten;
            lblDiaChi.Text = BienDungChung.NguoiDung.Diachi;
            dtNgayDanhGia.Value = DateTime.Now;
            pbNguoiDung.Image = ThaoTacAnh.LayAnh(BienDungChung.NguoiDung.Hinhanh);
        }
    }
}
