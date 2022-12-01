using MenuTab.Scripts.Menu;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MenuTabBase))]
public class ItemEditor : Editor
{
    private MenuTabBase _menuTab;

    public override void OnInspectorGUI()
    {
        Initialize();

        DrawDefaultInspector();
        ItemsButtonControllerGUI();
    }

    private void Initialize()
    {
        if (_menuTab == null)
            _menuTab = (MenuTabBase)target;
    }

    private void ItemsButtonControllerGUI()
    {
        GUILayout.Space(10);
        GUILayout.Label("Count items:" + _menuTab.Items.Count.ToString());

        if (GUILayout.Button("Add item"))
            _menuTab.Create();

        GUILayout.Space(10);
        if (GUILayout.Button("Remove item"))
            _menuTab.Remove();

        GUILayout.Space(10);
        if (GUILayout.Button("Clear"))
            _menuTab.Clear();
    }
}