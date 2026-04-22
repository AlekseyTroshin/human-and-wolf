using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;

    [SerializeField] private float _speed = 5;
    [SerializeField] private float _forceUp = 5;
    [SerializeField] private GroundDetection _groundDetection;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _isLeft;
    private bool _isRigth;
    private bool _isJump;
    private bool _isJumping;
    private Vector3 _direction;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        _direction = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
            _isRigth = true;

        if (Input.GetKey(KeyCode.A))
            _isLeft = true;

        if (Input.GetKeyDown(KeyCode.Space))
            _isJump = true;
        
    }

    private void FixedUpdate()
    {
        _animator.SetBool("isGrounded", _groundDetection.isGround);

        if (!_isJumping && !_groundDetection.isGround)
        {
            _animator.SetTrigger("StartFall");
        }
        _isJumping = _isJumping && !_groundDetection.isGround;

        if (_isLeft)
            _direction = Vector3.left;

        if (_isRigth)
            _direction = Vector3.right;

        _direction *= _speed;
        _direction.y = rigidbody2d.linearVelocity.y;

        rigidbody2d.linearVelocity = _direction;        

        if (_isJump && _groundDetection.isGround)
        {
            StartCoroutine(StartJump());
            _isJumping = true;
            _groundDetection.isGround = false;
        }

        if (_direction.x > 0)
            _spriteRenderer.flipX = false;
        else if (_direction.x < 0)
            _spriteRenderer.flipX = true;

        _animator.SetFloat("Speed", Math.Abs(_direction.x));

        _isJump = false;
        _isLeft = false;
        _isRigth = false;
    }

    private IEnumerator StartJump()
    {
        _animator.SetTrigger("StartJump");
        yield return new WaitForSeconds(0.1f);
        rigidbody2d.AddForce(Vector2.up * _forceUp, ForceMode2D.Impulse);
    }

}
