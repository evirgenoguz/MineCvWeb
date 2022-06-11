namespace MineCvWeb.Models
{
    public class ResumeDetail
    {
        public User User { get; set; }
        public Resume Resume { get; set; }
        public Education Education { get; set; }
        public List<Language> Languages { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Experience> Experiences { get; set; }
    }
}
