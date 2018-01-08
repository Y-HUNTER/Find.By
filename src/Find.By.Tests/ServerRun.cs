using System.Threading;
using Find.By.Core;
using Find.By.Core.Attributes;
using Find.By.Server;

namespace Find.By.Tests
{
    public class ServerRun
    {
        public static void Main()
        {
            Locator locator = LocatorFactory.CreateLocator("Xpath", "//li");
            Deamon.ShowLocator(locator);
            Thread.Sleep(5 * 60 * 1000);
        }
    }
}
