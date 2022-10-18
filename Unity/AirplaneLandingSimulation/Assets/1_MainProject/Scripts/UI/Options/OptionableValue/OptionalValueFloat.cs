public class OptionalValueFloat:IOptionableValue<float>
{

    public OptionalValueFloat()
    {
        
    }
    public OptionalValueFloat(float value)
    {
        SetValue(value);
    }
    
    public float OptionalValue { get; private set; }
    public void SetValue(float value)
    {
        OptionalValue = value;
    }
}