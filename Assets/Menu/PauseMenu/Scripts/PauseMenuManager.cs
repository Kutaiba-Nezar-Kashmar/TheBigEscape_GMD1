using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.PauseMenu.Scripts
{
    public class PauseMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        private void Awake()
        {
            menu.SetActive(false);
        }

        public void Resume()
        {
            menu.SetActive(false);
            Time.timeScale = 1;
        }

        public void Menu()
        {
            menu.SetActive(false);
            SceneManager.LoadScene("Menu");
        }
    }
}