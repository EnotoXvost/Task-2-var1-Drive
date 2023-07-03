using UnityEngine.Events;

internal class EventManager
{
    public static UnityEvent<float> onHorizontalButtonPassed = new UnityEvent<float>();
    public static UnityEvent<float> onVerticalButtonPassed = new UnityEvent<float>();

    public static void VerticalEvent(float value)
    {
        onVerticalButtonPassed?.Invoke(value);
    }

    public static void HorizonalEvent(float value)
    {
        onHorizontalButtonPassed?.Invoke(value);
    }
}

