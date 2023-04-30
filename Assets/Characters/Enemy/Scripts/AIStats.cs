using UnityEngine;

namespace Characters.Enemy.Scripts
{
    [CreateAssetMenu(fileName = "AIStats", menuName = "ScriptableObject/AI")]
    public class AIStats : ScriptableObject
    {
        public bool HasAttacked { get; set; }
        public bool IsInSight { get; set; }
        public bool IsInAttack { get; set; }
        public float SightRange { get; set; }
        public float AttackRange { get; set; }
    }
}