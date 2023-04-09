using UnityEngine;

namespace Projectiles.Scripts
{
    public class BulletScript : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            // Destroy the bullet when colliding with colliders
            Destroy(gameObject);
        }
    }
}
