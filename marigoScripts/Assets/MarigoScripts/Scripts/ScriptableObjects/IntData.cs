using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Data/Int")]
public class IntData : ScriptableObject
{
    public int value;

    public UnityEvent updateValueEvent, zeroEvent;

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

    private void OnUpdateValue()
    {
        updateValueEvent.Invoke();
        if (value <= 0)
        {
            zeroEvent.Invoke();
        }
    }
}
