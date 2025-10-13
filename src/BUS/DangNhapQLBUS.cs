using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
   public class DangNhapQLBUS
    {
        private static DangNhapQLBUS instance;
        public static DangNhapQLBUS Instance
        {
            get { if (instance == null) instance = new DangNhapQLBUS(); return instance; }
            private set { instance = value; }
        }

        private DangNhapQLBUS() { }

        public bool Login(string username, string password)
        {
            return DangNhapQLDAO.Instance.Login(username, password);
        }
        public int GetEmployeeIDByUsername(string username)
        {
            return DangNhapQLDAO.Instance.GetEmployeeIDByUsername(username);
        }
    }
}
