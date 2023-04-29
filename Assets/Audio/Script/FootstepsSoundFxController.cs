using Characters.Player.Scripts;
using Characters.Shared.Model;
using UnityEngine;

namespace Audio.Script
{
    public class FootstepsSoundFxController : MonoBehaviour
    {
        private AudioSource walkingAudio;
        private AudioSource runningAudio;

        private CharacterController _characterController;
        private ICharacter _character;
        private AudioManager _audioManager;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _audioManager = GetComponent<AudioManager>();
            _character = GetComponent<ICharacter>();
            walkingAudio = _audioManager.FetchSfxAudio("MetalWalk");
            runningAudio = _audioManager.FetchSfxAudio("MetalRun");
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