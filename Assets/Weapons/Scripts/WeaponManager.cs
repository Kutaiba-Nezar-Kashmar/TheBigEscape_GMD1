using System;
using System.Collections;
using UnityEngine;
using Weapons.Model;

namespace Weapons.Scripts
{
    public class WeaponManager : MonoBehaviour
    {
        private IFireInput _fireInput;
        private IReloadInput _reloadInput;
        private IWeapon _weapon;

        private void Awake()
        {
            _fireInput = GetComponent<IFireInput>();
            _reloadInput = GetComponent<IReloadInput>();
            _weapon = GetComponentInChildren<IWeapon>();
        }

        private void Start()
        {
            _fireInput.OnFire += Shoot;
            _reloadInput.OnReload += Reload;
        }

        private void Shoot()
        {
            _weapon.ShootWeapon();
        }

        private void Reload()
        {
            _weapon.ReloadWeapon();
        }
    }
}