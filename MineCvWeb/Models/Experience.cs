using System.ComponentModel.DataAnnotations;

namespace MineCvWeb.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public int HowManyYear { get; set; }
    }
}
