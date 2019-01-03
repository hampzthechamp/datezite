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
        [Display(Name ="Intressen")]
        public String Hobbies { get; set; }
        [Display(Name = "Ålder")]
        public int Age { get; set; }
        [Display(Name = "Arbete")]
        public String Work { get; set; }
        [Display(Name = "Förnamn")]
        public String Firstname { get; set; }
        [Display(Name = "Efternamn")]
        public String Lastname { get; set; }
        [Display(Name = "E-post adress")]
        public String Email { get; set; }
        [Display(Name = "Kön")]
        public String Gender { get; set; }

    }
}