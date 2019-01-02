using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace datezite.Models
{
    public class User
    {
        public int ID { get; set; }
        [Display(Name = "Användarnamn")]
        public String Username { get; set; }
        [Display(Name = "Lösenord")]
        public String Password { get; set; }
        public String Hobbies { get; set; }
        public int Age { get; set; }
        public String Work { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        [Display(Name = "E-post adress")]
        public String Email { get; set; }

    }
}