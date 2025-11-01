using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using BUS;
namespace CF36
{
    public partial class XemSanPhamNhanVien : Form
    {
        private DataTable dtSanPham;

        public XemSanPhamNhanVien()
        {
            InitializeComponent();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dtSanPham != null)
            {
                string keyword = txtTimKiem.Text.Trim();
                dtSanPham.DefaultView.RowFilter = $"[Tên sản phẩm] LIKE '%{keyword}%' OR [Mã sản phẩm] LIKE '%{keyword}%'";
            }

        }

        private void XemSanPhamNhanVien_Load(object sender, EventArgs e)
        {
            dtSanPham = DanhSachSanPhamBUS.Instance.GetSanPhamWithVoucher();
            dgvSanPham.DataSource = dtSanPham;

            if (dgvSanPham.Columns.Contains("Giá bán"))
            {
                dgvSanPham.Columns["Giá bán"].DefaultCellStyle.Format = "N0";
                dgvSanPham.Columns["Giá bán"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvSanPham.Columns.Contains("Voucher liên quan"))
            {
                dgvSanPham.Columns["Voucher liên quan"].DefaultCellStyle.ForeColor = Color.DarkGreen;
            }
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
            UIText.ApplyButtonTextStyle(this);
            UIDataGridView.FormatDataGridView(dgvSanPham);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlpTimKiem_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
