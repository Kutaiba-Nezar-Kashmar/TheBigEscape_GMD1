using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Characters.Player.Scripts
{
    public class PlayerGameManager : MonoBehaviour
    {
        
        public void OnEscapePressed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}