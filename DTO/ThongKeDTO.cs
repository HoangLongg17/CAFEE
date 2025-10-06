namespace DTO
{
    public class ThongKeDTO
    {
        public int Nam { get; set; }
        public int Thang { get; set; }
        public decimal DoanhThu { get; set; }

        public ThongKeDTO(int nam, int thang, decimal doanhThu)
        {
            Nam = nam;
            Thang = thang;
            DoanhThu = doanhThu;
        }
    }
}