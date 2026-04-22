using UnityEngine;

public class FirstAid : MonoBehaviour
{
    
    [SerializeField] private int _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Health health = collision.gameObject.GetComponent<Health>();

            health.SetHealth(_health);
            Destroy(gameObject);
        }
    }

}
