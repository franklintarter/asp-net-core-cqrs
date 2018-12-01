using AspNetCore.CQRS.Domain.Core;
using AspNetCore.CQRS.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Domain.Person
{
    public interface IPersonRepository : IBaseRepository<Person, Guid>
    {
        Task<Person> GetPersonByEmail(Email email);
    }
}
