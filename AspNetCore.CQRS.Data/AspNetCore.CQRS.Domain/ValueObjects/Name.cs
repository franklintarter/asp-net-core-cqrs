using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace AspNetCore.CQRS.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public static Result<Name> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Fail<Name>("Name cannot be null or whitespace.");
            }
            return Result.Ok(new Name(value));
        }

        private Name(){} // ORM

        public string Value { get; private set; }

        private Name(string value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
