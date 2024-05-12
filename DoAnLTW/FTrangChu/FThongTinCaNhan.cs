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
    public partial class FThongTinCaNhan : Form
    {
        NguoiDung nd;
        string fileName = "";
        public FThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            FDangNhap fDangnhap = new FDangNhap();
            fDangnhap.Show();
            this.Hide();
        }

        private void btnTrangchu_Click(object sender, EventArgs e)
        {
            FTrangChu fTrangChu = new FTrangChu();
            fTrangChu.Show();
            this.Hide();
        }

        private void btnDondat_Click(object sender, EventArgs e)
        {
            FThongTinDatPhong fthongtindatphong = new FThongTinDatPhong();
            fthongtindatphong.Show();
            this.Hide();
        }

        private void btnThongTinChuKhach_Click(object sender, EventArgs e)
        {
            if (!bcCanhan.Visible) bunifuTransition1.ShowSync(bcCanhan);
            else bunifuTransition1.HideSync(bcCanhan);
        }
        public void LayThongTinND()
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

        private void FThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LayThongTinND();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
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
        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            pbNguoiDung.Image = ThaoTacAnh.ThemMotAnh(ref fileName);
            MessageBox.Show("Thêm tập tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FTrangChu ftrangChu = new FTrangChu();
            ftrangChu.Show();
            this.Hide();
        }
    }
}
