using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private bool isMovingBack;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private float walkingSpeed = 3f; 
    [SerializeField] private float runningSpeed = 6f;
    [SerializeField] private float rotationSpeed = 10f;

    private CharacterController CharacterController;
    private Camera _mainCamera;
    private Plane _enemyPlane;
    private Vector3 _enemyWalkingMovement;
    private Vector3 _enemyRunningMovement;
    private bool _isRunning;

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        EnemyMove();
        Gravity();
    }

    private void EnemyMove()
    {
        if (isMovingBack)
        {
            navMeshAgent.SetDestination(pointA.position);
            if (!navMeshAgent.pathPending)
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    navMeshAgent.SetDestination(pointB.position);
                    isMovingBack = false;
                }
            }
        }
        else
        {
            navMeshAgent.SetDestination(pointB.position);
            if (!navMeshAgent.pathPending)
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    isMovingBack = true;
                }
            }
        }
    }

    /// <summary>
    /// Handle the gravity since no rigidbody is used here,
    /// instead relying on the character controller   
    /// </summary>
    private void Gravity()
    {
        // Check if the enemy is above or on the ground
        if (CharacterController.isGrounded)
        {
            const float groundedGravity = -0.05f;
            _enemyWalkingMovement.y = groundedGravity;
            _enemyRunningMovement.y = groundedGravity;
        }
        else
        {
            // gravity constant
            const float gravity = -9.8f;
            _enemyWalkingMovement.y = gravity;
            _enemyRunningMovement.y = gravity;
        }
    }
}
