using DoAnLTW.DAL;
using DoAnLTW.DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTW
{
    public partial class FTaoTaiKhoanNguoiDung : Form
    {
        string fileName = "";
        NguoiDung nd;
        public FTaoTaiKhoanNguoiDung()
        {
            InitializeComponent();
        }
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            try
            {
                pbNguoiDung.Image = ThaoTacAnh.ThemMotAnh(ref fileName);
                MessageBox.Show("Thêm ảnh thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                (string matKhau, string idKS) = NguoiDungDAO.Instance.LayMatKhau(txtTenDN.Text);
                if (matKhau != "")
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!");
                    return;
                }
                string idKhach = NguoiDungDAO.Instance.LayIDTiepTheo();
                string gioiTinh = rbtNam.Checked == true ? "Nam" : "Nu";
                nd = new NguoiDung(idKhach, txtHovaTen.Text, txtCMND.Text, dtNgaySinh.Value, gioiTinh, txtDiaChi.Text, txtDienThoai.Text,
                    txtEmail.Text, txtTenDN.Text, txtMatKhau.Text, fileName, null);
                if (nd.KTraThongTin() != "Thông tin hợp lệ!")
                    MessageBox.Show(nd.KTraThongTin(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (NguoiDungDAO.Instance.Them(nd))
                    {
                        MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
}
        private void btnThoat_Click(object sender, EventArgs e)
        {
            FDangNhap f = new FDangNhap();
            f.Show();
            this.Hide();
        }
    }
}
