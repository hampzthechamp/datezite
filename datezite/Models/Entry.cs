using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace datezite.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public ApplicationUser Author { get; set; }
        public ApplicationUser Recipient { get; set; }
    }
}