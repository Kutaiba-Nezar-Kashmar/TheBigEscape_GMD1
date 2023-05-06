using UnityEngine;
using UnityEngine.SceneManagement;

namespace Environment.Level_1.WinCondition.Scripts
{
    public class WinMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        
        private void Awake()
        {
            menu.SetActive(false);
        }

        public void NextLevel()
        {
           Debug.Log("No extra levels...for now");
        }

        public void ToMenu()
        {
            menu.SetActive(false);
            SceneManager.LoadScene("Menu");
        }
    }
}