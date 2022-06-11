namespace MineCvWeb.Models
{
    public class Education
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public int EntranceYear { get; set; }
        public int GraduationYear { get; set; }
        public float GPA { get; set; }
    }
}
