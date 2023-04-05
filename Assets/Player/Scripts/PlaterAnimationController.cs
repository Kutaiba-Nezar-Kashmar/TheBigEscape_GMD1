using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterAnimationController : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovementController _playerMovementController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovementController = GetComponent<PlayerMovementController>();
    }

    private void Update()
    {
        MovingAnimation();
    }

    private void MovingAnimation()
    {
        var speed = _playerMovementController.CharacterController.velocity
            .magnitude;
        _animator.SetFloat("MovingSpeed", speed);
    }
}