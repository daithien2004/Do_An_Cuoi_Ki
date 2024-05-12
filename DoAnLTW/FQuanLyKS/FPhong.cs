using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using DoAnLTW.DTO;
using DoAnLTW.DAL;

namespace DoAnLTW
{
    public partial class FPhong : Form
    {
        string fileAnh = "";
        string tienNghi = "";
        private List<Image> images = new List<Image>();
        private int currentIndex = 0;
        public FPhong()
        {
            InitializeComponent();           
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            try
            {
                int gia;
                decimal dientich;
                if (int.TryParse(txtGia.Text, out gia) && decimal.TryParse(txtDienTich.Text, out dientich))
                {
                    tienNghi = XuLyChuoiTienNghi.GetCheckedValuesAsString(ref clbTienNghi);
                    string iDP = PhongDAO.Instance.LayIDTiepTheo(BienDungChung.NguoiDung.Khachsanid);
                    Phong PhongNew = new Phong(iDP, BienDungChung.NguoiDung.Khachsanid, txtMoTa.Text, txtLoaiPhong.Text, tienNghi, gia,
                        dientich, Int32.Parse(ucNguoiLon.txtDem.Text), Int32.Parse(ucTreEm.txtDem.Text),
                        Int32.Parse(ucGiuongLon.txtDem.Text), Int32.Parse(ucGiuongNho.txtDem.Text), fileAnh);
                    string validationResult = PhongNew.KTraThongTin();
                    if (validationResult == "Thông tin hợp lệ!")
                    {
                        if (PhongDAO.Instance.Them(PhongNew))
                        {
                            MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(validationResult, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Giá hoặc diện tích không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi " + ex.Message + "hoặc không thể thêm 2 ID phòng giống nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {                  
            try
            {
                if (PhongDAO.Instance.Xoa(txtIDPhong.Text, BienDungChung.NguoiDung.Khachsanid))
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Xóa thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi" + ex.Message + " hoặc phòng đang được đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                int gia;
                decimal dientich;
                if (int.TryParse(txtGia.Text, out gia) && decimal.TryParse(txtDienTich.Text, out dientich))
                {
                    tienNghi = XuLyChuoiTienNghi.GetCheckedValuesAsString(ref clbTienNghi);
                    Phong PhongNew = new Phong(txtIDPhong.Text, BienDungChung.NguoiDung.Khachsanid, txtMoTa.Text, txtLoaiPhong.Text, tienNghi, Int32.Parse(txtGia.Text),
                             Decimal.Parse(txtDienTich.Text), Int32.Parse(ucNguoiLon.txtDem.Text),
                             Int32.Parse(ucTreEm.txtDem.Text), Int32.Parse(ucGiuongLon.txtDem.Text), Int32.Parse(ucGiuongNho.txtDem.Text), fileAnh);
                    string validationResult = PhongNew.KTraThongTin();
                    if (validationResult == "Thông tin hợp lệ!")
                    {
                        if (PhongDAO.Instance.CapNhat(PhongNew))
                        {
                            MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(validationResult, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Giá hoặc diện tích không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                fileAnh = ThaoTacAnh.ThemAnh();
                images = ThaoTacAnh.TachAnh(fileAnh);
                HienThiAnh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        private void HienThiAnh()
        {
            pbAnh.Image = images[currentIndex];
        }         

        private void FPhong_Load(object sender, EventArgs e)
        {
            bool check = false;
            try
            {
                if (BienDungChung.PhongChon != null)
                {
                    txtIDPhong.ReadOnly = true;
                    txtIDPhong.Text = BienDungChung.PhongChon.PhongID;
                    txtDienTich.Text = BienDungChung.PhongChon.DienTich.ToString();
                    txtLoaiPhong.Text = BienDungChung.PhongChon.PhanLoai;
                    txtMoTa.Text = BienDungChung.PhongChon.ThongTinChung;
                    txtGia.Text = BienDungChung.PhongChon.Gia.ToString();
                    fileAnh = BienDungChung.PhongChon.DSHinhAnh;
                    ucNguoiLon.txtDem.Text = BienDungChung.PhongChon.NguoiLon.ToString();
                    ucTreEm.txtDem.Text = BienDungChung.PhongChon.TreEm.ToString();
                    ucGiuongLon.txtDem.Text = BienDungChung.PhongChon.GiuongLon.ToString();
                    ucGiuongNho.txtDem.Text = BienDungChung.PhongChon.GiuongNho.ToString();
                    tienNghi = BienDungChung.PhongChon.TienNghi;                  
                    clbTienNghi.Items.AddRange(TienNghiDAO.Instance.LayTienNghi().ToArray());
                    XuLyChuoiTienNghi.CheckItemsFromString(ref tienNghi, clbTienNghi);
                    images = ThaoTacAnh.TachAnh(BienDungChung.PhongChon.DSHinhAnh);
                    check = true;
                    if (images.Count > 0)
                        HienThiAnh();
                }
                if (check == false)                  
                    clbTienNghi.Items.AddRange(TienNghiDAO.Instance.LayTienNghi().ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
