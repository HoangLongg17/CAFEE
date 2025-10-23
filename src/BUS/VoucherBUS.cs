using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using Microsoft.Data.SqlClient;
using System.Data;
namespace BUS
{
    public class VoucherBUS
    {
        private static VoucherBUS instance;
        public static VoucherBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new VoucherBUS();
                return instance;
            }
            private set { instance = value; }
        }

        private VoucherBUS() { }

        public DataTable GetAllVouchers()
        {
            return VoucherDAO.Instance.GetAllVouchers();
        }

        public DataTable GetVouchersByType(int maloaivc)
        {
            return VoucherDAO.Instance.GetVouchersByType(maloaivc);
        }

        public VoucherDTO GetVoucherByID(int mavc)
        {
            return VoucherDAO.Instance.GetVoucherByID(mavc);
        }

        public bool AddVoucher(VoucherDTO voucher)
        {
            // Kiểm tra trùng mã
            if (VoucherDAO.Instance.CheckCodeExists(voucher.Code))
                return false;

            // Kiểm tra giá trị giảm
            if (voucher.Giatri <= 0 || voucher.Giatri > 100)
                return false;

            // Kiểm tra ngày
            if (voucher.Ngaykt < voucher.Ngaybd)
                return false;

            return VoucherDAO.Instance.AddVoucher(voucher);
        }
        public bool UpdateVoucher(VoucherDTO voucher)
        {
            return VoucherDAO.Instance.UpdateVoucher(voucher);
        }

        public int UpdateVoucherAndReturnAffectedRows(VoucherDTO voucher)
        {
            return VoucherDAO.Instance.UpdateVoucherAndReturnAffectedRows(voucher);
        }

        public bool UpdateVoucherChiTiet(int mavc, List<int> idkcspList)
        {
            return VoucherDAO.Instance.UpdateVoucherChiTiet(mavc, idkcspList);
        }

        public bool DeleteVoucher(int mavc)
        {
            return VoucherDAO.Instance.DeleteVoucher(mavc);
        }

        public bool CheckCodeExists(string code, int? excludeMavc = null)
        {
            return VoucherDAO.Instance.CheckCodeExists(code, excludeMavc);
        }

        public DataTable GetVouchersByDateRange(DateTime from, DateTime to)
        {
            return VoucherDAO.Instance.GetVouchersByDateRange(from, to);
        }

        public DataTable GetVoucherTypes()
        {
            return VoucherDAO.Instance.GetVoucherTypes();
        }
        public bool AddVoucherChiTiet(int mavc, int idkcsp)
        {
            return VoucherDAO.Instance.AddVoucherChiTiet(mavc, idkcsp);
        }
        public int AddVoucherAndGetID(VoucherDTO voucher)
        {
            return VoucherDAO.Instance.AddVoucherAndReturnID(voucher);
        }
        public DataTable GetAllVouchersWithJoin()
        {
            return VoucherDAO.Instance.GetAllVouchersWithJoin();
        }
    }
}
