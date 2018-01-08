namespace Find.By.Server
{
    public class Locator
    {
        public Locator(By @by, string value)
        {
            By = @by;
            Value = value;
        }

        public By By { get; private set; }

        public string Value { get; private set; }
    }
}
