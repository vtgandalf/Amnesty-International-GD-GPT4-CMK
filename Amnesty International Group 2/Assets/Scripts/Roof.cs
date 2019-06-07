using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Roof : MonoBehaviour
{
    [SerializeField] private List<Renderer> rends;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && rends.Count > 0)
        {
            foreach (Renderer r in rends)
                r.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && rends.Count > 0)
        {
            foreach (Renderer r in rends)
                r.enabled = true;
        }
    }
}
