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

namespace DoAnLTW.Admin
{
    public partial class FKSTiemNang : Form
    {
        public FKSTiemNang()
        {
            InitializeComponent();
        }
        private void FKSTiemNang_Load(object sender, EventArgs e)
        {
            DataTable table = DbConnection.Instance.Load("SELECT NguoiDung.HinhAnh, HoTen, SoLuongDatPhong " +
                "FROM NguoiDung JOIN (SELECT NguoiDungID, COUNT(DatPhongID) AS SoLuongDatPhong " +
                "FROM DatPhong WHERE TrangThai = N'Đã Trả Phòng' GROUP BY NguoiDungID) AS Q ON NguoiDung.NguoiDungID = Q.NguoiDungID " +
                "ORDER BY Q.SoLuongDatPhong ASC");
            dtKhachHang.DataSource = table;
            dtKhachHang.Columns["HinhAnh"].Visible = false;
            SetValuesPicture();
        }
        public void SetValuesPicture()
        {
            foreach (DataGridViewRow row in dtKhachHang.Rows)
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
    }
}
