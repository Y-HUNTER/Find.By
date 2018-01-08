namespace Find.By.Tests
{
    class Page
    {
        [FindBy(How.CssSelector, "div a")]
        public string Div { get; set; }
    }
}
