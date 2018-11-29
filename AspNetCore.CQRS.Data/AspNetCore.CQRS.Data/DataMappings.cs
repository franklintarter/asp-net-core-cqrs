using AspNetCore.CQRS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.CQRS.Data
{
    class DataMappings
    {
    }

    internal class PersonMap : IEntityTypeConfiguration<Person>
    {
        public virtual void Configure(EntityTypeBuilder<Person> builder)
        {
        }
    }
}
