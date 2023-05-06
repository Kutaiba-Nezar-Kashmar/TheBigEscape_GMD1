using System;
using Characters.HealthBar.Scripts;
using Characters.Player.Scripts;
using Projectiles.Shared.Scripts;
using UnityEngine;

namespace HUD.HealthBar.Scripts
{
    public class PlayerHealthIndicator : MonoBehaviour, IDamageable
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private Canvas hud;
        [SerializeField] private int hp;
        private HealthBarManager _healthBarManager;

        private void Awake()
        {
            playerStats.HitPoints = hp;
            _healthBarManager = hud.GetComponentInChildren<HealthBarManager>();
        }

        private void Start()
        {
            _healthBarManager.SetObjectMaxHealth(playerStats.HitPoints);
        }
        
        public void ReceivedDamage(int damage)
        {
            var hitPoint = playerStats.HitPoints;
            hitPoint -= damage;
            _healthBarManager.SetObjectHealthBar(hitPoint);
            if (hitPoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}