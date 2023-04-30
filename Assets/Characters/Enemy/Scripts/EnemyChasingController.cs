using System;
using Characters.Shared.Model;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy.Scripts
{
    public class EnemyChasingController : MonoBehaviour
    {
        [SerializeField] private AIStats aiStats;
        [SerializeField] private LayerMask targetMask;
        [SerializeField] private float sightRange;
        
        private Transform target;
        private NavMeshAgent _navMeshAgent;
        
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            target = GameObject.Find(EnemyTarget.Character_Soldier.ToString())
                .transform;
        }

        private void Start()
        {
            aiStats.SightRange = sightRange;
        }

        private void FixedUpdate()
        {
            aiStats.IsInSight = Physics.CheckSphere(transform.position, aiStats.SightRange,
                targetMask);
            
            if ( aiStats.IsInSight && !aiStats.IsInAttack) Chase();
        }
        
        private void Chase()
        {
            _navMeshAgent.SetDestination(target.position);
        }
    }
}