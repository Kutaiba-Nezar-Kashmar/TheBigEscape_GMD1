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

        private void Awake()
        {
            _pauseInput = GetComponent<IPauseInput>();
            LoadSoundSettings();
        }

        private void Start()
        {
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