using BUS;
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

namespace CF36
{
    public partial class SuaMaGiamGiaMua1Tang1 : Form
    {
        public SuaMaGiamGiaMua1Tang1()
        {
            InitializeComponent();
        }
        private int mavc;

        public SuaMaGiamGiaMua1Tang1(int mavc)
        {
            InitializeComponent();
            this.mavc = mavc;
        }
        private void LoadSanPhamTang()
        {
            dgvSanPhamTang.DataSource = Voucher1tang1BUS.Instance.TimSanPhamTang("");
        }
        private void LoadLoaiMaGiamGia1Tang1()
        {
            cbbLoaiMaGiamGia.Items.Clear();
            cbbLoaiMaGiamGia.Items.Add("Mua 1 tặng 1 cùng dòng"); // Maloaivc = 2
            cbbLoaiMaGiamGia.Items.Add("Mua 1 tặng 1 bất kỳ");    // Maloaivc = 4
            cbbLoaiMaGiamGia.SelectedIndex = -1;
        }
        private void LoadLoaiSanPhamMua()
        {
            var dtLoaiSP = DataProvider.Instance.ExecuteQuery("SELECT maloai, tenloai FROM LOAISP");
            cbbSanPhamMua.DataSource = dtLoaiSP;
            cbbSanPhamMua.DisplayMember = "tenloai";
            cbbSanPhamMua.ValueMember = "maloai";
            cbbSanPhamMua.SelectedIndex = -1;
        }
        private void SuaMaGiamGiaMua1Tang1_Load(object sender, EventArgs e)
        {
            LoadLoaiMaGiamGia1Tang1();
            LoadLoaiSanPhamMua();
            LoadSanPhamTang();


            // Load dữ liệu voucher
            var row = Voucher1tang1BUS.Instance.GetVoucherByID(mavc);
            if (row != null)
            {
                txtMaGiamGia.Text = row["Code"].ToString();
                txtTenMaGiamGia.Text = row["Code"].ToString();
                txtHoaDonToiThieu.Text = row["DieuKien"].ToString();
                cbbSanPhamMua.SelectedValue = Convert.ToInt32(row["maloai"]);

                int loaiVC = Convert.ToInt32(row["Maloaivc"]);
                cbbLoaiMaGiamGia.SelectedIndex = (loaiVC == 2) ? 0 : 1;
                dgvSanPhamTang.Enabled = (loaiVC == 4);

                // Nếu là loại 4 thì load sản phẩm tặng đã chọn
                if (loaiVC == 4)
                {
                    var dsTang = Voucher1tang1BUS.Instance.GetSanPhamTangByVoucher(mavc);
                    foreach (DataGridViewRow r in dgvSanPhamTang.Rows)
                    {
                        string masp = r.Cells["masp"].Value?.ToString() ?? "";
                        string kichco = r.Cells["kichco"].Value?.ToString() ?? "";

                        foreach (DataRow d in dsTang.Rows)
                        {
                            if (d["masp"].ToString() == masp && d["kichco"].ToString() == kichco)
                            {
                                r.Selected = true;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã giảm giá cần sửa.");
                this.Close();
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string code = txtMaGiamGia.Text.Trim();
            string ten = txtTenMaGiamGia.Text.Trim();
            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã và tên mã giảm giá.");
                return;
            }

            if (cbbLoaiMaGiamGia.SelectedIndex == -1 || cbbSanPhamMua.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại mã và loại sản phẩm mua.");
                return;
            }

            int loaiVC = cbbLoaiMaGiamGia.SelectedIndex == 0 ? 2 : 4;
            int maloai = Convert.ToInt32(cbbSanPhamMua.SelectedValue);

            if (!decimal.TryParse(txtHoaDonToiThieu.Text.Trim(), out decimal dieuKien))
            {
                MessageBox.Show("Giá trị hóa đơn tối thiểu không hợp lệ.");
                return;
            }

            List<(string masp, string kichco)> dsTang = new List<(string, string)>();
            if (loaiVC == 4)
            {
                foreach (DataGridViewRow row in dgvSanPhamTang.SelectedRows)
                {
                    string masp = row.Cells["masp"].Value.ToString();
                    string kichco = row.Cells["kichco"].Value.ToString();
                    dsTang.Add((masp, kichco));
                }

                if (dsTang.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm tặng.");
                    return;
                }
            }

            try
            {
                bool ok = Voucher1tang1BUS.Instance.SuaVoucher(mavc, code, loaiVC, maloai, dieuKien, dsTang);
                MessageBox.Show(ok ? "Cập nhật mã giảm giá thành công!" : "Cập nhật thất bại!");
                if (ok) this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void cbbLoaiMaGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSanPhamTang.Enabled = (cbbLoaiMaGiamGia.SelectedIndex == 1); // chỉ bật khi là loại 4

        }
    }
}
