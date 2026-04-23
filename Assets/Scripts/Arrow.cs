using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _force;
    [SerializeField] private float _timeLife;
    [SerializeField] private TriggerDamage _triggerDamage;

    public float Force
    {
        get { return _force; }
        set { _force = value; }
    }

    public void SetImpulce(Vector2 direction, float force, GameObject parent)
    {
        if (direction.x < 0)
            transform.rotation = Quaternion.Euler(
                                        transform.rotation.x,
                                        180f,
                                        transform.rotation.z
                                    );

        _triggerDamage.Parent = parent;
        _rigidbody2D.AddForce(direction * _force * force, ForceMode2D.Impulse);
        StartCoroutine(TimeLife());
    }

    private IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(_timeLife);
        Destroy(gameObject);
        yield break;
    }

}
