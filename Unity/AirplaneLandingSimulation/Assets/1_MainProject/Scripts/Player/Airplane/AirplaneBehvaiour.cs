using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AirplaneOptions))]
public class AirplaneBehvaiour:MonoBehaviour
{
    private AirplaneOptions _airplaneOptions;

    private void Awake()
    {
        _airplaneOptions = GetComponent<AirplaneOptions>();
    }

    public virtual void Start()
    {
        
    }

    private void SetDefaultPosition(AirplaneOptions targetOptions)
    {
        
    }
}