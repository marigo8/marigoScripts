using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Data/Action")]
public class ActionData : ScriptableObject
{
    public UnityAction action;

    public void Raise()
    {
        action?.Invoke();
    }
}