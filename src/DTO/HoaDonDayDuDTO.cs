using DTO;

public class HoaDonDayDuDTO
{
    public int MaHD { get; set; }
    public DateTime NgayLap { get; set; }
    public string TenNhanVien { get; set; }
    public string TenKhachHang { get; set; }
    public string SdtKhachHang { get; set; }
    public int TichDiem { get; set; }
    public decimal TongTienCuoiCung { get; set; }
    public List<string> VouchersSuDung { get; set; }
    public List<ChiTietLichSuDTO> Items { get; set; }

    public HoaDonDayDuDTO()
    {
        VouchersSuDung = new List<string>();
        Items = new List<ChiTietLichSuDTO>();
    }
}