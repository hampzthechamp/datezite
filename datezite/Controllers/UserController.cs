using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using datezite.Models;
using datezite.ViewModels;
using Microsoft.AspNet.Identity;

namespace datezite.Controllers
{
    public class UserController : Controller
    {
        GetApplicationUser fetchUser = new GetApplicationUser();

        private ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        //public ActionResult Create(User user) {
        //    _context.Users.Add(user);
        //    _context.SaveChanges();
        //    return RedirectToAction("YourProfile", "User");
        //}

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
        public ActionResult YourProfile(ApplicationUser model)
        {
            var user = fetchUser.GetUserByName(User.Identity.Name);
            model.Förnamn = user.Förnamn;
            model.Efternamn = user.Efternamn;
            model.Ålder = user.Ålder;
            model.Kön = user.Kön;
            return View(model);
            
        }
        public ActionResult PotentialMatches()
        {
            return View();
        }

        public ActionResult OtherProfile()
        {
            
            return View();
        }
    }
}   
        
    
