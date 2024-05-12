using DoAnLTW.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTW.FQuanLyKS
{
    public partial class FKhachHang : Form
    {
        public FKhachHang()
        {
            InitializeComponent();
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

        private void FKhachHang_Load(object sender, EventArgs e)
        {
            DataTable table = KhachSanDAO.Instance.LayThongTinNguoi(BienDungChung.NguoiDung.Khachsanid);
            dtKhachHang.DataSource = table;
            dtKhachHang.Columns["HinhAnh"].Visible = false;
            SetValuesPicture();
        }
    }
}
