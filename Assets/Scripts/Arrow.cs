using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour, IObjectDestroyer
{
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _force;
    [SerializeField] private float _timeLife;
    [SerializeField] private TriggerDamage _triggerDamage;

    public TriggerDamage TriggerDamage
    {
        get { return _triggerDamage; }
    }

    private Player _player;

    public float Force
    {
        get { return _force; }
        set { _force = value; }
    }
    
    public void Destroy(GameObject gameObject)
    {
        Debug.Log("One");
        _player.ReturnArrowToPool(this);
    }

    public void SetImpulce(Vector2 direction, float force, Player player)
    {
        _player = player;
        if (direction.x < 0)
            transform.rotation = Quaternion.Euler(
                                        transform.rotation.x,
                                        180f,
                                        transform.rotation.z
                                    );
        _triggerDamage.Init(this);
        _triggerDamage.Parent = _player.gameObject;
        _rigidbody2D.AddForce(direction * _force * force, ForceMode2D.Impulse);
        StartCoroutine(TimeLife());
    }

    private IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(_timeLife);
        this.Destroy(gameObject);
        yield break;
    }

}
