using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FiredShot : MonoBehaviour
{
    private static float Vector2ToAngle(Vector2 givenVector)
    {
        float givenX = givenVector.x * -1;
        if (givenX < 0)
        {
            return 360 - (Mathf.Atan2(givenX, givenVector.y) * Mathf.Rad2Deg * -1);
        }
        else
        {
            return Mathf.Atan2(givenX, givenVector.y) * Mathf.Rad2Deg;
        }
    }

    public void Fire( float velocity , Vector2 angle )
    {
        GetComponent<Rigidbody2D>().velocity = angle * velocity;
        transform.Rotate(new Vector3(0, 0, Vector2ToAngle(angle)));
        StartCoroutine(SelfDestruct());
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
