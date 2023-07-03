using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private float _decreaseRateHorizontal = 2f;

    private float _horizontalValue = 0;
    private float _verticalValue = 0;

    private void Start()
    {
        _horizontalValue = 0;
        _verticalValue = 0;
    }

    public void OnLeftButtonDown()
    {
        _horizontalValue = -1;
    }

    public void OnRightButtonDown()
    {
        _horizontalValue = 1;
    }

    public void OnUpButtonDown()
    {
        _verticalValue = 1;
        _horizontalValue = 0;
    }

    public void OnDownButtonDown()
    {
        _verticalValue = -1;
    }

    private void FixedUpdate()
    {
        if (_horizontalValue > 0)
        {
            _horizontalValue -= _decreaseRateHorizontal * Time.deltaTime;
        }
        else if (_horizontalValue < 0)
        {
            _horizontalValue += _decreaseRateHorizontal * Time.deltaTime;
        }

        EventManager.VerticalEvent(_verticalValue);
        EventManager.HorizonalEvent(_horizontalValue);
    }
}
