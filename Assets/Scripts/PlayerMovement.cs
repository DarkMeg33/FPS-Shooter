using UnityEditorInternal;
using UnityEngine;

enum MovementState
{
    Walking,
    Sprinting
}

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _orientation;

    private Rigidbody _rb;

    private float _speed;
    public float walkSpeed = 10;
    public float sprintSpeed = 15;

    private MovementState _state;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 _moveDirection;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    private void Update()
    {
        SetInputs();
        HandleMovementState();
    }

    private void HandleMovementState()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _state = MovementState.Sprinting;
            _speed = sprintSpeed;
        }
        else
        {
            _state = MovementState.Sprinting;
            _speed = walkSpeed;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void SetInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;
    }

    private void Move()
    {
        _rb.velocity = _moveDirection.normalized * _speed;
    }
}
