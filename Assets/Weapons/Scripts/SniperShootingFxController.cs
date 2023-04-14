using System;
using UnityEngine;

namespace Weapons.Scripts
{
    public class SniperShootingFxController : MonoBehaviour, IShootingSoundFx
    {
        private AudioSource _audio;
        private ShootingController _shootingController;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            _shootingController = GetComponent<ShootingController>();
        }

        private void Update()
        {
            PlayShootingAudio();
        }

        public void PlayShootingAudio()
        {
            var weaponData = _shootingController.GetWeaponData();

            if (weaponData.IsFiring)
            {
                _audio.Play();
            }
        }
    }
}