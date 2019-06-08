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
}
