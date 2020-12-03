using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Data/Int")]
public class IntData : ScriptableObject
{
    public int value;

    public IntData max;

    public bool stopAtZero;

    public UnityEvent updateValueEvent, zeroEvent, maxEvent;

    public void AddToValue(int amount)
    {
        value += amount;
        OnUpdateValue();
    }

    public void AddToValue(IntData data)
    {
        value += data.value;
        OnUpdateValue();
    }

    public void SetValue(int amount)
    {
        value = amount;
        OnUpdateValue();
    }

    public void SetValue(IntData data)
    {
        value = data.value;
        OnUpdateValue();
    }

    public void SetValueToMax()
    {
        if (max == null) return;
        SetValue(max);
    }

    private void OnUpdateValue()
    {
        updateValueEvent.Invoke();
        if (value <= 0)
        {
            zeroEvent.Invoke();
            if (stopAtZero) value = 0;
        }

        if (max != null)
        {
            if (value > max.value)
            {
                value = max.value;
                maxEvent.Invoke();
            }
        }
    }
}
