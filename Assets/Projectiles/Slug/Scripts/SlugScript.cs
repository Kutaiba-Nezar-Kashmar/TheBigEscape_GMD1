using Projectiles.Shared.Scripts;
using UnityEngine;

namespace Projectiles.Slug.Scripts
{
    public class SlugScript : MonoBehaviour
    {
        [SerializeField] private int damage = 20;
        [SerializeField] private float timeToLive = 5.0f;

        private void Start()
        {
            Destroy(gameObject, timeToLive);
        }

        private void OnCollisionEnter(Collision collision)
        {
            // When the bullet collide with a damageable object, then set the damage taken to the bullet damage
            var hit = collision.gameObject.GetComponent<IDamageable>();
            if (hit != null)
            {
                collision.gameObject.GetComponent<IDamageable>().ReceivedDamage(damage);
            }
            // Destroy the bullet when colliding with colliders
            Destroy(gameObject);
        }
    }
}