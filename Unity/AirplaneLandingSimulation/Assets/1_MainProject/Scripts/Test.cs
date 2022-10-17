using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform EndPoint;
    void Start()
    {
        Debug.Log(Math.Abs(transform.position.z/69.44f*10));
        StartCoroutine(kek());
        
    }

    IEnumerator kek()
    {
        yield return transform.DOMove(EndPoint.position, Math.Abs(transform.position.z/69.44f*10));
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colliderEntered");
        PreLandingAnimation(69.44f*10).OnComplete(() => LandingAnimation(69.44f*10));
        
    }

    private TweenerCore<Quaternion, Quaternion, NoOptions> PreLandingAnimation(float speed)
    {
        var preLandRotation = Quaternion.Euler(85, 0, 0);
        return transform.DORotateQuaternion(preLandRotation, Math.Abs((transform.position.z / speed) * 40));
    }

    private TweenerCore<Quaternion, Quaternion, NoOptions> LandingAnimation(float speed)
    {
        var landRotation = Quaternion.Euler(90, transform.localEulerAngles.y, transform.localEulerAngles.z);
        return transform.DORotateQuaternion(landRotation, Math.Abs(transform.position.z / speed*20));
    }
    

    
}
