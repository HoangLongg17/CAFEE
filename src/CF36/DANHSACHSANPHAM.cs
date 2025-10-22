using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CF36
{
    public partial class DANHSACHSANPHAM : Form
    {
        private DanhSachSanPhamBUS sanPhamBUS = new DanhSachSanPhamBUS();

        // Dùng Dictionary để map tên hiển thị và giá trị thực tế cho ComboBox
        private Dictionary<string, string> searchTypes = new Dictionary<string, string>();
        public DANHSACHSANPHAM()
        {
            InitializeComponent();
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            ThemSanPham themSanPham = new ThemSanPham();
            themSanPham.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaSanPham suaSanPham = new SuaSanPham();
            suaSanPham.Show();
        }

        private void DANHSACHSANPHAM_Load(object sender, EventArgs e)
        {
            LoadSearchComboBox();
            LoadDataGrid(); // Tải tất cả sản phẩm khi form mở
            SetupDataGridView();
        }
        private void LoadSearchComboBox()
        {
            searchTypes.Add("Mã sản phẩm", "MaSP");
            searchTypes.Add("Tên sản phẩm", "TenSP");
            searchTypes.Add("Loại sản phẩm", "LoaiSP");

            cbbLoaiTimKiem.DataSource = new BindingSource(searchTypes, null);
            cbbLoaiTimKiem.DisplayMember = "Key";
            cbbLoaiTimKiem.ValueMember = "Value";
        }

        // Cấu hình hiển thị cho DataGridView
        private void SetupDataGridView()
        {
            dgvDanhSachSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachSanPham.MultiSelect = false;
            dgvDanhSachSanPham.ReadOnly = true;

            // Đặt tên cột cho thân thiện
            dgvDanhSachSanPham.Columns["ID"].HeaderText = "ID";
            dgvDanhSachSanPham.Columns["MaSP"].HeaderText = "Mã SP";
            dgvDanhSachSanPham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvDanhSachSanPham.Columns["TenLoai"].HeaderText = "Loại";
            dgvDanhSachSanPham.Columns["KichCo"].HeaderText = "Size";
            dgvDanhSachSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
            dgvDanhSachSanPham.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
            dgvDanhSachSanPham.Columns["TrangThaiText"].HeaderText = "Trạng Thái";

            // Định dạng cột tiền
            dgvDanhSachSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
        }

        // Hàm tải/tải lại dữ liệu cho DataGridView
        private void LoadDataGrid(string searchType = null, string searchTerm = null)
        {
            try
            {
                dgvDanhSachSanPham.DataSource = sanPhamBUS.SearchSanPham(searchType, searchTerm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string searchType = cbbLoaiTimKiem.SelectedValue.ToString();
            string searchTerm = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // Nếu ô tìm kiếm rỗng, tải lại tất cả
                LoadDataGrid();
            }
            else
            {
                // Nếu có chữ, bắt đầu tìm
                LoadDataGrid(searchType, searchTerm);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
