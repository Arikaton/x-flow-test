using Core;
using UnityEngine;

namespace VipDomain.Actions
{
    [CreateAssetMenu(fileName = "VipTimeChangeAction", menuName = "VIP/Time Change Action")]
    public class VipTimeChangeAction : ActionSo
    {
        [SerializeField]
        private double _seconds;

        public override bool IsAvailable()
        {
            return VipService.Instance.CanModify(_seconds);
        }

        public override void Apply()
        {
            VipService.Instance.AddSeconds(_seconds);
        }
    }
}
