using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace Find.By.Core.Attributes.Parsers
{
    public class SeleniumLocatorParser : ILocatorParser
    {
        public Attribute Parse(IAttribute attribute)
        {
            string name = attribute.Name.ShortName;
            if (name == "FindsBy" && attribute.PropertyAssignments.Count >= 2)
            {
                Attribute result = new Attribute
                {
                    IsLocator = true,
                    How = GetHow(attribute)
                };
                result.Value = GetValue(attribute, result);
                return result;
            }
            return null;
        }

        private string GetValue(IAttribute attribute, Attribute result)
        {
            foreach (IPropertyAssignment property in attribute.PropertyAssignments)
            {
                ICSharpIdentifier identifier = ((ICSharpIdentifier)property.FirstChild);
                if (identifier.Name == "Using")
                {
                    var locator = property.LastChild;
                    result.ValueExpression = locator as ICSharpLiteralExpression;
                    return result.ValueExpression.ConstantValue.Value as string;
                }
            }
            return string.Empty;
        }

        private string GetHow(IAttribute attribute)
        {
            foreach (IPropertyAssignment property in attribute.PropertyAssignments)
            {
                ICSharpIdentifier identifier = ((ICSharpIdentifier)property.FirstChild);
                if (identifier.Name == "How")
                {
                    return property.LastChild.ToString().Replace("ReferenceExpression:How.", string.Empty);
                }
            }
            return string.Empty;
        }
    }
}
