using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters.Player.Scripts
{
    public class FootstepsSoundFxController : MonoBehaviour
    {
        [SerializeField] private AudioSource walkingAudio;
        [SerializeField] private AudioSource runningAudio;
        private CharacterController _characterController;
        private PlayerMovementController _movementController;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _movementController = GetComponent<PlayerMovementController>();
        }

        private void Update()
        {
            PlayFootsteps();
        }

        private void PlayFootsteps()
        {
            var playerData = _movementController.GetPlayerData();

            if (!_characterController.isGrounded) return;
            if
            (
                playerData.IsMoving &&
                !playerData.IsRunning &&
                !walkingAudio.isPlaying
            )
            {
                runningAudio.Stop();
                // randomize the pitch and volume of each foot step to simulate realistic walking sound
                walkingAudio.volume = Random.Range(0.2f, 0.5f);
                walkingAudio.pitch = Random.Range(0.7f, 1.1f);
                walkingAudio.Play();
            }
            else if
            (
                playerData.IsRunning &&
                !runningAudio.isPlaying
            )
            {
                walkingAudio.Stop();
                // randomize the pitch and volume of each foot step to simulate realistic walking sound
                runningAudio.volume = Random.Range(0.2f, 0.5f);
                runningAudio.pitch = Random.Range(0.7f, 1.1f);
                runningAudio.Play();
            }
        }
    }
}