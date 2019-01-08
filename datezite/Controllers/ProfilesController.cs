using datezite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace datezite.Controllers
{
    public class ProfilesController : Controller
    {

        GetApplicationUser get = new GetApplicationUser();
        // GET: Profiles
        //public ActionResult YourProfile(ApplicationUser model)
        //{
        //    //var user = get.GetUserByName();
        //    model.Förnamn = user.Förnamn;
        //    model.Efternamn = user.Efternamn;
        //    return View(model);
        //}
    }
}