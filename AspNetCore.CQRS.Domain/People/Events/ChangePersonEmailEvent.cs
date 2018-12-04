using AspNetCore.CQRS.Domain.Core;
using AspNetCore.CQRS.Domain.ValueObjects;
using System;

namespace AspNetCore.CQRS.Domain.People.Events
{
    public class ChangePersonEmailEvent : Event<Guid>
    {
        public ChangePersonEmailEvent(Guid aggregateId, Email newEmail):base(aggregateId)
        {
            NewEmail = newEmail;
        }

        public Email NewEmail { get; }
    }
}
