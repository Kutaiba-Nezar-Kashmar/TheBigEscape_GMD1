using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Serialization;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 5.0f;
    [SerializeField] private GameObject projectile;


    private PlayerInputAction _playerInput;
    private Camera _mainCamera;
    private bool _isFiring;

    private void Awake()
    {
        _playerInput = new PlayerInputAction();

        _playerInput.Player.Fire.started += OnFire;
        _playerInput.Player.Fire.performed += OnFire;
        _playerInput.Player.Fire.canceled += OnFire;
    }

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        var click = context.ReadValue<float>();
        print(click);
        if (context.performed)
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        var bullet = Instantiate(projectile, firePoint.position,
            firePoint.rotation);
        var rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(firePoint.right * fireRate, ForceMode.Impulse);
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