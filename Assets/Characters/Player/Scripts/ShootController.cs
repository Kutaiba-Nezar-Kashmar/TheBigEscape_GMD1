using System;
using System.Collections;
using Input;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class ShootController : MonoBehaviour
    {
        [SerializeField] private Transform firingOrigin;
        [SerializeField] private float fireRate = 25.0f;
        [SerializeField] private float fireSpeed = 1.0f;
        [SerializeField] private GameObject projectile;
        [SerializeField] private int ammo;
        [SerializeField] private int magSize = 5;
        [SerializeField] private float reloadSpeed = 3;

        private InputManager _inputManager;
        private bool _isShooting = false;
        private bool _isReadyToShoot = true;
        private int _numberOfProjectiles;

        private void Awake()
        {
            ammo = magSize;
        }

        private void Start()
        {
            _inputManager = GetComponent<InputManager>();
        }

        private void Update()
        {
            var isFiringInput = _inputManager.IsFiringInput;
            _isReadyToShoot = true;
            _isShooting = false;
            if (isFiringInput)
            {
                if (!_isShooting && _isReadyToShoot)
                {
                    ShootWeapon();
                }
            }
        }


        private void ShootWeapon()
        {
            _isReadyToShoot = true;
            _isShooting = false;
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
                _isShooting = true;
                _isReadyToShoot = false;
        }
    }
}