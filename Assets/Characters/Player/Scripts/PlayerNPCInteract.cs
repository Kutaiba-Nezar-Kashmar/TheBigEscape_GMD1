using Characters.Npc.Scripts;
using Input;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class PlayerNPCInteract : MonoBehaviour
    {
        [SerializeField] private float interactionDiameter = 3.0f;
        private InputManager _inputManager;
        private bool _isFollowing = false;

        private void Start()
        {
            _inputManager = GetComponent<InputManager>();
        }

        private void FixedUpdate()
        {
            if (_inputManager.IsInteracting)
            {
                _isFollowing = true;
            }

            if (_isFollowing)
            {
                InteractWith();
            }
        }

        private void InteractWith()
        {
            // Check for collider that overlap in a given aria
            // In this case sphere collider is chosen with a set parameter 
            var colliders = Physics.OverlapSphere(transform.position,
                interactionDiameter);
            foreach (var collider in colliders)
            {
                // Check if the collider that the player is overlapping with has
                // a component of type NpcFollow. that is to indicate if that
                // collider belongs to the NPC or not
                if (collider.TryGetComponent(out NpcFollow npcFollow))
                {
                    npcFollow.Follow(transform);
                }
            }
        }
    }
}