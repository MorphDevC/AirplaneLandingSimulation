using System;

public interface ISliderInfo
{
    event Action<float> OnOptionValueChange;
    float GetCurrentValue { get; }
    float GetMinValue { get; }
    float GetMaxValue { get; }
    PropertyTag GetTargetTag { get; }
}
