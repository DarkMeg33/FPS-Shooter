using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    
    private Rigidbody _rb;
    private float _horizontalMove;
    private float _verticalMove;

    private bool _isJumping = false;
    private float _jump;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        _verticalMove = Input.GetAxisRaw("Vertical");
        _jump = Input.GetAxisRaw("Jump");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
        }
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector3(_horizontalMove, _rb.velocity.y, _verticalMove) * _speed;

        if (_isJumping)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumping = false;
            Debug.Log("Jump");
        }
    }
}
