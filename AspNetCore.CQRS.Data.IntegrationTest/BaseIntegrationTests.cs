using AspNetCore.CQRS.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private DataContext _context;

        [SetUp]
        public void Setup()
        {
            var dbopts = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SocialFeed;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .Options;

            _context = new DataContext(dbopts);
            _context.Database.Migrate();

            //DataSeeder = new DataSeeder(_context);
            //DataSeeder.ClearSeedData();
            //DataSeeder.Seed();

            _context.Dispose();
            _context = new DataContext(dbopts);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}