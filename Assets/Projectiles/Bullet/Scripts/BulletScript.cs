using Projectiles.Shared.Model;
using UnityEngine;

namespace Projectiles.Bullet.Scripts
{
    public class BulletScript : MonoBehaviour
    {
        [SerializeField] private int damage = 10;
        [SerializeField] private float timeToLive = 5.0f;

        private void Start()
        {
            Destroy(gameObject, timeToLive);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var hit = collision.gameObject.GetComponent<IDamageable>();
            if (hit != null)
            {
                collision.gameObject.GetComponent<IDamageable>()
                    .ReceivedDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}