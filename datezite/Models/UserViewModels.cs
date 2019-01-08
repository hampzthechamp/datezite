using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace datezite.Models
{
    public class UserViewModels
    {
       
        public List<User> Friends { get; set; }
        

        
        
    }

    public class LoggedInViewModel
    {
        public List<Entry> WallEntries { get; set; }
        public List<ApplicationUser> Friends { get; set; }
        
    }
}