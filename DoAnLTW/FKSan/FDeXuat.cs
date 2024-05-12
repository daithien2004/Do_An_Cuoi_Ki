using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnLTW.DTO;
using System.Windows.Forms;
using DoAnLTW.DAL;
using DoAnLTW.FKSan;
using System.Drawing;

namespace DoAnLTW
{
    public partial class FDeXuat : Form
    {
        public FDeXuat()
        {
            InitializeComponent();
        }

        private void FDeXuat_Load(object sender, EventArgs e)
        {
            Load_DiaDiem();      
            Load_KhachSan();
        }
        private void Load_DiaDiem()
        {
            try
            {
                dtDiaDiem.DataSource = DbConnection.Instance.Load("SELECT TOP 5 KhachSan.Tinh, COUNT(DatPhong.KhachSanID) as SoLuot " +
                    "FROM DatPhong " +
                    "JOIN KhachSan ON DatPhong.KhachSanID = KhachSan.KhachSanID " +
                    "GROUP BY KhachSan.Tinh " +
                    "ORDER BY SoLuot ASC");
                if (dtDiaDiem != null)
                {
                    foreach (DataGridViewRow row in dtDiaDiem.Rows)
                    {
                        // Kiểm tra nếu hàng hiện tại không phải là hàng header hoặc mới được thêm
                        if (!row.IsNewRow)
                        {
                            string ten = row.Cells["Ten"].Value.ToString();
                            int soLuong = Convert.ToInt32(row.Cells["SoLuot"].Value);
                            UCDeXuat ucDeXuat = new UCDeXuat();
                            ucDeXuat.lblTen.Text = ten;
                            ucDeXuat.lblSoLuot.Text = soLuong.ToString() + " lượt đặt chỗ";
                            string imagePath = TinhDAO.Instance.LayTenAnh(ten);
                            if (imagePath != null)
                            {
                                Image image = ThaoTacAnh.LayAnh(imagePath);
                                ucDeXuat.pic.Image = image;
                            }                                                   
                            pnlDiemDen.Controls.Add(ucDeXuat);
                            ucDeXuat.Dock = DockStyle.Left;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Load_KhachSan()
        {
            try
            {
                dtKhachSan.DataSource = DbConnection.Instance.Load("SELECT Top 10 Q.KhachSanID, Q.TenKhachSan, Q.SoLuongDanhGia, COALESCE(T.SoLuongPhong, 0) AS SoLuongPhong " +
                     "FROM (SELECT KhachSan.KhachSanID, KhachSan.TenKhachSan, COUNT(DanhGia.KhachSanID) as SoLuongDanhGia " +
                     "FROM KhachSan LEFT JOIN DanhGia ON DanhGia.KhachSanID = KhachSan.KhachSanID " +
                     "GROUP BY KhachSan.KhachSanID, KhachSan.TenKhachSan) Q LEFT JOIN (SELECT KhachSan.KhachSanID, COUNT(DatPhong.DatPhongID) as SoLuongDat " +
                     "FROM KhachSan LEFT JOIN DatPhong ON DatPhong.KhachSanID = KhachSan.KhachSanID GROUP BY KhachSan.KhachSanID) K ON Q.KhachSanID = K.KhachSanID " +
                     "LEFT JOIN (SELECT KhachSanID, COUNT(PhongID) as SoLuongPhong FROM Phong GROUP BY KhachSanID) T ON Q.KhachSanID = T.KhachSanID " +
                     "Where SoLuongDat > 0  AND SoLuongPhong > 0" +
                     "ORDER BY K.SoLuongDat ASC, Q.SoLuongDanhGia ASC");
                if (dtKhachSan != null)
                {
                    foreach (DataGridViewRow row in dtKhachSan.Rows)
                    {
                        // Kiểm tra nếu hàng hiện tại không phải là hàng header hoặc mới được thêm
                        if (!row.IsNewRow)
                        {
                            List<Image> images = new List<Image>();
                            KhachSan ks = KhachSanDAO.Instance.LayThongTinRieng(row.Cells["KhachSanID"].Value.ToString());
                            string ten = row.Cells["TenKhachSan"].Value.ToString();
                            string[] listAnhs = ks.HinhAnh.Split(',');
                            // Thêm vào imagelist
                            foreach (string listAnh in listAnhs)
                            {
                                Image image = ThaoTacAnh.LayAnh(listAnh);
                                images.Add(image);
                            }
                            int soLuongphong = Convert.ToInt32(row.Cells["SoLuongPhong"].Value);
                            int soLuongdanhgia = Convert.ToInt32(row.Cells["SoLuongDanhGia"].Value);
                            UCDeXuat ucDeXuat = new UCDeXuat();
                            ucDeXuat.lblTen.Text = ten;
                            ucDeXuat.lblSoLuot.Text = soLuongphong.ToString() + " phòng";
                            ucDeXuat.lblLuotDanhGia.Text = soLuongdanhgia.ToString() + " lượt đánh giá";
                            ucDeXuat.pic.Image = images[0];
                            pnlKhachSan.Controls.Add(ucDeXuat);
                            ucDeXuat.Dock = DockStyle.Left;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Load_KhachHang()
        {

        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            FTrangChu ftt = new FTrangChu();
            ftt.Show();
            this.Hide();
        }
    }
}
