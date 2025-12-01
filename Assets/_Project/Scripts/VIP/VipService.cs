using Core;
using System;

namespace Vip
{
    public class VipService
    {
        private static VipService _instance;

        public static VipService Instance => _instance ??= new VipService(PlayerData.Instance);

        public event Action<TimeSpan> VipTimeChanged;

        public TimeSpan CurrentVipTime {
            get => TimeSpan.FromSeconds(_data.VipSeconds);
        }

        private double CurrentVipTimeInSeconds {
            get => _data.VipSeconds;
            set {
                _data.VipSeconds = value;
                VipTimeChanged?.Invoke(CurrentVipTime);
            }
        }

        private readonly VipData _data;

        public VipService(PlayerData playerData)
        {
            _data = playerData.GetOrCreate<VipData>();
        }

        public void AddTime(TimeSpan delta)
        {
            AddSeconds(delta.TotalSeconds);
        }

        public void AddSeconds(double seconds)
        {
            if (seconds >= 0) {
                CurrentVipTimeInSeconds += seconds;
            } else {
                RemoveSeconds(-seconds);
            }
        }

        private void RemoveSeconds(double seconds)
        {
            if (seconds <= 0) {
                return;
            }

            if (CurrentVipTimeInSeconds - seconds < 0) {
                CurrentVipTimeInSeconds = 0;
            } else {
                CurrentVipTimeInSeconds -= seconds;
            }
        }

        public bool CanModify(double deltaSeconds)
        {
            if (deltaSeconds >= 0) {
                return true;
            }
            return CurrentVipTimeInSeconds + deltaSeconds >= 0;
        }
    }
}