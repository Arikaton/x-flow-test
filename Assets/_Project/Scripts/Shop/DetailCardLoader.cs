using Shop.UI;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shop
{
    public class DetailCardLoader : MonoBehaviour
    {
        [SerializeField]
        private DetailCardView _detailCardView;
        private DetailCardPresenter _detailCardPresenter;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            var shopService = ShopService.Instance;
            Assert.IsNotNull(shopService, "DetailCardScene supposed to be loaded from ShopScene");

            _detailCardPresenter = new DetailCardPresenter(shopService, _detailCardView, shopService.SelectedBundle,
                shopService.PurchasingManager);
        }

        private void Update()
        {
            _detailCardPresenter.Refresh();
        }

        private void OnDestroy()
        {
            _detailCardPresenter.Unsubscribe();
        }
    }
}