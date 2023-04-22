using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons.Model
{
    public class ReloadInput : MonoBehaviour, IReloadInput, IReload
    {
        public bool IsReload { get; set; }
        public event IReloadInput.ReloadInput OnReload;

        public void ReloadWeapon(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                IsReload = true;
                OnReload?.Invoke();
            }

            if (context.canceled)
            {
                IsReload = false;
            }
        }
    }
}