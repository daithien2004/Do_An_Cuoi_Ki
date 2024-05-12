using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DoAnLTW.DAL;

namespace DoAnLTW
{
    public partial class FChuTrangChu : Form
    {
        public FChuTrangChu()
        {
            InitializeComponent();
        }
        private void LoadDuLieu()
        {
            //hôm nay
            List<int> don = KhachSanDAO.Instance.TinhDonDat(BienDungChung.NguoiDung.Khachsanid);
            if (don.Count != 0)
            {
                lblDaHuy.Text = don[0].ToString();
                lblDangCho.Text = don[1].ToString();
                lblHoanTat.Text = don[2].ToString();
                lblDonDat.Text = don.Sum().ToString();

                int soPhong = KhachSanDAO.Instance.TongSoPhong(BienDungChung.NguoiDung.Khachsanid);
                int phongCoKhach = KhachSanDAO.Instance.SoPhongCoKhach();
                lblPhong.Text = soPhong.ToString();
                lblCoKhach.Text = phongCoKhach.ToString();
                lblPhongTrong.Text = (soPhong - phongCoKhach).ToString();

                float tiLePhongTrong = (float)phongCoKhach / soPhong * 100;
                rgTiLePhong.Value = (int)tiLePhongTrong;
            }
        }
        private void FChuTrangChu_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            VeBieuDo();
        }
        public void VeBieuDo()
        {
            Series series = new Series("Doanh thu");
            series.ChartType = SeriesChartType.Column;

            // Thêm dữ liệu từ DataTable vào chuỗi dữ liệu của biểu đồ
            Dictionary<string, decimal> doanhThu = KhachSanDAO.Instance.TinhDoanhThuTheoThang(BienDungChung.NguoiDung.Khachsanid);
            foreach (KeyValuePair<string, decimal> entry in doanhThu)
            {
                series.Points.AddXY(entry.Key, entry.Value);
            }

            chartDoanhSo.Series.Clear();
            chartDoanhSo.Series.Add(series);

            //trạng thái
            chartTrangThai.Series[0].ChartType = SeriesChartType.Pie;
            Dictionary<string, int> trangThai = KhachSanDAO.Instance.TinhTrangThai(BienDungChung.NguoiDung.Khachsanid);
            int sum = 0;
            foreach (KeyValuePair<string, int> entry in trangThai)
            {
                sum += entry.Value;
            }
            foreach (KeyValuePair<string, int> entry in trangThai)
            {
                chartTrangThai.Series[0].Points.AddXY(entry.Value.ToString(), (entry.Value / (float)sum) * 100);
                int pointIndex = chartTrangThai.Series[0].Points.Count - 1;
                chartTrangThai.Series[0].Points[pointIndex].LegendText = entry.Key;
            }
            foreach (DataPoint point in chartTrangThai.Series[0].Points)
            {
                point.IsValueShownAsLabel = false;
            }

            chart.Series.Clear();
            chart.Series.Add("TongSoDon");
            Dictionary<string, int> soDon = KhachSanDAO.Instance.TinhDonDatTheoThang(BienDungChung.NguoiDung.Khachsanid);
            foreach (var don in soDon)
            {
                chart.Series["TongSoDon"].Points.AddXY(don.Key, don.Value);
            }

            chart.Series.Add("SoDonHuy");
            Dictionary<string, int> soDonHuy = KhachSanDAO.Instance.TinhDonHuyTheoThang(BienDungChung.NguoiDung.Khachsanid);
            foreach (var don in soDonHuy)
            {
                chart.Series["SoDonHuy"].Points.AddXY(don.Key, don.Value);
            }

            chart.Series.Add("SoDonHoanThanh");
            Dictionary<string, int> soDonHoanThanh = KhachSanDAO.Instance.TinhDonHoanThanhTheoThang(BienDungChung.NguoiDung.Khachsanid);
            foreach (var don in soDonHoanThanh)
            {
                chart.Series["SoDonHoanThanh"].Points.AddXY(don.Key, don.Value);
            }

            //Đặt loại biểu đồ là spline
            for (int i = 0; i < chart.Series.Count; i++)
            {
                chart.Series[i].ChartType = SeriesChartType.Spline;
            }
        }
    }
}
