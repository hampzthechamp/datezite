using datezite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace datezite.ViewModels
{
    public class EditYourProfileViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public List <Interests> Interests { get; set; }
    }
}