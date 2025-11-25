using UnityEngine;

namespace Core
{
    public abstract class ActionSo : ScriptableObject
    {
        public abstract bool IsAvailable();

        public abstract void Apply();
    }
}
