using System.ComponentModel.DataAnnotations;

namespace MineCvWeb.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string LanguageName { get; set; }
        [Required]
        public string LanguageLevel { get; set; }
    }
}
