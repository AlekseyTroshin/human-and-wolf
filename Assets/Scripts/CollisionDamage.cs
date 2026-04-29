using System;
using System.Collections;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{

    [SerializeField] private int _damage = 10;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _timeBeetweenSetDamage = 0.5f;

    private Health _health;
    private float _direction;
    private bool _startDamage = true;

    public float Direction
    {
        get { return _direction; }
    }

    private void OnCollisionStay2D(Collision2D collision)
    { 
        bool exists = GameManager.Instance.healthContainer
                        .TryGetValue(collision.gameObject, out _health);

        if (exists)
        {
            if (!_startDamage) return;

            _direction = collision.transform.position.x - transform.position.x;
            _animator.SetFloat("Direction", Math.Abs(_direction));
    
            if (GameManager.Instance.animatorContainer.ContainsKey(collision.gameObject))
            {
                GameManager.Instance
                    .animatorContainer[collision.gameObject].SetTrigger("TakeDamage");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
         bool exists = GameManager.Instance.healthContainer
                        .TryGetValue(collision.gameObject, out _health);

        if (exists)
        {
            if (!_startDamage) return;

    
            if (GameManager.Instance.animatorContainer.ContainsKey(collision.gameObject))
            {
                GameManager.Instance
                    .animatorContainer[collision.gameObject].SetTrigger("TakeDamage");
            }
        }
    }

    public void SetDamage()
    {
        if (!_startDamage) return;
        
        _startDamage = false;

        if (_health != null)
            _health.TakeHit(_damage);

        _health = null;
        _direction = 0;
        _animator.SetFloat("Direction", 0);

        StartCoroutine(StartDamage());
    }

    private IEnumerator StartDamage()
    {
        yield return new WaitForSeconds(_timeBeetweenSetDamage);
        _startDamage = true;

        yield break;
    }

}
