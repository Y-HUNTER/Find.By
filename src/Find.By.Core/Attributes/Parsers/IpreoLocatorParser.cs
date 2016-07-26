using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace Find.By.Core.Ipr
{
    class IpreoLocatorParser : ILocatorParser
    {
        public Attribute Parse(IAttribute attribute)
        {
            string name = attribute.Name.ShortName;
            if (name == "FindBy" && attribute.Arguments.Count == 2)
            {
                Attribute result = new Attribute
                {
                    IsLocator = true,
                    How = attribute.Arguments[0].Value.ToString().Replace("ReferenceExpression:How.", string.Empty)
                };
                ICSharpExpression locator = attribute.Arguments[1].Value;
                result.ValueExpression = locator as ICSharpLiteralExpression;
                result.Value = locator.ConstantValue.Value as string;
                return result;
            }
            return null;
        }
    }
}
