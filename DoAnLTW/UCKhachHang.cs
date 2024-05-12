using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTW.FQuanLyKS
{
    public partial class UCKhachHang : UserControl
    {
        public UCKhachHang(string anh, string ten, string cmnd, string dc, string sdt, string phong)
        {
            InitializeComponent();
            lblTen.Text = ten;
            lblCmnd.Text = cmnd;
            lblDiaChi.Text = dc;
            lblDienThoai.Text = sdt;
            lblPhong.Text = phong;


            string path = Path.Combine(pathPro(), $"Resources/{anh}");
            if (File.Exists(path))
            {
                pic.Image = Image.FromFile(path);
            }
            else
            {
                //MessageBox.Show("hinh anh khong ton tai");
            }

        }
        public string pathPro()
        {
            // Lấy đối tượng Assembly của assembly hiện tại
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Lấy đường dẫn đầy đủ của file thực thi (bao gồm cả tên file)
            string assemblyLocation = assembly.Location;

            // Lấy đường dẫn thư mục cha của file thực thi
            string debug = Path.GetDirectoryName(assemblyLocation);
            string bin = Path.GetDirectoryName(debug);
            string proj = Path.GetDirectoryName(bin);
            return proj;
        }
    }
}
