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

    private Rigidbody2D rb2d;

    [SerializeField] private InteractEventCaller InteractEC;
   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Teleporter.OnTeleportStart.AddListener(delegate { canMove = false; });
        Teleporter.OnTeleportDone.AddListener(delegate { canMove = true; });
    }

    void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractEC.InteractEvent.Invoke(transform.position);
        }
    }

    private void Move()
    {
        if (!canMove)
            return;

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (Input.GetKey(KeyCode.LeftShift))
            movement *= sprintMultiplier;

        rb2d.velocity = movement * speed * Time.fixedDeltaTime;
    }
}
