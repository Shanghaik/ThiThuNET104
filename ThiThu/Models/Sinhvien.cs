namespace ThiThu.Models
{
    public class Sinhvien
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Tuoi { get; set; }
        public string Nganh { get; set; }
        public string Email { get; set; }
        public int HocBong { get; set; }
        public bool Status { get; set; }
    }
}
