using System.ComponentModel.DataAnnotations;

namespace MineCvWeb.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string SkillName { get; set; }
    }
}
