using UnityEngine;
using UnityEngine.Events;

public class Vector3Event : UnityEvent<Vector3> { }

[CreateAssetMenu(fileName = "InteractEC", menuName = "EventCallers/Interact")]
public class InteractEventCaller : ScriptableObject
{
    public Vector3Event InteractEvent = new Vector3Event();
}
