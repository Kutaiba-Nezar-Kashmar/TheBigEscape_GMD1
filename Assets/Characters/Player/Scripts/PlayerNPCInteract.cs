using Characters.Npc.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player.Scripts
{
    public class PlayerNPCInteract : MonoBehaviour
    {
        [SerializeField] private float interactionDiameter = 3.0f;

        private bool _isFollowing = false;

        private void FixedUpdate()
        {
            if (_isFollowing)
            {
                InteractWith();
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _isFollowing = true;
            }
        }

        private void InteractWith()
        {
            var colliders = Physics.OverlapSphere
            (
                transform.position,
                interactionDiameter
            );
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out NpcFollow npcFollow))
                {
                    npcFollow.Follow(transform);
                }
            }
        }
    }
}