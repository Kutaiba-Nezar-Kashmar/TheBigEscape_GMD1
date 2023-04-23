using Characters.Player.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player.Scripts
{
    public class PauseInput : MonoBehaviour, IPauseInput
    {
        public event IPauseInput.PauseInput OnPause;

        public void Pause(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnPause?.Invoke();
            }
        }
    }
}