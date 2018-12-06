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
    public class RegisterPersonCommand : IRequest<Result<Guid>>
    {
        public RegisterPersonCommand(Name name, Email email)
        {
            Name = name;
            Email = email;
        }

        public Name Name { get; }
        public Email Email { get; }
    }

    public class RegisterPersonCommandHandler : Core.RequestHandler<RegisterPersonCommand, Result<Guid>>
    {
        private IPersonRepository _repo;

        public RegisterPersonCommandHandler(
            IPersonRepository repository,
            IUnitOfWork uow,
            IMediator mediator
        ): base(uow, mediator)
        {
            _repo = repository;
        }

        public override async Task<Result<Guid>> Handle(RegisterPersonCommand request, CancellationToken cancellationToken)
        {
            var personExists = await _repo.GetPersonByEmailAsync(request.Email);

            if (personExists != null)
            {
                // TODO Raise fail event
                return Result.Fail<Guid>("A user is already registered with that email.");
            }

            var person = new Person(request.Name, request.Email);

            _repo.Insert(person);

            if (await CommitAsync())
            {
                await Mediator.Send(new RegisterPersonEvent(person.Id, person.Email));
            }
            else
            {
                // TODO Raise fail event
                return Result.Fail<Guid>("Person could not be saved.");
            }

            return Result.Ok(person.Id);
        }
    }
}
