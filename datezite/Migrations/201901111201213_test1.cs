namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserInterests", newName: "användares_Intressen");
            RenameColumn(table: "dbo.användares_Intressen", name: "ApplicationUser_Id", newName: "id");
            RenameColumn(table: "dbo.användares_Intressen", name: "Interests_InterestID", newName: "InterestID");
            RenameIndex(table: "dbo.användares_Intressen", name: "IX_ApplicationUser_Id", newName: "IX_id");
            RenameIndex(table: "dbo.användares_Intressen", name: "IX_Interests_InterestID", newName: "IX_InterestID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.användares_Intressen", name: "IX_InterestID", newName: "IX_Interests_InterestID");
            RenameIndex(table: "dbo.användares_Intressen", name: "IX_id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.användares_Intressen", name: "InterestID", newName: "Interests_InterestID");
            RenameColumn(table: "dbo.användares_Intressen", name: "id", newName: "ApplicationUser_Id");
            RenameTable(name: "dbo.användares_Intressen", newName: "ApplicationUserInterests");
        }
    }
}
