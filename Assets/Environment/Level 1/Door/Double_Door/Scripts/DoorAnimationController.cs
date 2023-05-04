using System;
using UnityEngine;

namespace Environment.Level_1.Door.Double_Door.Scripts
{
    public class DoorAnimationController : MonoBehaviour
    {
        [SerializeField] private float doorSensorRange = 1.0f;
        [SerializeField] private LayerMask player;

        private Animator _animator;
        private static readonly int IsClose = Animator.StringToHash("IsClose");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Physics.CheckSphere(transform.position, doorSensorRange, player))
            {
                Debug.Log("TRUE");
                _animator.SetBool(IsClose, true);
            }
            else
            {
                Debug.Log("FALSE");
                _animator.SetBool(IsClose, false);
            }
        }
    }
}