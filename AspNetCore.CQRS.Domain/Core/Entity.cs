using System;

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
            Id = id;
        }

        public TId Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastModifiedAt { get; private set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity<TId> other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetRealType() != other.GetRealType())
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetRealType().ToString() + Id).GetHashCode();
        }

        protected Type GetRealType()
        {
            return GetType();
        }
    }
}
