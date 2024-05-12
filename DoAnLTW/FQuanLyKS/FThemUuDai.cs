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
    public partial class FThemUuDai : Form
    {
        public FThemUuDai()
        {
            InitializeComponent();
        }

        private void FThemUuDai_Load(object sender, EventArgs e)
        {
            dtUuDai.DataSource = null;
            dtUuDai.DataSource = UuDaiDAO.Instance.LayUDTheoKS(BienDungChung.NguoiDung.Khachsanid);
        }

        private void dtUuDai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dtUuDai.Rows[e.RowIndex];
                txtMaUuDai.Text = selectedRow.Cells["MaUuDai"].Value.ToString();
                txtPhanTram.Text = selectedRow.Cells["PhanTram"].Value.ToString();
                object hsdValue = selectedRow.Cells["HSD"].Value;
                if (hsdValue != null && DateTime.TryParse(hsdValue.ToString(), out DateTime hsdDateTime))
                {
                    dtHSD.Value = hsdDateTime;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemUD_Click(object sender, EventArgs e)
        {
            try
            {
                decimal phanTram;
                if (!decimal.TryParse(txtPhanTram.Text, out phanTram))
                {
                    MessageBox.Show("Phần trăm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }              
                UuDai ud = new UuDai(BienDungChung.NguoiDung.Khachsanid, txtMaUuDai.Text, phanTram, dtHSD.Value.Date.AddDays(1).AddSeconds(-1));
                string validationResult = ud.KiemTraThongTin();
                if (validationResult == "Thông tin hợp lệ!")
                {
                    if (UuDaiDAO.Instance.Them(ud))
                    {
                        MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FThemUuDai_Load(sender, e);
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
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi " + ex.Message + "hoặc không thể thêm 2 mã giống nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                UuDai ud = new UuDai(BienDungChung.NguoiDung.Khachsanid, txtMaUuDai.Text, phanTram, dtHSD.Value.Date.AddDays(1).AddSeconds(-1));
                string validationResult = ud.KiemTraThongTin();
                if (validationResult == "Thông tin hợp lệ!")
                {
                    if (UuDaiDAO.Instance.Sua(ud))
                    {
                        MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FThemUuDai_Load(sender, e);
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
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                UuDai ud = new UuDai(BienDungChung.NguoiDung.Khachsanid, txtMaUuDai.Text,
                    Convert.ToDecimal(txtPhanTram.Text), dtHSD.Value.Date.AddDays(1).AddSeconds(-1));
                if (UuDaiDAO.Instance.Xoa(ud))
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FThemUuDai_Load(sender, e);
                }
                else
                    MessageBox.Show("Xóa thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
