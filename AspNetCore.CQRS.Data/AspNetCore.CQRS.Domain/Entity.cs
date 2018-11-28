using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.CQRS.Domain
{
    public abstract class Entity<TId>
    {
        protected Entity() { } // ORM

        protected Entity(TId id)
        {
            var now = DateTime.UtcNow;
            CreatedAt = now;
            LastModifiedAt = now;
        }

        public TId Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }
}
