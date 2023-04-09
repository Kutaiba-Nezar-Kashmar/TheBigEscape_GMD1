using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Scripts
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float walkingSpeed = 3f; 
        [SerializeField] private float runningSpeed = 6f;
        [SerializeField] private float rotationSpeed = 10f;

        private Camera _mainCamera;
        private Plane _playerPlane;

        public CharacterController CharacterController { get; private set; }
        private PlayerInputAction _playerInput;
        private Vector2 _movementInput;
        private Vector3 _playerWalkingMovement;
        private Vector3 _playerRunningMovement;
        private bool isMoving;
        private bool isRunning;

        private void Awake()
        {
            _playerInput = new PlayerInputAction();
            CharacterController = GetComponent<CharacterController>();

            // Binding Unity Events
            _playerInput.Player.Move.started += OnMove;
            _playerInput.Player.Move.performed += OnMove;
            _playerInput.Player.Move.canceled += OnMove;

            _playerInput.Player.Run.started += OnRun;
            _playerInput.Player.Run.canceled += OnRun;
        }

        private void Start()
        {
            _mainCamera = Camera.main;
            _playerPlane = new Plane(Vector3.up, transform.position);
        }

        private void FixedUpdate()
        {
            PlayerRotation();
            Gravity();
            Running();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            // Reading the Input
            _movementInput = context.ReadValue<Vector2>();
        
            // Taking input vector axes and assigning them to the player movement vector
            // Walkng
            _playerWalkingMovement.x = _movementInput.x * walkingSpeed;
            _playerWalkingMovement.z = _movementInput.y * walkingSpeed;
            // Running
            _playerRunningMovement.x = _movementInput.x * runningSpeed;
            _playerRunningMovement.z = _movementInput.y * runningSpeed;

            isMoving = _movementInput.x != 0 || _movementInput.y != 0;
        }

        private void OnRun(InputAction.CallbackContext context)
        {
            isRunning = context.ReadValueAsButton();
        }


        /// <summary>
        /// Handle the gravity since no rigidbody is used here,
        /// instead relying on the character controller   
        /// </summary>
        private void Gravity()
        {
            // Check if the player is above or on the ground
            if (CharacterController.isGrounded)
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
                CharacterController.Move(_playerRunningMovement * Time.deltaTime);
            }
            else
            {
                CharacterController.Move(_playerWalkingMovement * Time.deltaTime);
            }
        }

        /// <summary>
        /// Dynamically rotate the player around its Y axis
        /// </summary>
        private void PlayerRotation()
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
    
        private void OnEnable()
        {
            _playerInput.Player.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Player.Disable();
        }
    }
}