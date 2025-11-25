using Core;
using UnityEngine;

namespace HealthDomain.Actions
{
    [CreateAssetMenu(fileName = "HealthFixedChangeAction", menuName = "Health/Fixed Change Action")]
    public class HealthFixedChangeAction : ActionSo
    {
        [SerializeField]
        private int _amount;

        public override bool IsAvailable()
        {
            return HealthService.Instance.CanModify(_amount);
        }

        public override void Apply()
        {
            HealthService.Instance.Modify(_amount);
        }
    }
}
