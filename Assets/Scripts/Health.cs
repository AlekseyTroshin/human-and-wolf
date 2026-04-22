using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField] private int _health;

    public void TakeHit(int damage)
    {
        _health -= damage;

        Debug.Log("Health - " + _health);

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
