using UnityEngine;

namespace Characters.Shared.Scripts
{
    public class MovingAnimationController : MonoBehaviour
    {
        private Animator _animator;
        private CharacterController _characterController;
        private static readonly int MovingSpeed = Animator.StringToHash("MovingSpeed");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
        }
        
        private void Update()
        {
            MovingAnimation();
        }

        private void MovingAnimation()
        {
            var speed = _characterController.velocity
                .magnitude;
            _animator.SetFloat(MovingSpeed, speed);
        }
    }
}