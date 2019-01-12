namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inlägg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Entries", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Entries", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entries", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Entries", "ApplicationUser_Id");
            AddForeignKey("dbo.Entries", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            
        }
    }
}
