using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace Find.By.Core.Ipr
{
    interface ILocatorParser
    {
        Attribute Parse(IAttribute attribute);
    }
}
