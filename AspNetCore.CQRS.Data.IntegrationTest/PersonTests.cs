using AspNetCore.CQRS.Data.Repositories;
using AspNetCore.CQRS.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Data.IntegrationTest
{
    [TestFixture]
    public class PersonTests : BaseIntegrationTests
    {
        private PersonRepository _repo;

        [SetUp]
        public void BeforeEach()
        {
            _repo = new PersonRepository(Context);
        }

        [Test]
        public async Task GetPersonByEmail()
        {
            var person = await _repo.GetPersonByEmailAsync(Seeder.Person1.Email);

            Assert.That(person.Name == Seeder.Person1.Name);
        }

        [Test]
        public async Task UpdatePerson()
        {
            var newName = Name.Create("New Name").Value;
            var person = await _repo.GetByIdAsync(Seeder.Person1.Id);

            person.ChangeName(newName);
            _repo.Update(person);
            await UnitOfWork.CommitAsync();

            var refreshedPerson = await _repo.GetByIdAsync(Seeder.Person1.Id);
            Assert.That(refreshedPerson.Name, Is.EqualTo(newName));
        }
    }
}
