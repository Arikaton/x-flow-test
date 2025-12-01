using Core;
using UnityEngine;

namespace Gold.Actions
{
    [CreateAssetMenu(fileName = "GoldFixedChangeAction", menuName = "Gold/Fixed Change Action")]
    public class GoldFixedChangeAction : ActionSo
    {
        [SerializeField]
        private int _amount;

        public override bool IsAvailable()
        {
            return GoldService.Instance.CanModify(_amount);
        }

        public override void Apply()
        {
            GoldService.Instance.Modify(_amount);
        }
    }
}
