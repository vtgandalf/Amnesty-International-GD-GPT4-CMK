using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementController : MonoBehaviour
{
    private NPCMovement movement;
    public Vector2 locationToGoTo;
    public GameObject MarkersContainer;
    public GameObject MarkersContainer2;

    private List<GameObject> markers = new List<GameObject>();
    private List<GameObject> markers2 = new List<GameObject>();
    int position = 0;
    bool previousTargetReached = false;
    public bool targetReached = false;
    public bool eventHappened = false;
    [SerializeField] private DialogueEventCaller DialogueEC;

    // Start is called before the first frame update
    //[SerializeField] private InteractEventCaller InteractEC;
    void Start()
    {
        DialogueEC.SceneEvent.AddListener(SceneEventAction);
        movement = gameObject.GetComponent<NPCMovement>();
        UpdateMarkers();
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetReached)
        {
            if (markers.Count != 0)
            {
                FollowMarkers(markers);
            }
            if (!eventHappened)
            {
                if (markers2.Count != 0)
                {
                    FollowMarkers(markers2);
                }
            }
        }
    }

    public void UpdateMarkers()
    {
        if (MarkersContainer != null)
        {
            Transform par = MarkersContainer.transform;
            int childCnt = par.childCount;
            for (int i = 0; i < childCnt; i++)
            {
                Transform childX = par.GetChild(i);
                markers.Add(childX.gameObject);
                if (childX == transform)
                {
                    break;
                }
            }
        }
        if (MarkersContainer2 != null)
        {
            Transform par = MarkersContainer.transform;
            int childCnt = par.childCount;
            for (int i = 0; i < childCnt; i++)
            {
                Transform childX = par.GetChild(i);
                markers2.Add(childX.gameObject);
                if (childX == transform)
                {
                    break;
                }
            }
        }
    }

    private void FollowMarkers(List<GameObject> _markers)
    {
        GoTo(_markers[position].transform.position);
        if (previousTargetReached != movement.TargetHasBeenReached)
        {
            previousTargetReached = movement.TargetHasBeenReached;
            if (movement.TargetHasBeenReached)
            {
                position++;
                if (position > _markers.Count - 1)
                {
                    //position = 0;
                    targetReached = true;
                    //if (InteractEC != null) InteractEC.InteractEvent.Invoke(this.gameObject.transform.position);
                }
            }
        }
    }
    private void GoTo(Vector2 target)
    {
        Vector3 currentPosition = gameObject.transform.position;
        float x = target.x - currentPosition.x;
        float y = target.y - currentPosition.y;
        if (x != 0 || y != 0)
        {
            movement.UpdateHorizontal(x);
            movement.UpdateVertical(y);
        }
    }

    private void SceneEventAction(bool x)
    {
        position = 0;
        eventHappened = true;
        targetReached = false;
        Object.Destroy(this.gameObject, 1f);
    }
}
