using UnityEngine;
using UnityEngine.EventSystems;

public interface IWeaponInputTarget : IEventSystemHandler
{

    void Aim(Vector2 aimDirection);
    void Fire();

}
