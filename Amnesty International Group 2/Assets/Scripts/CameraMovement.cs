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

    private void Start()
    {
        if (Target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null && player.transform != null)
                Target = player.transform;

            Teleporter.OnTeleport.AddListener(delegate { transform.position = Target.position; }); // Snaps camera to player when teleporting
        }
    }

    private void Update()
    {
        if (Target != null)
            transform.position = Vector3.SmoothDamp(transform.position, Target.position + TargetOffset, ref velocity, smoothTime, maxSpeed);
    }
}
