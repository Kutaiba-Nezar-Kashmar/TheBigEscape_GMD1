using Projectiles.Scripts;
using UnityEngine;

namespace Characters.Enemy.Scripts
{
    public class Stats : MonoBehaviour, IDamageable
    {
        public float HitPoint { get; set; } = 100.0f;
        public void ReceivedDamage(float damage)
        {
            HitPoint -= damage;
            if (HitPoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
