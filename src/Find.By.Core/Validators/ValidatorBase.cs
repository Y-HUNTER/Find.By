namespace Find.By.Core.Validators
{
    interface ILocatorValidator
    {
        bool IsValid { get; }
        string ErrorMessage { get; } 
    }

    public abstract class ValidatorBase : ILocatorValidator
    {
        public bool IsValid { get; protected set; }
        public string ErrorMessage { get; protected set; }
    }
}
