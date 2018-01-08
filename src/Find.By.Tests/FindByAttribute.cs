using System;

namespace Find.By.Tests
{
    internal class FindByAttribute : Attribute
    {
        public FindByAttribute(object cssSelector, string div)
        {
        }
    }
}