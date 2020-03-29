using UnityEngine;
using UnityEngine.EventSystems;

public interface IMovementInputTarget : IEventSystemHandler
{

    void Move(Vector3 direction);

}
