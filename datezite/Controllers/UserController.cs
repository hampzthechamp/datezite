using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using datezite.Models;
using datezite.ViewModels;

namespace datezite.Controllers
{
    public class UserController : Controller
    {

        private ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create(User user) {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "User/FirstPage");
        }

        public ActionResult EditYourProfile() {
            return View();
        }
        public ActionResult Update(User user) {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult MyMatches()
        {
            return View();
        }
        public ActionResult YourProfile()
        {
            return View();
        }
        public ActionResult potentialMatches()
        {
            return View();
        }

        public ActionResult OtherProfile()
        {
            
            return View();
        }
    }
}   
        
    
