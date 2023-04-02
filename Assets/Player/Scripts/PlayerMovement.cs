using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputController input;
    [SerializeField] private float moveSpeed = 25;
    [SerializeField] private float runSpeed = 6;
    [SerializeField] private float jumpHeight = 4;
    [SerializeField] private float gravity = 9.807f;

    private Rigidbody _rigidbody;
    private Vector3 _playerMove = Vector3.zero;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _playerMove = new Vector3(input.MoveInput.x, 0, input.MoveInput.y);
        Move();
        _rigidbody.AddRelativeForce(_playerMove, ForceMode.Force);
    }

    private void Move()
    {
        // make movement constant with the player mass
        var mass = _rigidbody.mass;
        _playerMove = new Vector3(_playerMove.x * moveSpeed * mass,
            _playerMove.y, _playerMove.z * moveSpeed * mass);
    }
}