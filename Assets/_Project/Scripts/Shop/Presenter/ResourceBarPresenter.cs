using System;
using Gold;
using Health;
using Shop.UI;
using Vip;
using LocationService = Location.LocationService;

namespace Shop
{
    public class ResourceBarPresenter
    {
        private readonly IResourceBarView _view;
        private readonly GoldService _goldService;
        private readonly HealthService _healthService;
        private readonly LocationService _locationService;
        private readonly VipService _vipService;
        private readonly ShopConfigSo _shopConfig;

        public ResourceBarPresenter(
            IResourceBarView resourceBarView,
            GoldService goldService,
            HealthService healthService,
            LocationService locationService,
            VipService vipService,
            ShopConfigSo shopConfig)
        {
            _shopConfig = shopConfig;
            _vipService = vipService;
            _locationService = locationService;
            _healthService = healthService;
            _goldService = goldService;
            _view = resourceBarView;

            CreateGoldResourceItem();
            CreateHealthResourceItem();
            CreateLocationResourceItem();
            CreateVipResourceItem();
        }

        private void CreateGoldResourceItem()
        {
            var view = _view.CreateResourceItemView(ShopConstants.GoldResourceName, _goldService.CurrentAmount.ToString());
            view.AddButtonClicked += () => _goldService.AddGold(_shopConfig.GoldToAdd);
            _goldService.AmountChanged += gold => view.UpdateValue(gold.ToString());
        }

        private void CreateHealthResourceItem()
        {
            var view = _view.CreateResourceItemView(ShopConstants.HealthResourceName, _healthService.CurrentHealth.ToString());
            view.AddButtonClicked += () => _healthService.AddHealth(_shopConfig.HealthToAdd);
            _healthService.HealthChanged += health => view.UpdateValue(health.ToString());
        }

        private void CreateLocationResourceItem()
        {
            var view = _view.CreateResourceItemView(ShopConstants.LocationResourceName, _locationService.CurrentLocation);
            view.AddButtonClicked += () => _locationService.SetLocation(_shopConfig.DefaultLocation);
            _locationService.LocationChanged += location => view.UpdateValue(location);
        }

        private void CreateVipResourceItem()
        {
            var view = _view.CreateResourceItemView(ShopConstants.VipResourceName, FormatTime(_vipService.CurrentVipTime));
            view.AddButtonClicked += () => _vipService.AddSeconds(_shopConfig.VipSecondsToAdd);
            _vipService.VipTimeChanged += vipTime => view.UpdateValue(FormatTime(vipTime));
        }

        private static string FormatTime(TimeSpan time)
        {
            return time.ToString(@"hh\:mm\:ss");
        }
    }
}