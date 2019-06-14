using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private InteractEventCaller InteractEC;
    [SerializeField] private DialogueEventCaller DialogueEC;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private SpriteRenderer emoteRenderer;
    [SerializeField] private Sprite[] emotes;
    public void Interact(Vector3 playerPos)
    {
        if (dialogue)
        {
            RotateToPlayer(playerPos); // Function not finished
            DialogueEC.DialogueEvent.Invoke(dialogue);
            DialogueEC.DialogueEvent.AddListener(EndDialog);
            DialogueEC.EmoteEvent.AddListener(SetActiveEmote);
            SetActiveEmote(-1);
        }
    }

    private void EndDialog(Dialogue newDialogue)
    {
        if (DialogueEC.Dialogging)
            return;

        Debug.Log("Dialogue has Ended!");
        dialogue = newDialogue;

        DialogueEC.DialogueEvent.RemoveListener(EndDialog);
        DialogueEC.EmoteEvent.RemoveListener(SetActiveEmote);
        SetActiveEmote(0);
    }

    public void SetActiveEmote(int emoteIndex)
    {
        if (emoteRenderer == null)
            return;

        if (emoteIndex < 0 || emoteIndex > emotes.Length - 1)
        {
            emoteRenderer.enabled = false;
            emoteRenderer.sprite = null;
        }
        else
        {
            emoteRenderer.enabled = true;
            emoteRenderer.sprite = emotes[emoteIndex];
        }
    }

    private void RotateToPlayer(Vector3 playerPos)
    {
        Vector3 direction = playerPos - transform.position;
        /* // Still need a way to rotate npc
        if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
            direction.x >= 0 ? LookRight : LookLeft
        else direction.y >= 0 ? LookUp : LookDown
        */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogue != null)
            {
                InteractEC.InteractEvent.AddListener(Interact);

                SetActiveEmote(0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InteractEC.InteractEvent.RemoveListener(Interact);

            SetActiveEmote(-1);
        }
    }
}