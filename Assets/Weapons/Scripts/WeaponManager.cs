using System;
using UnityEngine;
using Weapons.Model;

namespace Weapons.Scripts
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private Transform firingOrigin;
        [SerializeField] private float fireRate = 25.0f;
        [SerializeField] private float fireSpeed = 1.0f;
        [SerializeField] private GameObject projectile;
        [SerializeField] private int ammo;
        [SerializeField] private int magSize = 5;
        [SerializeField] private float reloadSpeed = 3;

        private IFireInput _fireInput;

        private void Awake()
        {
            _fireInput = GetComponent<IFireInput>();
        }

        private void Start()
        {
            _fireInput.OnFire += ShootWeapon;
        }
        
        private void ShootWeapon()
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
    }
}