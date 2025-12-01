using Core;
using UnityEngine;

namespace Location.Actions
{
    [CreateAssetMenu(fileName = "ChangeLocationAction", menuName = "Location/Change Location Action")]
    public class ChangeLocationAction : ActionSo
    {
        [SerializeField]
        private string _targetLocation;

        public override bool IsAvailable()
        {
            return true;
        }

        public override void Apply()
        {
            LocationService.Instance.SetLocation(_targetLocation);
        }
    }
}
