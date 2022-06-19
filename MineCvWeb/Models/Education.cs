using System.ComponentModel.DataAnnotations;

namespace MineCvWeb.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string University { get; set; }
        [Required] 
        public string Department { get; set; }
        [Required]
        public int EntranceYear { get; set; }
        [Required]
        public int GraduationYear { get; set; }
        [Required]
        public float GPA { get; set; }
    }
}
