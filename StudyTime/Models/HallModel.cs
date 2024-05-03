namespace StudyTime.Models
{
    public class HallModel
    {
        public int Id { get; set; } = default!;
        public byte HallName { get; set; } = default!;
        public int HallTime { get; set; } = default!;
        public string Day { get; set; } = null!;
        public string Specialty { get; set; } = default!;

    }
}
