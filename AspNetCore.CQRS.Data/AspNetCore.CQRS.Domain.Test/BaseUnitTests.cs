namespace AspNetCore.CQRS.Domain.Test
{
    public abstract class BaseUnitTests
    {
        protected static Person ValidPerson => new Person("Valid Name", "test@email.com");
        //protected static Name ValidPersonName => Name.Create("Valid Name").Value;
        //protected static Email ValidEmail => Email.Create("test@email.com").Value;
    }
}
