using AspNetCore.CQRS.Domain.Core;
using AspNetCore.CQRS.Domain.ValueObjects;
using System;

namespace AspNetCore.CQRS.Domain.People.Events
{
    public class RegisterPersonEvent : Event<Guid>
    {
        public RegisterPersonEvent(Guid aggregateId, Email email): base(aggregateId)
        {
            Email = email;
        }

        public Email Email { get; }
    }
}
