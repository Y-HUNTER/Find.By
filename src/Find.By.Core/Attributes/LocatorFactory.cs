using Find.By.Server;

namespace Find.By.Core
{
    public static class LocatorFactory
    {
        public static Locator CreateLocator(string how, string value)
        {
            switch (how)
            {
                case "ClassName":
                    return new Locator(Server.By.ClassName, value);
                case "CssSelector":
                    return new Locator(Server.By.CssSelector, value);
                case "Id":
                    return new Locator(Server.By.Id, value);
                case "LinkText":
                    return new Locator(Server.By.LinkText, value);
                case "Name":
                    return new Locator(Server.By.Name, value);
                case "PartialLinkText":
                    return new Locator(Server.By.PartialLinkText, value);
                case "TagName":
                    return new Locator(Server.By.TagName, value);
                case "Xpath":
                case "XPath":
                    return new Locator(Server.By.XPath, value);
            }
            return null;
        }
    }
}
