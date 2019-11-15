using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using freelancer.Models;

namespace freelancer.Controllers
{
    public class Gender
    {
        public string Type { get; set; }
        public int Id { get; set; }
    }
    public class HomeController : Controller
    {
        FreeLancerDBEntities entity = new FreeLancerDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hirer()
        {
            List<Gender> genderlist = new List<Gender>();
            genderlist.Add(new Gender { Type = "Male", Id = 0 });
            genderlist.Add(new Gender { Type = "Female", Id = 1 });
            ViewBag.gender = new SelectList(genderlist, "Type", "Type");
            return View();
        }
        [HttpPost]
        public ActionResult Hirer(Hirer hirer)
        {
            if (ModelState.IsValid)
            {
                tblUser user = new tblUser();
                Hirer Hirer = new Hirer();
                Hirer.FirstName = hirer.FirstName;
                Hirer.LastName = hirer.LastName;
                Hirer.Age = hirer.Age;
                Hirer.Email = hirer.Email;
                Hirer.Gender = hirer.Gender;
                Hirer.Address = hirer.Address;

                user.Username = hirer.user.Username;
                user.Password = hirer.user.Password;
                user.Type = "Hirer";
                entity.Hirers.Add(Hirer);
                entity.tblUsers.Add(user);
                entity.SaveChanges();

                return RedirectToAction("Login");
            }
            return View();
           
        }
        public ActionResult Login(string type)
        {
            ViewBag.type = type;
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblUser user)
        {
            if (ModelState.IsValid)
            {
                bool IsValid = entity.tblUsers.Any(u => u.Username == user.Username && u.Password == user.Password);
                if (IsValid)
                {
                    tblUser user1 = entity.tblUsers.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                    if(user1.Type == "Hirer")
                    {
                        return RedirectToAction("HirerProfile");
                    }
                    else
                    {
                        return RedirectToAction("FreelancerProfile");
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            return View();

        }
        public ActionResult HirerProfile()
        {
            return View("HirerProfile");
        }

        public ActionResult FreelancerProfile()
        {
            return View("FreelancerProfile");
        }
        public ActionResult Freelancer()
        {
            return View();
        }
    }
}