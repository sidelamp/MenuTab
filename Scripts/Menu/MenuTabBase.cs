using MenuTab.Scripts.Factories;
using MenuTab.Scripts.Items;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MenuTab.Scripts.Menu
{
    public class MenuTabBase : MonoBehaviour
    {
        [SerializeField] private Transform _itemParent;
        [SerializeField] private Transform _bodyParent;
        [SerializeField] private float _spacing = 5f;
        private HorizontalLayoutGroup _layoutGroup;
        private ItemFactoryBase _factory;
        private ItemTabBase _activeItem;

        public List<ItemTabBase> Items { get; } = new();

        private void Awake()
        {
            FindAndAdd();

            if (Items.Count > 0)
            {
                _activeItem = Items[0];
                _activeItem.SetActive(true);
            }
        }

        public void Add(ItemTabBase item)
        {
            if (Items.Contains(item)) return;

            item.OnButtonClick += OnButtonClicked;
            item.Body.SetParent(_bodyParent, false);
            item.SetActive(false);

            Items.Add(item);
        }

        public void Remove(ItemTabBase item)
        {
            if (Items.Contains(item))
                Items.Remove(item);

            DestroyItem(item);
        }

        public void Remove(int index)
        {
            Remove(Items[index]);
        }

        public void Remove()
        {
            var last = Items.Count - 1;

            if (last >= 0)
                Remove(last);
        }

        public void Clear()
        {
            for (int i = 0; i < Items.Count; i++)
                DestroyItem(Items[i]);

            Items.Clear();

            FindAndRemove();
        }

        public void Create()
        {
            InitializeFactory();

            var item = _factory.CreateItem();
            Add(item);
        }

        public void FindAndAdd()
        {
            var count = _itemParent.childCount;

            for (int i = 0; i < count; i++)
            {
                var item = _itemParent.GetChild(i);

                if (!item.TryGetComponent<ItemTabBase>(out var tab))
                    continue;

                Add(tab);
            }
        }

        private void OnValidate()
        {
            ChangeSapcing();
        }

        private void FindAndRemove()
        {
            var count = _itemParent.childCount;

            for (int i = 0; i < count; i++)
            {
                var item = _itemParent.GetChild(i);

                if (!item.TryGetComponent<ItemTabBase>(out var tab))
                    continue;

                Remove(tab);
            }
        }

        private void OnButtonClicked(ItemTabBase item)
        {
            _activeItem?.SetActive(false);
            _activeItem = item;
            _activeItem.SetActive(true);
        }

        private void DestroyItem(ItemTabBase item)
        {
            item.OnButtonClick -= OnButtonClicked;

            DestroyImmediate(item.Body.gameObject);
            DestroyImmediate(item.gameObject);
        }

        private void ChangeSapcing()
        {
            _layoutGroup ??= _itemParent.GetComponent<HorizontalLayoutGroup>();

            _layoutGroup.spacing = _spacing;
        }

        private void InitializeFactory()
        {
            _factory ??= new ItemFactoryStandart(_itemParent);
        }
    }
}