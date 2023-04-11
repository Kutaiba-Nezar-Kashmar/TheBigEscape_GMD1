using UnityEngine;

namespace Characters.Player.Scripts
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;
        private PlayerMovementController _playerMovementController;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _playerMovementController = GetComponent<PlayerMovementController>();
        }

        private void Update()
        {
            MovingAnimation();
        }

        private void MovingAnimation()
        {
            // Retrieve the speed attribute from the CharacterController
            var speed = _playerMovementController.CharacterController.velocity
                .magnitude;
            _animator.SetFloat("MovingSpeed", speed);
        }
    }
}