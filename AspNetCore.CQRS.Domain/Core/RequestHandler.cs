using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Domain.Core
{
    public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private IUnitOfWork _uow;

        public RequestHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        protected async Task<bool> CommitAsync()
        {
            return await _uow.CommitAsync();
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
