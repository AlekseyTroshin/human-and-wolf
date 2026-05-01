using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemBase))]

public class ItemBaseEditor : Editor
{

    private ItemBase _itemBase;

    private void Awake()
    {
        _itemBase = (ItemBase)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("New Item"))
            _itemBase.CreateItem();

        if (GUILayout.Button("Delete Item"))
            _itemBase.DeleteItem();

        if (GUILayout.Button("<="))
            _itemBase.PrevItem();

        if (GUILayout.Button("=>"))
            _itemBase.NextItem();

        GUILayout.EndHorizontal();
        
        if (GUILayout.Button("Show"))
            _itemBase.ShowItems();
        base.OnInspectorGUI();        
    }

}
