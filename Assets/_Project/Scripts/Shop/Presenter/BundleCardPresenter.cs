using System;
using ShopDomain.View;

namespace ShopDomain
{
    public class BundleCardPresenter
    {
        private readonly IBundleCardView _view;
        private readonly BundleSo _bundle;
        private readonly ShopService _shopService;

        public event Action<BundleCardPresenter> OnInfoRequested;

        public BundleCardPresenter(IBundleCardView view, BundleSo bundle, ShopService shopService)
        {
            _view = view;
            _bundle = bundle;
            _shopService = shopService;

            _view.SetName(_bundle.BundleName);
            _view.SetBuyButtonText(ShopConstants.BuyText);
            _view.SetInfoVisible(true);

            _view.BuyClicked += OnBuyClicked;
            _view.InfoClicked += OnInfoClicked;

            _shopService.PurchaseStarted += OnPurchaseStarted;
            _shopService.PurchaseCompleted += OnPurchaseCompleted;
        }

        private void OnBuyClicked()
        {
            _shopService.Purchase(_bundle);
        }

        private void OnInfoClicked()
        {
            OnInfoRequested?.Invoke(this);
        }

        private void OnPurchaseStarted(BundleSo targetBundle)
        {
            if (targetBundle != _bundle) {
                return;
            }

            _view.SetBuyButtonText(ShopConstants.ProcessingText);
            _view.SetBuyInteractable(false);
        }

        private void OnPurchaseCompleted(BundleSo targetBundle)
        {
            if (targetBundle == _bundle) {
                _view.SetBuyButtonText(ShopConstants.BuyText);
            }
        }

        public void Refresh()
        {
            _view.SetBuyInteractable(_shopService.CanPurchase(_bundle));
        }
    }
}