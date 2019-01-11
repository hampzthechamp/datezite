using datezite.Models;
using System.Data.Entity;
//...

public class MockInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
{
    // Note: you can also use DropCreateDatabaseAlways to force a re-creation of your database
    protected override void Seed(ApplicationDbContext _context)
    {
        base.Seed(_context);

        var intresse1 = (new Interests {InterestID = 12, Name = "Fågelskådning"});
        var intresse2 = (new Interests {InterestID = 13, Name = "Hälsa" });
        var intresse3 = (new Interests {InterestID = 14, Name = "Pengar" });
         
        _context.Intressen.Add(intresse1);
        _context.Intressen.Add(intresse2);
        _context.Intressen.Add(intresse3);
        _context.SaveChanges();
    }
}