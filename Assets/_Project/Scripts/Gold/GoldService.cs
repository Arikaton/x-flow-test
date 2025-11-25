using System;
using Core;

namespace GoldDomain
{
    public class GoldService
    {
        private static GoldService _instance;

        public static GoldService Instance => _instance ??= new GoldService(PlayerData.Instance);

        public event Action<int> AmountChanged;

        public int CurrentAmount {
            get => _data.CurrentAmount;
            private set {
                _data.CurrentAmount = value;
                AmountChanged?.Invoke(value);
            }
        }

        private readonly GoldData _data;

        public GoldService(PlayerData playerData)
        {
            _data = playerData.GetOrCreate<GoldData>();
        }

        public void AddGold(int amount)
        {
            if (amount >= 0) {
                CurrentAmount += amount;
            } else {
                RemoveGold(-amount);
            }
        }

        public void RemoveGold(int amount)
        {
            if (amount <= 0) {
                return;
            }
            if (CurrentAmount - amount < 0) {
                CurrentAmount = 0;
            } else {
                CurrentAmount -= amount;
            }
        }

        public bool CanModify(int delta)
        {
            if (delta >= 0) {
                return true;
            }
            return CurrentAmount + delta >= 0;
        }

        public void Modify(int delta)
        {
            if (delta >= 0) {
                AddGold(delta);
            } else {
                RemoveGold(-delta);
            }
        }
    }
}