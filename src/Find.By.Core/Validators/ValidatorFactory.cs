using Find.By.Core.Attributes;

namespace Find.By.Core.Validators
{
    public static class ValidatorFactory
    {
        public static ILocatorValidator CreateValidator(Attribute attribute)
        {
            switch (attribute.How)
            {
                case "Xpath":
                case "XPath":
                    return new XPathValidator(attribute.Value);
                case "CssSelector":
                    return new CssValidator();
                default:
                    return new FakeValidator();
            }
        }
    }
}
