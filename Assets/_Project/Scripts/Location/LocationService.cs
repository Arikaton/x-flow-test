using System;
using Core;

namespace LocationDomain
{
    public class LocationService
    {
        private static LocationService _instance;

        public static LocationService Instance => _instance ??= new LocationService(PlayerData.Instance);

        public event Action<string> LocationChanged;

        public string CurrentLocation {
            get => _data.CurrentLocation;
            private set {
                _data.CurrentLocation = value;
                LocationChanged?.Invoke(value);
            }
        }

        private readonly LocationData _data;

        public LocationService(PlayerData playerData)
        {
            _data = playerData.GetOrCreate<LocationData>();
        }

        public void SetLocation(string location)
        {
            CurrentLocation = location;
        }
    }
}
