using System;
using System.Collections;
using DG.Tweening;
using UniRx;
using UnityEngine;

public class AirplaneFlying : AirplaneBehvaiour
{
    public event Action<object> OnButtonPressed;
    
    [SerializeField]
    private Transform endPoint;

    private bool _isSecondPressed = false;
    private Tween _tween;

    public override void Awake()
    {
        base.Awake();
        OnButtonPressed += PlaneAction;
    }

    private void PlaneAction(object obj)
    {
        if(_isSecondPressed) 
            StopFlying();
        else
            StartCoroutine(FlyToEndPoint());
        _isSecondPressed = !_isSecondPressed;
    }

    public override void Start()
    {
        base.Start();
        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.G)).Subscribe (key =>
        {
            OnButtonPressed?.Invoke(this);
        }).AddTo(this); 
    }

    private IEnumerator FlyToEndPoint()
    {
        _tween = transform.DOMove(endPoint.position, Math.Abs(transform.position.z / 69.44f * 10));
        yield return _tween;
    }

    private void StopFlying()
    {
        _tween.Kill();
        transform.position = new Vector3(1619, 36.7f, -1000);
    }
}


