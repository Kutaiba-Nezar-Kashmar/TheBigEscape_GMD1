using System;
using Input;
using UnityEngine;
using Weapons.Model;

namespace Audio.Script
{
    public class WeaponSoundFxController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        private IShoot _shoot;


        private void Start()
        {
            _shoot = GetComponent<IShoot>();
        }

        private void Update()
        {
            if (_shoot.IsShooting)
            {
                audioSource.Play();
            }
            else
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
        }
    }
}