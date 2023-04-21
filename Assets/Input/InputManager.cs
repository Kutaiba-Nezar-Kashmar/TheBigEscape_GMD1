using System;
using UnityEngine;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInputAction _inputAction;
        public bool IsInteracting { get; set; }

        private void Awake()
        {
            _inputAction = new PlayerInputAction();

            // Interacting
            _inputAction.Player.Interact.performed
                += _ => IsInteracting = true;
            _inputAction.Player.Interact.canceled
                += _ => IsInteracting = false;
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