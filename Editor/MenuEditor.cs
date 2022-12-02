using MenuTab.Scripts.Items;
using MenuTab.Scripts.Menu;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MenuTabBase))]
public class MenuEditor : Editor
{
    private MenuTabBase _menuTab;
    private ItemTabBase _lastButton;

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

        _menuTab.FindAndAdd();
    }

    private void OnSceneGUI()
    {
        if (EditorApplication.isPlaying) return;

        Initialize();

        for (int i = 0; i < _menuTab.Items.Count; i++)
            DrawButton(_menuTab.Items[i]);
    }

    private void DrawButton(ItemTabBase button)
    {
        var rectTransform = button.GetComponent<RectTransform>();

        var height = rectTransform.sizeDelta.y / 2;
        var width = rectTransform.sizeDelta.x / 2;
        var pickSize = height;
        var position = rectTransform.position +
            Vector3.right * height + Vector3.up * width;

        if (Handles.Button(position, Quaternion.identity, height, pickSize, Handles.RectangleHandleCap))
        {
            if (_lastButton != null)
                _lastButton.SetActive(false);

            _lastButton = button;
            button.SetActive(true);
        }
    }
}