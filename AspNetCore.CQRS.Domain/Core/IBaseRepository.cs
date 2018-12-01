using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Domain.Core
{
    public interface IBaseRepository<T, TId>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> exp);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Exists(TId id);
    }
}
