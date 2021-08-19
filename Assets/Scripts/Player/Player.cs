using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _accelerationCoef;
    [SerializeField] private Animator _animator;

    private direction _direction;
    private bool _isGrounded;
    private float _currentSpeed;
    private Transform _transform;

    public enum direction:int
    {
        Left = -1,
        Right = 1
    }

    public direction Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    private void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        checkGround();
        changePlayerDirection();
    }

    private void checkGround()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));
        _isGrounded = hitInfo;
    }

    private void changePlayerDirection()
    {
        Vector3 InverseVector = new Vector3(_transform.localScale.x * -1, _transform.localScale.y, _transform.localScale.z);

            if (_direction == direction.Left && transform.localScale.x > 0)
                _transform.localScale = InverseVector;

            if (_direction == direction.Right && transform.localScale.x < 0)
                _transform.localScale = InverseVector;
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            Vector2 movementVector;
            movementVector = new Vector2(_currentSpeed* (int)_direction, _jumpForce);
            gameObject.GetComponent<Rigidbody2D>().velocity = movementVector;
            _animator.Play("Jump");
        }
        else return;
    }

    public void Move(bool isRunning)
    {
        if (isRunning)
        {
            _animator.Play("Run");
            _currentSpeed = _walkSpeed * _accelerationCoef;
        }
        else
        {
            _animator.Play("Walk");
            _currentSpeed = _walkSpeed;
        }

        Vector2 movementVector;

        if (_isGrounded)
            movementVector = new Vector2(_currentSpeed, 0) * (int)_direction;
        else movementVector = new Vector2(_currentSpeed * (int)_direction, -_jumpForce/_accelerationCoef);

        gameObject.GetComponent<Rigidbody2D>().velocity = movementVector;
    }

}
