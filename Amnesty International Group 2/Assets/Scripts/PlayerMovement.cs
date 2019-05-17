using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D playerRigidbody;

    private InteractableObject objectInRangeScript = null;
   
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        playerRigidbody.MovePosition(playerRigidbody.position + movement * speed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.E) && objectInRangeScript != null)
        {
            objectInRangeScript.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter");
        if (other.CompareTag("Interactable"))
        {
            objectInRangeScript = other.GetComponent<InteractableObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == objectInRangeScript.gameObject)
        {
            Debug.Log("exit");
            objectInRangeScript = null;
        }
    }
}
