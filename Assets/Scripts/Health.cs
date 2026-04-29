using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField] private int _health;

    private void Start()
    {
        GameManager.Instance.healthContainer.Add(gameObject, this); 
    }

    public void TakeHit(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetHealth(int health)
    {
        _health += health;
    }

}
