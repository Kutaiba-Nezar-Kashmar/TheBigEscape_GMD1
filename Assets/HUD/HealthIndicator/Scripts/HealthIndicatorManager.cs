using System;
using TMPro;
using UnityEngine;

namespace HUD.HealthIndicator.Scripts
{
    public class HealthIndicatorManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI indicator;

        public void SetHealth(int hp, int maxHp)
        {
            indicator.text = $"{hp}/{maxHp}";
        }
    }
}