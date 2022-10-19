using System;
using System.Collections;
using System.IO;
using DG.Tweening;
using UnityEngine;

public class AirplaneFlying : AirplaneBehaviour
{
    [SerializeField]
    private Transform endPoint;
    private bool _isSecondPressed = false;
   

    protected override void Awake()
    {
        base.Awake();
        airplaneManagerRef.OnButtonPressed += PlaneAction;
    }

    private void PlaneAction(object obj)
    {
        if(_isSecondPressed) 
            StopFlying();
        else
            StartCoroutine(FlyToEndPoint());
        _isSecondPressed = !_isSecondPressed;
    }

    private IEnumerator FlyToEndPoint()
    {
        Tween = transform.DOMove(endPoint.position, AirplaneOptions.GetFlyingDuration);
        yield return Tween;
    }

    private void StopFlying()
    {
        Tween.Kill();
    }
}


