using AspNetCore.CQRS.Domain.Test.Utils.SocialFeed.Domain.Tests.TestUtils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.CQRS.Domain.Test
{
    [TestFixture]
    public class PersonTests : BaseUnitTests
    {
        [Test]
        public void CtorTests()
        {
            new ConstructorTests()
                .ThrowWhenAnyInputNull_OtherwiseSucceed<Person>("valid name", "test@email.com")
                .Run();
        }
    }
}
