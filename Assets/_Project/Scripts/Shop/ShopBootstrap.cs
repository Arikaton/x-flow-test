using Core;
using UnityEngine;

namespace ShopDomain
{
    public class ShopBootstrap : MonoBehaviour
    {
        private void Start()
        {
            LoadShop();
        }

        public void LoadShop()
        {
            var playerData = PlayerData.Instance;
        }
    }
}