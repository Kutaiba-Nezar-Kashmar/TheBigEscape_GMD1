using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float runSpeed = 6;
    [SerializeField] private float jumpHeight = 4;
    [SerializeField] private float gravity = 9.807f;

    private PlayerInputAction _playerAction;
    private Vector2 _moveInput;
    private Vector3 direction = Vector3.zero;


    private void Awake()
    {
        _playerAction = new PlayerInputAction();
        _moveInput = _playerAction.Player.Move.ReadValue<Vector2>();
        _playerAction.Player.Move.performed += context =>
            _moveInput = context.ReadValue<Vector2>();
        _moveInput.y = 0f;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var moveX = _moveInput.x;
        var moveZ = _moveInput.y;

        direction = new Vector3(moveX, 0, moveZ).normalized;
        transform.Translate(direction * moveSpeed);
    }

    private void OnEnable()
    {
        _playerAction.Player.Enable();
    }

    private void OnDisable()
    {
        _playerAction.Player.Disable();
    }
}