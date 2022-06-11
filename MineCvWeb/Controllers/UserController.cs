using Microsoft.AspNetCore.Mvc;
using MineCvWeb.Data;
using MineCvWeb.Models;

namespace MineCvWeb.Controllers
{
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            ResumeDetail resumeDetail = new ResumeDetail();
            resumeDetail.User = (User)_db.Users.Where(u => u.Id == 1).SingleOrDefault(); //buradaki 1 daha sonrasında tıklanan userın id si olacak
            resumeDetail.Resume = (Resume)_db.Resumes.Where(r => r.UserId == resumeDetail.User.Id).SingleOrDefault();
            resumeDetail.Education = (Education)_db.Eduations.Where(e => e.UserId == resumeDetail.User.Id).SingleOrDefault();
            resumeDetail.Languages = (List<Language>)_db.Languages.Where(l => l.UserId == resumeDetail.User.Id).ToList();
            resumeDetail.Skills = (List<Skill>)_db.Skills.Where(s => s.UserId == resumeDetail.User.Id).ToList();
            resumeDetail.Experiences = (List<Experience>)_db.Experiences.Where(e => e.UserId == resumeDetail.User.Id).ToList();


            return View(resumeDetail);
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
