using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class DangNhapNVBUS
    {

        private static DangNhapNVBUS instance;
        public static DangNhapNVBUS Instance
        {
            get { if (instance == null) instance = new DangNhapNVBUS(); return instance; }
            private set { instance = value; }
        }

        private DangNhapNVBUS() { }

        public bool Login(string username, string password)
        {
            return DangNhapNVDAO.Instance.Login(username, password);
        }

        public int GetEmployeeIDByUsername(string username)
        {
            return DangNhapNVDAO.Instance.GetEmployeeIDByUsername(username);
        }
    }
}
