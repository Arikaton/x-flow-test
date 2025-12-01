using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "Bundle", menuName = "Shop/Bundle")]
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
