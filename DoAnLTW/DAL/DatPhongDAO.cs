using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnLTW.DTO;
using DoAnLTW.DAL;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Net;
using System.Data;

namespace DoAnLTW.DAL
{
    public class DatPhongDAO
    {
        private static DatPhongDAO instance;

        public static DatPhongDAO Instance
        {
            get
            {
                if (instance == null) instance = new DatPhongDAO();
                return instance;
            }
            private set => instance = value;
        }
        private DatPhongDAO() { }
        public string LayIDTiepTheo(string iDKS)
        {
            DbConnection.Instance.OpenConnection();
            string sqlStr = $"SELECT DatPhongID FROM DatPhong Where KhachSanID = '{iDKS}'";
            DataTable table = DbConnection.Instance.Load(sqlStr);
            int id, max = 0;
            foreach (DataRow row in table.Rows)
            {
                id = Convert.ToInt32(row[0].ToString().Substring(2));
                if (id > max)
                    max = id;
            }
            DbConnection.Instance.CloseConnection();
            return "DP" + (max + 1).ToString();
        }
        public bool DatPhong(DatPhong dp)
        {
            string SQL = string.Format("INSERT INTO DatPhong(DatPhongID , KhachSanID, PhongID, NguoiDungID, NgayDat, NgayTra, TrangThai, HinhThucThanhToan, Gia, NgayTaoDon) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', N'{6}', N'{7}', {8}, '{9}')"
                    , dp.DatPhongID, dp.KhachSanID, dp.PhongID, dp.NguoiDungID, dp.NgayDat, dp.NgayTra, dp.TrangThai, dp.HinhThucThanhToan, dp.Gia, dp.NgayTaoDon);
            return DbConnection.Instance.ThucThi(SQL);
        }
        public bool Sua(DatPhong dp)
        {
            string SQL = string.Format("UPDATE DatPhong SET NgayDat = '{0}', NgayTra ='{1}' , HinhThucThanhToan = N'{2}' " +
                "WHERE DatPhongID = '{3}' AND KhachSanID = '{4}'", dp.NgayDat, dp.NgayTra, dp.HinhThucThanhToan, dp.DatPhongID, dp.KhachSanID);
            return DbConnection.Instance.ThucThi(SQL);
        }
        public bool Xoa(string iDDP, string iDKS)
        {
            string SQL = string.Format("DELETE FROM DatPhong WHERE DatPhongID = '{0}' AND KhachSanID = '{1}'", iDDP, iDKS);
            return DbConnection.Instance.ThucThi(SQL);
        }
        public bool Huy(HuyPhong hp)
        {
            string SQL = string.Format("UPDATE DatPhong SET TrangThai = N'{0}' WHERE DatPhongID = '{1}' AND KhachSanID = '{2}'", "Đã Hủy", hp.DatPhongID, hp.KhachSanID);
            bool kq = DbConnection.Instance.ThucThi(SQL);

            string sql2 = string.Format("INSERT INTO HuyPhong(LyDo, DatPhongID, KhachSanID, ThoiGian) VALUES (N'{0}','{1}', '{2}', '{3}')", hp.LyDo, hp.DatPhongID, hp.KhachSanID, hp.ThoiGian);
            kq = kq && DbConnection.Instance.ThucThi(sql2);
            return kq;
        }
        public List<DatPhong> TimPhongDat(string key)
        {
            DbConnection.Instance.OpenConnection();
            List<DatPhong> list = new List<DatPhong>();
            string query = "SELECT * FROM DatPhong Where DatPhongID LIKE @DatPhongID";
            SqlCommand cmd = DbConnection.Instance.conn.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@DatPhongID", key + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            list.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DatPhong dp = new DatPhong(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4),
                            reader.GetDateTime(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetDateTime(9));
                    list.Add(dp);
                }
            }
            reader.Dispose();
            cmd.Dispose();
            DbConnection.Instance.CloseConnection();
            return list;
        }
        public List<string> TimTinh(string key)
        {
            List<string> resultList = TinhDAO.Instance.LayTinh().FindAll(tinh => tinh.StartsWith(key, StringComparison.OrdinalIgnoreCase));
            return resultList;
        }
        public List<DatPhong> LayThongTinChung()
        {
            DbConnection.Instance.OpenConnection();
            string query = "SELECT DatPhongID, KhachSanID, PhongID, NguoiDungID, NgayDat, NgayTra, TrangThai, HinhThucThanhToan, Gia, NgayTaoDon FROM DatPhong";

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<DatPhong> results = new List<DatPhong>();

                    while (reader.Read())
                    {
                        DatPhong dp = new DatPhong(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4),
                            reader.GetDateTime(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetDateTime(9));
                        results.Add(dp);
                    }
                    DbConnection.Instance.CloseConnection();
                    return results;
                }
            }
        }
        public DatPhong LayThongTinRieng(string idDP, string KSId)
        {
            DbConnection.Instance.OpenConnection();
            DatPhong dp = null;
            string query = "SELECT DatPhongID, KhachSanID, PhongID, NguoiDungID, NgayDat, NgayTra, " +
                "TrangThai, HinhThucThanhToan, Gia, NgayTaoDon FROM DatPhong WHERE DatPhongID = @Id AND KhachSanID = @KSId";

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@Id", idDP);
                command.Parameters.AddWithValue("@KSId", KSId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dp = new DatPhong(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4),
                            reader.GetDateTime(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetDateTime(9));
                    }
                    DbConnection.Instance.CloseConnection();
                    return dp;
                }
            }
        }
        public List<DatPhong> LayThongTinPhong(string idP, string idKhachSan)
        {
            DbConnection.Instance.OpenConnection();
            List<DatPhong> danhSachDatPhong = new List<DatPhong>();
            string query = "SELECT DatPhongID, NgayDat, NgayTra, TrangThai FROM DatPhong WHERE PhongID = @Id AND KhachSanID = @KhachSanId";

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@Id", idP);
                command.Parameters.AddWithValue("@KhachSanId", idKhachSan);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DatPhong dp = new DatPhong(reader.GetString(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetString(3));
                        danhSachDatPhong.Add(dp);
                    }
                    DbConnection.Instance.CloseConnection();
                }
            }
            return danhSachDatPhong;
        }
        public List<Tuple<string, string>> LayIDPhong(string iD)
        {
            DbConnection.Instance.OpenConnection();
            List<Tuple<string, string>> results = new List<Tuple<string, string>>();
            string query = "SELECT DISTINCT PhongID, KhachSanID FROM DatPhong WHERE KhachSanID = @iD";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@iD", iD);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            continue;
                        }
                        Tuple<string, string> pKS = new Tuple<string, string>(reader.GetString(0), reader.GetString(1));
                        results.Add(pKS);
                    }
                    DbConnection.Instance.CloseConnection();
                }
            }
            return results;
        }
        public List<Tuple<string, string>> LayIDPhong()
        {
            DbConnection.Instance.OpenConnection();
            List<Tuple<string, string>> results = new List<Tuple<string, string>>();
            string query = "SELECT DISTINCT PhongID, KhachSanID FROM DatPhong";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            continue;
                        }
                        Tuple<string, string> pKS = new Tuple<string, string>(reader.GetString(0), reader.GetString(1));
                        results.Add(pKS);
                    }
                    DbConnection.Instance.CloseConnection();
                }
            }
            return results;
        }
        public List<Tuple<string, string, DateTime, DateTime>> LayNgayDatCuaPhong(string idPhong, string iDKS)
        {
            DbConnection.Instance.OpenConnection();
            List<Tuple<string, string, DateTime, DateTime>> listNgay = new List<Tuple<string, string, DateTime, DateTime>>();
            string query = "SELECT KhachSanID, PhongID, NgayDat, NgayTra From DatPhong Where PhongID = @iD AND KhachSanID = @iDKS AND TrangThai = @tt";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@iD", idPhong);
                command.Parameters.AddWithValue("@iDKS", iDKS);
                command.Parameters.AddWithValue("@tt", "Đang Chờ");
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            Tuple<string, string, DateTime, DateTime> dp = new Tuple<string, string, DateTime, DateTime>(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3));
                            listNgay.Add(dp);
                        }
                    }
                    DbConnection.Instance.OpenConnection();
                }
            }
            return listNgay;
        }
        public void CapNhatTrangThai(string idKS, string idDat, string trangThaiMoi, DateTime nTra)
        {
            DbConnection.Instance.OpenConnection();
            string query = "UPDATE DatPhong SET TrangThai = @trangThaiMoi, NgayTra = @nTra WHERE DatPhongID = @idDat AND KhachSanID = @idKS";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@trangThaiMoi", trangThaiMoi);
                command.Parameters.AddWithValue("@idDat", idDat);
                command.Parameters.AddWithValue("@nTra", nTra);
                command.Parameters.AddWithValue("@idKS", idKS);
                command.ExecuteNonQuery();
            }
            DbConnection.Instance.CloseConnection();
        }
    }
}
