using DoAnLTW.DTO;
using DoAnLTW.DAL;
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
    public partial class FDanhSachPhong : Form
    {
        public FDanhSachPhong()
        {
            InitializeComponent();
            
        }
        private void FDanhSachPhong_Load(object sender, EventArgs e)
        {
            try
            {
                dtPhong.DataSource = DbConnection.Instance.Load($"SELECT PhongID, PhanLoai, " +
                $"Gia, DienTich, NguoiLon, TreEm, GiuongLon, GiuongNho FROM PHONG WHERE KhachSanID = " +
                $"'{BienDungChung.NguoiDung.Khachsanid}'");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dtPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dtPhong.Rows[e.RowIndex];
                BienDungChung.PhongChon = PhongDAO.Instance.LayThongTinRieng(selectedRow.Cells["PhongID"].Value.ToString(), BienDungChung.NguoiDung.Khachsanid);
                FPhong fphong = new FPhong();
                fphong.btnThem.Visible = false;
                fphong.FormClosed += Dialog_FormClosed;
                fphong.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Dialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            FDanhSachPhong_Load(sender, e);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            BienDungChung.PhongChon = null;
            FPhong fphong = new FPhong();
            fphong.btnCapnhat.Visible = false;
            fphong.btnXoa.Visible = false;
            fphong.FormClosed += Dialog_FormClosed;
            fphong.ShowDialog();
        }
    }
}
