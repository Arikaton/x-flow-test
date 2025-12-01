using NSubstitute;
using NUnit.Framework;
using Shop.View;
using UnityEngine;

namespace Shop.Tests._Project.Scripts.Shop.Tests
{
    public class ShopTests
    {
        private IPurchasingManager _purchasingManager;
        private BundleSo _firstBundle;
        private BundleSo _secondBundle;

        [SetUp]
        public void Setup()
        {
            _purchasingManager = Substitute.For<IPurchasingManager>();
            _firstBundle = ScriptableObject.CreateInstance<BundleSo>();
            _secondBundle = ScriptableObject.CreateInstance<BundleSo>();
        }

        [Test]
        public void BuyBundleClicked_SameBundle_SetIsProcessing()
        {
            var bundleCardView = Substitute.For<IBundleCardView>();
            var shopCardPresenter = new ShopCardPresenter(bundleCardView, _firstBundle, _purchasingManager);

            _purchasingManager.PurchaseStarted += Raise.Event<System.Action<BundleSo>>(_firstBundle);

            bundleCardView.Received(1).SetProcessingInProgress(true);
        }

        [Test]
        public void BuyBundleClicked_OtherBundle_NotSetIsProcessing()
        {
            var bundleCardView = Substitute.For<IBundleCardView>();
            var shopCardPresenter = new ShopCardPresenter(bundleCardView, _firstBundle, _purchasingManager);

            _purchasingManager.PurchaseStarted += Raise.Event<System.Action<BundleSo>>(_secondBundle);

            bundleCardView.Received(0).SetProcessingInProgress(Arg.Any<bool>());
        }

        [TestCase(true, true, false)]
        [TestCase(false, false, false)]
        [TestCase(false, true, true)]
        [TestCase(true, false, false)]
        public void ProcessPurchase_SetInteractable_ToCorrectState(bool isProcessing, bool canPurchase, bool expectedInteractable)
        {
            _purchasingManager.CanPurchase(Arg.Any<BundleSo>()).Returns(canPurchase);
            _purchasingManager.IsProcessing.Returns(isProcessing);
            var bundleCardView = Substitute.For<IBundleCardView>();
            var shopCardPresenter = new ShopCardPresenter(bundleCardView, _firstBundle, _purchasingManager);

            shopCardPresenter.Refresh();

            bundleCardView.Received(1).SetBuyInteractable(expectedInteractable);
        }
    }
}