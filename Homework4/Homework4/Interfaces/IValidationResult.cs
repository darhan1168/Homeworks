namespace Homework4.Interfaces;

public interface IValidationResult
{
    bool IsValid { get; }
    
    void AddError(string error);
    void AddErrors(IEnumerable<string> errors);
    IEnumerable<string> GetErrors();
}