namespace Shop.View
{
    public interface IShopView
    {
        void ClearCards();

        IBundleCardView CreateCardView();
    }
}
