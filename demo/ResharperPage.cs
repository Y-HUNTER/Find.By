using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Find.By.Demo
{
    //https://resharper-plugins.jetbrains.com/packages/Find.By/
    public class ResharperPage
    {   
        [FindsBy(How = How.XPath, Using = "//img[@class='logo']")]
        public IWebElement Icon { get; set; }

        [FindsBy(How = How.LinkText, Using = "Download")]
        public IWebElement Download { get; set; }

        [FindsBy(How = How.TagName, Using = "a")]
        public IWebElement AllLinks { get; set; }

        [FindsBy(How = How.TagName, Using = "div")]
        public IWebElement AllDivs { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ol")]
        public IWebElement Spans { get; set; }
    }
}
