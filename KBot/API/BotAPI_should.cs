using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace KBot.API
{
    [TestFixture]
    class BotAPI_should
    {
        [Test]
        public void TestInvalid()
        {
            Assert.Catch<ArgumentException>(()=>new BotAPI().ExecuteCommand(new[]{"lol"}));
        }

    }

    
}
