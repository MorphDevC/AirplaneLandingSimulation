using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;


[RequireComponent(typeof(AirplaneSettings))]
public class AirplaneBehvaiour : MonoBehaviour
{
    private AirplaneSettings _airplaneOptions;

    public virtual void Awake()
    {
        _airplaneOptions = GetComponent<AirplaneSettings>();
    }

    public virtual void Start()
    {
        SetDefaultPosition(_airplaneOptions);
    }



    private void SetDefaultPosition(AirplaneSettings targetOptions)
    {
        Debug.Log("G sah been pressed");
    }

}