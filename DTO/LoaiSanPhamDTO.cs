namespace CF36.DTO
{
    public class LoaiSanPhamDTO
    {
        public string TenLoai { get; set; }

        public LoaiSanPhamDTO(string tenLoai)
        {
            TenLoai = tenLoai;
        }
    }
}