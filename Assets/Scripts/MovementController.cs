using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Bounds
{
    public float xMin, xMax, yMin, yMax;
}

public class MovementController : MonoBehaviour, IMovementInputTarget
{
    [SerializeField] private float Speed = 1;
    [SerializeField] private Bounds bounds;

    public void Move(Vector3 direction)
    {
        Vector3 normalizedDirection = direction;
        transform.Translate(normalizedDirection * Time.deltaTime * Speed);
        transform.SetPositionAndRotation(ClampedPosition(), transform.rotation);
    }

    private Vector3 ClampedPosition()
    {
        return new Vector3(
            Mathf.Clamp(transform.position.x, bounds.xMin, bounds.xMax),
            Mathf.Clamp(transform.position.y, bounds.yMin, bounds.yMax),
            transform.position.z
            );
    }
}
