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

namespace DoAnLTW.FQuanLyKS
{
    public partial class FDanhSachDon : Form
    {
        public FDanhSachDon()
        {
            InitializeComponent();
        }
        public void SetValuesPicture()
        {
            foreach (DataGridViewRow row in dtDonDat.Rows)
            {
                if (row.Cells["HinhAnh"].Value != null)
                {
                    // Lấy đường dẫn đến hình ảnh từ cột "ImagePath" (giả sử)
                    string fileAnh = row.Cells["HinhAnh"].Value.ToString();

                    // Tạo một đối tượng hình ảnh từ đường dẫn
                    Image image = ThaoTacAnh.LayAnh(fileAnh);

                    // Gán hình ảnh vào cột kiểu hình ảnh
                    row.Cells["Anh"].Value = image;
                }
            }
        }
        bool columnSizesAdjusted = false;
        public void LayThongTin()
        {
            if (!columnSizesAdjusted)
            {
                dtDonDat.Columns["HoTen"].Width = 120;
                dtDonDat.Columns["TrangThai"].Width = 120;
                dtDonDat.Columns["NgayTra"].Width = 120;
                dtDonDat.Columns["HinhAnh"].Visible = false;
                columnSizesAdjusted = true;
            }
            SetValuesPicture();
            if (dtDonDat.Columns.Contains("btnXacNhan") == false)
            {
                DataGridViewButtonColumn buttonColumnXN = new DataGridViewButtonColumn
                {
                    Name = "btnXacNhan",
                    HeaderText = "Button Column",
                    Text = "✓",                  
                    UseColumnTextForButtonValue = true,
                    Width = 30,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None

                };
                DataGridViewButtonColumn buttonColumnHuy = new DataGridViewButtonColumn
                {
                    Name = "btnHuy",
                    HeaderText = "Button Column",
                    Text = "✗",
                    UseColumnTextForButtonValue = true,
                    Width = 30,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };

                dtDonDat.Columns.Add(buttonColumnXN);
                dtDonDat.Columns.Add(buttonColumnHuy);
            }
        }
        private void dtDonDat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dtDonDat.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Kiểm tra tên của cột 
                int rowIndex = e.RowIndex;
                DataGridViewRow row = dtDonDat.Rows[rowIndex];

                DateTime ngayDat = (DateTime)row.Cells["NgayDat"].Value;
                DateTime ngayTra = (DateTime)row.Cells["NgayTra"].Value;
                DateTime ngayHienTai = DateTime.Now;
                
                if(row.Cells["TrangThai"].Value.ToString() == "Đang Chờ")
                {

                    if (dtDonDat.Columns[e.ColumnIndex].Name == "btnXacNhan")
                    {
                        if (ngayDat < ngayHienTai)
                        {

                            DatPhongDAO.Instance.CapNhatTrangThai(BienDungChung.NguoiDung.Khachsanid, row.Cells["DatPhongID"].Value.ToString(), "Đã Trả Phòng", DateTime.Now);
                            btnTatCa.PerformClick();
                        }
                        else
                            MessageBox.Show("Chưa tới ngày xác nhận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (dtDonDat.Columns[e.ColumnIndex].Name == "btnHuy")
                    {
                        DatPhongDAO.Instance.CapNhatTrangThai(BienDungChung.NguoiDung.Khachsanid, row.Cells["DatPhongID"].Value.ToString(), "Đã Hủy", ngayTra);
                        btnTatCa.PerformClick();
                    }

                }
                else
                   MessageBox.Show("Chỉ đơn đang chờ mới có thể thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);        
            }
        }

        private void btnDaHuy_Click(object sender, EventArgs e)
        {
            DataTable table = KhachSanDAO.Instance.LayThongTinDonDat(BienDungChung.NguoiDung.Khachsanid);

            DataRow[] filteredRows = table.Select("TrangThai = 'Đã Hủy'");

            DataTable filteredTable = table.Clone();
            foreach (DataRow row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }
            dtDonDat.DataSource = filteredTable;
            LayThongTin();
        }

        private void btnDaTra_Click(object sender, EventArgs e)
        {
            DataTable table = KhachSanDAO.Instance.LayThongTinDonDat(BienDungChung.NguoiDung.Khachsanid);

            DataRow[] filteredRows = table.Select("TrangThai = 'Đã Trả Phòng'");

            DataTable filteredTable = table.Clone();
            foreach (DataRow row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }
            dtDonDat.DataSource = filteredTable;
            LayThongTin();
        }
        private void btnTatCa_Click(object sender, EventArgs e)
        {
            DataTable table = KhachSanDAO.Instance.LayThongTinDonDat(BienDungChung.NguoiDung.Khachsanid);

            DataRow[] filteredRows = table.Select("TrangThai = 'Đã Trả Phòng' or TrangThai = 'Đã Hủy' or TrangThai = 'Đang Chờ'");

            DataTable filteredTable = table.Clone();
            foreach (DataRow row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }
            dtDonDat.DataSource = filteredTable;

            LayThongTin();
        }

        private void btnDangCho_Click(object sender, EventArgs e)
        {
            DataTable table = KhachSanDAO.Instance.LayThongTinDonDat(BienDungChung.NguoiDung.Khachsanid);

            DataRow[] filteredRows = table.Select("TrangThai = 'Đang Chờ'");

            DataTable filteredTable = table.Clone();
            foreach (DataRow row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }
            dtDonDat.DataSource = filteredTable;
            LayThongTin();
        }

        private void FDanhSachDon_Load(object sender, EventArgs e)
        {
            DataTable table = KhachSanDAO.Instance.LayThongTinDonDat(BienDungChung.NguoiDung.Khachsanid);         
            dtDonDat.DataSource = table;
            LayThongTin();
        }
    }
}
