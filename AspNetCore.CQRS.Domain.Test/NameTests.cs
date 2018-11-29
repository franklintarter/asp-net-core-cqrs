using AspNetCore.CQRS.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.CQRS.Domain.UnitTest
{
    [TestFixture]
    public class NameTests
    {
        [TestCase(" ")]
        [TestCase("")]
        [TestCase(null)]
        public void Factory_InvalidInput_IsFailure(string value)
        {
            var maybeName = Name.Create(value);

            Assert.That(maybeName.IsFailure);
        }

        [TestCase("a")]
        [TestCase("really really really long name")]
        [TestCase("Normal Name")]
        public void Factory_ValidInputs_IsSuccess(string value)
        {
            var maybeName = Name.Create(value);

            Assert.That(maybeName.IsSuccess);
        }
    }
}
