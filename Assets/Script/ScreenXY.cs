﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ScreenXY
{


    public static float MaxX { get { return GetWorldPos(new Vector3(1, 1, -10)).x; } }
    public static float MinX { get { return GetWorldPos(new Vector3(0, 0, -10)).x; } }
    public static float MaxY { get { return GetWorldPos(new Vector3(1, 1, -10)).y; } }
    public static float MinY { get { return GetWorldPos(new Vector3(0, 0, -10)).y; } }

    private static Vector3 GetWorldPos(Vector3 v)
    {
        return Camera.main.ViewportToWorldPoint(v);
    }

  
}
