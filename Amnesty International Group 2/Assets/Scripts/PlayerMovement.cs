using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float sprintMultiplier = 1.5f;
    private bool canMove = true;

    public bool touchControls = false;
    private Rigidbody2D rb2d;
    public UIControls touchUI;

    [SerializeField] private InteractEventCaller InteractEC;
   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Teleporter.OnTeleportStart.AddListener(delegate { canMove = false; });
        Teleporter.OnTeleport.AddListener(delegate { canMove = true; });
    }

    void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractEC.InteractEvent.Invoke();
        }
    }

    private void Move()
    {
        if (!canMove)
            return;

        float moveHorizontal = 0f;
        float moveVertical = 0f;
        if (touchControls)
        {
            moveHorizontal = touchUI.Horizontal;
            moveVertical = touchUI.Vertical;
        }
        else
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
        }
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (Input.GetKey(KeyCode.LeftShift))
            movement *= sprintMultiplier;

        rb2d.velocity = movement * speed * Time.fixedDeltaTime;
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("enter");
    //    if (other.CompareTag("Interactable"))
    //    {
    //        objectInRangeScript = other.GetComponent<InteractableObject>();
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject == objectInRangeScript.gameObject)
    //    {
    //        Debug.Log("exit");
    //        objectInRangeScript = null;
    //    }
    //}
}
