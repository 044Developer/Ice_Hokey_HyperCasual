using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStats
{
    public float ShootForce;
    public float SmoothRotation;
    public int AngleLimits;

    [Range(0, 10)] public int DragLimit;
}
