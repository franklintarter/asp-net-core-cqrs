using AspNetCore.CQRS.Domain.Core;
using System;

namespace AspNetCore.CQRS.Domain.Person
{
    public interface IPersonRepository : IBaseRepository<Person, Guid>
    {
    }
}
