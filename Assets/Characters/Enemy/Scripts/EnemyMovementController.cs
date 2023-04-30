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
        [SerializeField] private LayerMask targetMask;
        [SerializeField] private float patrollingRange;
        [SerializeField] private float sightRange;
        [SerializeField] private float attackRange;
        [SerializeField] private float rateOfFire;

        private IWeapon _weapon;
        private NavMeshAgent _navMeshAgent;
        private Transform target;
        private Vector3 _wayPoint;
        private bool _isWayPointSet;
        private bool _hasAttacked;
        private bool _isInSight;
        private bool _isInAttack;

        private void Awake()
        {
            target = GameObject.Find(EnemyTarget.Character_Soldier.ToString())
                .transform;
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _weapon = GetComponentInChildren<IWeapon>();
        }

        private void FixedUpdate()
        {
            CheckTargetState();
            EnemyBehavior();
        }

        private void CheckTargetState()
        {
            var position = transform.position;
            _isInSight = Physics.CheckSphere(position, sightRange,
                targetMask);
            _isInAttack = Physics.CheckSphere(position, attackRange,
                targetMask);
        }

        private void EnemyBehavior()
        {
            if (!_isInSight && !_isInAttack) Patrole();
            if (_isInSight && !_isInAttack) Chase();
            if (_isInSight && _isInAttack) Attack();
        }

        private void Patrole()
        {
            if (!_isWayPointSet) SetWayPoint();
            if (_isWayPointSet) _navMeshAgent.SetDestination(_wayPoint);
            var distanceBetween = transform.position - _wayPoint;
            if (distanceBetween.magnitude < 1f) _isWayPointSet = false;
        }

        private void Chase()
        {
            _navMeshAgent.SetDestination(target.position);
        }

        private void Attack()
        {
            _navMeshAgent.SetDestination(transform.position);
            transform.LookAt(target);
            if (_hasAttacked) return;
            _weapon.ShootWeapon();
            _hasAttacked = true;
            Invoke(nameof(ResetAttack), rateOfFire);
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

        private void ResetAttack()
        {
            _hasAttacked = false;
        }
    }
}