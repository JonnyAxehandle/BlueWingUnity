using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    private void Update()
    {
        DoMovementInputKeyboard();
        DoWeaponInputMouse();
    }

    private void DoMovementInputKeyboard()
    {
        float x = 0,y = 0;

        x += Input.GetKey(KeyCode.A) ? -1 : 0;
        x += Input.GetKey(KeyCode.D) ? 1 : 0;
        y += Input.GetKey(KeyCode.W) ? 1 : 0;
        y += Input.GetKey(KeyCode.S) ? -1 : 0;

        if (!(x == 0 && y == 0))
        {
            ExecuteEvents.Execute<IMovementInputTarget>(
                gameObject,
                null,
                (handler, data) => handler.Move(new Vector3(x, y, 0))
                );
        }
    }

    private void DoWeaponInputMouse()
    {
        ExecuteEvents.Execute<IWeaponInputTarget>(
                gameObject,
                null,
                (handler, data) => handler.Aim(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)
                );

        if (Input.GetMouseButton(0))
        {
            ExecuteEvents.Execute<IWeaponInputTarget>(gameObject, null, (handler, data) => handler.Fire() );
        }
    }
}
