using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    
    [SerializeField] private int _damage;
    [SerializeField] private bool _isDestroyAfterCollision;
    [SerializeField] private GameObject _parent;
    private IObjectDestroyer _objectDestroyer;

    public void Init(IObjectDestroyer destroyer)
    {
        _objectDestroyer = destroyer;
    }

    public GameObject Parent
    {
        get { return _parent; }
        set { _parent = value; }
    }

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _parent) return;
        
        Health health = collision.GetComponent<Health>();
        if (health != null)
            health.TakeHit(_damage);

        if (_isDestroyAfterCollision)
        {
            if (_objectDestroyer == null)
            {
                Destroy(gameObject);
            }
            else
            {
                _objectDestroyer.Destroy(gameObject);
            }
        }
            
    }

}

public interface IObjectDestroyer
{
    void Destroy(GameObject gameObject);
}
