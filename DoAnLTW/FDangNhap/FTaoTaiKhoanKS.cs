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
    public partial class FTaoTaiKhoanKS : Form
    {
        string fileName = "";
        string thanhToan = "";
        public FTaoTaiKhoanKS()
        {
            InitializeComponent();
        }
        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            try
            {
                thanhToan = XuLyChuoiTienNghi.GetCheckedValuesAsString(ref clbThanhToan);

                if (NguoiDungDAO.Instance.LayMatKhau(txtTenDN.Text).Item1 != "")
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!");
                    return;
                }

                string idKS = KhachSanDAO.Instance.LayIDTiepTheo();
                KhachSan khachSan = new KhachSan(idKS, txtTenKS.Text, txtDiaChi.Text, "", cboSao.Text != "" ? int.Parse(cboSao.Text) : 0, "", "", thanhToan, cboLoai.Text, txtTinh.Text);

                string idKhach = NguoiDungDAO.Instance.LayIDTiepTheo();
                string gioiTinh = rbtNam.Checked == true ? "Nam" : "Nu";
                NguoiDung nd = new NguoiDung(idKhach, txtHovaTen.Text, txtCMND.Text, dtNgaySinh.Value, gioiTinh, txtDiaChi.Text, txtDienThoai.Text,
                    txtEmail.Text, txtTenDN.Text, txtMatKhau.Text, fileName, idKS);
                if (nd.KTraThongTin() != "Thông tin hợp lệ!")
                    MessageBox.Show(nd.KTraThongTin(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (khachSan.KTraThongTinTaoTK() != "Thông tin hợp lệ!")
                {
                    MessageBox.Show(khachSan.KTraThongTinTaoTK(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!KhachSanDAO.Instance.Them(khachSan))
                    {
                        MessageBox.Show("Thêm thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
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

        private void btnChonAnh_Click(object sender, EventArgs e)
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FDangNhap f = new FDangNhap();
            f.Show();
            this.Hide();
        }

        private void FTaoTaiKhoanKS_Load(object sender, EventArgs e)
        {
            clbThanhToan.DataSource = BienDungChung.PTTT;
        }
    }
}
