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
    private Animator animator;
    private bool prevUp = false;
    private bool prevDown = false;
    private bool prevLeft = false;
    private bool prevRight = false;

    [SerializeField] private InteractEventCaller InteractEC;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Teleporter.OnTeleportStart.AddListener(delegate { canMove = false; });
        Teleporter.OnTeleport.AddListener(delegate { canMove = true; });
        animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
        if (touchControls)
        {
            if (touchUI.Action)
            {
                InteractEC.InteractEvent.Invoke();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractEC.InteractEvent.Invoke();
            }
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
        PlayAnimationsWalking(moveHorizontal, moveVertical);
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

    private void PlayAnimationsWalking(float x, float y)
    {
        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;
        switch (x)
        {
            case -1:
                left = true;
                right = false;
                break;

            case 0:
                left = false;
                right = false;
                break;

            case 1:
                left = false;
                right = true;
                break;

            default:
                break;
        }
        switch (y)
        {
            case -1:
                down = true;
                up = false;
                break;

            case 0:
                down = false;
                up = false;
                break;

            case 1:
                down = false;
                up = true;
                break;

            default:
                break;
        }
        if (left & up)
        {
            if (prevLeft)
            {
                up = false;
            }
            if (prevUp)
            {
                left = false;
            }
        }
        if (right & up)
        {
            if (prevRight)
            {
                up = false;
            }
            if (prevUp)
            {
                right = false;
            }
        }
        if (left & down)
        {
            if (prevLeft)
            {
                down = false;
            }
            if (prevDown)
            {
                left = false;
            }
        }
        if (right & down)
        {
            if (prevRight)
            {
                down = false;
            }
            if (prevDown)
            {
                right = false;
            }
        }
        prevDown = down;
        prevUp = up;
        prevLeft = left;
        prevRight = right;
        animator.SetBool("moveLeft", left);
        animator.SetBool("moveRight", right);
        animator.SetBool("moveUp", up);
        animator.SetBool("moveDown", down);
    }
}
