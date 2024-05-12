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
    public class DanhGiaDAO
    {
        private static DanhGiaDAO instance;

        public static DanhGiaDAO Instance
        {
            get
            {
                if (instance == null) instance = new DanhGiaDAO();
                return instance;
            }
            set => instance = value;
        }
        private DanhGiaDAO() {}
        public string LayIDTiepTheo(string iDKS)
        {
            DbConnection.Instance.OpenConnection();
            string sqlStr = $"SELECT DanhGiaID FROM DanhGia Where KhachSanID = '{iDKS}'";
            DataTable table = DbConnection.Instance.Load(sqlStr);
            int id, max = 0;
            foreach (DataRow row in table.Rows)
            {
                id = Convert.ToInt32(row[0].ToString().Substring(2));
                if (id > max)
                    max = id;
            }
            DbConnection.Instance.CloseConnection();
            return "DG" + (max + 1).ToString();
        }
        public bool DanhGia(DanhGia dg)
        {
            string SQL = string.Format("INSERT INTO DanhGia(DanhGiaID , KhachSanID, PhongID, NguoiDungID, Sao, NoiDung, Ngay) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', N'{5}', N'{6}')"
                    , dg.DanhGiaID, dg.KhachSanID, dg.PhongID, dg.NguoiDungID, dg.Sao, dg.NoiDung, dg.Ngay);
            return DbConnection.Instance.ThucThi(SQL);
        }
        public List<DanhGia> LayThongTinTheoIDKS(string idKS)
        {
            DbConnection.Instance.OpenConnection();
            string query = "SELECT DanhGiaID , KhachSanID, PhongID, NguoiDungID, Sao, NoiDung, Ngay FROM DanhGia Where KhachSanID = @Id";

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@Id", idKS);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<DanhGia> results = new List<DanhGia>();

                    while (reader.Read())
                    {
                        DanhGia dg = new DanhGia(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                            reader.GetInt32(4), reader.GetString(5), reader.GetDateTime(6));
                        results.Add(dg);
                    }
                    DbConnection.Instance.CloseConnection();
                    return results;
                }
            }
        }
    }
}
