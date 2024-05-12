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

namespace DoAnLTW.Admin
{
    public partial class FDoanhThuKS : Form
    {
        public FDoanhThuKS()
        {
            InitializeComponent();
        }

        private void FDoanhThuKS_Load(object sender, EventArgs e)
        {
            Dictionary<string, decimal> hotelRevenues = KhachSanDAO.Instance.TinhDoanhThuTatCaKhachSan();

            DataTable dt = new DataTable();
            dt.Columns.Add("Tên Khách Sạn", typeof(string));
            dt.Columns.Add("Doanh Thu", typeof(decimal));

            foreach (KeyValuePair<string, decimal> entry in hotelRevenues)
            {
                dt.Rows.Add(entry.Key, entry.Value);
            }

            dtDoanhThu.DataSource = dt;

            Series series = new Series("Doanh Thu");
            series.ChartType = SeriesChartType.Column;

            foreach (KeyValuePair<string, decimal> entry in hotelRevenues)
            {
                string khachSanID = entry.Key;
                decimal revenue = entry.Value;

                series.Points.AddXY(khachSanID, revenue);
            }

            // Clear any existing series in the chart and add the new series
            chDoanhThuk.Series.Clear();
            chDoanhThuk.Series.Add(series);

            chDoanhThuk.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
            chDoanhThuk.ChartAreas[0].AxisX.Interval = 1;
            chDoanhThuk.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            chDoanhThuk.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.WordWrap;
        }
    }
}
