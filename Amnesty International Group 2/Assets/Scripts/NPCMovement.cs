using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NPCMovement : MonoBehaviour
{
    public float Horizontal = 0;
    public float Vertical = 0;
    public bool shouldMove = true;
    public float speed;
    private Animator animator;
    private bool prevUp = false;
    private bool prevDown = false;
    private bool prevLeft = false;
    private bool prevRight = false;
    private bool canMove = true;
    private Rigidbody2D rb2d;
    private bool targetHasBeenReached = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (shouldMove)
        {
            Move();
        }
    }

    private void Move()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;
        if(Horizontal+Vertical>1)
        {
            Horizontal = 0.5f;
            Vertical = 0.5f;
        }
        if (Horizontal == 0 && Vertical == 0)
        {
            targetHasBeenReached = true;
        }
        else
        {
            targetHasBeenReached = false;
        }
        moveHorizontal = Horizontal;
        moveVertical = Vertical;
        PlayAnimationsWalking(moveHorizontal, moveVertical);
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * speed * Time.fixedDeltaTime;
    }

    private void PlayAnimationsWalking(float x, float y)
    {
        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;
        if (x < 0) x = -1f;
        if (y < 0) y = -1f;
        if (x > 0) x = 1f;
        if (y > 0) y = 1f;
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
        animator.SetBool("left", left);
        animator.SetBool("right", right);
        animator.SetBool("up", up);
        animator.SetBool("down", down);
    }

    public void UpdateHorizontal(float value)
    {
        if (value < 1 && value > -1)
        {
            value = 0;
        }
        if (value > 1)
        {
            value = 1;
        }
        if (value < -1)
        {
            value = -1;
        }
        Horizontal = value;
    }

    public void UpdateVertical(float value)
    {
        if (value < 0.1 && value > -0.1)
        {
            value = 0;
        }
        if (value > 1)
        {
            value = 1;
        }
        if (value < -1)
        {
            value = -1;
        }
        Vertical = value;
    }

    public bool TargetHasBeenReached { get { return this.targetHasBeenReached; } }
}
