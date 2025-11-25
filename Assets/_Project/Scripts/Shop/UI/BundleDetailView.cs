using ShopDomain.View;
using UnityEngine;

namespace ShopDomain.UI
{
    public class BundleDetailView : MonoBehaviour, IBundleDetailView
    {
        [SerializeField] private BundleCardView cardView;

        public void ShowBundle(BundleCardPresenter bundlePresenter)
        {
            if (cardView == null) return;
            cardView.SetInfoVisible(false);
        }
    }
}
