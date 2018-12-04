using AspNetCore.CQRS.Domain.Core;
using System;

namespace AspNetCore.CQRS.Domain.People.Events
{
    public class DeletePersonEvent : Event<Guid>
    {
        public DeletePersonEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
