using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace API
{
    [TestFixture]
    class BotAPI_should
    {
        [Test]
        public void TestInvalid()
        {
            Assert.Catch<ArgumentException>(async () => await new BotAPI().ExecuteCommand(new[] { "lol" }));
        }
        //TODO: MORE TESTS!

    }
}
