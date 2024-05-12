using Bunifu.UI.WinForms;
using DoAnLTW.DAL;
using DoAnLTW.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace DoAnLTW
{
    public partial class FThongTinKhachSan : Form
    {
        string filesText = "";
        string tienNghi = "";
        string thanhToan = "";
        private List<Image> images = new List<Image>();
        private int currentIndex = 0;
        KhachSan ks;
        public FThongTinKhachSan()
        {
            InitializeComponent();
        }
        public void LayThongTinKS()
        {
            try
            {
                // Lấy thông tin khách sạn
                ks = KhachSanDAO.Instance.LayThongTinRieng(BienDungChung.NguoiDung.Khachsanid);
                txtLoaiKS.Text = ks.Loai;
                txtTenKhachSan.Text = ks.TenKhachSan;
                txtDiaChi.Text = ks.DiaChi;
                txtMoTa.Text = ks.TongQuan;
                rDanhGia.Value = ks.Sao;
                tienNghi = ks.TienNghi;
                thanhToan = ks.HinhThucThanhToan;
                filesText = ks.HinhAnh;
                clbTienNghi.Items.AddRange(TienNghiDAO.Instance.LayTienNghi().ToArray());
                clbThanhToan.DataSource = BienDungChung.PTTT;
                XuLyChuoiTienNghi.CheckItemsFromString(ref thanhToan, clbThanhToan);
                XuLyChuoiTienNghi.CheckItemsFromString(ref tienNghi, clbTienNghi);
                images = ThaoTacAnh.TachAnh(ks.HinhAnh);
                if (images.Count > 0)
                    HienThiAnh();
                txtTinh.Text = ks.Tinh;
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
                tienNghi = XuLyChuoiTienNghi.GetCheckedValuesAsString(ref clbTienNghi);
                thanhToan = XuLyChuoiTienNghi.GetCheckedValuesAsString(ref clbThanhToan);
                KhachSan ks = new KhachSan(BienDungChung.NguoiDung.Khachsanid, txtTenKhachSan.Text, txtDiaChi.Text
                    , txtMoTa.Text, rDanhGia.Value, tienNghi, filesText, thanhToan, txtLoaiKS.Text, txtTinh.Text);
                string dk = ks.KTraThongTin();
                if (dk == "Thông tin hợp lệ!")
                {
                    if (KhachSanDAO.Instance.CapNhat(ks))
                    {
                        MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Sửa thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                images.Clear();
                currentIndex = 0;
                filesText = ThaoTacAnh.ThemAnh();
                images = ThaoTacAnh.TachAnh(filesText);
                HienThiAnh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void HienThiAnh()
        {
            pbAnh.Image = images[currentIndex];
        }
        private void btnChuyenTrai_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }  
            else
            {
                currentIndex = images.Count - 1;
            }
            if (images.Count > 0)
                HienThiAnh();
        }
        private void btnChuyenPhai_Click(object sender, EventArgs e)
        {
            if (currentIndex < images.Count - 1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
            if (images.Count > 0)
                HienThiAnh();
        }

        private void FThongTinKhachSan_Load(object sender, EventArgs e)
        {
            LayThongTinKS();
        }
    }
}
