using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons.Scripts
{
    public class ShootingController : MonoBehaviour
    {
        [SerializeField] private Transform weapon;
        [SerializeField] private float fireRate = 5.0f;
        [SerializeField] private GameObject projectile;

        private PlayerInputAction _playerInput;
        private bool _isFiring;

        private void Awake()
        {
            _playerInput = new PlayerInputAction();

            // Binding unity events
            _playerInput.Player.Fire.started += OnFire;
            _playerInput.Player.Fire.performed += OnFire;
            _playerInput.Player.Fire.canceled += OnFire;
        }

        private void OnFire(InputAction.CallbackContext context)
        {
            // Debug 
            var click = context.ReadValue<float>();
            print(click);

            /*
         * Execute Firing only when the mouse is clicked
         * This is done as a game mechanic, since rapid fire is not
         * taken into consideration
         */
            if (context.performed)
            {
                _isFiring = true;
                FireWeapon();
            }

            if (context.canceled)
            {
                _isFiring = false;
            }
        }

        private void FireWeapon()
        {
            // Create new projectile object. in this case a bullet
            var bullet = Instantiate(projectile, weapon.position,
                weapon.rotation);
            var rigidbody = bullet.GetComponent<Rigidbody>();
            /*
         * Apply force to the bullet to fire in the z-axes direction
         * that is due to the weapon position on the character and animation of shooting
         */
            rigidbody.AddForce(weapon.right * fireRate, ForceMode.Impulse);
        }

        private void OnEnable()
        {
            _playerInput.Player.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Player.Disable();
        }

        public WeaponData GetWeaponData()
        {
            var weaponData = new WeaponData
            {
                IsFiring = _isFiring
            };

            return weaponData;
        }
    }
}