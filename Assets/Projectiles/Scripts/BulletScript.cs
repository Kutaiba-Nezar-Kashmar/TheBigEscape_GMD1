using UnityEngine;

namespace Projectiles.Scripts
{
    public class BulletScript : MonoBehaviour
    {
        [SerializeField] private int damage = 10;

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
