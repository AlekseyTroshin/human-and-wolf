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
    public Dictionary<GameObject, ItemComponent> itemsContainer;
    public ItemBase itemDataBase;

    [SerializeField] private GameObject _inventoryPanel;

    [HideInInspector] public PlayerInventory inventory;

    private void Awake()
    {
        Instance = this;
        healthContainer = new Dictionary<GameObject, Health>();
        coinContainer = new Dictionary<GameObject, Coin>();
        buffReceiverContainer = new Dictionary<GameObject, BuffReceiver>();
        animatorContainer = new Dictionary<GameObject, Animator>();
        itemsContainer = new Dictionary<GameObject, ItemComponent>();
    }


    public void OnPauseClick()
    {
        if (Time.timeScale > 0)
        {
            _inventoryPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _inventoryPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

}
