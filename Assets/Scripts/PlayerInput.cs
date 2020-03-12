using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static Vector2 ClampMagnitude(Vector2 v, float max, float min)
    {
        double sm = v.sqrMagnitude;
        if (sm > (double)max * (double)max) return v.normalized * max;
        else if (sm < (double)min * (double)min) return v.normalized * min;
        return v;
    }

    public Vector2? GetAimAngle()
    {
        return GetJoystickAngle("HorizontalFire", "VerticalFire");
    }

    public Vector2? GetMovementAngle()
    {
        return GetJoystickAngle("Horizontal", "Vertical");
    }

    private Vector2? GetJoystickAngle(string xAxis, string yAxis)
    {
        Vector2 angle = new Vector2(Input.GetAxis(xAxis), Input.GetAxis(yAxis));
        if (!(angle.x == 0 && angle.y == 0))
        {
            return ClampMagnitude(angle, 1, 1);
        }
        return null;
    }
}
