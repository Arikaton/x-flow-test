using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "Shop Config", menuName = "Shop/Config", order = 0)]
    public class ShopConfigSo : ScriptableObject
    {
        [SerializeField]
        private List<BundleSo> _bundles = new();

        [Header("Debug Section")]
        [SerializeField]
        private int _goldToAdd = 100;
        [SerializeField]
        private int _healthToAdd = 10;
        [SerializeField]
        private string _defaultLocation = "StartVillage";
        [SerializeField]
        private double _vipSecondsToAdd = 10d;

        public List<BundleSo> Bundles => _bundles;

        public int GoldToAdd => _goldToAdd;
        public int HealthToAdd => _healthToAdd;
        public string DefaultLocation => _defaultLocation;
        public double VipSecondsToAdd => _vipSecondsToAdd;
    }
}