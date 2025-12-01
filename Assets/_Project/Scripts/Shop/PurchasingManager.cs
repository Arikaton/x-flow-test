using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    public class PurchasingManager : IPurchasingManager
    {
        public event Action<BundleSo> PurchaseStarted;

        public event Action<BundleSo> PurchaseCompleted;

        public bool IsProcessing { get; private set; }

        public bool CanPurchase(BundleSo bundle)
        {
            return bundle != null && bundle.Costs.All(cost => cost.IsAvailable());
        }

        public async void Purchase(BundleSo bundle)
        {
            if (!CanPurchase(bundle)) {
                return;
            }
            IsProcessing = true;
            PurchaseStarted?.Invoke(bundle);

            // Simulate processing delay
            await Task.Delay(3000);
            ApplyPurchase(bundle);
            IsProcessing = false;
        }

        public void ApplyPurchase(BundleSo bundle)
        {
            foreach (var cost in bundle.Costs) {
                cost.Apply();
            }

            foreach (var reward in bundle.Rewards) {
                reward.Apply();
            }

            PurchaseCompleted?.Invoke(bundle);
        }
    }
}