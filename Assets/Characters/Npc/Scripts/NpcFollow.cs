using Characters.Shared.Scripts;
using UnityEngine;

namespace Characters.Npc.Scripts
{
    public class NpcFollow : MonoBehaviour, IFollow
    {
        [SerializeField] private float distanceFromTarget = 5;

        public void Follow(Transform target)
        {
            // Face the object to follow
            transform.LookAt(target);
            
            // Follow the object on with a given distance
            transform.position = target.position -
                                 transform.forward * distanceFromTarget;
        }
    }
}