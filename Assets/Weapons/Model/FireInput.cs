using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons.Model
{
    public class FireInput : MonoBehaviour, IFireInput, IShoot
    {
        public bool IsShooting { get; set; }
        public event IFireInput.FireInput OnFire;

        public void FireWeapon(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                IsShooting = true;
                OnFire?.Invoke();
            }

            if (context.canceled)
            {
                IsShooting = false;
            }
        }
    }
}