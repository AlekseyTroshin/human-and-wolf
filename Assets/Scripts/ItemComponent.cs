using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    
    [SerializeField] private ItemType _itemType;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Item _item;

    private void Start()
    {
        _item = GameManager.Instance.itemDataBase.GetItemOfId((int)_itemType);
        _spriteRenderer.sprite  = _item.Sprite;
    }

}

public enum ItemType
{
    DamagePoint = 1,
    ArmorPoint = 2,
    ForcePoint = 3
}
