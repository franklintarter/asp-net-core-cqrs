using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Domain.Core
{
    public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>, IDisposable
        where TRequest : IRequest<TResponse>
    {
        private IUnitOfWork _uow;
        protected IMediator Mediator;

        public RequestHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _uow = unitOfWork;
            Mediator = mediator;
        }

        protected async Task<bool> CommitAsync()
        {
            return await _uow.CommitAsync();
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
