using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    [SerializeField] private int _amountCouns;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            _amountCouns++;
            Destroy(collision.gameObject);
        }        
    }

}
