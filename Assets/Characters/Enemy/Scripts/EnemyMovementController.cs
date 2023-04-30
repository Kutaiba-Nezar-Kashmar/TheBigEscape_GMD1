using System;
using Characters.Shared.Model;
using UnityEngine;
using UnityEngine.AI;
using Weapons.Model;
using Random = UnityEngine.Random;

namespace Characters.Enemy.Scripts
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float patrollingRange;
        [SerializeField] private AIStats aiStats;
        
        private NavMeshAgent _navMeshAgent;
        private Vector3 _wayPoint;
        private bool _isWayPointSet;
       

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void FixedUpdate()
        {
            if (!aiStats.IsInSight && !aiStats.IsInAttack) Patrole();
        }
        
        private void Patrole()
        {
            if (!_isWayPointSet) SetWayPoint();
            if (_isWayPointSet) _navMeshAgent.SetDestination(_wayPoint);
            var distanceBetween = transform.position - _wayPoint;
            if (distanceBetween.magnitude < 1f) _isWayPointSet = false;
        }

        private void SetWayPoint()
        {
            var x = Random.Range(-patrollingRange, patrollingRange);
            var z = Random.Range(-patrollingRange, patrollingRange);

            var position = transform.position;
            _wayPoint = new Vector3(position.x + x,
                position.y, position.z + z);

            if (Physics.Raycast(_wayPoint, -transform.up, 2f, groundMask))
                _isWayPointSet = true;
        }
    }
}