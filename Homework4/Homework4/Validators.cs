using Homework4.Interfaces;

namespace Homework4;

public class Validator<T>
{
    private readonly List<IValidator<T>> _validators;

    public bool Validate(T model)
    {
        foreach (var validator in _validators)
        {
            if (!validator.Validate(model))
            {
                return false;
            }
        }

        return true;
    }

    public void AddValidator(IValidator<T> validator)
    {
        _validators.Add(validator);
    }
}