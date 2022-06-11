using System.ComponentModel.DataAnnotations;

namespace MineCvWeb.Models
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }
        public string MyDescription { get; set; }

    }
}
