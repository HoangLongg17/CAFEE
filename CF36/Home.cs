namespace CF36
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhapQuanLi_Click(object sender, EventArgs e)
        {
            QuanLi quanLi = new QuanLi();
            this.Hide();
            quanLi.ShowDialog();
            this.Show();
        }

        private void btnDangNhapNhanVien_Click(object sender, EventArgs e)
        {
            NHANVIEN nHANVIEN = new NHANVIEN();
            this.Hide();
            nHANVIEN.ShowDialog();
            this.Show();
        }
    }
}
