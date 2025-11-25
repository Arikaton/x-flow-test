using System;

namespace ShopDomain.View
{
    public interface IBundleCardView
    {
        event Action BuyClicked;
        event Action InfoClicked;

        void SetName(string newName);

        void SetBuyInteractable(bool interactable);

        void SetBuyButtonText(string text);

        void SetInfoVisible(bool visible);
    }
}
