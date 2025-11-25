using System.Collections.Generic;
using Core;
using UnityEngine;

namespace ShopDomain
{
    [CreateAssetMenu(fileName = "Bundle", menuName = "Shop/Bundle", order = 0)]
    public class BundleSo : ScriptableObject
    {
        [SerializeField]
        private string _bundleName;

        [SerializeField]
        private List<ActionSo> _costs = new();

        [SerializeField]
        private List<ActionSo> _rewards = new();

        public string BundleName => _bundleName;

        public List<ActionSo> Costs => _costs;

        public List<ActionSo> Rewards => _rewards;
    }
}
