using Shop.View;

namespace Shop
{
    public abstract class BaseCardPresenter
    {
        protected readonly BundleSo Bundle;

        private readonly IBundleCardView _view;
        private readonly IPurchasingManager _purchasingManager;

        private bool _canPurchase;

        protected BaseCardPresenter(IBundleCardView view, BundleSo bundle, IPurchasingManager purchasingManager)
        {
            _view = view;
            Bundle = bundle;
            _purchasingManager = purchasingManager;

            _view.SetName(Bundle.BundleName);
            _view.SetProcessingInProgress(false);

            _view.BuyClicked += OnBuyClicked;

            _purchasingManager.PurchaseStarted += OnPurchaseStarted;
            _purchasingManager.PurchaseCompleted += OnPurchaseCompleted;
        }

        public void Unsubscribe()
        {
            _purchasingManager.PurchaseStarted -= OnPurchaseStarted;
            _purchasingManager.PurchaseCompleted -= OnPurchaseCompleted;
        }

        private void OnPurchaseStarted(BundleSo targetBundle)
        {
            if (targetBundle == Bundle) {
                _view.SetProcessingInProgress(true);
            }

            UpdateInteractable();
        }

        private void OnPurchaseCompleted(BundleSo targetBundle)
        {
            if (targetBundle == Bundle) {
                _view.SetProcessingInProgress(false);
            }

            UpdateInteractable();
        }

        public void Refresh()
        {
            _canPurchase = _purchasingManager.CanPurchase(Bundle);
            UpdateInteractable();
        }

        protected void UpdateInteractable()
        {
            _view.SetBuyInteractable(_canPurchase && !_purchasingManager.IsProcessing);
        }

        private void OnBuyClicked()
        {
            _purchasingManager.Purchase(Bundle);
        }
    }
}