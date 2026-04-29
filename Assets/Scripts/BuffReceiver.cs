using System.Collections.Generic;
using UnityEngine;

public class BuffReceiver : MonoBehaviour
{
    
    private List<Buff> _buffs;

    private void Start()
    {
        GameManager.Instance.buffReceiverContainer.Add(gameObject, this);
        _buffs = new List<Buff>();
    }

    public void AddBuff(Buff buff)
    {
        if (!_buffs.Contains(buff))
        {
            _buffs.Add(buff);
        }
    }

    public void DeleteBuff(Buff buff)
    {
        if (_buffs.Contains(buff))
            _buffs.Remove(buff);
    }

}
