using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace datezite.Models
{
    public class WallEntry
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Posted { get; set; }

        public User Author { get; set; }


        [ForeignKey("RecipientId")]
        public int? Recipient { get; set; }
        public User Uzer { get; set; }
    }

}