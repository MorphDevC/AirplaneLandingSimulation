using System;
using UnityEngine;

[RequireComponent(typeof(AirplaneBehaviour))]
public class AirplaneManager:MonoBehaviour
{
    private AirplaneBehaviour _airplaneBehaviourRef;
    public event Action<object> OnButtonPressed;
    private bool _isButtonPressedTwicly = false;

    private void Awake()
    {
        _airplaneBehaviourRef = GetComponent<AirplaneBehaviour>();
    }

    private void Start()
    {
        _airplaneBehaviourRef.SetListenerOnButtonPress();
    }

    public void InvokeEventOnButtonPressed()
    {
        
        OnButtonPressed?.Invoke(this);
    }
}
