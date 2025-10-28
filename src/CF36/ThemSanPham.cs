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
    public partial class ThemSanPham : Form
    {
        private ThemSanPhamBUS themSanPhamBUS = new ThemSanPhamBUS();
        private Dictionary<char, int> kichCoMap; // Biến lưu map S/M/L -> 1/2/3
        private string selectedImagePath = null; // Biến lưu đường dẫn ảnh đã chọn
        public ThemSanPham()
        {
            InitializeComponent();
        }

        private void ThemSanPham_Load(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
            LoadKichCoMap();
            SetupInitialState();
        }
        private void LoadLoaiSanPham()
        {
            try
            {
                cbbLoaiSanPham.DataSource = themSanPhamBUS.GetLoaiSP();
                cbbLoaiSanPham.DisplayMember = "TenLoai";
                cbbLoaiSanPham.ValueMember = "MaLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải loại sản phẩm: " + ex.Message);
            }
        }
        private void LoadKichCoMap()
        {
            try
            {
                // Lấy map S/M/L về và lưu lại
                kichCoMap = themSanPhamBUS.GetKichCoMap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải kích cỡ: " + ex.Message);
            }
        }
        // Cài đặt ban đầu: vô hiệu hóa các textbox giá
        private void SetupInitialState()
        {
            txtGiaS.Enabled = false;
            txtGiaM.Enabled = false;
            txtGiaL.Enabled = false;
        }






        private void HandleImageUpload(string maSP)
        {
            if (string.IsNullOrEmpty(selectedImagePath) || string.IsNullOrEmpty(maSP))
            {
                return; // Không có ảnh để lưu hoặc không có MaSP
            }

            try
            {
                // Lấy đường dẫn thư mục images/products (giả sử nó nằm cùng cấp với file .exe)
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                string imagesFolder = Path.Combine(projectPath, "images", "products");

                // Tạo thư mục nếu chưa có
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                // Tạo tên file mới (ví dụ: SP001.png)
                // Lấy đuôi file từ ảnh gốc
                string extension = Path.GetExtension(selectedImagePath);
                string newFileName = maSP + extension;
                string destinationPath = Path.Combine(imagesFolder, newFileName);

                // Copy và ghi đè nếu file đã tồn tại
                File.Copy(selectedImagePath, destinationPath, true);
            }
            catch (Exception ex)
            {
                // Không dừng chương trình nếu lưu ảnh lỗi, chỉ cảnh báo
                MessageBox.Show("Thêm dữ liệu thành công, nhưng lưu ảnh thất bại: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void cbS_CheckedChanged(object sender, EventArgs e)
        {
            txtGiaS.Enabled = cbS.Checked;
            if (!cbS.Checked) txtGiaS.Text = "";
        }

        private void cbM_CheckedChanged(object sender, EventArgs e)
        {
            txtGiaM.Enabled = cbM.Checked;
            if (!cbM.Checked) txtGiaM.Text = "";
        }

        private void cbL_CheckedChanged(object sender, EventArgs e)
        {
            txtGiaL.Enabled = cbL.Checked;
            if (!cbL.Checked) txtGiaL.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Thu thập dữ liệu
                string maSP = txtMaSanPham.Text.Trim();
                string tenSP = txtTenSanPham.Text.Trim();
                int maLoai = (int)cbbLoaiSanPham.SelectedValue;

                // 2. Gọi BUS để xử lý
                // Lớp BUS sẽ lo hết việc Validation và Transaction
                themSanPhamBUS.ThemSanPham(maSP, tenSP, maLoai,
                                           cbS.Checked, txtGiaS.Text,
                                           cbM.Checked, txtGiaM.Text,
                                           cbL.Checked, txtGiaL.Text,
                                           kichCoMap);

                // 3. Xử lý lưu ảnh (nếu thêm CSDL thành công)
                HandleImageUpload(maSP);

                MessageBox.Show("Thêm sản phẩm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Báo cho form cha (Quản lí sản phẩm) biết là đã thêm
                this.Close();
            }
            catch (Exception ex)
            {
                // Bắt lỗi từ BUS (lỗi validation hoặc lỗi CSDL)
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedImagePath = openFileDialog.FileName; // Lưu đường dẫn
                    picAnh.Image = Image.FromFile(selectedImagePath);
                    picAnh.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                    selectedImagePath = null;
                }
            }
        }
    }
}
