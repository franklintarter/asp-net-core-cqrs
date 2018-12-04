using System;

namespace AspNetCore.CQRS.Domain.Core
{
    public abstract class Event<TId>
    {
        public Event(TId aggregateId)
        {
            AggregateId = aggregateId;
            TimeStamp = DateTime.UtcNow;
        }

        public DateTime TimeStamp { get; }
        public TId AggregateId { get; }
    }
}
