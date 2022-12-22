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

    private Animator _animator;

    private Rigidbody _rb;

    private float _speed;
    public float WalkSpeed = 10;
    public float SprintSpeed = 15;

    private MovementState _state;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 _moveDirection;
    
    [SerializeField] private float _groundDrag;
    public bool _isGrounded;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private float _airMultiplier;
    private bool _canJump = true;

    private int _animIdSpeed;
    private int _animIdMotionSpeed;
    private int _animIdIsGrounded;
    private int _animIdIsJumping;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _isGrounded = true;
            _rb.drag = _groundDrag;

            _animator.SetBool(_animIdIsGrounded, _isGrounded);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _isGrounded = false;
            _rb.drag = 0;

            _animator.SetBool(_animIdIsGrounded, _isGrounded);
        }
    }

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _animator = GetComponent<Animator>();

        SetAnimationIDs();
    }

    private void SetAnimationIDs()
    {
        _animIdSpeed = Animator.StringToHash("speed");
        _animIdMotionSpeed = Animator.StringToHash("motionSpeed");
        _animIdIsGrounded = Animator.StringToHash("isGrounded");
        _animIdIsJumping = Animator.StringToHash("isJumping");
    }

    private void Update()
    {
        SetInputs();
        HandleMovementState();
        SpeedControl();
    }

    private void SetInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && _canJump && _isGrounded)
        {
            Jump();

            Invoke(nameof(ResetJump), _jumpCooldown);
        }
    }

    private void HandleMovementState()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _state = MovementState.Sprinting;
            _speed = SprintSpeed;
        }
        else
        {
            _state = MovementState.Walking;
            _speed = WalkSpeed;
        }
    }

    private void SpeedControl()
    {
        var flatVelocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);

        if (flatVelocity.magnitude > _speed)
        {
            var limitedVelocity = flatVelocity.normalized * _speed;
            _rb.velocity = new Vector3(limitedVelocity.x, _rb.velocity.y, limitedVelocity.z);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;

        if (_isGrounded)
        {
            _rb.AddForce(_moveDirection.normalized * _speed * 10f, ForceMode.Force);
        }
        else
        {
            _rb.AddForce(_moveDirection.normalized * _speed * 10f * _airMultiplier, ForceMode.Force);
        }

        float currentHorizontalSpeed = new Vector3(_rb.velocity.x, 0.0f, _rb.velocity.z).magnitude;
        _animator.SetFloat(_animIdSpeed, currentHorizontalSpeed);
        _animator.SetFloat(_animIdMotionSpeed, 1f);
    }

    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        _canJump = false;
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);

        _animator.SetBool(_animIdIsJumping, !_canJump);
    }

    private void ResetJump()
    {
        _canJump = true;

        _animator.SetBool(_animIdIsJumping, !_canJump);
    }
}
