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
    public class HuyPhongDAO
    {
        private static HuyPhongDAO instance;

        public static HuyPhongDAO Instance
        {
            get
            {
                if (instance == null) instance = new HuyPhongDAO();
                return instance;
            }
            private set => instance = value;
        }
        private HuyPhongDAO() { }
        public List<HuyPhong> LayDHTheoP(string idKS)
        {
            DbConnection.Instance.OpenConnection();
            string query = "SELECT LyDo, DatPhongID, KhachSanID, ThoiGian FROM HuyPhong WHERE KhachSanID = @IdKS";

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@IdKS", idKS);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<HuyPhong> results = new List<HuyPhong>();

                    while (reader.Read())
                    {
                        HuyPhong hp = new HuyPhong(reader.GetString(0),
                            reader.GetString(1), reader.GetString(2), reader.GetDateTime(3));
                        results.Add(hp);
                    }
                    DbConnection.Instance.CloseConnection();
                    return results;
                }
            }
        }
    }
}
