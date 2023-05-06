using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.Enemy.HealthBar.Scripts
{
    public class HealthBarManager : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private Gradient gradient;
        [SerializeField] private Image fill;
        [SerializeField] private TextMeshProUGUI text;

        public void SetObjectMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
        
            fill.color = gradient.Evaluate(1f);
            text.SetText($"Health {slider.value}");
        }
    
        public void SetObjectHealthBar(int health)
        {
            slider.value = health;

            /*
         * Use normalizedValue here to to read values from 0 to 1 independently of the max health.
         * That is because gradient is between 0 and 1 
         */
            fill.color = gradient.Evaluate(slider.normalizedValue);
            text.SetText($"Health {slider.value}");
        }
    }
}
