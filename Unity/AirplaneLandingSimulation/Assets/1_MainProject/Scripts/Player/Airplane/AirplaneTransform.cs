using UnityEngine;

public class AirplaneTransform : AirplaneBehaviour
{
    public Vector3 DefaultPosition { get; private set; }
    public Vector3 DefaultRotation { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        DefaultPosition = transform.position;
        DefaultRotation = transform.eulerAngles;
        airplaneManagerRef.OnButtonPressed += UpdateTransform;
    }

    protected override void Start()
    {
        UpdateTransform(this);
    }
    
    private void SetPosition(AirplaneSettings targetOptions)
    {
        transform.position = new Vector3(DefaultPosition.x, targetOptions.GetAmountHeight,-targetOptions.GetDistance);
    }

    private void SetRotation(AirplaneSettings targetOptions)
    {
        transform.eulerAngles = new Vector3(DefaultRotation.x+targetOptions.GetGlidePathAngle,DefaultRotation.y,DefaultRotation.z);
    }
    
    public void UpdateTransform(object sender)
    {
        SetPosition(AirplaneOptions);
        SetRotation(AirplaneOptions);
    }

}