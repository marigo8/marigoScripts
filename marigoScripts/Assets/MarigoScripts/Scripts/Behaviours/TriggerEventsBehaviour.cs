using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerEventsBehaviour : EventsBehaviour
{
    public UnityEvent<Collider> triggerEnterEvent, triggerStayEvent, triggerExitEvent;

    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke(other);
    }
    
    private void OnTriggerStay(Collider other)
    {
        triggerStayEvent.Invoke(other);
    }
    
    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent.Invoke(other);
    }
}
