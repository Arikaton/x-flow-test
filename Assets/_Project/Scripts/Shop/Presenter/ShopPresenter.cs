using System;
using System.Collections.Generic;
using ShopDomain.View;
using UnityEngine;

namespace ShopDomain
{
    public class ShopPresenter
    {
        private readonly IShopView _view;
        private readonly ShopService _shopService;
        private readonly List<BundleCardPresenter> _cardPresenters = new List<BundleCardPresenter>();

        public event Action<BundleCardPresenter> OnShowBundleDetail;

        public ShopPresenter(IShopView view, ShopService shopService)
        {
            _view = view;
            _shopService = shopService;
            BuildCards();
        }

        private void BuildCards()
        {
            _view.ClearCards();
            _cardPresenters.Clear();

            foreach (var bundle in _shopService.Bundles) {
                var cardView = _view.CreateCardView();
                var presenter = new BundleCardPresenter(cardView, bundle, _shopService);
                presenter.OnInfoRequested += HandleInfoRequested;
                _cardPresenters.Add(presenter);
            }
        }

        private void HandleInfoRequested(BundleCardPresenter presenter)
        {
            OnShowBundleDetail?.Invoke(presenter);
        }

        public void Refresh()
        {
            foreach (var presenter in _cardPresenters) {
                presenter.Refresh();
            }
        }
    }
}