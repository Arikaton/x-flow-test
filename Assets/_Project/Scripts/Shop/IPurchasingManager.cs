using System;

namespace Shop
{
    public interface IPurchasingManager
    {
        event Action<BundleSo> PurchaseStarted;
        event Action<BundleSo> PurchaseCompleted;
        bool IsProcessing { get; }
        bool CanPurchase(BundleSo bundle);
        void Purchase(BundleSo bundle);
        void ApplyPurchase(BundleSo bundle);
    }
}