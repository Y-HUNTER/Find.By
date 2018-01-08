using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace Find.By.Core.Attributes.Parsers
{
    interface ILocatorParser
    {
        Attribute Parse(IAttribute attribute);
    }
}
