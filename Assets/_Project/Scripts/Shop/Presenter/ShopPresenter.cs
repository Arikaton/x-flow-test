using System;
using System.Collections.Generic;
using Shop.View;

namespace Shop
{
    public class ShopPresenter
    {
        public event Action<BundleSo> BundleInfoClicked;

        private readonly IShopView _view;
        private readonly PurchasingManager _purchasingManager;
        private readonly List<BundleSo> _bundles;
        private readonly List<BaseCardPresenter> _cardPresenters = new List<BaseCardPresenter>();

        public ShopPresenter(IShopView view, List<BundleSo> bundles, PurchasingManager purchasingManager)
        {
            _bundles = bundles;
            _view = view;
            _purchasingManager = purchasingManager;

            BuildCards();
        }

        private void BuildCards()
        {
            _view.ClearCards();
            _cardPresenters.Clear();

            foreach (var bundle in _bundles) {
                var cardView = _view.CreateCardView();
                var presenter = new ShopCardPresenter(cardView, bundle, _purchasingManager);
                presenter.BundleInfoClicked += OnBundleInfoClicked;

                _cardPresenters.Add(presenter);
            }
        }

        public void Refresh()
        {
            foreach (var cardPresenter in _cardPresenters) {
                cardPresenter.Refresh();
            }
        }

        private void OnBundleInfoClicked(BundleSo bundleSo)
        {
            BundleInfoClicked?.Invoke(bundleSo);
        }
    }
}