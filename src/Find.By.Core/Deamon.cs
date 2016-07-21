using Find.By.Server;

namespace Find.By.Core
{
    public static class Deamon
    {
        private static readonly HostServer Server;

        static Deamon()
        {
            Server = new HostServer();
            Server.Start();
        }

        public static void ShowLocator(Locator locator)
        {
            Server.ShowLocator(locator);
        }
    }
}