using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using datezite.Models;
using datezite.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace datezite.Controllers
{
    public class ProfilesController : Controller
    {
        GetApplicationUser fetchUser = new GetApplicationUser();
        private ApplicationDbContext _context;
        //  private InterestDBContext db = new InterestDBContext();

        public ProfilesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Update(ApplicationUser LoggedInUser)
        {

            var UserToChange = fetchUser.GetUserByName(User.Identity.Name);

            LoggedInUser.UserName = UserToChange.UserName;

            var user = _context.Users.SingleOrDefault(u => u.UserName == UserToChange.UserName);

            user.Förnamn = LoggedInUser.Förnamn;
            user.Efternamn = LoggedInUser.Efternamn;
            user.Sysselsättning = LoggedInUser.Sysselsättning;
            user.Kön = LoggedInUser.Kön;
            user.Ålder = LoggedInUser.Ålder;
            //     user.Intressen = LoggedInUser.Intressen;


            _context.SaveChanges();
            return RedirectToAction("YourProfile");
        }

        public ActionResult EditYourProfile(ApplicationUser username)
        {


            username = fetchUser.GetUserByName(User.Identity.Name);
            var intressen = _context.Intressen.ToList();

            var viewModel = new EditYourProfileViewModel
            {
                ApplicationUser = username,
                Interests = intressen
            };
            viewModel.Ålder = username.Ålder;
            viewModel.Förnamn = username.Förnamn;
            viewModel.Efternamn = username.Efternamn;
            viewModel.Sysselsättning = username.Sysselsättning;
            viewModel.Kön = username.Kön;
            return View(viewModel);

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult MyMatches()
        {
            return View();
        }
        public ActionResult YourProfile(ProfileViewModel1 model)
        {
            var user = fetchUser.GetUserByName(User.Identity.Name);


            model.CurrentUser.Förnamn = user.Förnamn;
            model.CurrentUser.Efternamn = user.Efternamn;
            model.CurrentUser.Ålder = user.Ålder;
            model.CurrentUser.Kön = user.Kön;
            model.CurrentUser.Intressen = user.Intressen;
            model.CurrentUser.Sysselsättning = user.Sysselsättning;
            model.CurrentUser.Inlägg = user.Inlägg;

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

        public ApplicationUser GetOtherUser(String Id)
        {
            var appUser = _context.Users.Single(x => x.Id == Id);

            return appUser;
        }

        public FileContentResult UserPhotos()
        {
            if (User.Identity.IsAuthenticated)
            {
                String userId = User.Identity.GetUserId();
                if (userId == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/png");

                }
                var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                var userImage = bdUsers.Users.Where(u => u.Id == userId).FirstOrDefault();

                return new FileContentResult(userImage.UserPhoto, "image/jpeg");
            }
            else
            {
                string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLengt = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLengt);
                return File(imageData, "image/png");
            }
        }
    }
}