using TMPro;
using UnityEngine;

namespace HUD.AmmoIndecator.Scripts
{
    public class AmmoIndicatorManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI indicator;

        public void SetAmmo(int ammo, int magaSize)
        {
            indicator.text = $"{ammo} / {magaSize}";
        }
    }
}