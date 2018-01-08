namespace Find.By.Core.Validators
{
    public interface ILocatorValidator
    {
        bool IsValid { get; }
        string ErrorMessage { get; }
    }
}