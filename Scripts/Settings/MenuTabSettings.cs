using MenuTab.Scripts.Menu;
using UnityEngine;

namespace MenuTab.Scripts.Settings
{
    [CreateAssetMenu(fileName = "MenuTab", menuName = "MenuTab/Create main menu settings", order = 52)]
    public class MenuTabSettings : ScriptableObject
    {
        [SerializeField] private MenuTabBase _prefab;

        public MenuTabBase Prefab => _prefab;
    }
}