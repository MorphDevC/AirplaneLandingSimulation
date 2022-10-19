using DG.Tweening;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(AirplaneSettings))]
public class AirplaneBehaviour : MonoBehaviour
{
    [HideInInspector]
    public AirplaneSettings AirplaneOptions;
    //TODO: Make as interface
    [HideInInspector]
    public AirplaneManager airplaneManagerRef;
    public Tween Tween;


    protected virtual void Awake()
    {
        airplaneManagerRef = GetComponent<AirplaneManager>();
        AirplaneOptions = GetComponent<AirplaneSettings>();
    }

    protected virtual void Start()
    {
       
    }

    public void SetListenerOnButtonPress()
    {
         Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.G)).Subscribe (key =>
         { 
             airplaneManagerRef.InvokeEventOnButtonPressed();
         }).AddTo(this); 
    }
}
