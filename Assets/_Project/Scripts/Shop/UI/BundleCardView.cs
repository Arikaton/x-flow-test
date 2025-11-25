using System;
using ShopDomain.View;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace ShopDomain.UI
{
    public class BundleCardView : MonoBehaviour, IBundleCardView
    {
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Button buyButton;
        [SerializeField] private Button infoButton;
        [SerializeField] private TextMeshProUGUI buyButtonText;

        public event Action BuyClicked;
        public event Action InfoClicked;

        private void Start()
        {
            Assert.IsNotNull(buyButton);
            Assert.IsNotNull(infoButton);
            Assert.IsNotNull(nameText);

            buyButton.onClick.AddListener(() => BuyClicked?.Invoke());
            infoButton.onClick.AddListener(() => InfoClicked?.Invoke());
        }

        public void SetName(string newName)
        {
            nameText.text = newName;
        }

        public void SetBuyInteractable(bool interactable)
        {
            buyButton.interactable = interactable;
        }

        public void SetBuyButtonText(string text)
        {
            buyButtonText.text = text;
        }

        public void SetInfoVisible(bool visible)
        {
            infoButton.gameObject.SetActive(visible);
        }
    }
}
