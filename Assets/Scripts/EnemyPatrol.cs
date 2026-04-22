using System;
using NUnit.Framework;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public Animator animator;

    [SerializeField] private GameObject _leftBorder;
    [SerializeField] private GameObject _rightBorder;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private GroundDetection _groundDetection;
    [SerializeField] private bool _isRightDirection;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CollisionDamage _collisionDamage;

    private void FixedUpdate()
    {
        
        if (_groundDetection.isGround)
        {
            animator.SetFloat("Speed", Math.Abs(_speed));

            if (transform.position.x > _rightBorder.transform.position.x
                || _collisionDamage.Direction < 0)
                _isRightDirection = false;
            else if (transform.position.x < _leftBorder.transform.position.x
                || _collisionDamage.Direction > 0)
                _isRightDirection = true;

            _rigidbody.linearVelocity = _isRightDirection ? Vector2.right : Vector2.left;
            _rigidbody.position *= _speed;
        }

        if (_isRightDirection)
             _spriteRenderer.flipX = true;
        else
             _spriteRenderer.flipX = false;
    }

}
