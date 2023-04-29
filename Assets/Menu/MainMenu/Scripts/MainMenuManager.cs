using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.MainMenu.Scripts
{
    public class MainMenuManager : MonoBehaviour
    {
        public void OnNewGameButton()
        {
            // The New game button should always load Level 1 
            SceneManager.LoadScene("Level 1");
        }

        public void OnQuitButton()
        {
            Debug.Log("QUIT!!!");
            Application.Quit();
        }
    }
}