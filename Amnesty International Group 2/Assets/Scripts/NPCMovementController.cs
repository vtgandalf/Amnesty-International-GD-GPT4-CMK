using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementController : MonoBehaviour
{
    private NPCMovement movement;
    public Vector2 locationToGoTo;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        movement = gameObject.GetComponent<NPCMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //GoTo(locationToGoTo);
        GoTo(player.transform.position);
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
