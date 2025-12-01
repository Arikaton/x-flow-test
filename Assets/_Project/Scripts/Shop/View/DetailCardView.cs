using System;
using Shop.View;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Shop.UI
{
    public class DetailCardView : MonoBehaviour, IDetailCardView
    {
        public event Action BackButtonClicked;

        public IBundleCardView BundleCardView => _bundleCardView;

        [SerializeField]
        private BundleCardView _bundleCardView;

        [SerializeField]
        private Button _backButton;

        private void Start()
        {
            Assert.IsNotNull(_bundleCardView);
            Assert.IsNotNull(_backButton);
        }

        private void OnEnable()
        {
            _backButton.onClick.AddListener(() => BackButtonClicked?.Invoke());
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveAllListeners();
        }
    }
}
