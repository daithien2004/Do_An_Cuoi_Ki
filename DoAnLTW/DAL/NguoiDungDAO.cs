using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;
using DoAnLTW.DTO;

namespace DoAnLTW.DAL
{
    public class NguoiDungDAO
    {
        private static NguoiDungDAO instance;

        public static NguoiDungDAO Instance
        {
            get
            {
                if (instance == null) instance = new NguoiDungDAO();
                return instance;
            }
            private set => instance = value;
        }
        private NguoiDungDAO() { }
        public (string, string) LayMatKhau(string tenDangNhap)
        {
            string query = $"SELECT MatKhau, KhachSanID FROM NguoiDung Where TenDangNhap = '{tenDangNhap}'";
            DataTable table = DbConnection.Instance.Load(query);
            if (table.Rows.Count == 1)
            {
                return (table.Rows[0][0]?.ToString() ?? "", table.Rows[0][1]?.ToString() ?? "");
            }
            return (string.Empty, string.Empty);
        }
        public string LayIDTiepTheo()
        {
            DbConnection.Instance.OpenConnection();
            string sqlStr = "SELECT NguoiDungID FROM NguoiDung";
            DataTable table = DbConnection.Instance.Load(sqlStr);
            int id, max = 0;
            foreach (DataRow row in table.Rows)
            {
                id = Convert.ToInt32(row[0].ToString().Substring(2));
                if (id > max)
                    max = id;
            }
            DbConnection.Instance.CloseConnection();
            return "ND" + (max + 1).ToString();
        }
        public bool Them(NguoiDung NguoiDungNew)
        {
            DbConnection.Instance.OpenConnection();
            string sqlStr = "INSERT INTO NguoiDung (NguoiDungID, HoTen, Cmnd, NgaySinh, GioiTinh, DiaChi, DienThoai, Email, TenDangNhap, MatKhau, HinhAnh, KhachSanID) VALUES (@NguoiDungID, @HoTen, @Cmnd, @NgaySinh, @GioiTinh, @DiaChi, @DienThoai, @Email, @TenDangNhap, @MatKhau, @HinhAnh, @KhachSanID)";

            SqlCommand command = new SqlCommand(sqlStr, DbConnection.Instance.conn);
            command.Parameters.AddWithValue("@NguoiDungID", NguoiDungNew.Nguoidungid);
            command.Parameters.AddWithValue("@HoTen", NguoiDungNew.Hoten);
            command.Parameters.AddWithValue("@Cmnd", NguoiDungNew.Cmnd);
            command.Parameters.AddWithValue("@NgaySinh", NguoiDungNew.Ngaysinh);
            command.Parameters.AddWithValue("@GioiTinh", NguoiDungNew.Gioitinh);
            command.Parameters.AddWithValue("@DiaChi", NguoiDungNew.Diachi);
            command.Parameters.AddWithValue("@DienThoai", NguoiDungNew.Dienthoai);
            command.Parameters.AddWithValue("@Email", NguoiDungNew.Email);
            command.Parameters.AddWithValue("@TenDangNhap", NguoiDungNew.Tendangnhap);
            command.Parameters.AddWithValue("@MatKhau", NguoiDungNew.Matkhau);
            command.Parameters.AddWithValue("@HinhAnh", NguoiDungNew.Hinhanh);

            // Kiểm tra và truyền giá trị KhachSanID
            if (NguoiDungNew.Khachsanid == null)
            {
                command.Parameters.AddWithValue("@KhachSanID", DBNull.Value); // Truyền giá trị NULL
            }
            else
            {
                command.Parameters.AddWithValue("@KhachSanID", NguoiDungNew.Khachsanid);
            }

            int rowsAffected = command.ExecuteNonQuery();
            DbConnection.Instance.CloseConnection();

            return rowsAffected > 0; // Trả về true nếu có hàng bị ảnh hưởng, ngược lại trả về false
        }
        public bool CapNhat(NguoiDung NguoiDungNew)
        {
            string sqlStr = $"UPDATE NGUOIDUNG SET HoTen=N'{NguoiDungNew.Hoten}', Cmnd='{NguoiDungNew.Cmnd}', GioiTinh=N'{NguoiDungNew.Gioitinh}', NgaySinh='{NguoiDungNew.Ngaysinh.ToString("yyyy-MM-dd")}', " +
            $"DiaChi=N'{NguoiDungNew.Diachi}', DienThoai='{NguoiDungNew.Dienthoai}', Email='{NguoiDungNew.Email}', TenDangNhap='{NguoiDungNew.Tendangnhap}', MatKhau='{NguoiDungNew.Matkhau}', HinhAnh='{NguoiDungNew.Hinhanh}' " +
            $"WHERE NguoiDungID = '{NguoiDungNew.Nguoidungid}'";
            return DbConnection.Instance.ThucThi(sqlStr);
        }
        public NguoiDung LayThongTinRieng(string idNS)
        {
            DbConnection.Instance.OpenConnection();
            NguoiDung nd = null;
            string query = "SELECT NguoiDungID, HoTen, Cmnd, NgaySinh, GioiTinh, DiaChi, DienThoai, Email, TenDangNhap, MatKhau, HinhAnh, KhachSanID " +
                               "FROM NGUOIDUNG WHERE NguoiDungID = @Id";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@Id", idNS);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ks = reader.IsDBNull(11) ? null : reader.GetString(11);
                        nd = new NguoiDung(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3),
                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                            reader.GetString(8), reader.GetString(9), reader.GetString(10), ks);
                    }
                }
                DbConnection.Instance.CloseConnection();
                return nd;
            }
        }

        public NguoiDung LayThongTinTheoTenDN(string tendangnhap)
        {
            DbConnection.Instance.OpenConnection();
            NguoiDung nd = null;
            string query = "SELECT NguoiDungID, HoTen, Cmnd, NgaySinh, GioiTinh, DiaChi, DienThoai, Email, TenDangNhap, MatKhau, HinhAnh, KhachSanID " +
                               "FROM NGUOIDUNG WHERE TenDangNhap = @TND";
            using (SqlCommand command = new SqlCommand(query, DbConnection.Instance.conn))
            {
                command.Parameters.AddWithValue("@TND", tendangnhap);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ks = reader.IsDBNull(11) ? null : reader.GetString(11);
                        nd = new NguoiDung(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3),
                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                            reader.GetString(8), reader.GetString(9), reader.GetString(10), ks);
                    }
                }
                DbConnection.Instance.CloseConnection();
                return nd;
            }
        }
        public DataTable LayThongTinNguoiDatPhongKhachSan5Sao()
        {
            string sqlStr = "SELECT DISTINCT ND.HinhAnh, ND.HoTen, ND.Cmnd, ND.DiaChi, ND.DienThoai " +
                            "FROM NguoiDung ND INNER JOIN DatPhong DP ON ND.NguoiDungID = DP.NguoiDungID " +
                            "INNER JOIN KhachSan KS ON DP.KhachSanID = KS.KhachSanID " +
                            "WHERE KS.Sao = 5";
            return DbConnection.Instance.Load(sqlStr);
        }
        public DataTable LayThongTinChung()
        {
            string sqlStr = "SELECT HinhAnh, HoTen, Email, TenDangNhap, MatKhau, KhachSanID FROM NguoiDung ND";
            return DbConnection.Instance.Load(sqlStr);
        }
    }
}
