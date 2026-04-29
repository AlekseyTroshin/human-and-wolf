using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour, IObjectDestroyer
{
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _force;
    [SerializeField] private float _timeLife;
    [SerializeField] private TriggerDamage _triggerDamage;

    private float _directionFly;

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
        _player.ReturnArrowToPool(this);
    }

    public void SetImpulce(Vector2 direction, float force, Player player)
    {
        _player = player;
        _triggerDamage.Parent = _player.gameObject;
               
        if (direction.x < 0)
            _directionFly = 180f;
        else
            _directionFly = 0;
            
        transform.rotation = Quaternion.Euler(
                                        transform.rotation.x,
                                        _directionFly,
                                        transform.rotation.z
                                    );


        _triggerDamage.Init(this);
        _rigidbody2D.AddForce(direction * _force * force, ForceMode2D.Impulse);
 
        if (!gameObject.activeSelf) return;
        
        StartCoroutine(TimeLife());
    }

    private IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(_timeLife);
        this.Destroy(gameObject);
        yield break;
    }

}
