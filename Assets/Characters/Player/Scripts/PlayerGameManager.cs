using System;
using Characters.Player.Model;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class PlayerGameManager : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        private IPauseInput _pauseInput;

        private void Awake()
        {
            _pauseInput = GetComponent<IPauseInput>();
        }

        private void Start()
        {
            _pauseInput.OnPause += Pause;
        }

        private void Pause()
        {
            Debug.Log("PAUSE!!");
            Time.timeScale = 0;
            menu.SetActive(true);
        }
    }
}