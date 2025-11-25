using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShopDomain
{
    public class ShopService : MonoBehaviour
    {
        [SerializeField]
        private List<BundleSo> _bundles = new();

        public List<BundleSo> Bundles => _bundles;

        public event Action<BundleSo> PurchaseStarted;

        public event Action<BundleSo> PurchaseCompleted;

        public bool CanPurchase(BundleSo bundle)
        {
            return bundle != null && bundle.Costs.All(cost => cost.IsAvailable());
        }

        public void Purchase(BundleSo bundle)
        {
            if (!CanPurchase(bundle)) {
                return;
            }
            StartCoroutine(PurchaseRoutine(bundle));
        }

        private IEnumerator PurchaseRoutine(BundleSo bundle)
        {
            PurchaseStarted?.Invoke(bundle);

            yield return new WaitForSeconds(3f);

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