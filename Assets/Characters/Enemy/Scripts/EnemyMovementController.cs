using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy.Scripts
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private Transform pointA;
        [SerializeField] private Transform pointB;
        [SerializeField] private bool isMoving;
        [SerializeField] private NavMeshAgent navMeshAgent;

        private CharacterController _characterController;
        private Camera _mainCamera;
        private Plane _enemyPlane;
        private Vector3 _enemyWalkingMovement;
        private Vector3 _enemyRunningMovement;
        private bool _isRunning;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            EnemyMove();
            Gravity();
        }

        // Script the patrolling of the enemy based on navMesh
        private void EnemyMove()
        {
            /*
         * Check if the object is moving to create a loop between two points
         * Set the object destination to PointA
         * If the navPath is not ready yet
         * Check if the remainingDistance is the same or less than the soppingDistance
         * Then assign a new destination to PointB and set isMovingBack to false
         */
            if (isMoving)
            {
                navMeshAgent.SetDestination(pointA.position);
                if (navMeshAgent.pathPending) return;
                if (!(navMeshAgent.remainingDistance <=
                      navMeshAgent.stoppingDistance)) return;
                navMeshAgent.SetDestination(pointB.position);
                isMoving = false;
            }
            else
            {
                navMeshAgent.SetDestination(pointB.position);
                if (navMeshAgent.pathPending) return;
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    isMoving = true;
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
            if (_characterController.isGrounded)
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
}