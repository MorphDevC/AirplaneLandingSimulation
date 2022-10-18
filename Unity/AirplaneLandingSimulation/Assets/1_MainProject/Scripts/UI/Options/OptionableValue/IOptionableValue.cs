public interface IOptionableValue<T>
{
    T OptionalValue { get; }
    void SetValue(T value);
}