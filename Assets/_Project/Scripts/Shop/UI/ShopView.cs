using ShopDomain.View;
using UnityEngine;

namespace ShopDomain.UI
{
    public class ShopView : MonoBehaviour, IShopView
    {
        [Header("Dependencies")]
        [SerializeField]
        private ShopService shopService;
        [SerializeField]
        private Transform cardContainer;
        [SerializeField]
        private BundleCardView cardPrefab;

        private ShopPresenter _presenter;

        private void Awake()
        {
            _presenter = new ShopPresenter(this, shopService);
            _presenter.OnShowBundleDetail += HandleShowBundleDetail;
        }

        private void Update()
        {
            _presenter.Refresh();
        }

        public void ClearCards()
        {
            for (int i = cardContainer.childCount - 1; i >= 0; i--) {
                Destroy(cardContainer.GetChild(i).gameObject);
            }
        }

        public IBundleCardView CreateCardView()
        {
            var card = Instantiate(cardPrefab, cardContainer);
            return card;
        }

        private void HandleShowBundleDetail(BundleCardPresenter cardPresenter)
        {
            cardPresenter.OnInfoRequested -= HandleShowBundleDetail;
        }
    }
}