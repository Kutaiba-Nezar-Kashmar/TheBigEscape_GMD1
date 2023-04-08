using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Serialization;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private Transform weapon;
    [SerializeField] private float bulletSpeed = 10.0f;
    [SerializeField] private float damage = 10.0f;
    [SerializeField] private float fireRate = 5.0f;
    [SerializeField] private float range = 50.0f;
    [SerializeField] private Rigidbody projectile;

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

    private void Update()
    {
        if (_isFiring)
        {
            FireWeapon();
        }
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        var click = context.ReadValue<float>();
        print(click);
        if (context.performed)
        {
            if (_isFiring == true) return;
            _isFiring = true;
        }
        else if (context.canceled)
        {
            if (_isFiring == false) return;
            _isFiring = false;
        }
    }

    private void FireWeapon()
    {
        var bullet = Instantiate(projectile, weapon.position,
            Quaternion.identity);
        bullet.AddForce(bullet.transform.forward * fireRate);
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