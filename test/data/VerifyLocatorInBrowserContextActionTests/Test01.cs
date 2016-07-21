namespace N
{
    public class C
    {
        [FindsBy(How = How.XPath, Using = "{caret}.//tr[./td[div[contains(text(),'Description')]]]")]
        public void FooMethod()
        {
        }
    }
}
