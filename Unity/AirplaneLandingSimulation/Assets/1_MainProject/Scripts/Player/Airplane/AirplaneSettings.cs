using System;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneSettings:MonoBehaviour
{
    [SerializeField] private OptionsInfo OptionsInfoReference;
    [SerializeField] private List<AirplaneOptions> _airplaneOptions;
    
    public virtual void Start()
    {
        _airplaneOptions.ForEach(element =>
        {
            element.targetPropertyValue = new OptionalValueFloat(element.targetPropertyValueForEditor);
        });
        SetOptionalValue();
    }
    

    private void SetOptionalValue()
    {
        OptionsInfoReference.RegisterFloatOptionalValue(_airplaneOptions);
    }

    public float GetDistance => _airplaneOptions.GetTargetOptionByTag(PropertyTag.Distance);
    public float GetAirplaneHeight => _airplaneOptions.GetTargetOptionByTag(PropertyTag.AirplaneHeight);
    public float GetGlidePathAngle => _airplaneOptions.GetTargetOptionByTag(PropertyTag.GlidePathAngle);
    public float GetAirplaneSpeed => _airplaneOptions.GetTargetOptionByTag(PropertyTag.AirplaneSpeed);
}

[Serializable]
public class AirplaneOptions
{
    public PropertyTag targetPropertyTag;
    public float targetPropertyValueForEditor;
    public IOptionableValue<float> targetPropertyValue;
}