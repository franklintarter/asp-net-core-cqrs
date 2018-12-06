using AspNetCore.CQRS.Domain.People;
using AspNetCore.CQRS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person, Guid>, IPersonRepository
    {
        private DataContext _context;

        public PersonRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Person> GetPersonByEmail(Email email)
        {
            return await _context.People.FirstOrDefaultAsync(x => x.Email.Value == email.Value);
        }
    }
}
