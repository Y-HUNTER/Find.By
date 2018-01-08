namespace Find.By.Core.Validators
{
    public abstract class ValidatorBase : ILocatorValidator
    {
        public bool IsValid { get; protected set; }
        public string ErrorMessage { get; protected set; }
    }
}
