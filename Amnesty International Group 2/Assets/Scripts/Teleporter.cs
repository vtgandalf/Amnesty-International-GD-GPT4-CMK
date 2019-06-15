using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Teleporter : MonoBehaviour
{
    public static UnityEvent OnTeleportStart = new UnityEvent();
    public static UnityEvent OnTeleportReady = new UnityEvent();
    public static UnityEvent OnTeleport = new UnityEvent();
    public static UnityEvent OnTeleportDone = new UnityEvent();

    public Transform Destination;
    private Transform playerRef;
    public SceneEventHandler SceneEventHandler;
    public bool outOfScene1 = false;
    public bool outOfScene2 = false;
    public bool outOfScene3 = false;
    public bool outOfScene4 = false;
    public bool outOfScene5and7 = false;
    public bool outOfScene6 = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Destination != null)
        {
            playerRef = collision.transform;
            OnTeleportReady.AddListener(Teleport);
            OnTeleportStart.Invoke();
        }
    }

    // Waits for fadeout to be completed
    private void Teleport()
    {
        OnTeleportReady.RemoveListener(Teleport);
        if (playerRef)
        {
            playerRef.transform.position = Destination.position;
            OnTeleport.Invoke();
            playerRef = null;
            if(outOfScene1)
            {
                SceneEventHandler.Scene1Event.Invoke(true);
            }
            if(outOfScene2)
            {
                SceneEventHandler.Scene2Event.Invoke(true);
            }
            if(outOfScene3)
            {
                SceneEventHandler.Scene3Event.Invoke(true);
            }
            if(outOfScene4)
            {
                SceneEventHandler.Scene4Event.Invoke(true);
            }
            if(outOfScene5and7)
            {
                SceneEventHandler.Scene5Event.Invoke(true);
                SceneEventHandler.Scene7Event.Invoke(true);
            }
            if(outOfScene6)
            {
                SceneEventHandler.Scene6Event.Invoke(true);
            }
        }
    }
}
