using Shop.View;

namespace Shop
{
    public class DetailCardPresenter : BaseCardPresenter
    {
        private readonly ShopService _shopService;

        public DetailCardPresenter(
            ShopService shopService,
            IDetailCardView detailCardView,
            BundleSo bundle,
            IPurchasingManager purchasingManager) : base(detailCardView.BundleCardView, bundle, purchasingManager)
        {
            _shopService = shopService;
            detailCardView.BundleCardView.SetInfoVisible(false);
            detailCardView.BackButtonClicked += OnBackButtonClicked;

            UpdateInteractable();
        }

        private void OnBackButtonClicked()
        {
            _shopService.CloseDetailScene();
        }
    }
}
