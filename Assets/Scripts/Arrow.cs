using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _force;

    public float Force
    {
        get { return _force; }
        set { _force = value; }
    }

    public void SetImpulce(Vector2 direction, float force)
    {
        Debug.Log(_rigidbody2D);
        _rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
    }

}
