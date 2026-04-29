using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton

    private GameManager()
    {}

    public static GameManager Instance { get; private set; }

    #endregion

    public Dictionary<GameObject, Health> healthContainer;
    public Dictionary<GameObject, Coin> coinContainer;
    public Dictionary<GameObject, BuffReceiver> buffReceiverContainer;
    public Dictionary<GameObject, Animator> animatorContainer;

    private void Awake()
    {
        Instance = this;
        healthContainer = new Dictionary<GameObject, Health>();
        coinContainer = new Dictionary<GameObject, Coin>();
        buffReceiverContainer = new Dictionary<GameObject, BuffReceiver>();
        animatorContainer = new Dictionary<GameObject, Animator>();
    }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            healthContainer = new Dictionary<GameObject, Health>();
            coinContainer = new Dictionary<GameObject, Coin>();
            buffReceiverContainer = new Dictionary<GameObject, BuffReceiver>();
            animatorContainer = new Dictionary<GameObject, Animator>();
        }
    }

}
