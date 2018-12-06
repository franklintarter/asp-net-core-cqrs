using AspNetCore.CQRS.Domain.Core;
using AspNetCore.CQRS.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Domain.People
{
    public interface IPersonRepository : IBaseRepository<Person, Guid>
    {
        Task<Person> GetPersonByEmailAsync(Email email);
    }
}
