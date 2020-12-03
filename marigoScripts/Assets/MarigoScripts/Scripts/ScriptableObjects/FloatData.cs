using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Data/Float")]
public class FloatData : ScriptableObject
{
    public float value;

    public UnityEvent updateValueEvent, zeroEvent;

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
            zeroEvent.Invoke();
        }
    }
}
