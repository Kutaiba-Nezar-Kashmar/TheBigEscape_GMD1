using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; } = Vector3.zero;
    public Vector2 LookInput { get; private set; } = Vector3.zero;
    private PlayerInputAction _playerAction;
    public bool IsMoveInputPresssed = false;
    private void OnEnable()
    {
        _playerAction = new PlayerInputAction();
        _playerAction.Player.Enable();
        
        //Move
        _playerAction.Player.Move.performed += SetMove;
        _playerAction.Player.Move.canceled += SetMove;
        
        // Look
        _playerAction.Player.Move.performed += SetMove;
        _playerAction.Player.Move.canceled += SetMove;
    }

    private void OnDisable()
    {
        //Move
        _playerAction.Player.Move.performed -= SetMove;
        _playerAction.Player.Move.canceled -= SetMove;
        
        // Look
        _playerAction.Player.Move.performed -= SetMove;
        _playerAction.Player.Move.canceled -= SetMove;
        
        _playerAction.Player.Disable();
    }

    private void SetMove(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector2>();
        IsMoveInputPresssed = !(MoveInput == Vector2.zero);
    }
    private void SetLook(InputAction.CallbackContext ctx)
    {
        LookInput = ctx.ReadValue<Vector2>();
    }
    
    
}
