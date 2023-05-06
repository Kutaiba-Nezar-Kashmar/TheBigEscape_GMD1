using UnityEngine;

namespace Characters.Player.Scripts
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObject/Player")]
    public class PlayerStats : ScriptableObject
    {
        public int HitPoints { get; set; }
        public int Ammo { get; set; }
        public int Kills { get; set; }
    }
}