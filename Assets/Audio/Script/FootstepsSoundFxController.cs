using Characters.Player.Scripts;
using Characters.Shared.Model;
using UnityEngine;

namespace Audio.Script
{
    public class FootstepsSoundFxController : MonoBehaviour
    {
        [SerializeField] private AudioSource walkingAudio;
        [SerializeField] private AudioSource runningAudio;

        private CharacterController _characterController;
        private ICharacter _character;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _character = GetComponent<ICharacter>();
        }

        private void Update()
        {
            PlayFootsteps();
        }

        private void PlayFootsteps()
        {
            if (!_characterController.isGrounded) return;
            if
            (
                _character.IsMoving &&
                !_character.IsRunning &&
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
                _character.IsRunning &&
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