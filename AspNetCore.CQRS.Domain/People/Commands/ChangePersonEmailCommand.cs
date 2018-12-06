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
    public class ChangePersonEmailCommand : IRequest<Result>
    {
        public ChangePersonEmailCommand(Email email, Guid personId)
        {
            Email = email;
            PersonId = personId;
        }

        public Email Email { get; }
        public Guid PersonId { get; }
    }

    public class ChangePersonEmailCommandHandler : Core.RequestHandler<ChangePersonEmailCommand, Result>
    {
        private IPersonRepository _repo;

        public ChangePersonEmailCommandHandler(
            IPersonRepository personRepo,
            IUnitOfWork unitOfWork,
            IMediator mediator) : base(unitOfWork, mediator)
        {
            _repo = personRepo;
        }

        public override async Task<Result> Handle(ChangePersonEmailCommand request, CancellationToken cancellationToken)
        {
            var person = await _repo.GetByIdAsync(request.PersonId);

            if (person == null)
            {
                // TODO raise fail event
                return Result.Fail($"Person not found '{request.PersonId}'");
            }

            person.ChangeEmail(request.Email);

            _repo.Update(person);

            if (await CommitAsync())
            {
                await Mediator.Send(new ChangePersonEmailEvent(person.Id, person.Email));
            }
            else
            {
                // TODO raise fail event
                return Result.Fail($"Unable to update person email '{request.PersonId}'");
            }

            return Result.Ok();
        }
    }
}
