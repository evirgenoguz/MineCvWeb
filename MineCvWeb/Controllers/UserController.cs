using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MineCvWeb.Data;
using MineCvWeb.Models;
using Newtonsoft.Json;
using System.Security.Claims;
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

        [AllowAnonymous]
        public IActionResult Index()
        {
            User user = new User();
            ResumeDetail resumeDetail = new ResumeDetail();
            try
            {
                user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                
                resumeDetail.User = (User)_db.Users.Where(u => u.Id == user.Id).FirstOrDefault(); //buradaki 1 daha sonrasında tıklanan userın id si olacak
                resumeDetail.Resume = (Resume)_db.Resumes.Where(r => r.UserId == resumeDetail.User.Id).FirstOrDefault();
                resumeDetail.Education = (Education)_db.Eduations.Where(e => e.UserId == resumeDetail.User.Id).FirstOrDefault();
                resumeDetail.Languages = (List<Language>)_db.Languages.Where(l => l.UserId == resumeDetail.User.Id).ToList();
                resumeDetail.Skills = (List<Skill>)_db.Skills.Where(s => s.UserId == resumeDetail.User.Id).ToList();
                resumeDetail.Experiences = (List<Experience>)_db.Experiences.Where(e => e.UserId == resumeDetail.User.Id).ToList();


                
            } catch(Exception e)
            {
                
            }


            return View(resumeDetail);

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(User user)
        {
            ResumeDetail resumeDetail = new ResumeDetail();

            var loggedUser = _db.Users.Where(u => u.Email == user.Email && u.Password == user.Password).SingleOrDefault();
            if (loggedUser != null)
            {

                HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(loggedUser));
                

                return RedirectToAction("Index", "User");
                
                
            }

            return RedirectToAction("Login", "User");
        }

        [Authorize]
        public ActionResult Logout()
        {
            return View();
        }

       
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid) {
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Login", "User");
            }

            return View(user);
            
        }
    }
}
