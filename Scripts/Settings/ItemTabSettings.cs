using MenuTab.Scripts.Items;
using UnityEngine;

namespace MenuTab.Scripts.Settings
{
    [CreateAssetMenu(fileName = "Item", menuName = "MenuTab/Create item settings", order = 52)]
    public class ItemTabSettings : ScriptableObject
    {
        [SerializeField] private ItemTabBase _prefab;

        public ItemTabBase Prefab => _prefab;
    }
}