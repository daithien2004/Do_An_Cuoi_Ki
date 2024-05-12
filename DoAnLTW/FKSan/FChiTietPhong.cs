using DoAnLTW.DAL;
using DoAnLTW.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTW
{
    public partial class FChiTietPhong : Form
    {
        Phong phong = null;
        string tienNghi = "";
        private List<Image> images = new List<Image>();
        private int currentIndex = 0;
        public FChiTietPhong()
        {
            
            InitializeComponent();         
        }
        private void FChiTietPhong_Load(object sender, EventArgs e)
        {
            phong = PhongDAO.Instance.LayThongTinRieng(BienDungChung.PhongChon.PhongID, BienDungChung.KhachSan.KhachSanID);
            lblLoaiPhong.Text = "Phòng " + phong.PhanLoai;
            lblDienTich.Text = "Diện tích: " + phong.DienTich.ToString() + " m2";
            lblNguoiLon.Text = phong.NguoiLon.ToString() + " người lớn";
            lblTreEm.Text = phong.TreEm.ToString() + " trẻ em";
            lblGiuongLon.Text = phong.GiuongLon.ToString() + " giường lớn";
            lblGiuongNho.Text = phong.GiuongNho.ToString() + " giường nhỏ";
            LoadTienNghi(phong.TienNghi);
            txtMoTa.Text = phong.ThongTinChung;
            lblGiaTien.Text = phong.Gia.ToString();
            images = ThaoTacAnh.TachAnh(phong.DSHinhAnh);
            if (images.Count > 0)
                HienThiAnh();
        }
        private void HienThiAnh()
        {
            pbAnh.Image = images[currentIndex];
        }
        public void LoadTienNghi(string tienNghi)
        {
            foreach (TienNghi tn in TienNghiDAO.Instance.LayTienNghi(tienNghi))
            {
                UCTienNghi uCTienNghi = new UCTienNghi();
                string imagePath = tn.HinhAnh;
                Image image = ThaoTacAnh.LayAnh(imagePath);
                uCTienNghi.pic1.Image = image;
                uCTienNghi.lblTienNghi.Text = tn.TenTienNghi;
                flpTienNghi.Controls.Add(uCTienNghi);
                uCTienNghi.Dock = DockStyle.Top;
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
    }
}
