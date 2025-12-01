using System;

namespace Shop.View
{
    public interface IShopView
    {
        event Action InfoRequested;

        void ClearCards();

        IBundleCardView CreateCardView();
    }
}
