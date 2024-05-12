using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Guna.UI2.WinForms;
using System.Reflection;
using DoAnLTW.DTO;

namespace DoAnLTW
{
    public class ThaoTacAnh
    {
        public static Image LayAnh(string fileName)
        {
            Image image = null;
            string destinationPath = "";
            string pathImage = Path.Combine(pathPro(), "Resources");
            try
            {
                if (fileName.Contains(","))
                {
                    string[] stringArray = fileName.Split(',');
                    destinationPath = Path.Combine(pathImage, stringArray[0]);
                }
                else
                {
                    destinationPath = Path.Combine(pathImage, fileName);
                }
                image = Image.FromFile(destinationPath);
                return image;
            }
            catch
            {
                return null;
            }
        }
        public static string ThemAnh()
        {
            string fileAnh = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.bmp) | *.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> filePaths = new List<string>(openFileDialog.FileNames);

                string pathImage = Path.Combine(pathPro(), "Resources");

                foreach (string filePath in filePaths)
                {
                    // Kiểm tra xem đường dẫn nguồn có tồn tại không.
                    if (File.Exists(filePath))
                    {
                        // Lấy tên của tệp
                        string fileName = Path.GetFileName(filePath);

                        // Kết hợp đường dẫn của thư mục đích với tên tệp.
                        string fileInImage = Path.Combine(pathImage, fileName);

                        // Sao chép tệp từ đường dẫn nguồn đến đường dẫn đích.
                        if (!File.Exists(fileInImage))
                            File.Copy(filePath, fileInImage, true);

                        fileAnh += fileName + ",";
                    }
                    else
                    {
                        MessageBox.Show("Đường dẫn nguồn không tồn tại: " + filePath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("Thêm ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Xóa dấu phẩy cuối cùng nếu có
                if (!string.IsNullOrEmpty(fileAnh))
                {
                    fileAnh = fileAnh.Remove(fileAnh.Length - 1);
                }
            }
            return fileAnh;
        }
        public static List<Image> TachAnh(string danhSachAnh)
        {
            List<Image> images = new List<Image>();
            string[] fileArray = danhSachAnh.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string pathImage = Path.Combine(pathPro(), "Resources");
            foreach (string fileName in fileArray)
            {
                string destinationPath = Path.Combine(pathImage, fileName);
                Image image = Image.FromFile(destinationPath);
                images.Add(image);
            }
            return images;
        }
        public static string pathPro()
        {
            try
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
            catch (Exception ex)
            {
                MessageDialog.Show("Đã có lỗi! " + ex.Message);
                return null;
            }
        }
        public static Image ThemMotAnh(ref string fileName)
        {
            // Mở hộp thoại chọn tập tin nguồn
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tập tin ảnh (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn tập tin nguồn đã chọn
                string sourceFilePath = openFileDialog.FileName;
                fileName = Path.GetFileName(openFileDialog.FileNames[0]);

                // Lấy đường dẫn thư mục đích từ thư mục resource của dự án
                string currentDirectory = Directory.GetCurrentDirectory();
                string grandparentDirectory = Directory.GetParent(Directory.GetParent(currentDirectory)?.FullName)?.FullName;
                string destinationFolder = Path.Combine(grandparentDirectory, "Resources");

                // Tạo đường dẫn đến tập tin đích
                string destinationPath = Path.Combine(destinationFolder, fileName);
                // Copy tập tin nguồn vào thư mục đích
                if (!File.Exists(destinationPath))
                {
                    File.Copy(sourceFilePath, destinationPath);
                }
                // Lấy hình ảnh từ tài nguyên
                Image image = Image.FromFile(destinationPath);
                // Gán hình ảnh vào PictureBox
                return image;                
            }
            return null;
        }
    }
}
