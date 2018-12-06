using AspNetCore.CQRS.Domain.Core;
using AspNetCore.CQRS.Domain.People.Events;
using AspNetCore.CQRS.Domain.ValueObjects;
using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Domain.People.Commands
{
    public class ChangePersonNameCommand : IRequest<Result>
    {
        public ChangePersonNameCommand(Guid personId, Name name)
        {
            Name = name;
            PersonId = personId;
        }

        public Name Name { get; }
        public Guid PersonId { get; }
    }

    public class ChangePersonNameCommandHandler : Core.RequestHandler<ChangePersonNameCommand, Result>
    {
        private IPersonRepository _personRepo;

        public ChangePersonNameCommandHandler(
            IPersonRepository personRepo,
            IUnitOfWork unitOfWork,
            IMediator mediator
        ) : base(unitOfWork, mediator)
        {
            _personRepo = personRepo;
        }

        public override async Task<Result> Handle(ChangePersonNameCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepo.GetByIdAsync(request.PersonId);

            if (person == null)
            {
                // TODO raise failure event
                return Result.Fail($"Person not found '{request.PersonId}'");
            }

            person.ChangeName(request.Name);

            _personRepo.Update(person);

            if (await CommitAsync())
            {
                await Mediator.Send(new ChangePersonNameEvent(person.Id, person.Name));
            }
            else
            {
                // TODO raise fail event
                return Result.Fail($"Person name could not be changed '{request.PersonId}'");
            }

            return Result.Ok();
        }
    }
}
