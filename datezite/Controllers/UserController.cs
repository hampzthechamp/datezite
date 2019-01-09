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

        public ActionResult Update(ApplicationUser LoggedInUser) {

            var UserToChange = fetchUser.GetUserByName(User.Identity.Name);

            LoggedInUser.UserName = UserToChange.UserName;

            var user = _context.Users.SingleOrDefault(u => u.UserName == UserToChange.UserName);

            user.Förnamn = LoggedInUser.Förnamn;
            user.Efternamn = LoggedInUser.Efternamn;
            user.Sysselsättning = LoggedInUser.Sysselsättning;
            user.Kön = LoggedInUser.Kön;
            user.Ålder = LoggedInUser.Ålder;
            user.Intressen = LoggedInUser.Intressen;


            _context.SaveChanges();
            return RedirectToAction("YourProfile");
        }

        public ActionResult EditYourProfile(ApplicationUser model) {


            model = fetchUser.GetUserByName(User.Identity.Name);

            return View(model);
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
            model.Intressen = user.Intressen;
            model.Sysselsättning = user.Sysselsättning;
            return View(model);
            
        }
        public ActionResult PotentialMatches()
        {
            return View();
        }

        public ActionResult OtherProfile(ApplicationUser model, String Id)
        {
            var otherUser = GetOtherUser(Id);

            model.UserName = otherUser.UserName;

            var user = _context.Users.Single(u => u.UserName == model.UserName);

            model.Förnamn = user.Förnamn;
            model.Efternamn = user.Efternamn;
            model.Ålder = user.Ålder;
            model.Kön = user.Kön;
            model.Intressen = user.Intressen;
            model.Sysselsättning = user.Sysselsättning;
            model.UserName = user.UserName;

            return View(model);
        }

        
        public ActionResult GetUserByUsername(String Förnamn)
        {
            

            return Content(Förnamn);
        }

        public ApplicationUser GetOtherUser(String Id)
        {
            var appUser = _context.Users.Single(x => x.Id == Id);

            return appUser;
        }


    }
}   
        
    
