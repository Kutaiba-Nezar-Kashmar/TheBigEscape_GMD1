using UnityEngine;
using Weapons.Scripts;

namespace Characters.Player.Scripts
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;
        private PlayerMovementController _playerMovementController;
        private GameObject _weapon;
        private ShootingController _shootingController;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _playerMovementController = GetComponent<PlayerMovementController>();
            _weapon = GameObject.Find("Sniper_2");
            _shootingController = _weapon.GetComponent<ShootingController>();
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
            var isFiring = _shootingController.isFiring;
            if (isFiring)
            {
                print(isFiring);
            }
            _animator.SetBool("IsFiring", isFiring);
        }

    }
}