using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTW.DAL
{
    public class DbConnection
    {
        private static DbConnection instance;

        public static DbConnection Instance
        {
            get
            {
                if (instance == null) instance = new DbConnection();
                return instance;
            }
            private set => instance = value;
        }
        private DbConnection() { }

        public SqlConnection conn = null;
        public void OpenConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(Properties.Settings.Default.cnnStr);
            }
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public bool ThucThi(string sqlStr)
        {
            bool thanhCong = false;
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    thanhCong = true;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return thanhCong;
        }
        public DataTable Load(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                string sqlStr = string.Format(query);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
    }
}
