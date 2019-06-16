using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    public float Horizontal = 0;
    public float Vertical = 0;
    public bool Action = false;

    void Start()
    {
        Teleporter.OnTeleport.AddListener(ResetControls);
    }
    public void UpdateHorizontal(float value)
    {
        Horizontal = value;
    }

    public void UpdateVertical(float value)
    {
        Vertical = value;
    }

    public void UpdateAction(bool value)
    {
        Action = value;
    }

    private void ResetControls()
    {
        Horizontal = 0f;
        Vertical = 0f;
        Action = false;
    }
}
