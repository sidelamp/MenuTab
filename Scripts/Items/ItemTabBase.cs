using UnityEngine;
using UnityEngine.UI;

namespace MenuTab.Scripts.Items
{
    public abstract class ItemTabBase : MonoBehaviour
    {
        public event System.Action<ItemTabBase> OnButtonClick;

        [SerializeField] protected Transform body;
        [SerializeField] protected Button button;
        [SerializeField] private Image _icon;
        [SerializeField] private Sprite _active;
        [SerializeField] private Sprite _inactive;

        public Transform Body => body;
        public bool IsActive => body.gameObject.activeSelf;

        private void Awake()
        {
            button.onClick.AddListener(() => OnButtonClick?.Invoke(this));

            Initialize();
        }

        protected abstract void Initialize();

        public void SetActive(bool active)
        {
            if (body.gameObject.activeInHierarchy != active)
            {
                body.gameObject.SetActive(active);
                _icon.sprite = active ? _active : _inactive;
            }
        }
    }
}