using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAO
{
    public class DangNhapQLDAO
    {
        private static DangNhapQLDAO instance;
        public static DangNhapQLDAO Instance
        {
            get { if (instance == null) instance = new DangNhapQLDAO(); return instance; }
            private set { instance = value; }
        }
        private DangNhapQLDAO() { }
        public bool Login(string username, string password)
        {
            string query = "SELECT COUNT(1) FROM NGUOIDUNG  " +

                           "WHERE Tk = @Username AND Mk = @Password  " +
                           "AND Tk LIKE 'ad%'";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            int result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, parameters));
            return result == 1;
        }
        public string GetEmployeeIDByUsername(string username)
        {
            string query = @"
        SELECT Mand 
        FROM NGUOIDUNG 
        WHERE Tk = @Username 
        AND (LOWER(Tk) LIKE 'ad%' OR Vitri = 'Admin')";

            SqlParameter[] parameters = {
        new SqlParameter("@Username", username)
    };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return result != null ? result.ToString() : null;
        }
    }
}
