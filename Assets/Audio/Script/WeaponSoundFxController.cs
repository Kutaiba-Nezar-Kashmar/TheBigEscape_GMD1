using Input;
using UnityEngine;

namespace Audio.Script
{
    public class WeaponSoundFxController : MonoBehaviour
    {
        [SerializeField] private GameObject weapon;

        private InputManager _inputManager;
        

        private void Start()
        {
            _inputManager = GetComponent<InputManager>();
        }
    }
}