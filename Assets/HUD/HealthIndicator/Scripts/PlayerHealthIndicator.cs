using System;
using Characters.Enemy.HealthBar.Scripts;
using Characters.Player.Scripts;
using HUD.HealthIndicator.Scripts;
using Projectiles.Shared.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace HUD.HealthBar.Scripts
{
    public class PlayerHealthIndicator : MonoBehaviour, IDamageable
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private int hp;
        [SerializeField] private HealthIndicatorManager hpManager;

        private int _maxHp;
        private void Start()
        {
            playerStats.HitPoints = hp;
            _maxHp = hp;
            hpManager.SetHealth(hp, _maxHp);
        }
        
        public void ReceivedDamage(int damage)
        {
            hp -= damage;
            hpManager.SetHealth(hp, _maxHp);
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}