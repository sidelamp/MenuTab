using MenuTab.Scripts.Items;
using MenuTab.Scripts.Settings;
using UnityEngine;

namespace MenuTab.Scripts.Factories
{
    public class ItemFactoryBase
    {
        protected string path = "Settings/Item";
        protected Transform parent;
        protected ItemTabSettings settings;

        public ItemFactoryBase(Transform parent)
        {
            this.parent = parent;
        }

        public ItemTabBase CreateItem()
        {
            settings ??= Resources.Load<ItemTabSettings>(path);
            var item = Object.Instantiate(settings.Prefab, parent);

            return item;
        }
    }
}