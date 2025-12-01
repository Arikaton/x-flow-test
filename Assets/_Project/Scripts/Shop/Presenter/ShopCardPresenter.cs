using System;
using Shop.View;

namespace Shop
{
    public class ShopCardPresenter : BaseCardPresenter
    {
        public event Action<BundleSo> BundleInfoClicked;

        public ShopCardPresenter(IBundleCardView view, BundleSo bundle, IPurchasingManager purchasingManager) : base(view, bundle, purchasingManager)
        {
            view.SetInfoVisible(true);

            view.InfoClicked += OnInfoClicked;
        }

        private void OnInfoClicked()
        {
            BundleInfoClicked?.Invoke(Bundle);
        }
    }
}