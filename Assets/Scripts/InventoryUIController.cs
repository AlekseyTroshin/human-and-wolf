using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    
    [SerializeField] private CellInventory[] _cells;
    [SerializeField] private int _cellsCount;
    [SerializeField] private CellInventory _cellInventoryPrefab;
    [SerializeField] private Transform _rootParent;

    private void Init()
    {
        _cells = new CellInventory[_cellsCount];
        for (int i = 0; i < _cellsCount; i++)
        {
            _cells[i] = Instantiate(_cellInventoryPrefab, _rootParent);
        }
        _cellInventoryPrefab.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (_cells == null || _cells.Length <= 0)
            Init();

        var inventory = GameManager.Instance.inventory;
        for (int i = 0; i < inventory.Items.Count; i++)
        {
            if (i < _cells.Length)
                _cells[i].Init(inventory.Items[i]);
        }
    }

}
