using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnNewGameButton()
    {
        // The New game button should always load Level 1 
        SceneManager.LoadScene("Level 1");
    }

    public void OnContinueButton()
    {
        // Continue the game to the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnOptionsButton()
    {
        
    }

    public void OnQuitButton()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }
}
