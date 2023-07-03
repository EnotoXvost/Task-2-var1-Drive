using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class CarController : MonoBehaviour
{
    [SerializeField] private List<AxleInfo> _axleInfos;
    [SerializeField] private float _maxMotorTorque;
    [SerializeField] private float _maxSteeringAngle;

    private float _verticalValue;
    private float _horizontalValue;

    private void Awake()
    {
        EventManager.onVerticalButtonPassed.AddListener(GetVerticalValue);
        EventManager.onHorizontalButtonPassed.AddListener(GetHorizontalValue);
    }

    private void GetVerticalValue(float value)
    {
        _verticalValue = value;
    }

    private void GetHorizontalValue(float value)
    {
        _horizontalValue = value;
    }

    private void FixedUpdate()
    {
        float motor = _maxMotorTorque * _verticalValue;
        float steering = _maxSteeringAngle * _horizontalValue;
        foreach (AxleInfo axleInfo in _axleInfos)
        {
            if (axleInfo.steering == true)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor == true)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    private void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }
        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
}
