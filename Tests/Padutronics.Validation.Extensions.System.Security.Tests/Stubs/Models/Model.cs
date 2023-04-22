namespace Padutronics.Validation.Extensions.System.Security.Tests.Stubs.Models;

internal sealed class Model<T>
{
    public Model(T value)
    {
        Value = value;
    }

    public T Value { get; }
}