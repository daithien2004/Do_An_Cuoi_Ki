using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnLTW.DTO;

namespace DoAnLTW.DAL
{
    public class GiamGiaDAO
    {
        private static GiamGiaDAO instance;

        public static GiamGiaDAO Instance
        {
            get
            {
                if (instance == null) instance = new GiamGiaDAO();
                return instance;
            }
            private set => instance = value;
        }
        private GiamGiaDAO() { }
        public string LayIDTiepTheo(string iDKS)
        {
            DbConnection.Instance.OpenConnection();
            string sqlStr = $"SELECT GiamGiaID FROM GiamGia Where KhachSanID = '{iDKS}'";
            DataTable table = DbConnection.Instance.Load(sqlStr);
            int id, max = 0;
            foreach (DataRow row in table.Rows)
            {
                id = Convert.ToInt32(row[0].ToString().Substring(2));
                if (id > max)
                    max = id;
            }
            DbConnection.Instance.CloseConnection();
            return "GG" + (max + 1).ToString();
        }
        public bool Them(GiamGia gg)
        {
            string SQL = string.Format("INSERT INTO GiamGia(GiamGiaID, KhachSanID, PhongID, NgayBD, NgayKT, PhanTram) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5})"
                    , gg.GiamGiaID, gg.KhachSanID, gg.PhongID, gg.NgayBD, gg.NgayKT, gg.PhanTram);
            return DbConnection.Instance.ThucThi(SQL);
        }
        public bool Sua(GiamGia gg)
        {
            string SQL = string.Format("UPDATE GiamGia SET NgayBD = '{0}', NgayKT = '{1}', PhanTram = {2} " +
                "WHERE PhongID = '{3}' AND KhachSanID = '{4}' AND GiamGiaID = '{5}'", gg.NgayBD, gg.NgayKT, gg.PhanTram, gg.PhongID, gg.KhachSanID, gg.GiamGiaID);
            return DbConnection.Instance.ThucThi(SQL);
        }
        public bool Xoa(GiamGia gg)
        {
            string SQL = string.Format("DELETE FROM GiamGia WHERE GiamGiaID = '{0}' AND KhachSanID = '{1}' AND PhongID = '{2}'", gg.GiamGiaID, gg.KhachSanID, gg.PhongID);
            return DbConnection.Instance.ThucThi(SQL);
        }
        public List<GiamGia> LayGGTheoKS(string idKS)
        {
            DbConnection.Instance.OpenConnection();
            string query = "SELECT GiamGiaID, KhachSanID, PhongID, NgayBD, NgayKT, PhanTram FROM GiamGia WHERE KhachSanID = @Id";

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@Id", idKS);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<GiamGia> results = new List<GiamGia>();

                    while (reader.Read())
                    {
                        GiamGia gg = new GiamGia(reader.GetString(0),
                            reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetDecimal(5));
                        results.Add(gg);
                    }
                    DbConnection.Instance.CloseConnection();
                    return results;
                }
            }
        }
        public List<GiamGia> LayGGTheoP(string idP, string idKS)
        {
            DbConnection.Instance.OpenConnection();
            string query = "SELECT GiamGiaID, KhachSanID, PhongID, NgayBD, NgayKT, PhanTram FROM GiamGia WHERE KhachSanID = @IdKS AND PhongID = @IdP";

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@IdP", idP);
                command.Parameters.AddWithValue("@IdKS", idKS);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<GiamGia> results = new List<GiamGia>();

                    while (reader.Read())
                    {
                        GiamGia gg = new GiamGia(reader.GetString(0),
                            reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetDecimal(5));
                        results.Add(gg);
                    }
                    DbConnection.Instance.CloseConnection();
                    return results;
                }
            }
        }
        public List<Tuple<string, string, DateTime, DateTime, decimal>> LayNgayGiamGiaCuaPhong(string iDGiam, string iDPhong, string iDKS)
        {
            DbConnection.Instance.OpenConnection();
            List<Tuple<string, string, DateTime, DateTime, decimal>> listNgay = new List<Tuple<string, string, DateTime, DateTime, decimal>>();
            string query = "SELECT GiamGiaID, PhongID, KhachSanID, NgayBD, NgayKT, PhanTram From GiamGia Where PhongID = @iDP AND KhachSanID = @iDKS";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@iDP", iDPhong);
                command.Parameters.AddWithValue("@iDKS", iDKS);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            if (reader.GetString(0) == iDGiam)
                                continue;
                            Tuple<string, string, DateTime, DateTime, decimal> dp = new Tuple<string, string, DateTime, DateTime, decimal>(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetDecimal(5));
                            listNgay.Add(dp);
                        }
                    }
                    DbConnection.Instance.OpenConnection();
                }
            }
            return listNgay;
        }
    }
}
