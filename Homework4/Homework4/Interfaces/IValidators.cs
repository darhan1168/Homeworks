namespace Homework4.Interfaces;

public interface IValidator<T>
{
    bool Validate(T model);
}