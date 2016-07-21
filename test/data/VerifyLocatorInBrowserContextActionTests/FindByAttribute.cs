using System;

namespace N
{
    public class FindByAttribute : Attribute
    {
        public FindByAttribute(string firstArgument, string secondArgument)
        {
        }
    }

    public class How
    {
        public const string Xpath = "XPath";
    }
}
