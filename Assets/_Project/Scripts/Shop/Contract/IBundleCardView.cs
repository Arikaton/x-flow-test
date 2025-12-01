using System;

namespace Shop.View
{
    public interface IBundleCardView
    {
        event Action BuyClicked;
        event Action InfoClicked;

        void SetName(string newName);

        void SetBuyInteractable(bool interactable);

        void SetProcessingInProgress(bool processing);

        void SetInfoVisible(bool visible);
    }
}
