using AspNetCore.CQRS.Domain.Core;
using AspNetCore.CQRS.Domain.ValueObjects;
using System;

namespace AspNetCore.CQRS.Domain.People.Events
{
    public class ChangePersonNameEvent : Event<Guid>
    {
        public ChangePersonNameEvent(Guid aggregateId, Name newName): base(aggregateId)
        {
            NewName = newName;
        }

        public Name NewName { get; }
    }
}
