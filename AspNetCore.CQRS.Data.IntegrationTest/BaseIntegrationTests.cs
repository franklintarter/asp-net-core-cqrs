using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Data.IntegrationTest
{
    public class BaseIntegrationTests
    {
        protected DataContext Context { get; private set; }
        protected UnitOfWork UnitOfWork { get; private set; }
        protected TestDataSeeder Seeder { get; private set; }

        [SetUp]
        public async Task Setup()
        {
            var dbopts = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AspNetCoreCQRS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .Options;

            Context = new DataContext(dbopts);
            Context.Database.Migrate();
            UnitOfWork = new UnitOfWork(Context);

            Seeder = new TestDataSeeder(Context);
            await Seeder.ClearSeedData();
            await Seeder.Seed();
        }

        [TearDown]
        public async Task TearDown()
        {
            await Seeder.ClearSeedData();
            Context.Dispose();
            UnitOfWork.Dispose();
        }
    }
}