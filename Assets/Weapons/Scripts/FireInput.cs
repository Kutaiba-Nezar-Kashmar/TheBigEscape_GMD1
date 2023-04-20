using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons.Scripts
{
    public class FireInput : MonoBehaviour, IFireInput
    {
        public event IFireInput.FireInput OnFire;

        public void FireWeapon(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnFire?.Invoke();
            }
        }
    }
}