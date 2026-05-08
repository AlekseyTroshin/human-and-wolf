using UnityEngine;
using UnityEngine.UI;

public class CellInventory : MonoBehaviour
{
    
    [SerializeField] private Image _icon;
    private Item _item;

    private void Awake()
    {
        _icon.sprite = null;
    }

    public void Init(Item item)
    {
        _item = item;
        _icon.sprite = item.Sprite;    
    }

    public void OnClickCell()
    {
        if (_item == null)
            return;
         GameManager.Instance.inventory.Items.Remove(_item);
         Buff buff = new Buff
         {
             type = _item.Type,
             additiveBonus = _item.Value
         };
         GameManager.Instance.inventory.buffReceiver.AddBuff(buff);
    }

}
