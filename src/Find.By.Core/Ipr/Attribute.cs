using System.Collections.Generic;
using Find.By.Core.Ipr;
using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace Find.By.Core
{
    public class Attribute
    {
        private static List<ILocatorParser> _parsers = new List<ILocatorParser>()
        {
            new IpreoLocatorParser(),
            new SeleniumLocatorParser()
        };

        public Attribute()
        {
        }

        public static Attribute Parse(IAttribute attribute)
        {
            foreach (ILocatorParser parser in _parsers)
            {
                Attribute locator = parser.Parse(attribute);
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
