using System;
using Core;
using UnityEngine;

namespace Health
{
    public class HealthService
    {
        private static HealthService _instance;

        public static HealthService Instance => _instance ??= new HealthService(PlayerData.Instance);

        public event Action<int> HealthChanged;

        public int CurrentHealth {
            get => _data.CurrentHealth;
            private set {
                _data.CurrentHealth = value;
                HealthChanged?.Invoke(value);
            }
        }

        private readonly HealthData _data;

        public HealthService(PlayerData playerData)
        {
            _data = playerData.GetOrCreate<HealthData>();
        }

        public void AddHealth(int amount)
        {
            if (amount >= 0) {
                CurrentHealth += amount;
            } else {
                RemoveHealth(-amount);
            }
        }

        public void RemoveHealth(int amount)
        {
            if (amount <= 0) {
                return;
            }
            if (CurrentHealth - amount < 0) {
                CurrentHealth = 0;
            } else {
                CurrentHealth -= amount;
            }
        }

        public bool CanModify(int delta)
        {
            if (delta >= 0) {
                return true;
            }
            return CurrentHealth + delta >= 0;
        }

        public bool CanModify(float percent)
        {
            if (percent >= 0) {
                return true;
            }
            var delta = Mathf.CeilToInt(CurrentHealth * percent);
            return CanModify(delta);
        }

        public void Modify(int delta)
        {
            if (delta >= 0) {
                AddHealth(delta);
            } else {
                RemoveHealth(-delta);
            }
        }

        public void Modify(float percent)
        {
            var delta = Mathf.CeilToInt(CurrentHealth * percent);
            Modify(delta);
        }
    }
}