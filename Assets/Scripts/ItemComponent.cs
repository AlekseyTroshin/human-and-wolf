using UnityEngine;

public class ItemComponent : MonoBehaviour, IObjectDestroyer
{
    
    [SerializeField] private ItemType _itemType;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Item _item;

    public Item Item
    {
        get { return _item; }
    }

    private void Start()
    {
        GameManager.Instance.itemsContainer.Add(gameObject, this);
        _item = GameManager.Instance.itemDataBase.GetItemOfId((int)_itemType);
        _spriteRenderer.sprite  = _item.Sprite;
    }

    public void Destroy(GameObject gameObject)
    {
        MonoBehaviour.Destroy(gameObject);
    }
}

public enum ItemType
{
    DamagePoint = 1,
    ArmorPoint = 2,
    ForcePoint = 3
}
