using System;

namespace AspNetCore.CQRS.Domain
{
    public class Person : Entity<Guid>
    {
        private Person(){} // ORM

        public Person(string name, string email) : base(Guid.NewGuid())
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}
