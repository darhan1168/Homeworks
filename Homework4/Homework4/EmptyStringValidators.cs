using Homework4.Interfaces;

namespace Homework4;

public class EmptyStringValidators<T> : IValidator<T>
{
    private string _propertyName;

    public EmptyStringValidators(string propertyName)
    {
        _propertyName = propertyName;
    }

    public bool Validate(T model)
    {
        var propertyInfo = model.GetType().GetProperty(_propertyName);

        if (propertyInfo == null)
        {
            return true;
        }

        var value = propertyInfo.GetValue(model);

        return value != null && !string.IsNullOrWhiteSpace(value.ToString());
    }
}