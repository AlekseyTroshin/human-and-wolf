using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item Database", menuName = "Databases/Items")]

public class ItemBase : ScriptableObject
{

    [SerializeField, HideInInspector] private List<Item> _items;
    [SerializeField] private Item _currentItem;

    private int _currentIndex;

    public void CreateItem ()
    {
        if (_items == null)
        {
            _items = new List<Item>();
            Debug.Log("CREATE");
        }

        Item item = new Item();
        _items.Add(item);
        _currentItem = item;
        _currentIndex = _items.Count;
    }

    public void DeleteItem()
    {
        if (_items == null || _currentItem == null) return;

        _items.Remove(_currentItem); 

        if (_items.Count > 0)
            _currentItem = _items[0];
        _currentIndex = 0;
    }

    public void NextItem()
    {
        if (_currentIndex < _items.Count)
        {
            _currentItem = _items[_currentIndex];
            _currentIndex++;
        }
    }

    public void PrevItem()
    {
        if (_currentIndex > 0)
        {
            _currentIndex--;
            _currentItem = _items[_currentIndex];
        }
    }

    public Item GetItemOfId(int id)
    {
        return _items.Find( t => t.ID == id);
    }

    public void ShowItems()
    {
        foreach (var item in _items)
            Debug.Log("item " + item.ID + " " + item.ItemName + " " + item.Description + " " + item.Type + " " + item.Value);
    }
    
}

[System.Serializable]

public class Item
{

    [SerializeField] private int _id;
    [SerializeField] private string _itemName;
    [SerializeField] private string _description;
    [SerializeField] private BuffType _type;
    [SerializeField] private float _value;
    [SerializeField] private Sprite _sprite;

    public Item()
    {
        Debug.Log("constructor " + _id + " " + _itemName + " " + _description + " " + _type + " " + _value);
    }

    public int ID
    {
        get { return _id; }
    }
     
    public string ItemName
    {
        get { return _itemName; }
    }
     
    public string Description
    {
        get { return _description; }
    }
     
    public BuffType Type
    {
        get { return _type; } 
    }
     
    public float Value
    {
        get { return _value; }
    }

    public Sprite Sprite
    {
        get { return _sprite; }
    }

}
