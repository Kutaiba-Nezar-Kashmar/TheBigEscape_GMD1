using Characters.Enemy.HealthBar.Scripts;
using Projectiles.Shared.Scripts;
using UnityEngine;

namespace Characters.Enemy.Scripts
{
    public class EnemyHealthIndicator : MonoBehaviour, IDamageable
    {
        [SerializeField] private int hitPoint = 100;
        public HealthBarManager HealthBar;
        
        private void Start()
        {
            HealthBar.SetObjectMaxHealth(hitPoint);
        }

        public void ReceivedDamage(int damage)
        {
            hitPoint -= damage;
            HealthBar.SetObjectHealthBar(hitPoint);
            if (hitPoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
