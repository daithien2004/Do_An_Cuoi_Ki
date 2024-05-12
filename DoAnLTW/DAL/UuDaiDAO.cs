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
    public class UuDaiDAO
    {
        private static UuDaiDAO instance;

        public static UuDaiDAO Instance
        {
            get
            {
                if (instance == null) instance = new UuDaiDAO();
                return instance;
            }
            private set => instance = value;
        }
        private UuDaiDAO() { }
        public bool Them(UuDai ud)
        {
            string SQL = string.Format("INSERT INTO UuDai(KhachSanID, MaUuDai, PhanTram, HSD) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}')"
                    , ud.KhachSanID, ud.MaUuDai, ud.PhanTram, ud.HSD);
            return DbConnection.Instance.ThucThi(SQL);
        }
        public bool Sua(UuDai ud)
        {
            string SQL = string.Format("UPDATE UuDai SET PhanTram = {0}, HSD = '{1}' " +
                "WHERE MaUuDai = '{2}' AND KhachSanID = '{3}'", ud.PhanTram, ud.HSD, ud.MaUuDai, ud.KhachSanID);
            return DbConnection.Instance.ThucThi(SQL);
        }
        public bool Xoa(UuDai ud)
        {
            string SQL = string.Format("DELETE FROM UuDai WHERE MaUuDai = '{0}' AND KhachSanID = '{1}'", ud.MaUuDai, ud.KhachSanID);
            return DbConnection.Instance.ThucThi(SQL);
        }
        public List<UuDai> LayUDTheoKS(string idKS)
        {
            DbConnection.Instance.OpenConnection();
            string query = "SELECT MaUuDai, PhanTram, HSD FROM UuDai WHERE KhachSanID = @Id";

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@Id", idKS);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<UuDai> results = new List<UuDai>();

                    while (reader.Read())
                    {
                        UuDai ud = new UuDai(reader.GetString(0),
                        reader.GetDecimal(1), reader.GetDateTime(2));
                        results.Add(ud);
                    }
                    DbConnection.Instance.CloseConnection();
                    return results;
                }
            }
        }
    }
}
