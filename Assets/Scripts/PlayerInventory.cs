using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    
    [SerializeField] private int _amountCouns;
    [SerializeField] private TMP_Text coinsText;
    public BuffReceiver buffReceiver;
    
    private List<Item> _items;

    public List<Item> Items
    {
        get { return _items; }
    }

    private void Start()
    {
        coinsText.text = "0";
        _items = new List<Item>();
        GameManager.Instance.inventory = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (GameManager.Instance.coinContainer.ContainsKey(collision.gameObject))
        {
            _amountCouns++;
            GameManager.Instance.coinContainer[collision.gameObject].StartDestroy();
            coinsText.text = _amountCouns.ToString();
        }

        if (GameManager.Instance.itemsContainer.ContainsKey(collision.gameObject))
        {
            ItemComponent item = GameManager.Instance.itemsContainer[collision.gameObject];
            _items.Add(item.Item);
            item.Destroy(collision.gameObject);
        }
    }

  
}
