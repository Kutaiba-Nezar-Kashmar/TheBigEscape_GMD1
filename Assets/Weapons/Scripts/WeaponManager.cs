using System;
using System.Collections;
using UnityEngine;
using Weapons.Model;

namespace Weapons.Scripts
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private Transform firingOrigin;
        [SerializeField] private float fireRate = 25.0f;
        [SerializeField] private GameObject projectile;
        [SerializeField] private int ammo;
        [SerializeField] private int magSize = 5;

        private IFireInput _fireInput;
        private IReloadInput _reloadInput;

        private void Awake()
        {
            _fireInput = GetComponent<IFireInput>();
            _reloadInput = GetComponent<IReloadInput>();
            ammo = magSize;
        }

        private void Start()
        {
            _fireInput.OnFire += ShootWeapon;
            _reloadInput.OnReload += ReloadWeapon;
        }

        private void ShootWeapon()
        {
            if (ammo <= 0) return;
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

        private void ReloadWeapon()
        {
            ammo = magSize;
        }
    }
}