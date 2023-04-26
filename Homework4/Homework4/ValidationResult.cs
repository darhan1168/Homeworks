using Homework4.Interfaces;

namespace Homework4;

public class ValidationResult : IValidationResult
{
    private readonly List<string> _errors;

    public bool IsValid => _errors.Count == 0;

    public ValidationResult()
    {
        _errors = new List<string>();
    }

    public void AddError(string error)
    {
        _errors.Add(error);
    }

    public void AddErrors(IEnumerable<string> errors)
    {
        _errors.AddRange(errors);
    }

    public IEnumerable<string> GetErrors()
    {
        return _errors;
    }
}