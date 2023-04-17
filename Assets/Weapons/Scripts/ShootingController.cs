using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Weapons.Scripts
{
    public class ShootingController : MonoBehaviour
    {
        [SerializeField] private Transform firingOrigin;
        [SerializeField] private float fireRate = 25.0f;
        [SerializeField] private GameObject projectile;
        [SerializeField] private int ammo;
        [SerializeField] private int magSize;
        [SerializeField] private float reloadSpeed;

        private PlayerInputAction _playerInput;
        public bool isFiring;
        private bool _isReloading = false;


        private void Awake()
        {
            _playerInput = new PlayerInputAction();
            ammo = magSize;

            // Binding unity events
            _playerInput.Player.Fire.started += OnFire;
            _playerInput.Player.Fire.performed += OnFire;
            _playerInput.Player.Fire.canceled += OnFire;
        }

        private void OnFire(InputAction.CallbackContext context)
        {
            // Debug 
            var click = context.ReadValue<float>();
            print(click);
         /*
         * Execute Firing only when the mouse is clicked
         * This is done as a game mechanic, since rapid fire is not
         * taken into consideration
         */
            if (_isReloading) return;
            if (ammo <= 0)
            {
                StartCoroutine(ReloadWeapon());
            }

            if (context.performed)
            {
                isFiring = true;
                FireWeapon();
            }

            if (context.canceled)
            {
                isFiring = false;
            }
        }

        private void FireWeapon()
        {
            ammo--;
            // Create new projectile object. in this case a bullet
            var bullet = Instantiate(projectile, firingOrigin.position,
                firingOrigin.rotation);
            var rigidbody = bullet.GetComponent<Rigidbody>();
            /*
         * Apply force to the bullet to fire in the z-axes direction
         * that is due to the weapon position on the character and animation of shooting
         */
            rigidbody.AddForce(firingOrigin.right * fireRate,
                ForceMode.Impulse);
        }

        // Function to start a StartCoroutine to simulate reloading
        private IEnumerator ReloadWeapon()
        {
            _isReloading = true;
            yield return new WaitForSeconds(reloadSpeed);
            ammo = magSize;
            _isReloading = false;
        }

        private void OnEnable()
        {
            _playerInput.Player.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Player.Disable();
        }

        public WeaponData GetWeaponData()
        {
            var weaponData = new WeaponData
            {
                IsFiring = isFiring
            };

            return weaponData;
        }
    }
}