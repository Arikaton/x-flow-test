using Core;
using UnityEngine;

namespace HealthDomain.Actions
{
    [CreateAssetMenu(fileName = "HealthPercentageChangeAction", menuName = "Health/Percentage Change Action")]
    public class HealthPercentageChangeAction : ActionSo
    {
        [SerializeField]
        private float _percentage;

        public override bool IsAvailable()
        {
            return HealthService.Instance.CanModify(_percentage);
        }

        public override void Apply()
        {
            HealthService.Instance.Modify(_percentage);
        }
    }
}
