using AspNetCore.CQRS.Domain.Test.Utils.SocialFeed.Domain.Tests.TestUtils;
using NUnit.Framework;

namespace AspNetCore.CQRS.Domain.Test
{
    [TestFixture]
    public class PersonTests : BaseUnitTests
    {
        [Test]
        public void CtorTests()
        {
            new ConstructorTests()
                .ThrowWhenAnyInputNull_OtherwiseSucceed<Person>(ValidPersonName, ValidEmail)
                .Run();
        }
    }
}
