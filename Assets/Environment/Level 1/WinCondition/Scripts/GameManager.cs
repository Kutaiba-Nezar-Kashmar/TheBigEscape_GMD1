using System;
using TMPro;
using UnityEngine;

namespace Environment.Level_1.WinCondition.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private LayerMask escapePoint;
        [SerializeField] private float winAriaRange = 1.0f;
        [SerializeField] private GameObject winText;

        private void Update()
        {
            if (Physics.CheckSphere(transform.position,
                    winAriaRange,
                    escapePoint))
            {
                Time.timeScale = 0;
                winText.SetActive(true);
            }
        }
    }
}