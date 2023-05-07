using Characters.Shared.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player.Scripts
{
    public class PlayerMovementController : MonoBehaviour, ICharacter
    {
        [SerializeField] private float walkingSpeed = 3f;
        [SerializeField] private float runningSpeed = 6f;
        [SerializeField] private float rotationSpeed = 10f;

        public bool IsMoving { get; set; }
        public bool IsRunning { get; set; }

        private CharacterController _characterController;
        private Camera _mainCamera;
        private Plane _playerPlane;
        private Vector3 _playerWalkingMovement;
        private Vector3 _playerRunningMovement;
        private bool isMoving;
        private bool isRunning;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            _mainCamera = Camera.main;
            _playerPlane = new Plane(Vector3.up, transform.position);
        }

        private void FixedUpdate()
        {
            Gravity();
            Running();
            IsMoving = isMoving;
            IsRunning = isRunning;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            // Reading the Input
            var movementInput = context.ReadValue<Vector2>();

            // Taking input vector axes and assigning them to the player movement vector
            // Walkng
            _playerWalkingMovement.x = movementInput.x * walkingSpeed;
            _playerWalkingMovement.z = movementInput.y * walkingSpeed;
            // Running
            _playerRunningMovement.x = movementInput.x * runningSpeed;
            _playerRunningMovement.z = movementInput.y * runningSpeed;

            isMoving = movementInput.x != 0 || movementInput.y != 0;
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            isRunning = context.performed;
        }


        /// <summary>
        /// Handle the gravity since no rigidbody is used here,
        /// instead relying on the character controller   
        /// </summary>
        private void Gravity()
        {
            // Check if the player is above or on the ground
            if (_characterController.isGrounded)
            {
                const float groundedGravity = -0.05f;
                _playerWalkingMovement.y = groundedGravity;
                _playerRunningMovement.y = groundedGravity;
            }
            else
            {
                // gravity constant
                const float gravity = -9.8f;
                _playerWalkingMovement.y = gravity;
                _playerRunningMovement.y = gravity;
            }
        }

        /// <summary>
        /// Check the state of the player movement and handle running
        /// </summary>
        private void Running()
        {
            if (isRunning)
            {
                _characterController.Move
                (
                    _playerRunningMovement * Time.deltaTime
                );
            }
            else
            {
                _characterController.Move
                (
                    _playerWalkingMovement * Time.deltaTime
                );
            }
        }

        /// <summary>
        /// Dynamically rotate the player around its Y axis
        /// </summary>
        public void OnRotation(InputAction.CallbackContext context)
        {
            // Read mouse position
            var mousePosition = Mouse.current.position.ReadValue();

            // the ray is a raycast from the main camera to the mouse cursor position
            var ray = _mainCamera.ScreenPointToRay(mousePosition);

            // The playerPlane aligned with the Y axis of the player
            if (!_playerPlane.Raycast(ray, out var enter)) return;

            // calculating the look direction from the player to the hit point on the plane
            var hitPoint = ray.GetPoint(enter);
            var lookDirection = hitPoint - transform.position;
            lookDirection.y = 0;

            // Slerp to smoothly rotate the player object to look in that direction
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(lookDirection),
                rotationSpeed * Time.deltaTime);
        }
    }
}