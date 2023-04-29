using Audio.Script;
using Characters.Player.Model;
using UnityEngine;
using UnityEngine.Audio;

namespace Scenes.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private AudioMixer audioMixer;
        private IPauseInput _pauseInput;
        private AudioManager _audioManager;

        private void Awake()
        {
            _pauseInput = GetComponent<IPauseInput>();
            LoadSoundSettings();
        }

        private void Start()
        {
            _audioManager = GetComponent<AudioManager>();
            _audioManager.PlayMusicAudio("Alarm");
            _pauseInput.OnPause += Pause;
        }

        private void LoadSoundSettings()
        {
            var audioLevel = PlayerPrefs.GetFloat("Volume");
            audioMixer.SetFloat("MasterAudio", audioLevel);
        }

        private void Pause()
        {
            Debug.Log("PAUSE!!");
            Time.timeScale = 0;
            menu.SetActive(true);
        }
    }
}