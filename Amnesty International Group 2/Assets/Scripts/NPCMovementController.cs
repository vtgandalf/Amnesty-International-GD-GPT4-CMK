using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementController : MonoBehaviour
{
    private NPCMovement movement;
    public Vector2 locationToGoTo;
    public List<GameObject> markers;
    int position = 0;
    bool previousTargetReached = false;
    // Start is called before the first frame update
    void Start()
    {
        movement = gameObject.GetComponent<NPCMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(markers.Count!=0)
        {
            FollowMarkers();
        }
    }

    private void FollowMarkers()
    {
        GoTo(markers[position].transform.position);
        if(previousTargetReached != movement.TargetHasBeenReached)
        {
            previousTargetReached = movement.TargetHasBeenReached;
            if(movement.TargetHasBeenReached)
            {
                position++;
                if(position>markers.Count-1)
                {
                    position = 0;
                }
                Debug.Log(position);
            }
        }
    }
    private void GoTo(Vector2 target)
    {
        Vector3 currentPosition = gameObject.transform.position;
        float x = target.x-currentPosition.x;
        float y = target.y-currentPosition.y;
        if(x!=0 || y!=0)
        {
            movement.UpdateHorizontal(x);
            movement.UpdateVertical(y);
        }
    }
}
