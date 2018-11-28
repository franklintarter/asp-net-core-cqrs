using System;

namespace AspNetCore.CQRS.Domain
{
    public class Person : Entity<Guid>
    {
        private Person(){} // ORM

        public Person(string name) : base(Guid.NewGuid())
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
