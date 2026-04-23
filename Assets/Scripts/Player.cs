using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    [SerializeField] private float _speed = 5;
    [SerializeField] private float _forceUp = 5;
    [SerializeField] private GroundDetection _groundDetection;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _arrow;
    [SerializeField] private Transform _arrowSpawnPoint;
    [SerializeField] private float _shootForce = 20;

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
        _direction.y = _rigidbody2D.linearVelocity.y;

        _rigidbody2D.linearVelocity = _direction;        

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

        CheekShoot();
    }

    private void CheekShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject prefab = Instantiate
                (_arrow, _arrowSpawnPoint.position, Quaternion.identity);

            prefab.GetComponent<Arrow>().SetImpulce(
                _spriteRenderer.flipX ? Vector2.left : Vector2.right , 
                _shootForce, 
                gameObject
            );
        }
    }

    private IEnumerator StartJump()
    {
        _animator.SetTrigger("StartJump");
        yield return new WaitForSeconds(0.1f);
        _rigidbody2D.AddForce(Vector2.up * _forceUp, ForceMode2D.Impulse);
    }

}
