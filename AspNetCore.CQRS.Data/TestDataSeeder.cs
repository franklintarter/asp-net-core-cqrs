using AspNetCore.CQRS.Data.Repositories;
using AspNetCore.CQRS.Domain.People;
using AspNetCore.CQRS.Domain.ValueObjects;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Data
{
    public class TestDataSeeder
    {
        private UnitOfWork _uow;
        private PersonRepository _repository;

        public Person Person1;
        public Person Person2;

        public TestDataSeeder(DataContext dataContext)
        {
            _uow = new UnitOfWork(dataContext);
            _repository = new PersonRepository(dataContext);
        }

        public async Task Seed()
        {
            Person1 = new Person(Name.Create("John Doe").Value, Email.Create("jdoe@mydomain.com").Value);
            Person2 = new Person(Name.Create("Jane Smith").Value, Email.Create("jsmith@mydomain.com").Value);
            _repository.Insert(Person1);
            _repository.Insert(Person2);
            await _uow.CommitAsync();
        }

        public async Task ClearSeedData()
        {
            var people = await _repository.WhereAsync(x => true);
            people.ForEach(x => _repository.Delete(x));
            await _uow.CommitAsync();
        }
    }
}
