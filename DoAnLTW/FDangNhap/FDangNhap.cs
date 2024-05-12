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
using DoAnLTW.Admin;

namespace DoAnLTW
{
    public partial class FDangNhap : Form
    {
        public FDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDN = txtTenDN.Text;
                string matKhauNhap = txtMatKhau.Text;
                if (rbAdmin.Checked && tenDN == "admin" && matKhauNhap == "admin")
                {
                    FAdmin fadmin = new FAdmin();
                    fadmin.Show();
                    this.Hide();
                    return;
                }

                (string matKhauThat, string KhachSanID) = NguoiDungDAO.Instance.LayMatKhau(tenDN);

                if (matKhauThat == "")
                {
                    MessageBox.Show("Tên đăng nhập không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                };

                if (rbNguoiDung.Checked && KhachSanID == "" && matKhauNhap == matKhauThat)
                {
                    BienDungChung.NguoiDung = NguoiDungDAO.Instance.LayThongTinTheoTenDN(tenDN);
                    FTrangChu ftrangchu = new FTrangChu();
                    ftrangchu.Show();
                    this.Hide();
                }
                else if (rbKhachSan.Checked && KhachSanID != "" && matKhauNhap == matKhauThat)
                {
                    BienDungChung.NguoiDung = NguoiDungDAO.Instance.LayThongTinTheoTenDN(tenDN);
                    FChuKhachSan ftrangchu = new FChuKhachSan();
                    ftrangchu.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Mật khẩu hoặc tên đăng nhập đã nhập sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            if (rbNguoiDung.Checked)
            {
                FTaoTaiKhoanNguoiDung fKH = new FTaoTaiKhoanNguoiDung();
                fKH.Show();
                this.Hide();
            }    
            if (rbKhachSan.Checked)
            {
                FTaoTaiKhoanKS fKS = new FTaoTaiKhoanKS();
                fKS.Show();
                this.Hide();
            }
        }

        private void FDangNhap_Load(object sender, EventArgs e)
        {
            txtTenDN.Focus();
        }
    }
}
