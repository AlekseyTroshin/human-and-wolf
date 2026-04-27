using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    [SerializeField] private int _amountCouns;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (GameManager.Instance.coinContainer.ContainsKey(collision.gameObject))
        {
            _amountCouns++;
            GameManager.Instance.coinContainer[collision.gameObject].StartDestroy();
        }        
    }

}
