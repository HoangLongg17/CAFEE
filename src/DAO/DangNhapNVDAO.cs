using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DangNhapNVDAO
    {
       
        
    
        
        public DangNhapNVDTO Dangnhap(string username)
        {
            string query = "SELECT Tk,Mk,Hoten FROM NGUOIDUNG WHERE Tk = @Tk AND Tk LIKE 'nv%'";
            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@Tk", username)
            };

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            DangNhapNVDTO user = new DangNhapNVDTO
            {
                Tk = row["Tk"].ToString(),
                Mk = row["Mk"].ToString(),
                Hoten = row["Hoten"].ToString()
            };

            return user;
        }


    }
}
