using UnityEngine;
using Weapons.Model;

namespace Weapons.Scripts
{
    public class Sniper : MonoBehaviour, IWeapon
    {
        [SerializeField] private GameObject firingOrigin;
        [SerializeField] private float fireRate = 25.0f;
        [SerializeField] private GameObject projectile;
        [SerializeField] private int ammo;
        [SerializeField] private int magSize = 5;
        [SerializeField] private AudioSource audioSource;

        private void Awake()
        {
            ammo = magSize;
        }

        public void ShootWeapon()
        {
            audioSource.Play();
            if (ammo <= 0) return;
            ammo--;
            // Create new projectile object. in this case a bullet
            var bullet = Instantiate(projectile, firingOrigin.transform.position,
                firingOrigin.transform.rotation);
            var rigidbody = bullet.GetComponent<Rigidbody>();
            /*
                 * Apply force to the bullet to fire in the z-axes direction
                 * that is due to the weapon position on the character and animation of shooting
                 */
            rigidbody.AddForce(firingOrigin.transform.right * fireRate,
                ForceMode.Impulse);
        }

        public void ReloadWeapon()
        {
            ammo = magSize;
        }
    }
}