using System.Threading;
using Find.By.Core;
using Find.By.Server;
using NUnit.Framework;

namespace Find.By.Tests.Server_tests
{
    [TestFixture]
    public class ServerTest
    {
        [Test]
        public void ServerCreation()
        {
            Locator locator = LocatorFactory.CreateLocator("Xpath", "//li");
            Deamon.ShowLocator(locator);
            Thread.Sleep(5*60*1000);
        }
    }
}
