using System.ComponentModel.DataAnnotations;

namespace MineCvWeb.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string LanguageName { get; set; }
        public string LanguageLevel { get; set; }
    }
}
