using Homework4.Interfaces;

namespace Homework4;

public class Validator<T>
{
    private readonly List<IValidator<T>> _validators;

    public Validator()
    {
        _validators = new List<IValidator<T>>();
    }

    public ValidationResult Validate(T model)
    {
        var result = new ValidationResult();

        foreach (var validator in _validators)
        {
            try
            {
                validator.Validate(model);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
        }

        return result;
    }

    public void AddValidator(IValidator<T> validator)
    {
        _validators.Add(validator);
    }
}