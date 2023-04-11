using UnityEngine;

namespace Characters.HealthBar.Scripts
{
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private Transform camera;

        // Use LateUpdate here to execute the code after the camera finished its behavior in a frame
        private void LateUpdate()
        {
            // Now the health bar will be facing the direction that the camera is looking at
            transform.LookAt(transform.position + camera.forward);
        }
    }
}
