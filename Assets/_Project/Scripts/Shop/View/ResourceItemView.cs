using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Shop.View
{
    public class ResourceItemView : MonoBehaviour, IResourceItemView
    {
        public event Action AddButtonClicked;

        [SerializeField]
        private Button _addButton;
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private TextMeshProUGUI _resourceText;

        private void Start()
        {
            Assert.IsNotNull(_addButton);
            Assert.IsNotNull(_resourceText);
            Assert.IsNotNull(_nameText);

            _addButton.onClick.AddListener(() => AddButtonClicked?.Invoke());
        }

        public void SetName(string resourceName)
        {
            _nameText.text = resourceName;
        }

        public void UpdateValue(string text)
        {
            _resourceText.text = text;
        }
    }
}