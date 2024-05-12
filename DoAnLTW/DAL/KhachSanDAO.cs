using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using DoAnLTW.DTO;

namespace DoAnLTW.DAL
{
    public class KhachSanDAO
    {
        private static KhachSanDAO instance;

        public static KhachSanDAO Instance
        {
            get
            {
                if (instance == null) instance = new KhachSanDAO();
                return instance;
            }
            private set => instance = value;
        }
        private KhachSanDAO() { }
        public List<int> TinhDonDat(string iDKS)
        {
            List<int> list = new List<int>();
            string sql = $"SELECT\r\n\t SUM(CASE WHEN TrangThai = N'Đã Hủy' THEN 1 ELSE 0 END) AS DaHuy,\r\n\t SUM(CASE WHEN TrangThai = N'Đang Chờ' THEN 1 ELSE 0 END) AS DangCho,\r\n\t SUM(CASE WHEN TrangThai = N'Đã Trả Phòng' THEN 1 ELSE 0 END) AS DaTra\r\n" +
                             $"FROM DatPhong\r\nWHERE KhachSanID = '{iDKS}' AND CONVERT(DATE, NgayTaoDon) = CONVERT(DATE, GETDATE());";
            DataTable table = DbConnection.Instance.Load(sql);

            DataRow row = table.Rows[0];
            foreach (var item in row.ItemArray)
            {
                try
                {
                    list.Add(Convert.ToInt32(item));
                }
                catch
                {
                    continue;
                }
            }
            return list;
        }
        public int TongSoPhong(string iDKS)
        {
            string sql = $"SELECT count(*)\r\nFROM Phong\r\nWHERE Phong.KhachSanID = N'{iDKS}'";
            DataTable table = DbConnection.Instance.Load(sql);
            DataRow dataRow = table.Rows[0];

            return Convert.ToInt32(dataRow[0]);
        }
        public int SoPhongCoKhach()
        {
            string sql = $"SELECT COUNT(*)\r\n" +
                "FROM DatPhong\r\n" +
                $"WHERE DatPhong.KhachSanID = '{BienDungChung.NguoiDung.Khachsanid}' and TrangThai = N'Đang Chờ' and" +
                      " CONVERT(DATE,NgayDat) <= CONVERT(DATE, GETDATE())and CONVERT(DATE, NgayTra) >= CONVERT(DATE, GETDATE())\r\n";
            DataTable table = DbConnection.Instance.Load(sql);
            DataRow dataRow = table.Rows[0];

            return Convert.ToInt32(dataRow[0]);
        }
        public Dictionary<string, decimal> TinhDoanhThuTheoThang(string iDKS)
        {
            Dictionary<string, decimal> doanhThu = new Dictionary<string, decimal>();
            string sql = $"select YEAR(NgayDat) nam,MONTH(NgayDat) thang, sum(Gia) tong\r\nfrom DatPhong\r\nwhere TrangThai = N'Đã Trả Phòng' and KhachSanID = '{iDKS}' \r\ngroup by YEAR(NgayDat), MONTH(NgayDat) \r\nORDER BY nam, thang" +
                "";
            DataTable table = DbConnection.Instance.Load(sql);

            foreach (DataRow row in table.Rows)
            {
                string thang = row["thang"].ToString() + "/" + row["nam"].ToString();
                decimal tong = Convert.ToDecimal(row["tong"]);
                doanhThu[thang] = tong;
            }
            return doanhThu;
        }
        public Dictionary<string, int> TinhTrangThai(string iDKS)
        {
            Dictionary<string, int> kq = new Dictionary<string, int>();
            string sql = $"select TrangThai, count(TrangThai) SoLuong\r\nfrom DatPhong\r\nwhere KhachSanID = '{iDKS}'\r\ngroup by TrangThai";
            DataTable table = DbConnection.Instance.Load(sql);

            foreach (DataRow row in table.Rows)
            {
                kq[row["TrangThai"].ToString()] = Convert.ToInt32(row["SoLuong"]);
            }
            return kq;
        }
        public Dictionary<string, int> TinhDonDatTheoThang(string iDKS)
        {
            Dictionary<string, int> soDon = new Dictionary<string, int>();
            string sql = $"select YEAR(NgayDat) nam,MONTH(NgayDat) thang, count(*) soDon\r\nfrom DatPhong \r\n where KhachSanID = '{iDKS}' group by YEAR(NgayDat), MONTH(NgayDat) ORDER BY nam, thang";
            DataTable table = DbConnection.Instance.Load(sql);

            foreach (DataRow row in table.Rows)
            {
                string thang = row["thang"].ToString() + "/" + row["nam"].ToString();
                int sl = Convert.ToInt32(row["soDon"]);
                soDon[thang] = sl;
            }
            return soDon;
        }
        public Dictionary<string, int> TinhDonHuyTheoThang(string iDKS)
        {
            Dictionary<string, int> soDon = new Dictionary<string, int>();
            string sql = $"select YEAR(NgayDat) nam,MONTH(NgayDat) thang, count(*) soDon\r\nfrom DatPhong \r\nwhere DatPhong.TrangThai = N'Đã Hủy'\r\n and KhachSanID = '{iDKS}' group by YEAR(NgayDat), MONTH(NgayDat) ORDER BY nam, thang";
            DataTable table = DbConnection.Instance.Load(sql);

            foreach (DataRow row in table.Rows)
            {
                string thang = row["thang"].ToString() + "/" + row["nam"].ToString();
                int sl = Convert.ToInt32(row["soDon"]);
                soDon[thang] = sl;
            }
            return soDon;
        }
        public Dictionary<string, int> TinhDonHoanThanhTheoThang(string iDKS)
        {
            Dictionary<string, int> soDon = new Dictionary<string, int>();
            string sql = $"select YEAR(NgayDat) nam,MONTH(NgayDat) thang, count(*) soDon\r\nfrom DatPhong \r\nwhere DatPhong.TrangThai = N'Đã Trả Phòng'\r\n and KhachSanID = '{iDKS}' group by YEAR(NgayDat), MONTH(NgayDat) ORDER BY nam, thang";
            DataTable table = DbConnection.Instance.Load(sql);

            foreach (DataRow row in table.Rows)
            {
                string thang = row["thang"].ToString() + "/" + row["nam"].ToString();
                int sl = Convert.ToInt32(row["soDon"]);
                soDon[thang] = sl;
            }
            return soDon;
        }
        public DataTable LayThongTinNguoi(string KhachSanID)
        {
            string sqlStr = $"SELECT DISTINCT NguoiDung.HinhAnh, NguoiDung.HoTen, NguoiDung.Cmnd, NguoiDung.DiaChi, NguoiDung.DienThoai " +
            $"FROM DatPhong INNER JOIN NguoiDung ON DatPhong.NguoiDungID = NguoiDung.NguoiDungID " +
            $"WHERE DatPhong.KhachSanID = '{KhachSanID}'";
            return DbConnection.Instance.Load(sqlStr);
        }
        public DataTable LayThongTinDonDat(string KhachSanID)
        {
            string sqlStr = $"SELECT NguoiDung.HinhAnh, NguoiDung.HoTen, DatPhong.NgayDat, DatPhong.NgayTra, DatPhong.TrangThai, DatPhong.HinhThucThanhToan, DatPhong.Gia, DatPhongID, DatPhong.PhongID, DatPhong.NgayTaoDon " +
            $"FROM DatPhong INNER JOIN NguoiDung ON DatPhong.NguoiDungID = NguoiDung.NguoiDungID " +
            $"WHERE DatPhong.KhachSanID = '{KhachSanID}'";
            return DbConnection.Instance.Load(sqlStr);
        }
        public bool ThemKhachSanID(string id)
        {
            string sql = $"insert into KhachSan(KhachSanID) VALUES ('{id}')";
            return DbConnection.Instance.ThucThi(sql);
        }
        public KhachSan LayThongTinRieng(string idKS)
        {
            DbConnection.Instance.OpenConnection();
            KhachSan ks = null;
            string query = "SELECT KhachSanID, TenKhachSan, DiaChi, TongQuan, Sao, TienNghi, HinhAnh, HinhThucThanhToan, Loai, Tinh FROM KhachSan WHERE KhachSanID = @Id";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@Id", idKS);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ks = new KhachSan(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                            reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));
                    }
                }
            }
            DbConnection.Instance.CloseConnection();
            return ks;
        }
        public string LayIDTiepTheo()
        {
            DbConnection.Instance.OpenConnection();
            string sqlStr = "SELECT KhachSanID FROM KhachSan";
            DataTable table = DbConnection.Instance.Load(sqlStr);
            int id, max = 0;
            foreach (DataRow row in table.Rows)
            {
                id = Convert.ToInt32(row[0].ToString().Substring(2));
                if (id > max)
                    max = id;
            }
            DbConnection.Instance.CloseConnection();
            return "KS" + (max + 1).ToString();
        }
        public KhachSan LayThongTinTheoTinh(string tinh)
        {
            DbConnection.Instance.OpenConnection();
            KhachSan ks = null;
            string query = "SELECT KhachSanID, TenKhachSan, DiaChi, TongQuan, Sao, TienNghi, HinhAnh, HinhThucThanhToan, Loai, Tinh FROM KhachSan WHERE Tinh = @Tinh";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@Tinh", tinh);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ks = new KhachSan(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                            reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));
                    }
                }
            }
            DbConnection.Instance.CloseConnection();
            return ks;
        }

        public List<KhachSan> LayThongTinChung()
        {
            DbConnection.Instance.OpenConnection();
            string query = "SELECT KhachSanID, TenKhachSan, DiaChi, TongQuan, Sao, TienNghi, HinhAnh, HinhThucThanhToan, Loai, Tinh FROM KhachSan";
            KhachSan ks = null;
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<KhachSan> results = new List<KhachSan>();
                    while (reader.Read())
                    {                       
                        if (!reader.IsDBNull(0))
                        {
                            ks = new KhachSan(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                            reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));
                            if (ks.KTraThongTin() == "Thông tin hợp lệ!")
                                results.Add(ks);                           
                        }
                    }
                    DbConnection.Instance.CloseConnection();
                    return results;
                }
            }
        }
        public List<KhachSan> TimKS(string key)
        {
            DbConnection.Instance.OpenConnection();
            List<KhachSan> list = new List<KhachSan>();
            string query = "SELECT * FROM KhachSan Where TenKhachSan LIKE @TenKhachSan";
            SqlCommand cmd = DbConnection.Instance.conn.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@TenKhachSan", key + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            list.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    KhachSan ks = new KhachSan(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                            reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));
                    list.Add(ks);
                }
            }
            reader.Dispose();
            cmd.Dispose();
            DbConnection.Instance.CloseConnection();
            return list;
        }
        public bool CapNhat(KhachSan KhachSanNew)
        {
            string SQL = $"UPDATE KHACHSAN SET TenKhachSan=N'{KhachSanNew.TenKhachSan}', DiaChi=N'{KhachSanNew.DiaChi}', TongQuan=N'{KhachSanNew.TongQuan}', Sao={KhachSanNew.Sao}, " +
                $"TienNghi=N'{KhachSanNew.TienNghi}', HinhAnh='{KhachSanNew.HinhAnh}', HinhThucThanhToan=N'{KhachSanNew.HinhThucThanhToan}', Loai=N'{KhachSanNew.Loai}', Tinh=N'{KhachSanNew.Tinh}' WHERE KhachSanID='{KhachSanNew.KhachSanID}'";
            return DbConnection.Instance.ThucThi(SQL);
        }
        public bool Them(KhachSan ks)
        {
            string sqlStr = string.Format("INSERT INTO KhachSan (KhachSanID, TenKhachSan, DiaChi, TongQuan, Sao, TienNghi, HinhAnh, HinhThucThanhToan, Loai, Tinh) VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}')",
                ks.KhachSanID, ks.TenKhachSan, ks.DiaChi, ks.TongQuan, ks.Sao, ks.TienNghi, ks.HinhAnh, ks.HinhThucThanhToan, ks.Loai, ks.Tinh);
            return DbConnection.Instance.ThucThi(sqlStr);
        }
        public Dictionary<string, decimal> TinhDoanhThuTatCaKhachSan()
        {
            Dictionary<string, decimal> hotelRevenues = new Dictionary<string, decimal>();

            string sqlStr = "SELECT TenKhachSan, Gia FROM DatPhong " +
                "Join KhachSan On DatPhong.KhachSanID = KhachSan.KhachSanID WHERE TrangThai = N'Đã Trả Phòng'";
            DataTable table = DbConnection.Instance.Load(sqlStr);

            foreach (DataRow row in table.Rows)
            {
                string khachSanID = row["TenKhachSan"].ToString();
                decimal gia = Convert.ToDecimal(row["Gia"]);

                if (hotelRevenues.ContainsKey(khachSanID))
                {
                    hotelRevenues[khachSanID] += gia;
                }
                else
                {
                    hotelRevenues[khachSanID] = gia;
                }
            }

            return hotelRevenues;
        }
    }
}
