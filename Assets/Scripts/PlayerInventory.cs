using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    
    [SerializeField] private int _amountCouns;
    [SerializeField] private TMP_Text coinsText;

    private void Start()
    {
        coinsText.text = "Количество монет: 0";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (GameManager.Instance.coinContainer.ContainsKey(collision.gameObject))
        {
            _amountCouns++;
            GameManager.Instance.coinContainer[collision.gameObject].StartDestroy();
            coinsText.text = "Количество монет: " + _amountCouns;
        }        
    }

}
