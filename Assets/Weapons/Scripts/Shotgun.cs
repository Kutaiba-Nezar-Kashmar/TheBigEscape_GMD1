using System;
using System.Collections.Generic;
using Audio.Script;
using UnityEngine;
using UnityEngine.Serialization;
using Weapons.Model;

namespace Weapons.Scripts
{
    public class Shotgun : MonoBehaviour, IWeapon
    {
        [SerializeField] private GameObject firingOrigin;
        [SerializeField] private float projectileSpeed = 20.0f;
        [SerializeField] private GameObject projectile;
        [SerializeField] private int ammo;
        [SerializeField] private int magSize = 5;

         private AudioManager _audioManager;

        private void Awake()
        {
            ammo = magSize;
        }

        private void Start()
        {
           // _audioManager.GetComponent<AudioManager>();
        }

        public void ShootWeapon()
        {   
            // if (ammo <= 0) return;
            //_audioManager.PlaySfxAudio("Shotgun");
            ammo--;
            // Create new projectile object. in this case a slugs
            var slug = Instantiate(projectile,
                firingOrigin.transform.position,
                firingOrigin.transform.rotation);
            var rigidbody = slug.GetComponent<Rigidbody>();
            /*
            * Apply force to the bullet to fire in the z-axes direction
            * that is due to the weapon position on the character and animation of shooting
            */
            rigidbody.AddForce(firingOrigin.transform.right * projectileSpeed,
                ForceMode.Impulse);
        }

        public void ReloadWeapon()
        {
            ammo = magSize;
        }
    }
}