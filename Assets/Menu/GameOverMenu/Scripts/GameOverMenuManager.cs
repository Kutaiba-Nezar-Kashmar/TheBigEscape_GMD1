using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.GameOverMenu.Scripts
{
    public class GameOverMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject menu;

        private void Awake()
        {
            menu.SetActive(false);
        }

        public void Restart()
        {
            menu.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ToMenu()
        {
            menu.SetActive(false);
            SceneManager.LoadScene("Menu");
        }
    }
}