using Input;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;
        private PlayerMovementController _playerMovementController;
        private InputManager _inputManager;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _playerMovementController =
                GetComponent<PlayerMovementController>();
            _inputManager = GetComponent<InputManager>();
        }

        private void Update()
        {
            MovingAnimation();
            ShootingAnimation();
        }

        private void MovingAnimation()
        {
            // Retrieve the speed attribute from the CharacterController
            var speed = _playerMovementController.CharacterController.velocity
                .magnitude;
            _animator.SetFloat("MovingSpeed", speed);
        }

        private void ShootingAnimation()
        {
            //var isFiring = _inputManager.IsFiringInput;

            //_animator.SetBool("IsFiring", isFiring);
        }
    }
}