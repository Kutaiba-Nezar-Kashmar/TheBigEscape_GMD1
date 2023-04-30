using System;
using Characters.Shared.Model;
using UnityEngine;
using UnityEngine.AI;
using Weapons.Model;

namespace Characters.Enemy.Scripts
{
    public class EnemyShootingController : MonoBehaviour
    {
        [SerializeField] private LayerMask targetMask;
        [SerializeField] private float rateOfFire;
        [SerializeField] private AIStats aiStats;
        [SerializeField] private float attackRange;

        private IWeapon _weapon;
        private NavMeshAgent _navMeshAgent;
        private Transform target;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _weapon = GetComponentInChildren<IWeapon>();
            target = GameObject.Find(EnemyTarget.Character_Soldier.ToString())
                .transform;
        }

        private void Start()
        {
            aiStats.AttackRange = attackRange;
        }

        private void FixedUpdate()
        {
            aiStats.IsInAttack = Physics.CheckSphere(transform.position,
                aiStats.AttackRange,
                targetMask);
            if (aiStats.IsInSight && aiStats.IsInAttack) Attack();
        }

        private void Attack()
        {
            _navMeshAgent.SetDestination(transform.position);
            transform.LookAt(target);
            if (aiStats.HasAttacked) return;
            _weapon.ShootWeapon();
            aiStats.HasAttacked = true;
            Invoke(nameof(ResetAttack), rateOfFire);
        }


        private void ResetAttack()
        {
            aiStats.HasAttacked = false;
        }
    }
}