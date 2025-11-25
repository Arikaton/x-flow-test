using Core;
using ShopDomain.View;
using UnityEngine;
using UnityEngine.Assertions;

namespace _Project.Scripts.Shop.UI
{
    [RequireComponent(typeof(ResourceItemView))]
    public class DebugResourceSource : MonoBehaviour
    {
        [SerializeField]
        private ActionSo _action;

        private ResourceItemView _resourceItemView;

        private void Awake()
        {
            _resourceItemView = GetComponent<ResourceItemView>();

            Assert.IsNotNull(_resourceItemView);

            _resourceItemView.AddButtonClicked += () => _action.Apply();
        }

        private void OnEnable()
        {
            _resourceItemView.AddButtonClicked += OnAddButtonClicked;
        }

        private void OnDisable()
        {
            _resourceItemView.AddButtonClicked -= OnAddButtonClicked;
        }

        private void OnAddButtonClicked()
        {
            _action.Apply();
        }
    }
}