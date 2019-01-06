using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace datezite.Models
{
    public class DatingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<User> Friends { get; set; }
        public DbSet<WallEntry> Entrys { get; set; }


        public DatingDbContext() : base("datingdb") { }

    }
}