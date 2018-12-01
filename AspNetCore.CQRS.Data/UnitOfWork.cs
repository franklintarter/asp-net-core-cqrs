using AspNetCore.CQRS.Domain.Core;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return (await _context.SaveChangesAsync()) > 0; 
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
