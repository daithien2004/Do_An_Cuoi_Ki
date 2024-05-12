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

namespace DoAnLTW.FQuanLyKS
{
    public partial class FThemGiamGia : Form
    {
        public FThemGiamGia()
        {
            InitializeComponent();
        }

        private void FThemGiamGia_Load(object sender, EventArgs e)
        {
            dtGiamGia.DataSource = null;
            dtGiamGia.DataSource = GiamGiaDAO.Instance.LayGGTheoKS(BienDungChung.NguoiDung.Khachsanid);
            dtGiamGia.Columns["KhachSanID"].Visible = false;
            cbPhongID.DataSource = PhongDAO.Instance.LayIDPhong(BienDungChung.NguoiDung.Khachsanid);
        }

        private void dtGiamGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try

            {
                DataGridViewRow selectedRow = dtGiamGia.Rows[e.RowIndex];
                cbPhongID.Text = selectedRow.Cells["PhongID"].Value.ToString();
                txtPhanTram.Text = selectedRow.Cells["PhanTram"].Value.ToString();
                txtIDGiam.Text = selectedRow.Cells["GiamGiaID"].Value.ToString();
                object ngayBDValue = selectedRow.Cells["ngayBD"].Value;
                object ngayKTValue = selectedRow.Cells["ngayKT"].Value;
                if ((ngayBDValue != null && DateTime.TryParse(ngayBDValue.ToString(), out DateTime bdValue)) &&
                    (ngayKTValue != null && DateTime.TryParse(ngayKTValue.ToString(), out DateTime ktValue)))
                {
                    dtNgayBD.Value = bdValue;
                    dtNgayKT.Value = ktValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        Random random = new Random();
        private void btnThemGG_Click(object sender, EventArgs e)
        {
            try
            {
                decimal phanTram;
                if (!decimal.TryParse(txtPhanTram.Text, out phanTram))
                {
                    MessageBox.Show("Phần trăm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string ggID = GiamGiaDAO.Instance.LayIDTiepTheo(BienDungChung.NguoiDung.Khachsanid);
                GiamGia gg = new GiamGia(ggID, BienDungChung.NguoiDung.Khachsanid, cbPhongID.Text, dtNgayBD.Value.Date, dtNgayKT.Value.Date.AddDays(1).AddSeconds(-1), phanTram);
                string validationResult = gg.KiemTraThongTin();
                if (validationResult == "Thông tin hợp lệ!")
                {
                    if (KiemTraDonDatTheoNgay(gg.NgayBD, gg.NgayKT, "-1"))
                    {
                    
                            if (GiamGiaDAO.Instance.Them(gg))
                            {
                                MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FThemGiamGia_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                    
                    }
                    else
                    {
                        MessageBox.Show("Giảm Giá Trong Ngày Này Đã Được Thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(validationResult, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                decimal phanTram;
                if (!decimal.TryParse(txtPhanTram.Text, out phanTram))
                {
                    MessageBox.Show("Phần trăm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                GiamGia gg = new GiamGia(txtIDGiam.Text, BienDungChung.NguoiDung.Khachsanid, cbPhongID.Text, dtNgayBD.Value.Date, dtNgayKT.Value.Date.AddDays(1).AddSeconds(-1),
                   phanTram);
                string validationResult = gg.KiemTraThongTin();
                if (validationResult == "Thông tin hợp lệ!")
                {
                    if (KiemTraDonDatTheoNgay(gg.NgayBD, gg.NgayKT, txtIDGiam.Text))
                    {
                    
                            if (GiamGiaDAO.Instance.Sua(gg))
                            {
                                MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FThemGiamGia_Load(sender, e);
                            }
                            else
                                MessageBox.Show("Sửa thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    }
                    else
                    {
                        MessageBox.Show("Giảm Giá Trong Ngày Này Đã Được Thêm Hoặc Ngày Không Hợp Lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(validationResult, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                GiamGia gg = new GiamGia(txtIDGiam.Text, BienDungChung.NguoiDung.Khachsanid, cbPhongID.Text, dtNgayBD.Value.Date, dtNgayKT.Value.Date.AddDays(1).AddSeconds(-1),
                   Convert.ToDecimal(txtPhanTram.Text));
                if (GiamGiaDAO.Instance.Xoa(gg))
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FThemGiamGia_Load(sender, e);
                }
                else
                    MessageBox.Show("Xóa thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public bool KiemTraDonDatTheoNgay(DateTime ngayDat, DateTime ngayTra, string iDGiam)
        {
            List<Tuple<string, string, DateTime, DateTime, decimal>> listNgay = GiamGiaDAO.Instance.LayNgayGiamGiaCuaPhong(iDGiam, cbPhongID.Text, BienDungChung.NguoiDung.Khachsanid);
            foreach (Tuple<string, string, DateTime, DateTime, decimal> nd in listNgay)
            {
                if ((nd.Item3 <= ngayDat && ngayDat <= nd.Item4) || (nd.Item3 <= ngayTra && ngayTra <= nd.Item4) || ngayDat <= nd.Item3 && nd.Item4 <= ngayTra)
                    return false;
            }
            return true;
        }
    }
}
