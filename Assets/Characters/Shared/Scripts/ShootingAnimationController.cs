using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Shared.Scripts
{
    public class ShootingAnimationController : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerInput = GetComponent<PlayerInput>();
            
            _playerInput.actions["Fire"].performed += Fire;
            _playerInput.actions["Fire"].canceled += StopFire;
        }

        private void Fire(InputAction.CallbackContext context)
        {
            _animator.SetBool("IsFiring", true);
        }

        private void StopFire(InputAction.CallbackContext context)
        {
            _animator.SetBool("IsFiring", false);
        }
    }
}