using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAO
{
    public class DangNhapNVDAO
    {
        private static DangNhapNVDAO instance;
        public static DangNhapNVDAO Instance
        {
            get { if (instance == null) instance = new DangNhapNVDAO(); return instance; }
            private set { instance = value; }
        }

        private DangNhapNVDAO() { }
        public bool Login(string username, string password)
        {
            string query = "SELECT COUNT(1) FROM NGUOIDUNG  " +
                    
                           "WHERE Tk = @Username AND Mk = @Password  " +
                           "AND Tk LIKE 'nv%'";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            int result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, parameters));
            return result == 1;
        }
        public int GetEmployeeIDByUsername(string username)
        {
            string query = @"SELECT a.Mand FROM NGUOIDUNG a 
                   
                    WHERE a.Tk = @Username 
                    AND (LOWER(a.Tk) LIKE 'nv%' OR a.Tk NOT LIKE 'admin%')";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Username", username)
            };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            if (result != null)
            {
                string mand = result.ToString();
                // Trích xuất số từ chuỗi "NV01" → "01" → 1
                string numbers = new string(mand.Where(char.IsDigit).ToArray());
                return int.TryParse(numbers, out int id) ? id : 0;
            }
            return 0;
        }
    }
}
