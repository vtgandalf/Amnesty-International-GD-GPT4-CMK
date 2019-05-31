﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class IsometricObject : MonoBehaviour
{
    private const int isometricRangePerYUnit = 100;
    private Renderer rend;

    [Tooltip("Use this to offset the object slightly in front or behind the Target object")]
    [SerializeField] private int YOffset = 0;

    [Tooltip("Does this object move?")]
    public bool Dynamic = false;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sortingOrder = -(int)(transform.position.y * isometricRangePerYUnit) + YOffset;
    }
    
    private void Update()
    {
        if (Dynamic)
            rend.sortingOrder = -(int)(transform.position.y * isometricRangePerYUnit) + YOffset;
    }
}
