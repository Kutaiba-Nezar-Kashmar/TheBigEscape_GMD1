using Characters.Shared.Scripts;
using Input;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class PlayerShootingController : MonoBehaviour, IShoot
    {
        [SerializeField] private Transform firingOrigin;
        [SerializeField] private float fireRate = 25.0f;
        [SerializeField] private float fireSpeed = 1.0f;
        [SerializeField] private GameObject projectile;
        [SerializeField] private int ammo;
        [SerializeField] private int magSize = 5;
        [SerializeField] private float reloadSpeed = 3;

        private InputManager _inputManager;

        private void Awake()
        {
            ammo = magSize;
        }

        private void Start()
        {
            _inputManager = GetComponent<InputManager>();
            _inputManager.ShootingEvent += ShootWeapon;
        }

        public void ShootWeapon()
        {
            ammo--;
            // Create new projectile object. in this case a bullet
            var bullet = Instantiate(projectile, firingOrigin.position,
                firingOrigin.rotation);
            var rigidbody = bullet.GetComponent<Rigidbody>();
            /*
             * Apply force to the bullet to fire in the z-axes direction
             * that is due to the weapon position on the character and animation of shooting
             */
            rigidbody.AddForce(firingOrigin.right * fireRate,
                ForceMode.Impulse);
        }
    }
}