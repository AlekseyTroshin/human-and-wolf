using System;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{

    [SerializeField] private int _damage = 10;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Health _health;
    private float _direction;

    public float Direction
    {
        get { return _direction; }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _health = collision.gameObject.GetComponent<Health>();

        if (_health != null)
        {
            _direction = collision.transform.position.x - transform.position.x;
            _animator.SetFloat("Direction", Math.Abs(_direction));
        }
    }

    public void SetDamage()
    {
        if (_health != null)
            _health.TakeHit(_damage);

        _health = null;
        _direction = 0;
        _animator.SetFloat("Direction", 0);
    }

}
