using MenuTab.Scripts.Settings;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MenuTab.Scripts.Factories
{
    public class MenuFactory
    {
        private const string _path = "Settings/MenuTab";
        private const string _eventSystem = "EventSystem";

        [MenuItem("GameObject/UI/TabMenu", priority = 10)]
        private static void CreateMenu()
        {
            var parent = GetParent();
            var settings = Resources.Load<MenuTabSettings>(_path);
            var prefab = settings.Prefab;
            var menu = Object.Instantiate(prefab, parent);

            Undo.RegisterCreatedObjectUndo(menu, "Create " + menu.name);
            Selection.activeObject = menu;

            Debug.Log("Menu has created");
        }

        private static Transform GetParent()
        {
            var canvas = Object.FindObjectOfType<Canvas>();
            FindEventSystem();

            if (canvas == null)
                return CreateCanvas();
            else
                return canvas.transform;
        }

        private static Transform CreateCanvas()
        {
            var @object = new GameObject("Canvas");
            var canvas = @object.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            @object.AddComponent<CanvasScaler>();
            @object.AddComponent<GraphicRaycaster>();

            return @object.transform;
        }

        private static void FindEventSystem()
        {
            if (Object.FindObjectOfType<EventSystem>() == null)
            {
                var es = new GameObject(_eventSystem, typeof(EventSystem));
                es.AddComponent<StandaloneInputModule>();
            }
        }
    }
}