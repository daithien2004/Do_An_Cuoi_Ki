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
    public class TienNghiDAO
    {
        private static TienNghiDAO instance;

        public static TienNghiDAO Instance
        {
            get
            {
                if (instance == null) instance = new TienNghiDAO();
                return instance;
            }
            private set => instance = value;
        }
        private TienNghiDAO() { }
        public List<string> LayTienNghi()
        {
            DbConnection.Instance.OpenConnection();
            string query = "SELECT TenTienNghi FROM TienNghi";
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
        public List<TienNghi> LayTienNghi(string tienNghi)
        {
            DbConnection.Instance.OpenConnection();
            string[] listTienNghi = tienNghi.Split(',');
            List<TienNghi> results = new List<TienNghi>();
            foreach (string str in listTienNghi)
            {
                TienNghi tienNghiObj = new TienNghi(str, "");
                string query = $"SELECT HinhAnh FROM TienNghi WHERE TenTienNghi =N'{str}'";
                using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tienNghiObj.HinhAnh = reader.GetString(0);
                        }

                        results.Add(tienNghiObj);
                    }
                }
            }
            DbConnection.Instance.CloseConnection();
            return results;
        }
        public string LayTenAnh(string tienNghi)
        {
            DbConnection.Instance.OpenConnection();
            string tenAnh = "";
            string query = "SELECT HinhAnh FROM TienNghi WHERE TenTienNghi = @Id";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@Id", tienNghi);
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
