using System;
using System.Collections;
using Characters.Player.Scripts;
using HUD.AmmoIndecator.Scripts;
using UnityEngine;
using Weapons.Model;

namespace Weapons.Scripts
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private AmmoIndicatorManager ammoManager;
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
            ammoManager.SetAmmo(playerStats.Ammo, _weapon.FetchWeaponMagSize());
            _fireInput.OnFire += Shoot;
            _reloadInput.OnReload += Reload;
        }

        private void Shoot()
        {
            ammoManager.SetAmmo(playerStats.Ammo, _weapon.FetchWeaponMagSize());
            _weapon.ShootWeapon();
        }

        private void Reload()
        {
            _weapon.ReloadWeapon();
        }
    }
}