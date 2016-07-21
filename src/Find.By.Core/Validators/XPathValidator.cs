using System;
using System.Xml;
using System.Xml.XPath;
using Find.By.Core.Validators;

namespace Find.By.Core
{
    public class XPathValidator : ValidatorBase
    {
        public XPathValidator(string expression)
        {
            ValidateExpression(expression);
        }

        private void ValidateExpression(string expression)
        {
            XmlDocument document = new XmlDocument();
            var navigator = document.CreateNavigator();
            try
            {
                navigator.Compile(expression);
                IsValid = true;
            }
            catch (ArgumentException exception)
            {
                ErrorMessage = exception.Message;
            }
            catch (XPathException exception)
            {
                ErrorMessage = exception.Message;
            }
        }
    }
}
