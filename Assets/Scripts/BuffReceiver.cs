using System.Collections.Generic;
using UnityEngine;
using System;

public class BuffReceiver : MonoBehaviour
{
    
    private List<Buff> _buffs;
    public Action<Buff> OnBuffsChenged;

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

        if (OnBuffsChenged != null)
            OnBuffsChenged(buff);
    }

    public void DeleteBuff(Buff buff)
    {
        if (_buffs.Contains(buff))
            _buffs.Remove(buff);

        if (OnBuffsChenged != null)
            OnBuffsChenged(buff); 
    }

}
