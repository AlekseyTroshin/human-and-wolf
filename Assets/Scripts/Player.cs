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
    [SerializeField] private float _shootForce = 5;

    private bool _isLeft;
    private bool _isRigth;
    private bool _isJump;
    private bool _isJumping;
    private Vector3 _direction;
    private bool _isMove;
    private Coroutine _shotCoroutine;
    private bool _isStartShot;
    

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        _direction = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            _isMove = true;
            _isRigth = true;
        }
            

        if (Input.GetKey(KeyCode.A))
        {
            _isMove = true;
            _isLeft = true;
        }
            

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isMove = true;
            _isJump = true;
        }

        if ((_shotCoroutine != null && _isMove) || (_shotCoroutine != null && _isJumping))
        {
            _animator.SetBool("isShot", false);
            StopCoroutine(_shotCoroutine);
            _isStartShot = false;
        }
            
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
        {
            _direction = Vector3.left;
            _arrowSpawnPoint.localPosition = new Vector3(
                -Math.Abs(_arrowSpawnPoint.localPosition.x),
                _arrowSpawnPoint.localPosition.y,
                _arrowSpawnPoint.localPosition.z
            );
        }
            

        if (_isRigth)
        {
            _direction = Vector3.right;
            _arrowSpawnPoint.localPosition = new Vector3(
                Math.Abs(_arrowSpawnPoint.localPosition.x),
                _arrowSpawnPoint.localPosition.y,
                _arrowSpawnPoint.localPosition.z
            );
        }
            

        _direction *= _speed;
        _direction.y = _rigidbody2D.linearVelocity.y;

        _rigidbody2D.linearVelocity = _direction;        

        if (_isJump && _groundDetection.isGround)
        {
            StartCoroutine(StartJump());
            _isJumping = true;
            _groundDetection.isGround = false;
        }

        if (_isRigth)
            _spriteRenderer.flipX = false;
            
        else if (_direction.x < 0)
            _spriteRenderer.flipX = true;

        _animator.SetFloat("Speed", Math.Abs(_direction.x));

        CheekShoot();

        _isJump = false;
        _isLeft = false;
        _isRigth = false;

    }

    private void CheekShoot()
    {
        if (Input.GetMouseButtonDown(0) && !_isStartShot)
        {
            _isStartShot = true;

            _isMove = false;
            _isJump = false;
            _isLeft = false;
            _isRigth = false;
            _shotCoroutine = null;
            _animator.SetBool("isShot", true);
            _shotCoroutine = StartCoroutine(StartShot());
        }
    }

    private IEnumerator StartJump()
    {
        _animator.SetTrigger("StartJump");
        yield return new WaitForSeconds(0.1f);
        _rigidbody2D.AddForce(Vector2.up * _forceUp, ForceMode2D.Impulse);
    }

    private IEnumerator StartShot()
    {

            yield return new WaitForSeconds(0.2f);  

            GameObject prefab = Instantiate
                (_arrow, _arrowSpawnPoint.position, Quaternion.identity);

            prefab.GetComponent<Arrow>().SetImpulce(
                _spriteRenderer.flipX ? Vector2.left : Vector2.right, 
                0, 
                gameObject
            );

            yield return new WaitForSeconds(0.1f);

            prefab.GetComponent<Arrow>().SetImpulce(
                _spriteRenderer.flipX ? Vector2.left : Vector2.right, 
                _shootForce, 
                gameObject
            );

            _animator.SetBool("isShot", false);
            _shotCoroutine = null;

            yield return new WaitForSeconds(0.5f);

            _isStartShot = false;
        
    }

}
