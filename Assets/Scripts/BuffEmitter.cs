using UnityEngine;

public class BuffEmmiter : MonoBehaviour
{
    
    [SerializeField] private Buff _buff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.buffReceiverContainer.ContainsKey(collision.gameObject))
        {
            var receiver = GameManager.Instance.buffReceiverContainer[collision.gameObject];
            receiver.AddBuff(_buff);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameManager.Instance.buffReceiverContainer.ContainsKey(collision.gameObject))
        {
            var receiver = GameManager.Instance.buffReceiverContainer[collision.gameObject];
            receiver.DeleteBuff(_buff);
        }
    }

}

[System.Serializable]
public class Buff
{
    
    public BuffType type; 
    public float additiveBonus;
    public float multipleBonus;

}

public enum BuffType : byte
{
    
    Damage, Armor, Force

}
