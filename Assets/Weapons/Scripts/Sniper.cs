﻿using Audio.Script;
using Characters.Player.Scripts;
using UnityEngine;
using Weapons.Model;

namespace Weapons.Scripts
{
    // For now, sniper is the only weapon the player can use and it cannot be equipped by the enemy 
    public class Sniper : MonoBehaviour, IWeapon
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private GameObject firingOrigin;
        [SerializeField] private float fireRate = 25.0f;
        [SerializeField] private GameObject projectile;
        [SerializeField] private int ammo;
        [SerializeField] private int magSize = 10;

        private AudioManager _audioManager;

        private void Awake()
        {
            playerStats.Ammo = ammo;
            ammo = magSize;
        }

        private void Start()
        {
            _audioManager = GetComponent<AudioManager>();
        }

        public void ShootWeapon()
        {
            if (ammo <= 0) return;
            _audioManager.PlaySfxAudio("Sniper");
            ammo--;
            playerStats.Ammo = ammo;
            // Create new projectile object. in this case a bullet
            var bullet = Instantiate(projectile,
                firingOrigin.transform.position,
                firingOrigin.transform.rotation);
            var rigidbody = bullet.GetComponent<Rigidbody>();
            /*
             * Apply force to the bullet to fire in the z-axes direction
             * that is due to the weapon position on the character and animation of shooting
             */
            rigidbody.AddForce(firingOrigin.transform.right * fireRate,
                ForceMode.Impulse);
        }

        public void ReloadWeapon()
        {
            ammo = magSize;
        }

        public int FetchWeaponMagSize()
        {
            return magSize;
        }
    }
}