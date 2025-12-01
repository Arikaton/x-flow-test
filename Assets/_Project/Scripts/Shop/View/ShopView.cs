using Shop.View;
using UnityEngine;

namespace Shop.UI
{
    public class ShopView : MonoBehaviour, IShopView
    {
        [SerializeField]
        private Transform _cardContainer;
        [SerializeField]
        private BundleCardView _cardPrefab;

        public void ClearCards()
        {
            for (var i = _cardContainer.childCount - 1; i >= 0; i--) {
                Destroy(_cardContainer.GetChild(i).gameObject);
            }
        }

        public IBundleCardView CreateCardView()
        {
            var card = Instantiate(_cardPrefab, _cardContainer);
            return card;
        }
    }
}