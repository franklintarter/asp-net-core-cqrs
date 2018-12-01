using System;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
