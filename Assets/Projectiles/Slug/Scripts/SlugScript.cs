using Projectiles.Shared.Model;
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