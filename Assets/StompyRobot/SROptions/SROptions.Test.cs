using System;
using System.ComponentModel;
using SRDebugger;
using SRDebugger.Services;
using SRF;
using SRF.Service;
using Debug = UnityEngine.Debug;

public partial class SROptions
{
    public static event Action<float> SideMoveSpeedChanging;
    public static event Action<float> ForwardMoveSpeedChanging;

    public static event Action SetBackCameraActive;
    public static event Action SetSideCameraActive;
    public static event Action SetTopCameraActive;

    public static event Action<int> ObstacleHitSpeedChanging;
    public static event Action<int> ObstacleCountChanging;
    
    int _obstacleHitSpeed = 2;
    int _obstacleCount = 1;
    float _sideMoveSpeed = 0.1f;
    float _forwardMoveSpeed = 0.1f;

    [Category("Movement")]
    public float SideMoveSpeed
    {
        get { return _sideMoveSpeed; }
        set
        {
            OnValueChanged("TestFloat", value);
            SideMoveSpeedChanging?.Invoke(value);
            _sideMoveSpeed = value;
        }
    }

    [Category("Movement")]
    public float ForwardMoveSpeed
    {
        get { return _forwardMoveSpeed; }
        set
        {
            OnValueChanged("TestFloat", value);
            ForwardMoveSpeedChanging?.Invoke(value);
            _forwardMoveSpeed = value;
        }
    }

    [Category("Obstacle")]
    public int ObstacleHitSpeed
    {
        get { return _obstacleHitSpeed; }
        set
        {
            ObstacleHitSpeedChanging?.Invoke(value);
            OnValueChanged("TestInt", value);
            _obstacleHitSpeed = value;
        }
    }

    [Category("Obstacle"), NumberRange(1, 3)]
    public int ObstacleCount
    {
        get { return _obstacleCount; }
        set
        {
            ObstacleCountChanging?.Invoke(value);
            OnValueChanged("TestInt", value);
            _obstacleCount = value;
        }
    }

    [Category("Camera")]
    public void Back()
    {
        SetBackCameraActive?.Invoke();
    }
    
    [Category("Camera")]
    public void Side()
    {
        SetSideCameraActive?.Invoke();
    }
    
    [Category("Camera")]
    public void Top()
    {
        SetTopCameraActive?.Invoke();
    }
    
    private void OnValueChanged(string n, object newValue)
    {
        Debug.Log("[SRDebug] {0} value changed to {1}".Fmt(n, newValue));
        OnPropertyChanged(n);
    }

    [Category("SRDebugger")]
    public PinAlignment TriggerPosition
    {
        get { return SRServiceManager.GetService<IDebugTriggerService>().Position; }
        set { SRServiceManager.GetService<IDebugTriggerService>().Position = value; }
    }
}