using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace AspNetCore.CQRS.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public static Result<Email> Create(string value)
        {
            Email email;
            try
            {
                email = new Email(value);
            }
            catch (Exception e)
            {
                return Result.Fail<Email>("Email format not valid");
            }
            return Result.Ok(email);
        }

        public string Value { get; private set; }

        private Email()
        {
        }

        private Email(string value)
        {
            new MailAddress(value);
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
