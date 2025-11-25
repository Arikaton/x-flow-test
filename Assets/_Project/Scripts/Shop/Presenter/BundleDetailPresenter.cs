using ShopDomain.View;

namespace ShopDomain
{
    public class BundleDetailPresenter
    {
        private readonly IBundleDetailView _view;

        public BundleDetailPresenter(IBundleDetailView view)
        {
            _view = view;
        }

        public void Show(BundleCardPresenter cardPresenter)
        {
            _view.ShowBundle(cardPresenter);
        }
    }
}
