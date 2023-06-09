using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy.Scripts
{
    public class EnemyAnimationController : MonoBehaviour
    {
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            MovingAnimation();
        }

        private void MovingAnimation()
        {
            var speed = _navMeshAgent.speed;
            _animator.SetFloat("MoveSpeed", speed);
        }
    }
}
