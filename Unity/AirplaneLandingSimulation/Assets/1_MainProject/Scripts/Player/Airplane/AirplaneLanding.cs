using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class AirplaneLanding:AirplaneBehaviour
{
    private bool _isButtonPressedTwicly = false;
    protected override void Awake()
    {
        base.Awake();
        airplaneManagerRef.OnButtonPressed += KillLanding;
    }

    private void KillLanding(object obj)
    {
        if (_isButtonPressedTwicly)
        {
            _isButtonPressedTwicly = true;
            return;
        }
        Tween.Kill();
    }

    
    //TODO:Remove OnTrigger make another event (Distance <300)
    private void OnTriggerEnter(Collider other)
    {
        Tween = PreLandingAnimation(10f).OnComplete(() => LandingAnimation(7f));
    }

    private TweenerCore<Quaternion, Quaternion, NoOptions> PreLandingAnimation(float speed)
    {
        var preLandRotation = Quaternion.Euler(-10, transform.localEulerAngles.y, transform.localEulerAngles.z);
        return transform.DORotateQuaternion(preLandRotation, speed);
    }

    private TweenerCore<Quaternion, Quaternion, NoOptions> LandingAnimation(float speed)
    {
        var landRotation = Quaternion.Euler(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
        return transform.DORotateQuaternion(landRotation, speed);
    }
}
