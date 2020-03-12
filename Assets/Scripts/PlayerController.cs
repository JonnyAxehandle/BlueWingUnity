using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed = 1;

    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2? movementAngle = playerInput.GetMovementAngle();
        if (movementAngle != null)
        {
            Vector3 transformation = NormalizeMovementVector(movementAngle ?? Vector2.zero) * Time.deltaTime * Speed;
            transform.Translate(transformation);
        }
    }

    private Vector3 NormalizeMovementVector(Vector2 givenVector)
    {
        return new Vector3(givenVector.x, givenVector.y, 0);
    }
}
