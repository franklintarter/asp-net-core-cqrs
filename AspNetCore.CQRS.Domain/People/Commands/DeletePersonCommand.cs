using AspNetCore.CQRS.Domain.Core;
using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Domain.People.Commands
{
    public class DeletePersonCommand : IRequest<Result>
    {
        public DeletePersonCommand(Guid personId)
        {
            PersonId = personId;
        }

        public Guid PersonId { get; }
    }

    public class DeletePersonCommandHandler : Core.RequestHandler<DeletePersonCommand, Result>
    {
        private IPersonRepository _repo;

        public DeletePersonCommandHandler(IPersonRepository personRepo, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repo = personRepo;
        }

        public override async Task<Result> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _repo.GetById(request.PersonId);

            if (person == null)
            {
                // TODO raise fail event
                return Result.Fail($"Person not found '{request.PersonId}'");
            }

            _repo.Delete(person);

            if (await CommitAsync())
            {
                // TODO raise success event
            }
            else
            {
                // TODO raise fail event
                return Result.Fail($"Unable to delete person '{request.PersonId}'");
            }

            return Result.Ok();
        }
    }
}
