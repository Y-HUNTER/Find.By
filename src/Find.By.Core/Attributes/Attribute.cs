using System.Collections.Generic;
using Find.By.Core.Attributes.Parsers;
using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace Find.By.Core.Attributes
{
    public class Attribute
    {
        private static readonly List<ILocatorParser> Parsers = new List<ILocatorParser>
        {
            new LocatorParser(),
            new SeleniumLocatorParser()
        };

        public Attribute()
        {
        }

        public static Attribute Parse(IAttribute attribute)
        {
            foreach (ILocatorParser parser in Parsers)
            {
                var locator = parser.Parse(attribute);
                if (locator != null) return locator;
            }
            return new Attribute();
        }

        public bool IsLocator { get; set; }

        public string How { get; set; }

        public string Value { get; set; }

        public ICSharpLiteralExpression ValueExpression { get; set; }
    }
}
