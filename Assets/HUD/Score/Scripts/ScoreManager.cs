using System;
using Characters.Player.Scripts;
using TMPro;
using UnityEngine;

namespace HUD.Score.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private TextMeshProUGUI scoreText;

        private void Update()
        {
            scoreText.text = $"KILLS: {playerStats.Kills}";
        }
    }
}