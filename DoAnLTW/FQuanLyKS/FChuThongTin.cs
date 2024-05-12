using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data.Common;
using DoAnLTW.DAL;
using System.Resources;
using DoAnLTW.DTO;
using System.Runtime.InteropServices;

namespace DoAnLTW
{
    public partial class FChuThongTin : Form
    {
        NguoiDung nd;
        string fileName = "";
        public FChuThongTin()
        {
            InitializeComponent();
        }
        public void LayThongTinND()
        {
            try
            {
                nd = NguoiDungDAO.Instance.LayThongTinRieng(BienDungChung.NguoiDung.Nguoidungid);
                txtHovaTen.Text = nd.Hoten;
                txtCMND.Text = nd.Cmnd;
                dtpNgaySinh.Value = nd.Ngaysinh;
                if (nd.Gioitinh == "Nam")
                {
                    rbtNam.Checked = true;
                }
                else
                {
                    rbtNu.Checked = true;
                }
                txtDiaChi.Text = nd.Diachi;
                txtDienThoai.Text = nd.Dienthoai;
                txtEmail.Text = nd.Email;
                txtTenDangNhap.Text = nd.Tendangnhap;
                txtMatKhau.Text = nd.Matkhau;
                // Gán hình ảnh vào PictureBox
                pbNguoiDung.Image = ThaoTacAnh.LayAnh(nd.Hinhanh);
                fileName = nd.Hinhanh;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                NguoiDung NguoiDungNew = new NguoiDung(BienDungChung.NguoiDung.Nguoidungid, txtHovaTen.Text, txtCMND.Text,
                        dtpNgaySinh.Value, GioiTinh(), txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text, txtTenDangNhap.Text, txtMatKhau.Text, fileName);
                string dk = NguoiDungNew.KTraThongTin();
                if (dk == "Thông tin hợp lệ!")
                {
                    if (NguoiDungDAO.Instance.CapNhat(NguoiDungNew))
                    {
                        MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show(dk, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            try
            {
                pbNguoiDung.Image = ThaoTacAnh.ThemMotAnh(ref fileName);
                MessageBox.Show("Thêm tập tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public string GioiTinh()
        {
            if (rbtNam.Checked)
            {
                return "Nam";
            }
            else
            {
                return "Nữ";
            }
        }
        private void FChuThongTin_Load(object sender, EventArgs e)
        {
            LayThongTinND();
        }
    }
}
