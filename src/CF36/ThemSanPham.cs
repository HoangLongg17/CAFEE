using BUS;
using DTO;
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
                return;

            try
            {
                string rootPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                string imageFolder = Path.Combine(rootPath, "images", "products");

                if (!Directory.Exists(imageFolder))
                    Directory.CreateDirectory(imageFolder);

                string extension = Path.GetExtension(selectedImagePath);
                string newFileName = maSP + extension;
                string destinationPath = Path.Combine(imageFolder, newFileName);

                File.Copy(selectedImagePath, destinationPath, true);
            }
            catch (Exception ex)
            {
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

                // Kiểm tra ảnh đã chọn chưa
                string relativeImagePath = null;
                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    string extension = Path.GetExtension(selectedImagePath);
                    string fileName = maSP + extension;
                    relativeImagePath = Path.Combine("images", "products", fileName);
                }

                // 2. Tạo DTO sản phẩm
                SanPhamDTO sp = new SanPhamDTO
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    MaLoai = maLoai,
                    DuongDanAnh = relativeImagePath
                };

                // 3. Gọi BUS để xử lý thêm sản phẩm + kích cỡ
                themSanPhamBUS.ThemSanPham(sp,
                                           cbS.Checked, txtGiaS.Text,
                                           cbM.Checked, txtGiaM.Text,
                                           cbL.Checked, txtGiaL.Text,
                                           kichCoMap);

                // 4. Lưu ảnh vào thư mục nếu có
                HandleImageUpload(maSP);

                // 5. Thông báo thành công
                MessageBox.Show("Thêm sản phẩm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh sản phẩm";
                openFileDialog.Filter = "Ảnh (*.jpg; *.jpeg; *.png; *.gif)|*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        selectedImagePath = openFileDialog.FileName;

                        // Kiểm tra kích thước file (ví dụ: không quá 5MB)
                        FileInfo fileInfo = new FileInfo(selectedImagePath);
                        if (fileInfo.Length > 5 * 1024 * 1024)
                        {
                            MessageBox.Show("Ảnh quá lớn. Vui lòng chọn ảnh dưới 5MB.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            selectedImagePath = null;
                            return;
                        }

                        // Hiển thị ảnh
                        picAnh.Image = Image.FromFile(selectedImagePath);
                        picAnh.SizeMode = PictureBoxSizeMode.Zoom;
                        picAnh.BorderStyle = BorderStyle.FixedSingle;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        selectedImagePath = null;
                    }
                }

            }
        }
    }
}
