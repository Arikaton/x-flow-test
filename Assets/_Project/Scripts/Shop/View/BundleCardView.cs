using System;
using Shop.View;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Shop.UI
{
    public class BundleCardView : MonoBehaviour, IBundleCardView
    {
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private Button _buyButton;
        [SerializeField]
        private Button _infoButton;
        [SerializeField]
        private TextMeshProUGUI _buyButtonText;

        public event Action BuyClicked;
        public event Action InfoClicked;

        private void Start()
        {
            Assert.IsNotNull(_buyButton);
            Assert.IsNotNull(_infoButton);
            Assert.IsNotNull(_nameText);
        }

        private void OnEnable()
        {
            _buyButton.onClick.AddListener(() => BuyClicked?.Invoke());
            _infoButton.onClick.AddListener(() => InfoClicked?.Invoke());
        }

        private void OnDisable()
        {
            _buyButton.onClick.RemoveAllListeners();
            _infoButton.onClick.RemoveAllListeners();
        }

        public void SetName(string newName)
        {
            _nameText.text = newName;
        }

        public void SetBuyInteractable(bool interactable)
        {
            _buyButton.interactable = interactable;
        }

        public void SetProcessingInProgress(bool processing)
        {
            _buyButtonText.text = processing ? ShopConstants.ProcessingText : ShopConstants.BuyText;
        }

        public void SetInfoVisible(bool visible)
        {
            _infoButton.gameObject.SetActive(visible);
        }
    }
}