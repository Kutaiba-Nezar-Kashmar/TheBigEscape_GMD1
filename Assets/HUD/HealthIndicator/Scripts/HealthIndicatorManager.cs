using System;
using TMPro;
using UnityEngine;

namespace HUD.HealthIndicator.Scripts
{
    public class HealthIndicatorManager : MonoBehaviour
    {
        private TextMeshProUGUI indicator;

        private void Start()
        {
            indicator = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void SetHealth(int hp, int maxHp)
        {
            indicator.text = $"{hp}/{maxHp}";
        }
    }
}