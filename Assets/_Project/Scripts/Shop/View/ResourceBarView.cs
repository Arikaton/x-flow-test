using System.Collections.Generic;
using Shop.View;
using UnityEngine;

namespace Shop.UI
{
    public class ResourceBarView : MonoBehaviour, IResourceBarView
    {
        [SerializeField]
        private RectTransform _container;

        [SerializeField]
        private ResourceItemView _resourceItemViewPrefab;

        private List<IResourceItemView> _resourceItemViews;

        public IResourceItemView CreateResourceItemView(string resourceName, string resourceValue)
        {
            var view = Instantiate(_resourceItemViewPrefab, _container);
            view.SetName(resourceName);
            view.UpdateValue(resourceValue);
            return view;
        }
    }
}