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
       
            _context.SaveChanges();
            return RedirectToAction("YourProfile");
        }

        public ActionResult ChangeProfilePicture([Bind(Exclude = "UserPhoto")]ApplicationUser LoggedInUser) {

            var UserToChange = fetchUser.GetUserByName(User.Identity.Name);
            LoggedInUser.UserName = UserToChange.UserName;
            var user = _context.Users.SingleOrDefault(u => u.UserName == UserToChange.UserName);

            byte[] imageData = null;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase poImgFile = Request.Files["UserPhoto"];

                using (var binary = new BinaryReader(poImgFile.InputStream))
                {
                    imageData = binary.ReadBytes(poImgFile.ContentLength);
                }
            }

            user.UserPhoto = imageData;

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
        public ActionResult YourProfile(ApplicationUser model)
        {
            var user = fetchUser.GetUserByName(User.Identity.Name);
            model.Förnamn = user.Förnamn;
            model.Efternamn = user.Efternamn;
            model.Ålder = user.Ålder;
            model.Kön = user.Kön;
            model.Id = user.Id;
            
            model.Sysselsättning = user.Sysselsättning;
            model.UserPhoto = user.UserPhoto;
            model.Inlägg = user.Inlägg;
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

            model.Id = user.Id;
            model.Förnamn = user.Förnamn;
            model.Efternamn = user.Efternamn;
            model.Ålder = user.Ålder;
            model.Kön = user.Kön;
            //model.Intressen = user.Intressen;
            model.Sysselsättning = user.Sysselsättning;
            model.UserName = user.UserName;
            foreach(var entry in _context.Entries)
            {
                if (model.Id == entry.RecipientId)
                {
                    model.Inlägg.Add(entry);
                }
            }
            

            return View(model);
        }

        public ApplicationUser GetOtherUser(String Id)
        {
            var appUser = _context.Users.Single(x => x.Id == Id);

            return appUser;
        }

        public FileContentResult UserPhotos()
        {
            
                String userId = User.Identity.GetUserId();
                var LoggedInUser = fetchUser.GetUserByName(User.Identity.Name);
                if (LoggedInUser.UserPhoto == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.jpg");
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

        public FileContentResult OtherUsersPhoto(String Id)
        {
                
                String userId = Id;
                var OtherUser = GetOtherUser(userId);
                if (OtherUser.UserPhoto == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.jpg");
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

        public ActionResult SearchView(SearchResults model, String searchName) {
            var result = new List<ApplicationUser>();
            var allUsers = _context.Users.ToList();

            if (!String.IsNullOrEmpty(searchName))
            {
                result = allUsers.Where(u => u.Förnamn == searchName || u.Efternamn == searchName || u.Förnamn + " " + u.Efternamn == searchName).ToList();
            }
            model.Results = result;

            return View(model);
        }

        public ActionResult Return()
        {
            return RedirectToAction("YourProfile");
        }
    }
}