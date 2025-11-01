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
    public partial class SuaSanPham : Form
    {
        private SuaSanPhamBUS suaSanPhamBUS = new SuaSanPhamBUS();
        private Dictionary<char, int> kichCoMap;
        private string maSP; // Mã sản phẩm đang sửa
        private string selectedImagePath = null; // Đường dẫn ảnh mới (nếu có)
        public SuaSanPham(string maSP)
        {
            InitializeComponent();
            this.maSP = maSP;
        }

        private void SuaSanPham_Load(object sender, EventArgs e)
        {
            txtMa.ReadOnly = true; // Không cho sửa Mã SP
            txtMa.Text = this.maSP;

            LoadComboBoxes();
            LoadKichCoMap();
            LoadProductDetails();
            LoadProductImage();
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
            UIText.ApplyButtonTextStyle(this);
        }
        private void LoadComboBoxes()
        {
            try
            {
                cbbLoaiSanPham.DataSource = suaSanPhamBUS.GetLoaiSP();
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
                kichCoMap = suaSanPhamBUS.GetKichCoMap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải kích cỡ: " + ex.Message);
            }
        }

        // Hàm chính tải thông tin lên form
        private void LoadProductDetails()
        {
            try
            {
                SuaSanPhamLoadDTO info = suaSanPhamBUS.GetSanPhamInfo(this.maSP);
                if (info == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin sản phẩm.");
                    this.Close();
                    return;
                }

                // 1. Tải thông tin cơ bản
                txtTen.Text = info.TenSP;
                cbbLoaiSanPham.SelectedValue = info.MaLoai;

                // 2. Tải thông tin size/giá
                // Vô hiệu hóa hết textbox trước
                txtSuaGiaS.Enabled = false;
                txtSuaGiaM.Enabled = false;
                txtSuaGiaL.Enabled = false;

                // Duyệt qua danh sách size/giá đã lấy từ DB
                foreach (var item in info.DanhSachKichCo)
                {
                    if (item.KichCo == 'S')
                    {
                        cbS.Checked = true;
                        txtSuaGiaS.Enabled = true;
                        txtSuaGiaS.Text = item.GiaBan.ToString("F0"); // F0 để bỏ .00
                    }
                    else if (item.KichCo == 'M')
                    {
                        cbM.Checked = true;
                        txtSuaGiaM.Enabled = true;
                        txtSuaGiaM.Text = item.GiaBan.ToString("F0");
                    }
                    else if (item.KichCo == 'L')
                    {
                        cbL.Checked = true;
                        txtSuaGiaL.Enabled = true;
                        txtSuaGiaL.Text = item.GiaBan.ToString("F0");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết sản phẩm: " + ex.Message);
            }
        }

        // Tải ảnh (dựa trên MaSP)
        private void LoadProductImage()
        {
            try
            {
                string rootPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                string imagesFolder = Path.Combine(rootPath, "images", "products");

                string[] extensions = { ".png", ".jpg", ".jpeg", ".gif" };
                string imagePath = null;

                foreach (string ext in extensions)
                {
                    string path = Path.Combine(imagesFolder, this.maSP + ext);
                    if (File.Exists(path))
                    {
                        imagePath = path;
                        break;
                    }
                }

                if (imagePath != null)
                {
                    if (picAnhSua.Image != null)
                        picAnhSua.Image.Dispose();

                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        picAnhSua.Image = Image.FromStream(ms);
                    }
                    picAnhSua.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch { /* Bỏ qua nếu lỗi */ }
        }

        private void HandleImageUpload(string maSP)
        {
            if (string.IsNullOrEmpty(selectedImagePath) || string.IsNullOrEmpty(maSP))
                return;

            try
            {
                // Đi lên thư mục gốc dự án (src/CF36)
                string rootPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                string imagesFolder = Path.Combine(rootPath, "images", "products");

                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                string extension = Path.GetExtension(selectedImagePath);
                string newFileName = maSP + extension;
                string destinationPath = Path.Combine(imagesFolder, newFileName);

                // Giải phóng file nếu đang bị giữ bởi PictureBox
                if (File.Exists(destinationPath))
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                // Ghi đè ảnh mới
                File.Copy(selectedImagePath, destinationPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công, nhưng lưu ảnh thất bại: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void cbS_CheckedChanged(object sender, EventArgs e)
        {
            txtSuaGiaS.Enabled = cbS.Checked;
            if (!cbS.Checked) txtSuaGiaS.Text = "";
        }

        private void cbM_CheckedChanged(object sender, EventArgs e)
        {
            txtSuaGiaM.Enabled = cbM.Checked;
            if (!cbM.Checked) txtSuaGiaM.Text = "";
        }

        private void cbL_CheckedChanged(object sender, EventArgs e)
        {
            txtSuaGiaL.Enabled = cbL.Checked;
            if (!cbL.Checked) txtSuaGiaL.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Tạo DTO sản phẩm
                SanPhamDTO sp = new SanPhamDTO
                {
                    MaSP = this.maSP,
                    TenSP = txtTen.Text.Trim(),
                    MaLoai = (int)cbbLoaiSanPham.SelectedValue
                };

                // 2. Nếu có ảnh mới, gán đường dẫn tương đối
                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    string extension = Path.GetExtension(selectedImagePath);
                    string fileName = this.maSP + extension;
                    string relativePath = Path.Combine("images", "products", fileName);
                    sp.DuongDanAnh = relativePath;

                    // Giải phóng ảnh cũ nếu đang hiển thị
                    if (picAnhSua.Image != null)
                    {
                        picAnhSua.Image.Dispose();
                        picAnhSua.Image = null;
                    }

                    // Copy ảnh vào thư mục
                    HandleImageUpload(this.maSP);
                }

                // 3. Gọi BUS để lưu thông tin + ảnh
                suaSanPhamBUS.LuuThongTinSanPham(
                    sp,
                    cbS.Checked, txtSuaGiaS.Text,
                    cbM.Checked, txtSuaGiaM.Text,
                    cbL.Checked, txtSuaGiaL.Text,
                    kichCoMap
                );

                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSuaAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedImagePath = openFileDialog.FileName; // Lưu đường dẫn

                    // (SỬA LẠI) Giải phóng ảnh cũ (nếu có)
                    if (picAnhSua.Image != null)
                    {
                        picAnhSua.Image.Dispose();
                    }

                    // (SỬA LẠI) Tải ảnh vào MemoryStream để không khóa file
                    // Đọc tất cả byte của file vào bộ nhớ
                    byte[] imageBytes = File.ReadAllBytes(selectedImagePath);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        // Tạo ảnh từ bộ nhớ (stream)
                        picAnhSua.Image = Image.FromStream(ms);
                    }

                    picAnhSua.SizeMode = PictureBoxSizeMode.Zoom;
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
