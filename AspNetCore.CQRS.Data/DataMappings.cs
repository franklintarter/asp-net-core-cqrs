using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.CQRS.Data
{
    class DataMappings
    {
    }

    internal class PersonMap : IEntityTypeConfiguration<Person>
    {
        public virtual void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.OwnsOne(x => x.Email).Property(x => x.Value).HasColumnName("Email");
            builder.OwnsOne(x => x.Name).Property(x => x.Value).HasColumnName("Name");
            builder.ToTable("Person");
        }
    }
}
