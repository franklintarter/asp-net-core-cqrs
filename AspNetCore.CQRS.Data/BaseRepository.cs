using AspNetCore.CQRS.Domain;
using AspNetCore.CQRS.Domain.Core;
using AspNetCore.CQRS.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Data
{
    public abstract class BaseRepository<T, TId> : IBaseRepository<T, TId> where T : Entity<TId>
    {
        protected DataContext DataContext { get; private set; }

        protected DbSet<T> Entities { get; private set; }

        public BaseRepository(DataContext context)
        {
            DataContext = context;
            Entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await Entities.SingleOrDefaultAsync(s => s.Id.Equals(id));
        }

        public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> exp)
        {
            return await DataContext.Set<T>().Where(exp).ToListAsync();
        }

        public async Task Insert(T entity)
        {
            Guard.NullArgument(entity);

            await Entities.AddAsync(entity);
            await DataContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            Guard.NullArgument(entity);

            var oldEntity = await DataContext.FindAsync<T>(entity.Id);
            DataContext.Entry(oldEntity).CurrentValues.SetValues(entity);
            DataContext.SaveChanges();
        }

        public async Task Delete(T entity)
        {
            Guard.NullArgument(entity);

            Entities.Remove(entity);
            await DataContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(TId id)
        {
            return await Entities.AnyAsync(x => x.Id.Equals(id));
        }
    }
}
