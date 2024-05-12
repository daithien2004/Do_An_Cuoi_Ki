using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DoAnLTW.DTO;

namespace DoAnLTW.DAL
{
    public class PhongDAO
    {
        private static PhongDAO instance;

        public static PhongDAO Instance
        {
            get
            {
                if (instance == null) instance = new PhongDAO();
                return instance;
            }
            private set => instance = value;
        }
        private PhongDAO() { }
        public string LayIDTiepTheo(string iDKS)
        {
            DbConnection.Instance.OpenConnection();
            string sqlStr = $"SELECT PhongID FROM Phong Where KhachSanID = '{iDKS}'";
            DataTable table = DbConnection.Instance.Load(sqlStr);
            int id, max = 0;
            foreach (DataRow row in table.Rows)
            {
                id = Convert.ToInt32(row[0].ToString().Substring(1));
                if (id > max)
                    max = id;
            }
            DbConnection.Instance.CloseConnection();
            return "P" + (max + 1).ToString();
        }
        public List<Phong> LayThongTinChung()
        {
            DbConnection.Instance.OpenConnection();
            string query = "SELECT PhongID, KhachSanID, ThongTinChung, PhanLoai, TienNghi, Gia, " +
                "DienTich, NguoiLon, TreEm, GiuongLon, GiuongNho, DSHinhAnh FROM Phong";

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Phong> results = new List<Phong>();

                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            Phong phong = new Phong(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                            reader.GetString(4), reader.GetInt32(5), reader.GetDecimal(6), reader.GetInt32(7), reader.GetInt32(8),
                            reader.GetInt32(9), reader.GetInt32(10), reader.GetString(11));
                            results.Add(phong);
                        }    
                    }
                    DbConnection.Instance.CloseConnection();
                    return results;
                }
            }
        }
        public List<Phong> LayPhongChuaDuocDat()
        {
            DbConnection.Instance.OpenConnection();

            string query = "SELECT p.PhongID, p.KhachSanID " +
         "FROM Phong p LEFT JOIN DatPhong dp ON p.PhongID = dp.PhongID WHERE (dp.PhongID IS NULL)";

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Phong> results = new List<Phong>();

                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            Phong p = new Phong(reader.GetString(0), reader.GetString(1));
                            results.Add(p);
                        }
                    }
                    DbConnection.Instance.CloseConnection();
                    return results;
                }
            }
        }
        public List<string> LayIDPhong(string idKS)
        {
            DbConnection.Instance.OpenConnection();
            List<string> results = new List<string>();
            string query = "SELECT PhongID FROM Phong Where KhachSanID = @iD";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@iD", idKS);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            string pKS = reader.GetString(0);
                            results.Add(pKS);
                        }
                    }
                    DbConnection.Instance.CloseConnection();
                }
            }
            return results;
        }
        public Phong LayThongTinRieng(string idPhong, string KSId)
        {
            DbConnection.Instance.OpenConnection();
            Phong p = null;
            string query = "SELECT PhongID, KhachSanID, ThongTinChung, PhanLoai, TienNghi, Gia, " +
                "DienTich, NguoiLon, TreEm, GiuongLon, GiuongNho, DSHinhAnh FROM Phong WHERE PhongID = @Id AND KhachSanID = @KSId";

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@KSId", KSId);
                command.Parameters.AddWithValue("@Id", idPhong);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        p = new Phong(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                            reader.GetString(4), reader.GetInt32(5), reader.GetDecimal(6), reader.GetInt32(7), reader.GetInt32(8),
                            reader.GetInt32(9), reader.GetInt32(10), reader.GetString(11));
                    }
                    DbConnection.Instance.CloseConnection();
                    return p;
                }
            }
        }
        public int[] LayMinMaxGia(string idKS)
        {
            int[] giatriMinMax = new int[2];
            DbConnection.Instance.OpenConnection();
            string query = "SELECT Gia FROM Phong Where KhachSanID = @Id";
            List<int> listGia = new List<int>();

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@Id", idKS);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listGia.Add(reader.GetInt32(0));
                    }
                }
            }
            listGia.Sort();
            if (listGia.Count > 0)
            {
                giatriMinMax[0] = listGia[0];
                giatriMinMax[1] = listGia[listGia.Count - 1];
            }    
            else
            {
                giatriMinMax[0] = 0;
                giatriMinMax[1] = 0;
            }
            DbConnection.Instance.CloseConnection();
            return giatriMinMax;
        }
        public List<Phong> LayPhongTheoNguoi(int nguoiLon, int treEm)
        {
            DbConnection.Instance.OpenConnection();
            string query = "SELECT DISTINCT PhongID, KhachSanID FROM Phong " +
                "WHERE NguoiLon>= @nguoiLon and TreEM >= @treEm";

            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@nguoiLon", nguoiLon);
                command.Parameters.AddWithValue("@treEm", treEm);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Phong> results = new List<Phong>();

                    while (reader.Read())
                    {
                        Phong phong = new Phong(reader.GetString(0), reader.GetString(1));
                        results.Add(phong);
                    }
                    DbConnection.Instance.CloseConnection();
                    return results;
                }
            }
        }
        public bool Them(Phong ps)
        {
            string sqlStr = string.Format("INSERT INTO PHONG(PhongID, KhachSanID, ThongTinChung, PhanLoai, TienNghi, Gia, DienTich, NguoiLon, TreEm, GiuongLon, GiuongNho, DSHinhAnh) " +
                "VALUES('{0}','{1}',N'{2}',N'{3}',N'{4}',{5},{6},{7},{8},{9},{10},'{11}')",
                ps.PhongID, ps.KhachSanID, ps.ThongTinChung, ps.PhanLoai, ps.TienNghi, ps.Gia, ps.DienTich, ps.NguoiLon, ps.TreEm, ps.GiuongLon, ps.GiuongNho, ps.DSHinhAnh);
            return DbConnection.Instance.ThucThi(sqlStr);
        }
        public bool Xoa(string idPhong, string idKS)
        {
            string sqlStr = string.Format("DELETE FROM PHONG WHERE PhongID = '{0}' AND KhachSanID = '{1}'", idPhong, idKS);
            return DbConnection.Instance.ThucThi(sqlStr);
        }
        public bool CapNhat(Phong PhongNew)
        {
            string SQL = string.Format("UPDATE PHONG SET ThongTinChung = N'{0}', PhanLoai =N'{1}' , TienNghi =N'{2}', " +
                "Gia = {3}, DienTich ={4} , NguoiLon ={5}, TreEm ={6}, GiuongLon ={7}, GiuongNho = {8}, DSHinhAnh = '{9}'" +
                   "WHERE PhongID = '{10}' AND KhachSanID = '{11}'", PhongNew.ThongTinChung, PhongNew.PhanLoai, PhongNew.TienNghi, PhongNew.Gia, PhongNew.DienTich, 
                   PhongNew.NguoiLon, PhongNew.TreEm, PhongNew.GiuongLon, PhongNew.GiuongNho, PhongNew.DSHinhAnh, PhongNew.PhongID, PhongNew.KhachSanID);
            return DbConnection.Instance.ThucThi(SQL);
        }
    }
}
