using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTW.DAL
{
    public class TinhDAO
    {
        private static TinhDAO instance;

        public static TinhDAO Instance
        {
            get
            {
                if (instance == null) instance = new TinhDAO();
                return instance;
            }
            private set => instance = value;
        }
        private TinhDAO() { }
        public List<string> LayTinh()
        {
            DbConnection.Instance.OpenConnection();
            string query = "SELECT TenTinh FROM Tinh";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<string> results = new List<string>();
                    while (reader.Read())
                    {
                        string value = reader.GetString(0);
                        results.Add(value);
                    }
                    DbConnection.Instance.CloseConnection();
                    return results;
                }
            }
        }
        public string LayTenAnh(string tinh)
        {
            DbConnection.Instance.OpenConnection();
            string tenAnh = "";
            string query = "SELECT HinhAnh FROM Tinh WHERE TenTinh = @Id";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@Id", tinh);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tenAnh = reader.GetString(0);
                    }
                }
            }
            DbConnection.Instance.CloseConnection();
            return tenAnh;
        }
    }
}
