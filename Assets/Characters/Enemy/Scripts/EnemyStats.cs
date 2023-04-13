using Characters.HealthBar.Scripts;
using Projectiles.Scripts;
using UnityEngine;

namespace Characters.Enemy.Scripts
{
    public class EnemyStats : MonoBehaviour, IDamageable
    {
        public int HitPoint { get; set; } = 100;
        public HealthBarManager HealthBar;

        private void Start()
        {
            HealthBar.SetObjectMaxHealth(HitPoint);
        }

        public void ReceivedDamage(int damage)
        {
            HitPoint -= damage;
            HealthBar.SetObjectHealthBar(HitPoint);
            if (HitPoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
