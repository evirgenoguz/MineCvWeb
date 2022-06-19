using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MineCvWeb.Data;
using MineCvWeb.Models;
using Newtonsoft.Json;

namespace MineCvWeb.Controllers
{
    public class ResumeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ResumeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Resume> objResumeList = _db.Resumes.ToList();
            return View(objResumeList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResumeDetail resumeDetail)
        {
            if (ModelState.ErrorCount <= 4)
            {
                var user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));

                resumeDetail.Resume.UserId = user.Id;
                resumeDetail.Education.UserId = user.Id;
                resumeDetail.Skills[0].UserId = user.Id;
                resumeDetail.Languages[0].UserId = user.Id;




                _db.Resumes.Add(resumeDetail.Resume);
                _db.Eduations.Add(resumeDetail.Education);
                _db.Skills.Add(resumeDetail.Skills[0]);
                _db.Languages.Add(resumeDetail.Languages[0]);
                _db.SaveChanges();

                return RedirectToAction("Index", "Resume");
            }

            return View(resumeDetail);
            
        }

        public IActionResult Edit()
        {

            ResumeDetail resumeDetail = new ResumeDetail();

            resumeDetail.User = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));



            resumeDetail.Resume = (Resume)_db.Resumes.Where(r => r.UserId == resumeDetail.User.Id).FirstOrDefault();
            resumeDetail.Education = (Education)_db.Eduations.Where(e => e.UserId == resumeDetail.User.Id).FirstOrDefault();
            resumeDetail.Languages = (List<Language>)_db.Languages.Where(l => l.UserId == resumeDetail.User.Id).ToList();
            resumeDetail.Skills = (List<Skill>)_db.Skills.Where(s => s.UserId == resumeDetail.User.Id).ToList();

            if (resumeDetail.User == null) 
            {
                return NotFound();
            }

            return View(resumeDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ResumeDetail resumeDetail)
        {

            if (ModelState.ErrorCount <= 4)
            {
                var user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));

                resumeDetail.Resume.UserId = user.Id;
                resumeDetail.Education.UserId = user.Id;
                resumeDetail.Skills[0].UserId = user.Id;
                resumeDetail.Languages[0].UserId = user.Id;




                _db.Resumes.Update(resumeDetail.Resume);
                _db.Eduations.Update(resumeDetail.Education);
                _db.Skills.Update(resumeDetail.Skills[0]);
                _db.Languages.Update(resumeDetail.Languages[0]);
                _db.SaveChanges();



                return RedirectToAction("Index", "Resume");
            }

            return View(resumeDetail);

           
        }


        public IActionResult Delete()
        {

            ResumeDetail resumeDetail = new ResumeDetail();

            resumeDetail.User = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));


            resumeDetail.Resume = (Resume)_db.Resumes.Where(r => r.UserId == resumeDetail.User.Id).FirstOrDefault();
            resumeDetail.Education = (Education)_db.Eduations.Where(e => e.UserId == resumeDetail.User.Id).FirstOrDefault();
            resumeDetail.Languages = (List<Language>)_db.Languages.Where(l => l.UserId == resumeDetail.User.Id).ToList();
            resumeDetail.Skills = (List<Skill>)_db.Skills.Where(s => s.UserId == resumeDetail.User.Id).ToList();

            if (resumeDetail.User == null)
            {
                return NotFound();
            }

            return View(resumeDetail);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));

            ResumeDetail resumeDetail = new ResumeDetail();

            resumeDetail.User = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));

            resumeDetail.Resume = (Resume)_db.Resumes.Where(r => r.UserId == resumeDetail.User.Id).FirstOrDefault();
            resumeDetail.Education = (Education)_db.Eduations.Where(e => e.UserId == resumeDetail.User.Id).FirstOrDefault();
            resumeDetail.Languages = (List<Language>)_db.Languages.Where(l => l.UserId == resumeDetail.User.Id).ToList();
            resumeDetail.Skills = (List<Skill>)_db.Skills.Where(s => s.UserId == resumeDetail.User.Id).ToList();



            _db.Resumes.Remove(resumeDetail.Resume);
            _db.Eduations.Remove(resumeDetail.Education);
            _db.Skills.Remove(resumeDetail.Skills[0]);
            _db.Languages.Remove(resumeDetail.Languages[0]);
            _db.SaveChanges();



            return RedirectToAction("Index", "Resume");
        }



        [AllowAnonymous]
        public IActionResult Detail(int id)
        {
            ResumeDetail resumeDetail = new ResumeDetail();
            resumeDetail.User = (User)_db.Users.Where(u => u.Id == id).FirstOrDefault(); //buradaki 1 daha sonrasında tıklanan userın id si olacak
            resumeDetail.Resume = (Resume)_db.Resumes.Where(r => r.UserId == resumeDetail.User.Id).FirstOrDefault();
            resumeDetail.Education = (Education)_db.Eduations.Where(e => e.UserId == resumeDetail.User.Id).FirstOrDefault();
            resumeDetail.Languages = (List<Language>)_db.Languages.Where(l => l.UserId == resumeDetail.User.Id).ToList();
            resumeDetail.Skills = (List<Skill>)_db.Skills.Where(s => s.UserId == resumeDetail.User.Id).ToList();
            resumeDetail.Experiences = (List<Experience>)_db.Experiences.Where(e => e.UserId == resumeDetail.User.Id).ToList();

            return View(resumeDetail);
        }   


        



    }
}
