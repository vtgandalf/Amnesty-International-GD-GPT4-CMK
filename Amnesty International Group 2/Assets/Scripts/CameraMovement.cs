using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform Target;
    public Vector3 TargetOffset;
    public float smoothTime;
    public float maxSpeed;

    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
            transform.position = Vector3.SmoothDamp(transform.position, Target.position + TargetOffset, ref velocity, smoothTime, maxSpeed);
    }
}
