using AspNetCore.CQRS.Domain.ValueObjects;
using NUnit.Framework;

namespace AspNetCore.CQRS.Domain.UnitTest
{
    [TestFixture]
    public class EmailTests
    {
        [TestCase(" ")]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("notanemail.com")]
        [TestCase("stillnotanemail")]
        public void Factory_InvalidInput_IsFailure(string value)
        {
            var maybeName = Email.Create(value);

            Assert.That(maybeName.IsFailure);
        }

        [TestCase("validemail@email.com")]
        [TestCase("a@company.net")]
        public void Factory_ValidInputs_IsSuccess(string value)
        {
            var maybeName = Email.Create(value);

            Assert.That(maybeName.IsSuccess);
        }
    }
}
