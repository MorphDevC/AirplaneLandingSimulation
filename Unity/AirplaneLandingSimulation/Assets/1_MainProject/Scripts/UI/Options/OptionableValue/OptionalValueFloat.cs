using System;
using Unity.VisualScripting;

public class OptionalValueFloat:IOptionableValue<float>
{
    public event Action<float> OnNewValueSet; 
    public OptionalValueFloat(float value)
    {
        SetValue(value);
    }
    
    public float OptionalValue { get; private set; }
    public void SetValue(float value)
    {
        OnNewValueSet?.Invoke(value);
        OptionalValue = value;
    }
}