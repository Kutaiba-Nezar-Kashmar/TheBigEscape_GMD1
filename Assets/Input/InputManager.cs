using System;
using UnityEngine;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInputAction _inputAction;
        public Vector2 MovementInput { get; set; }
        public bool IsRunningInput { get; set; }
        public bool IsFiringInput { get; set; }
        public bool IsReloadingInput { get; set; }

        private void Awake()
        {
            _inputAction = new PlayerInputAction();

            // Movement
            _inputAction.Player.Move.performed
                += context =>
                    MovementInput = context.ReadValue<Vector2>();
            _inputAction.Player.Move.canceled
                += _ => MovementInput = Vector2.zero;

            // Running
            _inputAction.Player.Run.performed
                += _ => IsRunningInput = true;
            _inputAction.Player.Run.canceled
                += _ => IsRunningInput = false;

            // Firing
            _inputAction.Player.Fire.performed
                += _ => IsFiringInput = true;
            _inputAction.Player.Fire.canceled
                += _ => IsFiringInput = false;

            // Reloading
            _inputAction.Player.Reload.performed
                += _ => IsReloadingInput = true;
            _inputAction.Player.Reload.canceled
                += _ => IsReloadingInput = false;
        }

        private void OnEnable()
        {
            _inputAction.Player.Enable();
        }

        private void OnDisable()
        {
            _inputAction.Player.Disable();
        }
    }
}