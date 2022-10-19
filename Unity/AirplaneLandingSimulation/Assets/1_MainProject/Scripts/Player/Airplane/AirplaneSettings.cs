using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AirplaneSettings:MonoBehaviour
{
    [SerializeField] private OptionsInfo OptionsInfoReference;
    [SerializeField] private List<AirplaneOptions> _airplaneOptions;
    
    public virtual void Awake()
    {
        _airplaneOptions.ForEach(element =>
        {
            element.targetPropertyValue = new OptionalValueFloat(element.targetPropertyValueForEditor);
        });
        
    }

    private void Start()
    {
        SetOptionalValue();
    }

    private void SetOptionalValue()
    {
        OptionsInfoReference.RegisterFloatOptionalValue(_airplaneOptions);
    }
    
    /// <summary>
    /// This field is a sum of <see cref="GetBaseHeight"/> and <see cref="GetAirplaneHeight"/>
    /// </summary>
    public float GetAmountHeight => GetBaseHeight + (GetAirplaneHeight*GetResizableSimulationValue);
    public float GetBaseHeight =>GetGlidePathAngle.Tan() * GetDistance;
    public float GetDistance => _airplaneOptions.GetTargetOptionByTag(PropertyTag.Distance)*1000*GetResizableSimulationValue;
    public float GetAirplaneHeight => _airplaneOptions.GetTargetOptionByTag(PropertyTag.AirplaneHeight);
    public float GetGlidePathAngle => _airplaneOptions.GetTargetOptionByTag(PropertyTag.GlidePathAngle);
    public float GetAirplaneSpeed => (_airplaneOptions.GetTargetOptionByTag(PropertyTag.AirplaneSpeed) * 10*GetResizableSimulationValue)/36;
    public float GetFlyingDuration => GetDistance / (GetAirplaneSpeed);
    
    
    //TODO: take out in other class
    public float GetResizableSimulationValue => 0.1f;
}

[Serializable]
public class AirplaneOptions
{
    public PropertyTag targetPropertyTag;
    public float targetPropertyValueForEditor;
    public IOptionableValue<float> targetPropertyValue;
}