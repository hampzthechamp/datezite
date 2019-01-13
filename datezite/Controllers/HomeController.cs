using datezite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace datezite.Controllers
{
    public class HomeController : Controller
    {
        GetApplicationUser fetchUser = new GetApplicationUser();
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();

        }


        public ActionResult Index(ApplicationUser model)
        
            {
                //var otherUser = GetOtherUser("0c5297e9 - d9a0 - 4990 - 897b - 3cf034d6ed8f");

                //model.UserName = otherUser.UserName;

                var user = _context.Users.Single(u => u.UserName == "testing@hotmail.com");
                var user2 = _context.Users.Single(u => u.UserName == "testing2@hotmail.com");

            var exampleProfiles = new List<ApplicationUser>
            {
                user,
                user2
            };
            
            model.ExempelProfiler = exampleProfiles;
            

            ViewBag.MyList = exampleProfiles;

            return View(model);
            }

        public FileContentResult exUserPhotos(string loggedinId)
        {
          //  loggedinId = getLoggedInUser();
            var LoggedInUser = fetchUser.GerUserById(loggedinId);
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
            var userImage = bdUsers.Users.Where(u => u.Id == loggedinId).FirstOrDefault();

            return new FileContentResult(userImage.UserPhoto, "image/jpeg");
        }

        public string getLoggedInUser()
        {
            string userId = User.Identity.GetUserId();
            return userId;
        }





    }
}