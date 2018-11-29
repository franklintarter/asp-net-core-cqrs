using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.CQRS.Domain.Core
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.UtcNow;
        }

        public abstract bool IsValid();
    }
}
