using AspNetCore.CQRS.Domain.People;
using AspNetCore.CQRS.Domain.Test.Utils.SocialFeed.Domain.Tests.TestUtils;
using AspNetCore.CQRS.Domain.ValueObjects;
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
        
        [Test]
        public void ChangeName_HasCorrectValue()
        {
            var expectedResult = "new name";
            var person = ValidPerson;
            person.ChangeName(Name.Create(expectedResult).Value);
            Assert.That(person.Name.Value, Is.EqualTo(expectedResult));
        }
    }
}
