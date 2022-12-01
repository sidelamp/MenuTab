using UnityEngine;

namespace MenuTab.Scripts.Factories
{
    public class ItemFactoryStandart : ItemFactoryBase
    {
        public ItemFactoryStandart(Transform parent) : base(parent)
        {
            path = "Settings/Item";
        }
    }
}