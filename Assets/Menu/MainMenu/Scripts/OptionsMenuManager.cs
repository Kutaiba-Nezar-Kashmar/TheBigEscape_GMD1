using UnityEngine;
using UnityEngine.Audio;

namespace Menu.MainMenu.Scripts
{
    public class OptionsMenuManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        
        public void SetSound(float sound)
        {
            audioMixer.SetFloat("MasterAudio", sound);
            PlayerPrefs.SetFloat("Volume", sound);
        }

        public void SetGraphics(int index)
        {
            /*
             * In the dropdown UI, all of the available quality settings are
             * added in the same order as in the project setting window
             * this way the index chosen from the dropdown menu matches the
             * required quality setting
             */
            QualitySettings.SetQualityLevel(index);
        }

        public void SetIsFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }
    }
}
