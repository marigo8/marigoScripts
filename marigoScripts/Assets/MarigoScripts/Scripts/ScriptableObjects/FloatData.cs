using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Data/Float")]
public class FloatData : ScriptableObject
{
    public float value;

    public FloatData max;
    
    public bool stopAtZero;

    public UnityEvent updateValueEvent, zeroEvent, maxEvent;

    public void AddToValue(float amount)
    {
        value += amount;
        OnUpdateValue();
    }

    public void AddToValue(FloatData data)
    {
        value += data.value;
        OnUpdateValue();
    }

    public void SetValue(float amount)
    {
        value = amount;
        OnUpdateValue();
    }

    public void SetValue(FloatData data)
    {
        value = data.value;
        OnUpdateValue();
    }

    private void OnUpdateValue()
    {
        updateValueEvent.Invoke();
        if (value <= 0f)
        {
            if (stopAtZero) value = 0f;
            zeroEvent.Invoke();
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
