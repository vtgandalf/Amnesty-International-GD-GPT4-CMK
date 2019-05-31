using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InteractEC", menuName = "EventCallers/Interact")]
public class InteractEventCaller : ScriptableObject
{
    public UnityEvent InteractEvent = new UnityEvent();
}
