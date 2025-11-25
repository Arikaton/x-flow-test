using System;
using System.Collections.Generic;

namespace Core
{
    public class PlayerData
    {
        private static PlayerData _instance;

        public static PlayerData Instance {
            get {
                _instance ??= new PlayerData();
                return _instance;
            }
        }

        private readonly Dictionary<Type, object> _data = new();

        public void Set<T>(T value) where T : class
        {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }
            _data[typeof(T)] = value;
        }

        public T GetOrCreate<T>() where T : class, new()
        {
            if (_data.TryGetValue(typeof(T), out var existing)) {
                return existing as T;
            }
            var created = new T();
            _data[typeof(T)] = created;
            return created;
        }
    }
}