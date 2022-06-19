using System.ComponentModel.DataAnnotations;

namespace MineCvWeb.Models
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required] 
        public string Surname { get; set; }
        [Required] 
        public string Adress { get; set; }
        [Required] 
        public string PhoneNumber { get; set; }
        [Required] 
        public int Age { get; set; }
        [Required] 
        public string JobTitle { get; set; }
        [Required] 
        public string MyDescription { get; set; }

    }
}
