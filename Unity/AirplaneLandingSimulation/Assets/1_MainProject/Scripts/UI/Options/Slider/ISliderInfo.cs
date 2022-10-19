using System;

public interface ISliderInfo
{
    event Action<float> OnOptionValueChange;
    float GetCurrentValue { get; }
    float GetMinValue { get; }
    float GetMaxValue { get; }
    void RefreshValues();
    PropertyTag GetTargetTag { get; }
}
