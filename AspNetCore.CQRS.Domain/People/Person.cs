using AspNetCore.CQRS.Domain.ValueObjects;
using AspNetCore.CQRS.SharedKernel;
using System;

namespace AspNetCore.CQRS.Domain.People
{
    public class Person : Entity<Guid>
    {
        private Person(){} // ORM

        public Person(Name name, Email email) : base(Guid.NewGuid())
        {
            Guard.NullArgument(name);
            Guard.NullArgument(email);

            Name = name;
            Email = email;
        }

        public Name Name { get; set; }
        public Email Email { get; set; }
    }
}
